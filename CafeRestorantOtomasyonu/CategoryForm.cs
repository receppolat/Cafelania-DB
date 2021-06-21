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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void verigoster()
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            using (var cafeContext = new CafeDBEntities())
            {
                var result = from categories in cafeContext.Categories
                             select categories;
                foreach (var categories in result)
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = categories.CategoryID.ToString();
                    ekle.SubItems.Add(categories.CategoryName.ToString());                   
                    listView1.Items.Add(ekle);
                }
            }
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbadi.Text.Length != 0 )
                {
                    using (var cafeContext = new CafeDBEntities())
                    {
                        var resultCategory = from categories in cafeContext.Categories
                                             where categories.CategoryName.ToLower() == tbadi.Text.ToLower()
                                             select categories;
                        if(resultCategory.Count() == 0)
                        {
                            var result = from categories in cafeContext.Categories
                                         select categories;
                            cafeContext.Categories.Add(new Categories
                            {
                                CategoryName = tbadi.Text
                            });
                            cafeContext.SaveChanges();
                        }
                        else
                            MessageBox.Show("Böyle bir kategori mevcuttur. Lütfen kategori ismini değiştiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cafeContext = new CafeDBEntities())
                {
                    var result = from products in cafeContext.Products
                                 join categories in cafeContext.Categories
                                 on products.Categories.CategoryID equals categories.CategoryID
                                 where products.Categories.CategoryID == satir
                                 select products;
                    if(result.Count() > 0)
                    {
                        DialogResult cevap = MessageBox.Show("Eğer bu kategoriyi silerseniz bu kategorideki ürünler de silinecek. Yine de silmek ister misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (cevap == DialogResult.Yes)
                        {
                            foreach (var product in result)
                            {
                                cafeContext.Products.Remove(product);
                            }
                            cafeContext.SaveChanges();

                            Categories category = cafeContext.Categories.Find(satir);
                            cafeContext.Categories.Remove(category);
                            cafeContext.SaveChanges();

                        }
                    }
                    else
                    {
                        Categories category = cafeContext.Categories.Find(satir);
                        cafeContext.Categories.Remove(category);
                        cafeContext.SaveChanges();
                    }
                }
                verigoster();
           }
            catch
            {
                MessageBox.Show("Silmek için lütfen seçim yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            verigoster();
        }
        int satir;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                satir = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                tbadi.Text = listView1.SelectedItems[0].SubItems[1].Text;
            }
            catch { }
        }

        private void btnduzenle_Click(object sender, EventArgs e)
        {
            try
            {
                if (satir == -1)
                    MessageBox.Show("Düzenlemek için lütfen seçim yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (tbadi.Text.Length != 0 )
                    {
                        using (var cafeContext = new CafeDBEntities())
                        {
                            var resultCategory = from categories in cafeContext.Categories
                                                 where categories.CategoryName.ToLower() == tbadi.Text.ToLower()
                                                 select categories;
                            if (resultCategory.Count() == 0)
                            {
                                var result = from categoryId in cafeContext.Categories
                                             select categoryId.CategoryID;
                                int id = result.FirstOrDefault();
                                Categories category = cafeContext.Categories.Find(id);
                                category.CategoryName = tbadi.Text;
                                cafeContext.SaveChanges();
                            }
                            else
                                MessageBox.Show("Böyle bir kategori mevcuttur. Lütfen kategori ismini değiştiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void tbadi_TextChanged(object sender, EventArgs e)
        {
            using (var cafeContext1 = new CafeDBEntities())
            {
                listView1.Items.Clear();
                listView1.View = View.Details;
                listView1.FullRowSelect = true;
                listView1.GridLines = true;
                using (var cafeContext = new CafeDBEntities())
                {
                    var result2 = from categories in cafeContext.Categories
                                  where categories.CategoryName.Contains(tbadi.Text)
                                  select new
                                  {
                                      categories
                                  };
                    foreach (var categories in result2)
                    {
                        ListViewItem ekle = new ListViewItem();
                        ekle.Text = categories.categories.CategoryID.ToString();
                        ekle.SubItems.Add(categories.categories.CategoryName.ToString());
                        listView1.Items.Add(ekle);
                    }
                }

            }
        }
    }
}
