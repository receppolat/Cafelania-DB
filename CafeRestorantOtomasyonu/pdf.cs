using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeRestorantOtomasyonu
{
    public partial class pdf : Form
    {
        public pdf()
        {
            InitializeComponent();
        }

        private void pdf_Load(object sender, EventArgs e)
        {
            if(TableForm.odeme)
                axAcroPDF1.LoadFile(TableForm.receiptID.ToString()+".pdf");
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("receppolat95@gmail.com", "CAFELANIA");
            ePosta.To.Add(new MailAddress(textBox1.Text));
            ePosta.Subject = DateTime.Now.ToString() + " tarihli fişiniz.";
            ePosta.Body = "Fişiniz ektedir. Doğayı sevip koruduğunuz için teşekkürler.";
            Attachment attachment = new Attachment(Application.StartupPath + @"\" + TableForm.receiptID + ".pdf");
            ePosta.Attachments.Add(attachment);
            string kullanici = "receppolat95@gmail.com";
            string parola = "Qazdrewq1";
            NetworkCredential nc = new NetworkCredential(kullanici, parola);
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = nc;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            object userState = ePosta;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                MessageBox.Show(ex.Message, "Hata : E-Posta Gönderilemedi");
            }

        }
    }
}
