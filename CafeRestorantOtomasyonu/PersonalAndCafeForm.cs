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
    public partial class PersonalAndCafeForm : Form
    {
        public PersonalAndCafeForm()
        {
            InitializeComponent();
        }
        public void verigoster()
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            using (var cafeContext = new CafeDBEntities())
            {
                var result = from personals in cafeContext.Personals
                             select personals;
                foreach (var personel in result)
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = personel.PersonelID.ToString();
                    ekle.SubItems.Add(personel.PersonalName.ToString());
                    ekle.SubItems.Add(personel.PersonalSurname.ToString());
                    ekle.SubItems.Add(personel.PersonalCell.ToString());
                    ekle.SubItems.Add(personel.PersonalRank.ToString());
                    listView1.Items.Add(ekle);
                }
            }
        }

        private void PersonalAndCafeForm_Load(object sender, EventArgs e)
        {
            verigoster();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbadi.Text.Length != 0 && tbsoyadi.Text.Length != 0 && comboBox1.Text.Length != 0 && tbtc.Text.Length != 0 && textBox1.Text.Length != 0 )
                {
                    using (var cafeContext = new CafeDBEntities())
                    {
                        var result = from personals in cafeContext.Personals select personals;
                        cafeContext.Personals.Add(new Personals
                        {
                            PersonalName = tbadi.Text,
                            PersonalSurname = tbsoyadi.Text,
                            PersonelID = tbtc.Text,
                            PersonalCell = textBox1.Text,
                            PersonalRank = comboBox1.Text
                        });
                        cafeContext.SaveChanges();
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
        string tc = "";
        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cafeContext = new CafeDBEntities())
                {
                    Personals personal= cafeContext.Personals.Find(tc);
                    cafeContext.Personals.Remove(personal);
                    cafeContext.SaveChanges();
                }
                verigoster();
            }
            catch
            {
                MessageBox.Show("Silmek için lütfen seçim yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tc =tbtc.Text = listView1.SelectedItems[0].SubItems[0].Text;
                tbadi.Text = listView1.SelectedItems[0].SubItems[1].Text;
                tbsoyadi.Text = listView1.SelectedItems[0].SubItems[2].Text;
                textBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
                comboBox1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            }
            catch { }
        }

        private void btnduzenle_Click(object sender, EventArgs e)
        {
            try
            {
                if (tc == "")
                    MessageBox.Show("Düzenlemek için lütfen seçim yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (tbadi.Text.Length != 0 && tbsoyadi.Text.Length != 0 && comboBox1.Text.Length != 0 && tbtc.Text.Length != 0 && textBox1.Text.Length != 0)
                    {
                        btnekle_Click(sender,e);
                        btnsil_Click(sender, e);
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
                    var result2 = from personals in cafeContext.Personals
                                  where personals.PersonalName.Contains(tbsearch.Text)
                                  select personals;

                    foreach (var personel in result2)
                    {
                        ListViewItem ekle = new ListViewItem();
                        ekle.Text = personel.PersonelID.ToString();
                        ekle.SubItems.Add(personel.PersonalName.ToString());
                        ekle.SubItems.Add(personel.PersonalSurname.ToString());
                        ekle.SubItems.Add(personel.PersonalCell.ToString());
                        ekle.SubItems.Add(personel.PersonalRank.ToString());
                        listView1.Items.Add(ekle);
                    }
                }
            }
          
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbmasa.Text.Length != 0)
                {
                    using (var cafeContext = new CafeDBEntities())
                    {
                        var result = from cafeId in cafeContext.Cafes
                                     where cafeId.CafeID == 1
                                     select cafeId.CafeID;
                        Cafes cafe = cafeContext.Cafes.Find(1);
                        cafe.TableCount = int.Parse(tbmasa.Text);
                        cafeContext.SaveChanges();
                        MessageBox.Show("Güncel masa miktarı için programı kapatıp yeniden açınız.", "Güncelleme Başarılı!", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        tbmasa.Clear();
                    }
                }
                else
                    MessageBox.Show("Boş alan bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
            }
        }

        private void PersonalAndCafeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btncafe_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbmasa.Text.Length != 0)
                {
                    using (var cafeContext = new CafeDBEntities())
                    {
                        var result = from cafes in cafeContext.Cafes
                                     where cafes.CafeID == 1
                                     select cafes.CafeID;
                        Cafes cafe = cafeContext.Cafes.Find(1);
                        cafe.CafeEntry = tbcadi.Text;
                        cafe.CafeLoginKey = tbcparola.Text;
                        cafeContext.SaveChanges();
                        MessageBox.Show("Güncelleme Başarılı!");
                        tbcadi.Clear();
                        tbcparola.Clear();
                    }
                }
                else
                    MessageBox.Show("Boş alan bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
            }

        }
    }
}
