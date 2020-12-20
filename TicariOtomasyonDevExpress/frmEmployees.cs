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
    public partial class frmEmployees : Form
    {
        DBCon localdb = new DBCon();
        public frmEmployees()
        {
            InitializeComponent();
        }
        private void frmEmployees_Load(object sender, EventArgs e)
        {
            GetCityList();
            GetEmployees();
        }
        void GetEmployees()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Employees", localdb.DB());
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
        void InsertEmployees()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Insert into Employees (FirstName,LastName,IdentityNumber,PhoneNumber1,PhoneNumber2,EmailAddress,AddressCity,AddressTown,AddressDetail,JobDescription) values (@FirstName,@LastName,@IdentityNumber,@PhoneNumber1,@PhoneNumber2,@EmailAddress,@AddressCity,@AddressTown,@AddressDetail,@JobDescription)", localdb.DB());
                sql.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                sql.Parameters.AddWithValue("@LastName", txtLastName.Text);
                sql.Parameters.AddWithValue("@IdentityNumber", txtTC.Text);
                sql.Parameters.AddWithValue("@PhoneNumber1", mtxtPhone1.Text);
                sql.Parameters.AddWithValue("@PhoneNumber2", mtxtPhone2.Text);
                sql.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
                sql.Parameters.AddWithValue("@AddressCity", cmbCities.SelectedText);
                sql.Parameters.AddWithValue("@AddressTown", cmbTowns.SelectedText);
                sql.Parameters.AddWithValue("@AddressDetail", txtAddressDetail.Text);
                sql.Parameters.AddWithValue("@JobDescription", txtJobDesc.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Personel Sisteme Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void DeleteEmployees()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Delete from Employees where ID=@ID", localdb.DB());
                sql.Parameters.AddWithValue("@ID", txtID.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Personel Sistemden Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void UpdateEmployees()
        {
            try
            {
                SqlCommand sql = new SqlCommand("update Employees set FirstName=@FirstName,LastName=@LastName,IdentityNumber=@IdentityNumber,PhoneNumber1=@PhoneNumber1,PhoneNumber2=@PhoneNumber2,EmailAddress=@EmailAddress,AddressCity=@AddressCity,AddressTown=@AddressTown,AddressDetail=@AddressDetail,JobDescription=@JobDescription where ID=@ID ", localdb.DB());
                sql.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                sql.Parameters.AddWithValue("@LastName", txtLastName.Text);
                sql.Parameters.AddWithValue("@IdentityNumber", txtTC.Text);
                sql.Parameters.AddWithValue("@PhoneNumber1", mtxtPhone1.Text);
                sql.Parameters.AddWithValue("@PhoneNumber2", mtxtPhone2.Text);
                sql.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
                sql.Parameters.AddWithValue("@AddressCity", cmbCities.SelectedText);
                sql.Parameters.AddWithValue("@AddressTown", cmbTowns.SelectedText);
                sql.Parameters.AddWithValue("@AddressDetail", txtAddressDetail.Text);
                sql.Parameters.AddWithValue("@JobDescription", txtJobDesc.Text);
                sql.Parameters.AddWithValue("@ID", txtID.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Müşteri Sistemde Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnEmployeeSave_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Personeli kaydetmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                InsertEmployees();
                GetEmployees();
            }
        }

        private void btnEmployeeDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Personeli silmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteEmployees();
                GetEmployees();
            }
        }

        private void btnEmployeeUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Personeli güncellemek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateEmployees();
                GetEmployees();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["ID"].ToString();
            txtFirstName.Text = dr["FirstName"].ToString();
            txtLastName.Text = dr["LastName"].ToString();
            txtTC.Text = dr["IdentityNumber"].ToString();
            txtJobDesc.Text = dr["JobDescription"].ToString();
            txtEmail.Text = dr["EmailAddress"].ToString();
            mtxtPhone1.Text = dr["PhoneNumber1"].ToString();
            mtxtPhone2.Text = dr["PhoneNumber2"].ToString();
            txtAddressDetail.Text = dr["AddressDetail"].ToString();
            cmbCities.SelectedIndex = -1;
            cmbTowns.SelectedIndex = -1;
            cmbCities.SelectedText = dr["AddressCity"].ToString();
            cmbTowns.SelectedText = dr["AddressTown"].ToString();
        }
    }
}
