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
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        public static int adminGiris = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            using (var cafeContext = new CafeDBEntities())
            {
                var result = from cafe in cafeContext.Cafes
                             where cafe.CafeEntry == tbadi.Text && cafe.CafeLoginKey == tbparola.Text
                             select cafe;
                if (tbadi.Text == "Admin" && tbparola.Text == "pass")
                {
                    adminGiris = 1;
                    this.Hide();
                    MainForm gcs = new MainForm();
                    gcs.ShowDialog();

                }
                else if (result.Count() == 0)
                    MessageBox.Show("Böyle bir kullanıcı yoktur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);                  
                else
                {
                    adminGiris = 0;
                    this.Hide();
                    MainForm gcs = new MainForm();
                    gcs.Show();

                }
            }

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
