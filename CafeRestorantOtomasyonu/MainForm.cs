using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeRestorantOtomasyonu
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        string[] masalar = new string[999];
        public static string Masa;
        public static int i = 0;
        public void masaOlustur()
        {
            int masaSayisi = 20;
            using (var cafeContext = new CafeDBEntities())
            {
                var result = from cafes in cafeContext.Cafes
                             where cafes.CafeID == 1
                             select cafes.TableCount;
                foreach (var gez in result)
                    masaSayisi = gez;
            }

            for (i = 1; i <= masaSayisi; i++)
            {
                Button masa = new Button();
                masa.Name = i.ToString();
                masa.Text = i.ToString();
                masa.Size = new Size(50, 50);
                using (var cafeContext = new CafeDBEntities())
                {
                    var result = from receipts in cafeContext.Receipts
                                 join orders in cafeContext.Orders
                                 on receipts.TableNumber equals orders.TableNumber
                                 where receipts.TableNumber == i && orders.isAlive == true
                                 select receipts;
                    if (result.Count() > 0)
                    {
                        foreach (var gez in result)
                        {
                            masa.BackColor = Color.DarkRed;
                        }
                    }
                    else
                        masa.BackColor = Color.Gray;
                }

                Panel panel = new Panel();
                panel.Name = i.ToString() + "panel";
                panel.Size = new Size(25, 50);
                panel.BackColor = Color.Transparent;

                flowLayoutPanel1.Controls.Add(masa);
                flowLayoutPanel1.Controls.Add(panel);

                if (i % 16 == 0)
                {
                    panel.Size = new Size(1350, 19);
                    flowLayoutPanel1.Controls.Add(panel);
                }
                masa.Click += new EventHandler(masaTiklama);
            }
        }
        private void masaTiklama(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Masa = btn.Name;
            using (var cafeContext = new CafeDBEntities())
            {
                int temp = int.Parse(Masa);
                var result = from receipts in cafeContext.Receipts
                             join orders in cafeContext.Orders
                             on receipts.ReceiptID equals orders.Receipts.ReceiptID
                             where receipts.TableNumber == temp && orders.isAlive == true
                             select receipts;
                if (result.Count() > 0)
                {
                    TableForm gcs = new TableForm();
                    gcs.ShowDialog();
                }
                else
                {
                    LoadingForm gcs = new LoadingForm();
                    gcs.ShowDialog();
                }
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            masaOlustur();
        }

        private void ürünSilmeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void menuUrun_Click(object sender, EventArgs e)
        {
            ProductForm gcs = new ProductForm();
            gcs.ShowDialog();
        }

        private void menuTur_Click(object sender, EventArgs e)
        {
            CategoryForm gcs = new CategoryForm();
            gcs.ShowDialog();
        }

        private void menuPersonel_Click(object sender, EventArgs e)
        {
            PersonalAndCafeForm gcs = new PersonalAndCafeForm();
            gcs.ShowDialog();

        }
    }
}
