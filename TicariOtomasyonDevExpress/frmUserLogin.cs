using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomasyonDevExpress
{
    public partial class frmUserLogin : Form
    {
        public string hash = "deneme";
        public string Password = "";
        public int rights = 2;

        //TODO: USERRİGHTS GİBİ BİR YOLU BURAYA EKLE Kİ YETKİSİ OLAN KİŞİ BUNLARI GÖRSÜN BUNLARI GÖRMESİN VS.
        public bool UserHasRights = false;

        DBCon localdb = new DBCon();

        public frmUserLogin()
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
        public bool CheckUserRights(string Name,string Password)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select UserName,Password from Users", localdb.DB());
                da.Fill(dt);

                foreach (var DataRows in dt.Rows)
                {
                    Password = Decrypt(((System.Data.DataRow)DataRows).ItemArray[1].ToString());
                    if (((System.Data.DataRow)DataRows).ItemArray[0].ToString() == txtName.Text && Password == txtPw.Text )
                    {
                        UserHasRights = true;
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            rights--;
            if (rights==-1)
            {
                XtraMessageBox.Show("Hatalı kullanıcı adı veya şifre girdiniz. \n3 kere hatalı giriş yaptınız.\nUygulamadan Çıkılıyor.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return UserHasRights;            
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (rights>=0)
            {
                CheckUserRights(txtName.Text.ToString(), txtPw.Text.ToString());
                if (UserHasRights)
                {
                    frmMain fr = new frmMain();
                    this.Hide();
                    fr.Show();
                }
                else
                {
                    DialogResult result = XtraMessageBox.Show("Hatalı kullanıcı adı veya şifre girdiniz. \nTekrar Denemek ister misiniz?", "HATA!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (result == DialogResult.No)
                    {
                        Application.Exit();
                    }
                }
            }
        }

        private void frmUserLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
