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
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace TicariOtomasyonDevExpress
{
    public partial class frmMail : Form
    {
        public string hash = "deneme";
        DBCon localdb = new DBCon();
        string mailAddress;
        string maillAddressPassword;
        public frmMail()
        {
            InitializeComponent();
        }
        public string Decrypt(string SifrelenmisDeger)
        {
            byte[] data = Convert.FromBase64String(SifrelenmisDeger);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }
        public string MailAddress;
        private void frmMail_Load(object sender, EventArgs e)
        {
            txtMailAddress.Text = MailAddress;
        }
        void GetMailAddresses()
        {
            try
            {
                SqlCommand da = new SqlCommand("Select * from MailAddresses", localdb.DB());
                SqlDataReader reader = da.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        mailAddress = reader.GetString(1);
                        maillAddressPassword = Decrypt(reader.GetString(2));
                    }
                }
                else
                {
                    XtraMessageBox.Show("Sisteme mail adresi girişi yapmak için yazılım sahibi ile görüşün", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                GetMailAddresses();
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Credentials = new NetworkCredential(mailAddress, maillAddressPassword);
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                mailMessage.To.Add(txtMailAddress.Text);
                mailMessage.From = new MailAddress(mailAddress);
                mailMessage.Subject = txtMailSubject.Text;
                mailMessage.Body = txtMailMessage.Text;
                smtpClient.Send(mailMessage);
                svgSuccess.Visible = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Mail ayarlarınızı kontrol edin!\n" + ex.Message , "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                svgFail.Visible = true;
            }
        }
    }
}
