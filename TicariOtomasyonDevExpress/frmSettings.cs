using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomasyonDevExpress
{
    public partial class frmSettings : Form
    {
        public string hash = "deneme";
        DBCon localdb = new DBCon();
        public frmSettings()
        {
            InitializeComponent();
        }
        public string Encrypt(string sifre)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(sifre);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
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
        void GetUsers()
        {
            try
            {
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                // USERS TABLOSUNDA MD5 ŞİFRELİ PW DEĞERLERİ VAR GRİDE BUNLARI NORMAL OLARAK ÇEKMEK İSTEDİK.
                SqlDataAdapter da = new SqlDataAdapter("Select * from Users", localdb.DB());
                da.Fill(dt);
                // KULLANICI ADI VE ŞİFRELERİ BİR LİSTEYE ÇEKTİK.
                List<Int32> ID = new List<Int32>();
                List<string> passwords = new List<string>();
                List<string> usernames = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    // ŞİFRELERİ DECRYPT EDİP ÇEKTİK.
                    ID.Add((Int32)row[0]);
                    usernames.Add((string)row[1].ToString());
                    passwords.Add(Decrypt((string)row[2].ToString()));
                }
                // YENİ DATTABLE A İKİ SÜTUN EKLEDİK.
                DataColumn Id = dt2.Columns.Add("ID", typeof(Int32));
                DataColumn UN = dt2.Columns.Add("KULLANICI ADI", typeof(String));
                DataColumn PW = dt2.Columns.Add("ŞİFRE", typeof(String));
                for (int i = 0; i < ID.Count; i++)
                {
                    // DT2 YE SATIRLARI EKLEDİK.-
                    dt2.Rows.Add(new Object[] { ID[i], usernames[i], passwords[i] });
                }
                gridControl1.DataSource = dt2;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void UpdateUsers(Int32 ID,string userName,string password)
        {
            try
            {
                SqlCommand sql = new SqlCommand("update Users set UserName=@UserName,Password=@Password where ID=@ID",localdb.DB());
                sql.Parameters.AddWithValue("@UserName", userName);
                sql.Parameters.AddWithValue("@Password", password);
                sql.Parameters.AddWithValue("@ID", ID);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Giriş Bilgileri Sistemde Güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void InsertUsers()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Insert into Users (UserName,Password) values (@UserName,@Password)", localdb.DB());
                sql.Parameters.AddWithValue("@UserName", txtUserName.Text);
                sql.Parameters.AddWithValue("@Password", Encrypt(txtPassword.Text));
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Kullanıcı sisteme kaydedildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void DeleteUsers(Int32 ID)
        {
            try
            {
                SqlCommand sql = new SqlCommand("Delete from Users Where ID=@ID", localdb.DB());
                sql.Parameters.AddWithValue("@ID", ID);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Kullanıcı sistemden silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void GetMails()
        {
            try
            {
                SqlCommand da = new SqlCommand("Select * from MailAddresses", localdb.DB());
                SqlDataReader reader = da.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblID.Text = reader.GetInt32(0).ToString();
                        txtAddedMail.Text = reader.GetString(1);
                        txtAddedMailPassword.Text = Decrypt(reader.GetString(2));
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
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                DialogResult dialog = XtraMessageBox.Show("Bilgileri güncellemek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    var ID = Convert.ToInt32(dr["ID"]);
                    var userName = dr["KULLANICI ADI"].ToString();
                    var password = Encrypt(dr["ŞİFRE"].ToString());
                    UpdateUsers(ID, userName, password);
                    GetUsers();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void frmSettings_Load(object sender, EventArgs e)
        {
            GetUsers();
            GetMails();
        }
        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = XtraMessageBox.Show("Kullanıcıyı eklemek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    InsertUsers();
                    GetUsers();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedRowHandle == e.RowHandle && !view.FocusedColumn.Equals(e.Column))
                e.Appearance.BackColor = Color.CadetBlue;
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = XtraMessageBox.Show("Kullanıcıyı silmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    var ID = Convert.ToInt32(dr["ID"]);
                    DeleteUsers(ID);
                    GetUsers();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnSendMail_Click(object sender, EventArgs e)
        {
            
        }
        private void btnSendMail_Click_1(object sender, EventArgs e)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Credentials = new NetworkCredential(txtSenderName.Text, txtSenderPassword.Text);
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                mailMessage.To.Add(txtReceiver.Text);
                mailMessage.From = new MailAddress(txtSenderName.Text);
                mailMessage.Subject = "TEST";
                mailMessage.Body = "TEST";
                smtpClient.Send(mailMessage);
                svgSuccess.Visible = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Mail ayarlarınızı kontrol edin!\n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                svgFail.Visible = true;
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sql = new SqlCommand("Update MailAddresses set Email=@Email,Password=@Password", localdb.DB());
                sql.Parameters.AddWithValue("@Email", txtAddedMail.Text);
                sql.Parameters.AddWithValue("@Password", Encrypt(txtAddedMailPassword.Text));
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
