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
    public partial class frmCustomers : Form
    {
        //string type = "CUS";
        DBCon localdb = new DBCon();
        public frmCustomers()
        {
            InitializeComponent();
        }
        void GetCustomers()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Customers", localdb.DB());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void GetCityList()
        {
            SqlCommand da = new SqlCommand("Select * from Cities", localdb.DB());
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                cmbCities.Properties.Items.Add(dr[1]);
            }
            localdb.DB().Close();
        }
        private void cmbCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTowns.Properties.Items.Clear();
            SqlCommand da1 = new SqlCommand("Select * from Towns where Town=@p1", localdb.DB());
            da1.Parameters.AddWithValue("@p1",cmbCities.SelectedIndex+1);
            SqlDataReader dr1 = da1.ExecuteReader();
            while (dr1.Read())
            {
                cmbTowns.Properties.Items.Add(dr1[1]);
            }
            localdb.DB().Close();
        }
        private void frmCustomers_Load(object sender, EventArgs e)
        {
            GetCustomers();
            GetCityList();
        }
        void InsertCustomers()
        {
            SqlCommand sql = new SqlCommand("Insert into Customers (FirstName,LastName,IdentityNumber,PhoneNumber1,PhoneNumber2,EmailAddress,AddressCity,AddressTown,AddressDetail,TaxAddress) values (@FirstName,@LastName,@IdentityNumber,@PhoneNumber1,@PhoneNumber2,@EmailAddress,@AddressCity,@AddressTown,@AddressDetail,@TaxAddress)", localdb.DB());
            sql.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            sql.Parameters.AddWithValue("@LastName", txtLastName.Text);
            sql.Parameters.AddWithValue("@IdentityNumber", txtTC.Text);
            sql.Parameters.AddWithValue("@PhoneNumber1", mtxtPhone1.Text);
            sql.Parameters.AddWithValue("@PhoneNumber2", mtxtPhone2.Text);
            sql.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            sql.Parameters.AddWithValue("@AddressCity", cmbCities.SelectedText);
            sql.Parameters.AddWithValue("@AddressTown", cmbTowns.SelectedText);
            sql.Parameters.AddWithValue("@AddressDetail", txtAddressDetail.Text);
            sql.Parameters.AddWithValue("@TaxAddress", txtTaxAddress.Text);
            sql.ExecuteNonQuery();
            localdb.DB().Close();
            XtraMessageBox.Show("Müşteri Sisteme Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        void DeleteCustomers()
        {
            SqlCommand sql = new SqlCommand("Delete from Customers where ID=@ID", localdb.DB());
            sql.Parameters.AddWithValue("@ID", txtID.Text);
            sql.ExecuteNonQuery();
            localdb.DB().Close();
            XtraMessageBox.Show("Müşteri Sistemden Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        void UpdateCustomers()
        {
            SqlCommand sql = new SqlCommand("update Customers set FirstName=@FirstName,LastName=@LastName,IdentityNumber=@IdentityNumber,PhoneNumber1=@PhoneNumber1,PhoneNumber2=@PhoneNumber2,EmailAddress=@EmailAddress,AddressCity=@AddressCity,AddressTown=@AddressTown,AddressDetail=@AddressDetail,TaxAddress=@TaxAddress where ID=@ID ", localdb.DB());
            sql.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            sql.Parameters.AddWithValue("@LastName", txtLastName.Text);
            sql.Parameters.AddWithValue("@IdentityNumber", txtTC.Text);
            sql.Parameters.AddWithValue("@PhoneNumber1", mtxtPhone1.Text);
            sql.Parameters.AddWithValue("@PhoneNumber2", mtxtPhone2.Text);
            sql.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            sql.Parameters.AddWithValue("@AddressCity", cmbCities.SelectedText);
            sql.Parameters.AddWithValue("@AddressTown", cmbTowns.SelectedText);
            sql.Parameters.AddWithValue("@AddressDetail", txtAddressDetail.Text);
            sql.Parameters.AddWithValue("@TaxAddress", txtTaxAddress.Text);
            sql.Parameters.AddWithValue("@ID", txtID.Text);
            sql.ExecuteNonQuery();
            localdb.DB().Close();
            XtraMessageBox.Show("Müşteri Sistemde Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    opt.SheetName = "Ürünler";
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

        private void btnProductSave_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Müşteriyi kaydetmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                InsertCustomers();
                GetCustomers();
            }
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Müşteriyi silmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteCustomers();
                GetCustomers();
            }
        }

        private void btnProductUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Müşteriyi güncellemek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateCustomers();
                GetCustomers();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["ID"].ToString();
            txtFirstName.Text = dr["FirstName"].ToString();
            txtLastName.Text = dr["LastName"].ToString();
            txtTC.Text = dr["IdentityNumber"].ToString();
            txtTaxAddress.Text = dr["TaxAddress"].ToString();
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
