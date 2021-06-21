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
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(kuver != "")
            {
                using (var cafeContext = new CafeDBEntities())
                {
                    int temp = int.Parse(MainForm.Masa);
                    var result = from receipts in cafeContext.Receipts
                                 select receipts;
                        cafeContext.Receipts.Add(new Receipts
                        {
                            Cover = int.Parse(kuver),
                            Date = DateTime.Now.ToString(),
                            TableNumber = temp
                        });
                        cafeContext.SaveChanges();
                }
                TableForm gcs = new TableForm();
                gcs.ShowDialog();
                this.Close();
            }

        }

        private void LoadingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        public static string kuver = "";
        private void btn1_Click(object sender, EventArgs e)
        {
            kuver += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            kuver += "2";

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            kuver += "3";

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            kuver += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            kuver += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            kuver += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            kuver += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            kuver += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            kuver += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if(kuver != "")
                kuver += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(kuver);
            kuver = "";
        }
    }
}
