using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using DevExpress.XtraEditors;

namespace TicariOtomasyonDevExpress
{
    public partial class frmMail : Form
    {
        public frmMail()
        {
            InitializeComponent();
        }
        public string MailAddress;
        private void frmMail_Load(object sender, EventArgs e)
        {
            txtMailAddress.Text = MailAddress;
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {

                //TODO: GENEL AYARLAR KISMINI YAPTIĞINDA DATABASE E MAİL VE ŞİFRE EKLE ORADAN GÖNDERİM YAPAR.
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Credentials = new NetworkCredential("Mail", "Sifre");
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.live.com";
                smtpClient.EnableSsl = true;
                mailMessage.To.Add(txtMailAddress.Text);
                mailMessage.From = new MailAddress("Mail");
                mailMessage.Subject = txtMailSubject.Text;
                mailMessage.Body = txtMailMessage.Text;
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Mail ayarlarınızı kontrol edin!\n" + ex.Message , "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
