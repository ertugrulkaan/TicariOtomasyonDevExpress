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
    public partial class frmCompanies : Form
    {
        DBCon localdb = new DBCon();
        public frmCompanies()
        {
            InitializeComponent();

        }
        void GetCityList()
        {
            try
            {
                SqlCommand da = new SqlCommand("Select * from Cities", localdb.DB());
                SqlDataReader dr = da.ExecuteReader();
                while (dr.Read())
                {
                    cmbCities.Properties.Items.Add(dr[1]);
                }
                localdb.DB().Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void GetCompanies()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Companies", localdb.DB());
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void frmCompanies_Load(object sender, EventArgs e)
        {
            GetCompanies();
            GetCityList();
            SpecialCodeDesc();
        }
        void InsertCompanies()
        {
            try
            {

                SqlCommand sql = new SqlCommand("Insert into Companies (Name,AuthorizedPersonJobDescription,AuthorizedPersonFullName,AuthorizedPersonIdentityNumber,Sector,PhoneNumber1,PhoneNumber2,PhoneNumber3,EmailAddress,FaxNumber,AddressCity,AddressTown,AddressDetail,TaxAddress,SpecialCode1,SpecialCode2,SpecialCode3) values (@Name,@AuthorizedPersonJobDescription,@AuthorizedPersonFullName,@AuthorizedPersonIdentityNumber,@Sector,@PhoneNumber1,@PhoneNumber2,@PhoneNumber3,@EmailAddress,@FaxNumber,@AddressCity,@AddressTown,@AddressDetail,@TaxAddress,@SpecialCode1,@SpecialCode2,@SpecialCode3)", localdb.DB());
                sql.Parameters.AddWithValue("@Name", txtName.Text);
                sql.Parameters.AddWithValue("@AuthorizedPersonJobDescription", txtAuthJobDesc.Text);
                sql.Parameters.AddWithValue("@AuthorizedPersonFullName", txtAuthName.Text);
                sql.Parameters.AddWithValue("@AuthorizedPersonIdentityNumber", txtTC.Text);
                sql.Parameters.AddWithValue("@Sector", txtSector.Text);
                sql.Parameters.AddWithValue("@PhoneNumber1", mtxtPhone1.Text);
                sql.Parameters.AddWithValue("@PhoneNumber2", mtxtPhone2.Text);
                sql.Parameters.AddWithValue("@PhoneNumber3", mtxtPhone2.Text);
                sql.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
                sql.Parameters.AddWithValue("@FaxNumber", mtxtFax.Text);
                sql.Parameters.AddWithValue("@AddressCity", cmbCities.SelectedText);
                sql.Parameters.AddWithValue("@AddressTown", cmbTowns.SelectedText);
                sql.Parameters.AddWithValue("@AddressDetail", txtAddressDetail.Text);
                sql.Parameters.AddWithValue("@TaxAddress", txtTaxAddress.Text);
                sql.Parameters.AddWithValue("@SpecialCode1", txtCode1.Text);
                sql.Parameters.AddWithValue("@SpecialCode2", txtCode2.Text);
                sql.Parameters.AddWithValue("@SpecialCode3", txtCode3.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Firma Sisteme Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void DeleteCompanies()
        {
            SqlCommand sql = new SqlCommand("Delete from Companies where ID=@ID", localdb.DB());
            sql.Parameters.AddWithValue("@ID", txtID.Text);
            sql.ExecuteNonQuery();
            localdb.DB().Close();
            XtraMessageBox.Show("Firma Sistemden Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        void UpdateCompanies()
        {
            try
            {
            SqlCommand sql = new SqlCommand("update Companies set Name=@Name,AuthorizedPersonJobDescription=@AuthorizedPersonJobDescription,AuthorizedPersonFullName=@AuthorizedPersonFullName,AuthorizedPersonIdentityNumber=@AuthorizedPersonIdentityNumber,Sector=@Sector,PhoneNumber1=@PhoneNumber1,PhoneNumber2=@PhoneNumber2,PhoneNumber3=@PhoneNumber3,EmailAddress=@EmailAddress,FaxNumber=@FaxNumber,AddressCity=@AddressCity,AddressTown=@AddressTown,AddressDetail=@AddressDetail,TaxAddress=@TaxAddress,SpecialCode1=@SpecialCode1,SpecialCode2=@SpecialCode2,SpecialCode3=@SpecialCode3 where ID=@ID ", localdb.DB());
            sql.Parameters.AddWithValue("@Name", txtName.Text);
            sql.Parameters.AddWithValue("@AuthorizedPersonJobDescription", txtAuthJobDesc.Text);
            sql.Parameters.AddWithValue("@AuthorizedPersonFullName", txtAuthName.Text);
            sql.Parameters.AddWithValue("@AuthorizedPersonIdentityNumber", txtTC.Text);
            sql.Parameters.AddWithValue("@Sector", txtSector.Text);
            sql.Parameters.AddWithValue("@PhoneNumber1", mtxtPhone1.Text);
            sql.Parameters.AddWithValue("@PhoneNumber2", mtxtPhone2.Text);
            sql.Parameters.AddWithValue("@PhoneNumber3", mtxtPhone2.Text);
            sql.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            sql.Parameters.AddWithValue("@FaxNumber", mtxtFax.Text);
            sql.Parameters.AddWithValue("@AddressCity", cmbCities.SelectedText);
            sql.Parameters.AddWithValue("@AddressTown", cmbTowns.SelectedText);
            sql.Parameters.AddWithValue("@AddressDetail", txtAddressDetail.Text);
            sql.Parameters.AddWithValue("@TaxAddress", txtTaxAddress.Text);
            sql.Parameters.AddWithValue("@SpecialCode1", txtCode1.Text);
            sql.Parameters.AddWithValue("@SpecialCode2", txtCode2.Text);
            sql.Parameters.AddWithValue("@SpecialCode3", txtCode3.Text);
            sql.Parameters.AddWithValue("@ID", lblIDHelper.Text);
            sql.ExecuteNonQuery();
            localdb.DB().Close();
            XtraMessageBox.Show("Firma Sistemde Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    opt.SheetName = "Firmalar";
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                txtID.Text = dr["ID"].ToString();
                lblIDHelper.Text = dr["ID"].ToString();
                txtName.Text = dr["Name"].ToString();
                txtSector.Text = dr["Sector"].ToString();
                txtAuthName.Text = dr["AuthorizedPersonFullName"].ToString();
                txtAuthJobDesc.Text = dr["AuthorizedPersonJobDescription"].ToString();
                txtEmail.Text = dr["EmailAddress"].ToString();
                mtxtPhone1.Text = dr["PhoneNumber1"].ToString();
                mtxtPhone2.Text = dr["PhoneNumber2"].ToString();
                mtxtPhone3.Text = dr["PhoneNumber3"].ToString();
                mtxtFax.Text = dr["FaxNumber"].ToString();
                txtTC.Text = dr["AuthorizedPersonIdentityNumber"].ToString();
                txtAddressDetail.Text = dr["AddressDetail"].ToString();
                txtTaxAddress.Text = dr["TaxAddress"].ToString();
                cmbCities.SelectedIndex = -1;
                cmbTowns.SelectedIndex = -1;
                cmbCities.SelectedText = dr["AddressCity"].ToString();
                cmbTowns.SelectedText = dr["AddressTown"].ToString();
                txtCode1.Text = dr["SpecialCode1"].ToString();
                txtCode2.Text = dr["SpecialCode2"].ToString();
                txtCode3.Text = dr["SpecialCode3"].ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbTowns.Properties.Items.Clear();
                SqlCommand da1 = new SqlCommand("Select * from Towns where Town=@p1", localdb.DB());
                da1.Parameters.AddWithValue("@p1", cmbCities.SelectedIndex + 1);
                SqlDataReader dr1 = da1.ExecuteReader();
                while (dr1.Read())
                {
                    cmbTowns.Properties.Items.Add(dr1[1]);
                }
                localdb.DB().Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCompanySave_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = XtraMessageBox.Show("Firmayı kaydetmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    InsertCompanies();
                    GetCompanies();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCompanyDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = XtraMessageBox.Show("Firmayı silmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteCompanies();
                    GetCompanies();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCompanyUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = XtraMessageBox.Show("Firmayı güncellemek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    UpdateCompanies();
                    GetCompanies();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        void SpecialCodeDesc()
        {
            try
            {

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * from SpecialCodes  ", localdb.DB());
                da.Fill(dt);
                rtxtCode1.Text = dt.Rows[0]["Code"].ToString();
                rtxtCode2.Text = dt.Rows[1]["Code"].ToString();
                rtxtCode3.Text = dt.Rows[2]["Code"].ToString();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void SpecialCodeUpdate(int ID)
        {
            string A = null;
            if (ID == 1)
            {
                A = rtxtCode1.Text;
            }
            else if(ID == 2)
            {
                A = rtxtCode2.Text;
            }
            else 
            {
                A = rtxtCode3.Text;
            }
            try
            {
                SqlCommand sql = new SqlCommand("update SpecialCodes set Code=@Code where ID=@ID", localdb.DB());
                sql.Parameters.AddWithValue("@Code", A.ToString());
                sql.Parameters.AddWithValue("@ID", ID);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Özel Kod " + ID + " Sistemde Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SpecialCodeDesc();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSpecCode1_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Özel Kod "+ 1 +"'i güncellemek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SpecialCodeUpdate(1);
            }
        }

        private void btnSpecCode2_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Özel Kod " + 2 + "'yi güncellemek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SpecialCodeUpdate(2);
            }
        }

        private void btnSpecCode3_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Özel Kod " + 3 + "'ü güncellemek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SpecialCodeUpdate(3);
            }
        }
    }
}
