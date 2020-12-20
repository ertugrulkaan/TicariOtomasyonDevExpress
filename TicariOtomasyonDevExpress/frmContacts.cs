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
    public partial class frmContacts : Form
    {
        DBCon localdb = new DBCon();
        public frmContacts()
        {
            InitializeComponent();
        }
        void GetCustomers()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select FirstName,LastName,EmailAddress,PhoneNumber1,PhoneNumber2 from Customers", localdb.DB());
                da.Fill(dt);
                gridControl1.DataSource = dt;
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
                SqlDataAdapter da = new SqlDataAdapter("Select Name,AuthorizedPersonFullName,PhoneNumber1,PhoneNumber2,PhoneNumber3,EmailAddress,FaxNumber from Companies", localdb.DB());
                da.Fill(dt);
                gridControl2.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void frmContacts_Load(object sender, EventArgs e)
        {
            GetCustomers();
            GetCompanies();
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
            SaveFileDialog sfd2 = new SaveFileDialog();
            sfd2.Filter = "PDF Dosyaları (*.pdf)|*.pdf";

            if (sfd2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (sfd2.FileName.EndsWith(".pdf"))
                    {
                        gridView2.ExportToPdf(sfd2.FileName);
                        System.Diagnostics.Process.Start(sfd2.FileName);
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
                    opt.SheetName = "Müşteriler";
                    opt.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value;
                    gridView1.ExportToXlsx(sfd.FileName, opt);
                    System.Diagnostics.Process.Start(sfd.FileName);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
            SaveFileDialog sfd2 = new SaveFileDialog();
            sfd2.Filter = "Excel Dosyaları (*.xlsx)|*.xlsx";
            if (sfd2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DevExpress.XtraPrinting.XlsxExportOptions opt2 = new DevExpress.XtraPrinting.XlsxExportOptions();
                    opt2.ExportMode = DevExpress.XtraPrinting.XlsxExportMode.SingleFile;
                    opt2.SheetName = "Firmalar";
                    opt2.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value;
                    gridView2.ExportToXlsx(sfd2.FileName, opt2);
                    System.Diagnostics.Process.Start(sfd2.FileName);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }
        
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmMail fr = new frmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.MailAddress = dr["EmailAddress"].ToString();
            }
            fr.Show();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            frmMail fr = new frmMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                fr.MailAddress = dr["EmailAddress"].ToString();
            }
            fr.Show();
        }
    }
}
