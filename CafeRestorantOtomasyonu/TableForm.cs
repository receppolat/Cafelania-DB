using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;


namespace CafeRestorantOtomasyonu
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
        }
        public void islemler()
        {
            int temp = int.Parse(MainForm.Masa);
            lblKisi.Text =LoadingForm.kuver + " Kişi";
            int toplamfiyat = 0;
            foreach(var item in listView1.Items)
            {
                toplamfiyat += int.Parse(((ListViewItem)item).SubItems[3].Text) * int.Parse(((ListViewItem)item).SubItems[1].Text);
                lblfiyat.Text = toplamfiyat.ToString();
            }
        }
        private void butonGetir()
        {
            int i = 0;
            using (var cafeContect = new CafeDBEntities())
            {
                var result = from categories in cafeContect.Categories
                             select categories;
                foreach (var gez in result)
                {
                    Button kategori = new Button();
                    kategori.Name = gez.CategoryID.ToString();
                    kategori.Text = gez.CategoryName;
                    kategori.Font = new System.Drawing.Font(gez.CategoryName, 8, FontStyle.Bold);
                    kategori.ForeColor = Color.DimGray;
                    kategori.BackColor = Color.Transparent;
                    if (i < 6)
                    {
                         kategori.Size = new Size(150, 35);
                        flowLayoutPanel2.Controls.Add(kategori);
                        
                    }
                    else
                    {
                        kategori.Size = new Size(100, 35);
                        flowLayoutPanel3.Controls.Add(kategori);
                    }
                    i++;
                    kategori.Click += new EventHandler(kategoriTiklama);
                }
            }


           
        }
        string KategoriAdi = "";
        private void kategoriTiklama(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            KategoriAdi = btn.Text;
            urunOlustur(KategoriAdi);
        }

        public void veriGoster()
        {
            int temp = int.Parse(MainForm.Masa);
            listView1.Items.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            using (var cafeContext = new CafeDBEntities())
            {
                

                var result = from orders in cafeContext.Orders
                             join products in cafeContext.Products
                             on orders.Products.ProductID equals products.ProductID
                             where orders.isAlive == true && orders.TableNumber == temp
                             select new
                             {  
                                 orders,products
                             };
                foreach (var order in result)
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = order.orders.OrderID.ToString();
                    ekle.SubItems.Add(order.orders.ProductCount.ToString());
                    ekle.SubItems.Add(order.products.ProductName);
                    ekle.SubItems.Add(order.products.Amount.ToString());
                    listView1.Items.Add(ekle);

                }
            }
        }

        private void urunOlustur(string tur)
        {
            string urunAdi = "";
            int urunSayisi = 0, i=0;
            flowLayoutPanel1.Controls.Clear();
            using (var cc = new CafeDBEntities())
            {
                var result = from products in cc.Products
                             where products.Categories.CategoryName == tur
                             select products;
                foreach(var gez in result)
                {
                    urunAdi = gez.ProductName;
                    Button urun = new Button();
                    urun.Name = urunAdi;
                    urun.Text = urunAdi;
                    urun.Font = new System.Drawing.Font(gez.ProductName, 8, FontStyle.Bold);
                    urun.ForeColor = Color.DimGray;
                    urun.Size = new Size(145, 35);
                    urun.BackColor = Color.Transparent;
                    Panel panel = new Panel();
                    panel.Name = i.ToString() + "panel";
                    panel.Size = new Size(7, 35);
                    panel.BackColor = Color.Transparent;
                    flowLayoutPanel1.Controls.Add(urun);
                    flowLayoutPanel1.Controls.Add(panel);
                    i++;
                    urun.Click += new EventHandler(urunTiklama);
                }
                urunSayisi = result.Count();
            }
            
        }
        private void siparisEkleme(int adet)
        {
            using (var cafeContext = new CafeDBEntities())
            {
                int id = 0;
                int tableNumber = int.Parse(MainForm.Masa);
                var result = from products in cafeContext.Products
                             where products.ProductName == UrunAdi
                             select products;
                var result1 = from receipts in cafeContext.Receipts
                              where receipts.TableNumber == tableNumber
                              select receipts;
                var resultPrice = from receipt1 in cafeContext.Receipts
                                  where receipt1.TableNumber == tableNumber
                                  select receipt1.ReceiptID;
                foreach(var gez in resultPrice)
                {
                    id = gez;
                }
                cafeContext.Orders.Add(new Orders
                {
                    ProductCount = adet,
                    isAlive = true,
                    TableNumber = int.Parse(MainForm.Masa),
                    Information = "DETAY YOK",
                    Products = result.FirstOrDefault(),
                    Receipts = result1.FirstOrDefault()

                });
                Receipts receipt = cafeContext.Receipts.Find(id);
                receipt.TotalPrice = int.Parse(lblfiyat.Text);
                cafeContext.SaveChanges();
                veriGoster();
                islemler();
            }


        }
        string UrunAdi = "";
        private void urunTiklama(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            UrunAdi = btn.Text;
        }
        private void TableForm_Load(object sender, EventArgs e)
        {
            lblMasa.Text = "CAFELANIA | " + MainForm.Masa + ".Masa";
            veriGoster();
            islemler();
            butonGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string adet ="";
        private void btn0_Click(object sender, EventArgs e)
        {
            if(adet != "")
                adet += "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            adet += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            adet += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            adet += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            adet += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            adet += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            adet += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            adet += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            adet += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            adet += "9";
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            adet = "";
        }

        private void btnSiparisGonder_Click(object sender, EventArgs e)
        {
            if(UrunAdi != "")
            {
                if (adet != "")
                    siparisEkleme(int.Parse(adet));
                else
                    siparisEkleme(1);
                adet = "";
                kosullama();
            }
        }

        private void btnMutfagaMesaj_Click(object sender, EventArgs e)
        {
            string IsimGirisi = Interaction.InputBox("Açıklamayı giriniz...", "SİPARİŞ DETAYI", "Örn: BUZLU OLSUN", 550, 300);
            try
            {
                using (var cafeContext = new CafeDBEntities())
                {
                    var result = from orders in cafeContext.Orders
                                 where orders.OrderID == satir
                                 select orders.OrderID;
                    int id = result.FirstOrDefault();
                    Orders order = cafeContext.Orders.Find(id);
                    order.Information = IsimGirisi;
                    cafeContext.SaveChanges();
                }
                veriGoster();
            }
            catch { }
           
        }
        int satir = 0;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                satir = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            }
            catch { }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cafeContext = new CafeDBEntities())
                {
                    Orders order = cafeContext.Orders.Find(satir);
                    cafeContext.Orders.Remove(order);
                    cafeContext.SaveChanges();
                }
                veriGoster();
                islemler();
            }
            catch
            {
                MessageBox.Show("Silmek için lütfen seçim yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAraToplam_Click(object sender, EventArgs e)
        //PDF DOSYASI OLARAK KAYDETME ORTAMI BURASI.
        {
            try
            {
                if (listView1.Items.Count > 0)
                {
                    DialogResult cevap = MessageBox.Show("Fiş istiyor musunuz?", "HESAP", MessageBoxButtons.YesNo);
                    if (cevap == DialogResult.Yes)
                    {
                        string fileName = "", tarih = "", kuver = "", fiyat = "", urunAdi = "";
                        int fisID = 0;
                        int temp = int.Parse(MainForm.Masa), fiyatUrun = 0;

                        using (var cafeContext = new CafeDBEntities())
                        {
                            var result = from receipts in cafeContext.Receipts
                                         join orders in cafeContext.Orders
                                         on receipts.TableNumber equals orders.TableNumber
                                         where receipts.TableNumber == temp && orders.isAlive == true
                                         select new
                                         {
                                             orders,
                                             receipts
                                         };

                            foreach (var gez in result)
                            {
                                fileName = gez.receipts.ReceiptID.ToString();
                                tarih = gez.receipts.Date;
                                fisID = gez.receipts.ReceiptID;
                                kuver = gez.receipts.Cover.ToString();
                                fiyat = gez.receipts.TotalPrice.ToString();
                            }

                            var resultProduct = from orders in cafeContext.Orders
                                                join product in cafeContext.Products
                                                on orders.Products.ProductID equals product.ProductID
                                                where orders.isAlive == true & orders.TableNumber == temp
                                                select new
                                                {
                                                    orders,
                                                    product
                                                };

                            iTextSharp.text.Document raporum = new iTextSharp.text.Document();
                            PdfWriter.GetInstance(raporum, new FileStream("C:" + fileName + ".pdf", FileMode.Create));
                            raporum.AddAuthor("Cafelania");
                            raporum.AddCreationDate();
                            raporum.AddSubject("FIŞ BILGILERI");
                            raporum.AddKeywords("fis");
                            if (raporum.IsOpen() == false)
                                raporum.Open();
                            raporum.Add(new Paragraph("                                         CAFELANIA                                             " + tarih));
                            raporum.Add(new Paragraph("                                                                                                                              "));
                            raporum.Add(new Paragraph("Fis Numarasi:" + fisID.ToString() + "    Kuver Sayisi:" + kuver + "    Masa Numarasi:" + temp.ToString()));
                            raporum.Add(new Paragraph("                                                                                                                              "));

                            foreach (var gez in resultProduct)
                            {
                                urunAdi = gez.product.ProductName;
                                fiyatUrun = int.Parse(gez.product.Amount.ToString()) * int.Parse(gez.orders.ProductCount.ToString());
                                raporum.Add(new Paragraph("Adet: " + gez.orders.ProductCount.ToString() + "                  " + urunAdi + "               " + fiyatUrun.ToString() + "TL"));
                                raporum.Add(new Paragraph("                                                                                                                              "));

                            }
                            raporum.Add(new Paragraph("                                                                                     TOPLAM TUTAR:" + lblfiyat.Text));
                            MessageBox.Show("Toplam hesap: " + lblfiyat.Text + "\nFiş Numarası: "+fisID.ToString());
                            raporum.Close();
                        }
                    }
                }
                else
                    MessageBox.Show("Fiş oluşturmak için lütfen sipariş giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            

            }
            catch
            {

            }
        }
        public static bool odeme = false;
        public static int receiptID = 0;

        private void kosullama()
        {
            MainForm frm = null;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Cafelania | Masalar")
                {
                    frm = (MainForm)f;
                }
            }
            if (frm != null)
            {
                foreach (Control c in frm.flowLayoutPanel1.Controls)
                {
                    if (c is Button)
                    {
                        if (c.Text == MainForm.Masa.ToString())
                        {
                            c.BackColor = Color.Gray;
                            break;
                        }
                    }
                }
            }

        }


        private void btnOdeme_Click(object sender, EventArgs e)
        {   
            using (var cafeContext = new CafeDBEntities() )
            {
                int tableNumber = int.Parse(MainForm.Masa);
                var result = from receipt in cafeContext.Receipts
                             join orders in cafeContext.Orders
                             on receipt.TableNumber equals orders.TableNumber
                             where receipt.TableNumber == tableNumber && orders.isAlive == true
                             select new {
                                 orders,
                                 receipt
                             };
                foreach (var gez in result)
                {
                    receiptID = gez.receipt.ReceiptID;
                    Orders order = cafeContext.Orders.Find(gez.orders.OrderID);
                    order.isAlive = false;
                }
                cafeContext.SaveChanges();

                kosullama();
                LoadingForm.kuver = "";
                odeme = true;
                this.Close();
                pdf gcs = new pdf();
                gcs.ShowDialog();
            }
        }

        private void TableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (var cafeContext = new CafeDBEntities())
                {
                    int tableNumber = int.Parse(MainForm.Masa);
                    var result = from receipt in cafeContext.Receipts
                                 where receipt.TotalPrice == 0 && receipt.TableNumber == tableNumber
                                 select receipt;
                    cafeContext.Receipts.Remove(result.First());
                    cafeContext.SaveChanges();
                }
 
            }
            catch { }

        }
    }
}
