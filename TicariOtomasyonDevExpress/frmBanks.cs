using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomasyonDevExpress
{
    public partial class frmBanks : Form
    {
        DBCon localdb = new DBCon();
        public frmBanks()
        {
            InitializeComponent();
        }
        void GetBanks(bool IsActive)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Execute spGetBanks @IsActive=@p1", localdb.DB());
                if (IsActive)
                    da.SelectCommand.Parameters.AddWithValue("@p1", IsActive);
                else
                    da.SelectCommand.Parameters.AddWithValue("@p1", IsActive);
                da.Fill(dt);
                if (IsActive)
                    gridControl1.DataSource = dt;
                else
                    gridControl2.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void InsertBanks()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Insert into Banks (Name,Address,Branch,IBAN,AccountNo,AuthorizedPersonFullName,PhoneNumber,Email,AccountType,CompanyID) values (@Name,@Address,@Branch,@IBAN,@AccountNo,@AuthorizedPersonFullName,@PhoneNumber,@Email,@AccountType,@CompanyID)", localdb.DB());
                sql.Parameters.AddWithValue("@Name", txtName.Text);
                sql.Parameters.AddWithValue("@Address", txtAddress.Text);
                sql.Parameters.AddWithValue("@Branch", txtBranch.Text);
                sql.Parameters.AddWithValue("@IBAN", txtIBAN.Text);
                sql.Parameters.AddWithValue("@AccountNo", txtAccountNumber.Text);
                sql.Parameters.AddWithValue("@AuthorizedPersonFullName", txtAuthName.Text);
                sql.Parameters.AddWithValue("@PhoneNumber", mtxtPhone.Text);
                sql.Parameters.AddWithValue("@Email", txtEmail.Text);
                sql.Parameters.AddWithValue("@AccountType", cmbAccType.SelectedText);
                sql.Parameters.AddWithValue("@CompanyID", lueCompanies.EditValue);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Banka Sisteme Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void DeleteBanks()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Update Banks set IsActive=0,UpdateDate=@UpdateDate where ID=@ID", localdb.DB());
                sql.Parameters.AddWithValue("@ID", txtID.Text);
                sql.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Banka Sistemden Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void UpdateBanks()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Update Banks set Name=@Name,Address=@Address,Branch=@Branch,IBAN=@IBAN,AccountNo=@AccountNo,AuthorizedPersonFullName=@AuthorizedPersonFullName,PhoneNumber=@PhoneNumber,Email=@Email,UpdateDate=@UpdateDate,AccountType=@AccountType,CompanyID=@CompanyID where ID=@ID", localdb.DB());
                sql.Parameters.AddWithValue("@Name", txtName.Text);
                sql.Parameters.AddWithValue("@Address", txtAddress.Text);
                sql.Parameters.AddWithValue("@Branch", txtBranch.Text);
                sql.Parameters.AddWithValue("@IBAN", txtIBAN.Text);
                sql.Parameters.AddWithValue("@AccountNo", txtAccountNumber.Text);
                sql.Parameters.AddWithValue("@AuthorizedPersonFullName", txtAuthName.Text);
                sql.Parameters.AddWithValue("@PhoneNumber", mtxtPhone.Text);
                sql.Parameters.AddWithValue("@Email", txtEmail.Text);
                sql.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                sql.Parameters.AddWithValue("@AccountType", cmbAccType.SelectedText);
                sql.Parameters.AddWithValue("@CompanyID", lueCompanies.EditValue);
                sql.Parameters.AddWithValue("@ID", txtID.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Banka Sistemde Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void CompanyList()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Execute spGetCompanies", localdb.DB());
                da.Fill(dt);
                lueCompanies.Properties.NullText = "Firmalar";
                lueCompanies.Properties.ValueMember = "ID";
                lueCompanies.Properties.DisplayMember = "Name";
                lueCompanies.Properties.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnBankSave_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Bankayı kaydetmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                InsertBanks();
                GetBanks(true);
            }
        }
        private void btnBankDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Bankayı silmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteBanks();
                GetBanks(true);
                GetBanks(false);
            }
        }
        private void btnBankUpdate_Click(object sender, EventArgs e)
        {
            DateTime updateTime = DateTime.Now;
            DialogResult result = XtraMessageBox.Show("Bankayı güncellemek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateBanks();
                GetBanks(true);
            }
        }
        private void PDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Dosyaları (*.pdf)|*.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (sfd.FileName.EndsWith(".pdf"))
                    {
                        gridView1.ExportToPdf(sfd.FileName);
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }
        private void Excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Dosyaları (*.xlsx)|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DevExpress.XtraPrinting.XlsxExportOptions opt = new DevExpress.XtraPrinting.XlsxExportOptions();
                    opt.ExportMode = DevExpress.XtraPrinting.XlsxExportMode.SingleFile;
                    opt.SheetName = "Personeller";
                    opt.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value;
                    gridView1.ExportToXlsx(sfd.FileName, opt);
                    System.Diagnostics.Process.Start(sfd.FileName);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }
        private void frmBanks_Load(object sender, EventArgs e)
        {
            GetBanks(true);
            GetBanks(false);
            CompanyList();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //TODO: ŞİRKET İSMİ GELMİYOR DÜZELTİLECEK.
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                txtID.Text = dr["ID"].ToString();
                txtName.Text = dr["Name"].ToString();
                txtAddress.Text = dr["Address"].ToString();
                txtBranch.Text = dr["Branch"].ToString();
                txtIBAN.Text = dr["IBAN"].ToString();
                txtAccountNumber.Text = dr["AccountNo"].ToString();
                txtAuthName.Text = dr["AuthorizedPersonFullName"].ToString();
                mtxtPhone.Text = dr["PhoneNumber"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                cmbAccType.SelectedIndex = -1;
                cmbAccType.SelectedText = dr["AccountType"].ToString();
                lueCompanies.EditValue = -1;
                lueCompanies.EditValue = dr["CompanyName"].ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
