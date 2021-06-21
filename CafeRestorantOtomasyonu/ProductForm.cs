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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        public void verigoster()
        {
            listView1.Items.Clear();
            cbtur.Items.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            using (var cafeContext = new CafeDBEntities())
            {
                var result = from products in cafeContext.Products
                             join categories in cafeContext.Categories
                             on products.Categories.CategoryID equals categories.CategoryID
                             select new
                             {
                                 products,
                                 categories
                             };
                foreach (var product in result)
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = product.products.ProductID.ToString();
                    ekle.SubItems.Add(product.products.ProductName.ToString());
                    ekle.SubItems.Add(product.categories.CategoryName.ToString());
                    ekle.SubItems.Add(product.products.Amount.ToString());
                    listView1.Items.Add(ekle);
                }
                var result1 = from categories in cafeContext.Categories
                              select categories;
                foreach (var category in result1)
                    cbtur.Items.Add(category.CategoryName);
            }
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            verigoster();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbadi.Text.Length != 0 && tbfiyat.Text.Length != 0 && cbtur.Text.Length != 0)
                {
                    using (var cafeContext = new CafeDBEntities())
                    {
                        var resultProduct = from products in cafeContext.Products
                                            where products.ProductName.ToLower() == tbadi.Text.ToLower()
                                            select products;
                        if(resultProduct.Count() == 0)
                        {
                            var result = from categories in cafeContext.Categories
                                         where categories.CategoryName == cbtur.Text
                                         select categories;
                            cafeContext.Products.Add(new Products
                            {
                                ProductName = tbadi.Text,
                                Amount = float.Parse(tbfiyat.Text),
                                Categories = result.FirstOrDefault()
                            });
                            cafeContext.SaveChanges();
                        }
                        else
                            MessageBox.Show("Böyle bir ürün mevcuttur. Lütfen ürün ismini değiştiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    verigoster();
                }
                else
                    MessageBox.Show("Boş alan bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
            }

        }

        private void btnduzenle_Click(object sender, EventArgs e)
        {
            try
            {
                if (satir == -1)
                    MessageBox.Show("Düzenlemek için lütfen seçim yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (tbadi.Text.Length != 0 && tbfiyat.Text.Length != 0 && cbtur.Text.Length != 0)
                    {
                        using (var cafeContext = new CafeDBEntities())
                        {
                            var resultProduct = from products in cafeContext.Products
                                                where products.ProductName.ToLower() == tbadi.Text.ToLower()
                                                select products;
                            if (resultProduct.Count() == 0)
                            {
                                var result = from categoryId in cafeContext.Categories
                                             where categoryId.CategoryName == cbtur.Text
                                             select categoryId.CategoryID;
                                int id = result.FirstOrDefault();
                                Products product = cafeContext.Products.Find(satir);
                                Categories category = cafeContext.Categories.Find(id);
                                product.ProductID = satir;
                                product.ProductName = tbadi.Text;
                                product.Categories = category;
                                product.Amount = float.Parse(tbfiyat.Text);
                                cafeContext.SaveChanges();
                            }
                            else
                                MessageBox.Show("Böyle bir ürün mevcuttur. Lütfen ürün ismini değiştiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        verigoster();
                    }
                    else
                        MessageBox.Show("Boş alan bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
            }


        }

        int satir = -1;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                satir = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                tbadi.Text = listView1.SelectedItems[0].SubItems[1].Text;
                tbfiyat.Text = listView1.SelectedItems[0].SubItems[3].Text;
                cbtur.Text = listView1.SelectedItems[0].SubItems[2].Text;
            }
            catch { }

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cafeContext = new CafeDBEntities())
                {
                    Products product = cafeContext.Products.Find(satir);
                    cafeContext.Products.Remove(product);
                    cafeContext.SaveChanges();
                }
                verigoster();
            }
            catch
            {
                MessageBox.Show("Silmek için lütfen seçim yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbsearch_TextChanged(object sender, EventArgs e)
        {
            using (var cafeContext1 = new CafeDBEntities())
            {        
                listView1.Items.Clear();
                listView1.View = View.Details;
                listView1.FullRowSelect = true;
                listView1.GridLines = true;
                using (var cafeContext = new CafeDBEntities())
                {
                    var result2 = from products in cafeContext.Products
                                  join categories in cafeContext.Categories
                                  on products.Categories.CategoryID equals categories.CategoryID
                                  where products.ProductName.Contains(tbsearch.Text)
                                  select new
                                  {
                                      products,
                                      categories
                                  };
                    foreach (var product in result2)
                    {
                        ListViewItem ekle = new ListViewItem();
                        ekle.Text = product.products.ProductID.ToString();
                        ekle.SubItems.Add(product.products.ProductName.ToString());
                        ekle.SubItems.Add(product.categories.CategoryName.ToString());
                        ekle.SubItems.Add(product.products.Amount.ToString());
                        listView1.Items.Add(ekle);
                    }
                }
               
            }
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

