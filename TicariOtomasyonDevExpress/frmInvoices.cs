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
    public partial class frmInvoices : Form
    {
        //TODO: ŞUANA KADAR YAPILAN TÜM ZAMAN ETİKETLERİ SAAT DK VERMİYOR ONLARI DÜZELT. TÜM TABLOLARI READ ONLY YAP. TÜM SORGULARI SP İLE DÖNDÜR. DAL OLSUN İÇİNDEN DÖNSÜN.
        //burdaki datedit1 i kullanabilirsin.1
        //TODO: SİLME İŞLEMLERİ DATAGRİDDEN SAĞ TIKLANARAK YAPILSIN.

        DBCon localdb = new DBCon();
        public frmInvoices()
        {
            InitializeComponent();
        }
        void GetInvoices(bool IsActive)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Execute spGetInvoiceInfos @IsActive=@p1", localdb.DB());
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
        private void frmInvoices_Load(object sender, EventArgs e)
        {
            GetInvoices(true);
            GetInvoices(false);
        }
        void InsertInvoiceInfo()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Insert into InvoiceInfo (Series,InvoiceNumber,Date,TaxAddress,CustomerName,Sender,Receiver) values (@Series,@InvoiceNumber,@Date,@TaxAddress,@CustomerName,@Sender,@Receiver)", localdb.DB());
                sql.Parameters.AddWithValue("@Series", txtSeries.Text);
                sql.Parameters.AddWithValue("@InvoiceNumber", txtInvoiceNum.Text);
                sql.Parameters.AddWithValue("@Date", dateEdit1.EditValue);
                sql.Parameters.AddWithValue("@TaxAddress", txtTaxAddress.Text);
                sql.Parameters.AddWithValue("@CustomerName", txtCustomer.Text);
                sql.Parameters.AddWithValue("@Sender", txtSender.Text);
                sql.Parameters.AddWithValue("@Receiver", txtReceiver.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Fatura Sisteme Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void DeleteInvoiceInfo()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Update InvoiceInfo set IsActive=0,UpdateDate=@UpdateDate where ID=@ID", localdb.DB());
                sql.Parameters.AddWithValue("@ID", txtID.Text);
                sql.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Fatura Sistemden Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void UpdateInvoiceInfo()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Update InvoiceInfo set Series=@Series,InvoiceNumber=@InvoiceNumber,UpdateDate=@UpdateDate,TaxAddress=@TaxAddress,CustomerName=@CustomerName,Sender=@Sender,Receiver=@Receiver where ID=@ID", localdb.DB());
                sql.Parameters.AddWithValue("@Series", txtSeries.Text);
                sql.Parameters.AddWithValue("@InvoiceNumber", txtInvoiceNum.Text);
                sql.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                sql.Parameters.AddWithValue("@TaxAddress", txtTaxAddress.Text);
                sql.Parameters.AddWithValue("@CustomerName", txtCustomer.Text);
                sql.Parameters.AddWithValue("@Sender", txtSender.Text);
                sql.Parameters.AddWithValue("@Receiver", txtReceiver.Text);
                sql.Parameters.AddWithValue("@ID", txtID.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Fatura Sistemde Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }        
        private void btnInvoiceSave_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Faturayı kaydetmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                InsertInvoiceInfo();
                GetInvoices(true);
            }
        }
        private void btnInvoiceDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Faturayı silmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteInvoiceInfo();
                GetInvoices(true);
                GetInvoices(false);
            }
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                txtID.Text = dr["ID"].ToString();
                txtSeries.Text = dr["Series"].ToString();
                txtInvoiceNum.Text = dr["InvoiceNumber"].ToString();
                dateEdit1.Text = dr["Date"].ToString();
                txtTaxAddress.Text = dr["TaxAddress"].ToString();
                txtCustomer.Text = dr["CustomerName"].ToString();
                txtSender.Text = dr["Sender"].ToString();
                txtReceiver.Text = dr["Receiver"].ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnInvoiceUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Faturayı güncellemek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateInvoiceInfo();
                GetInvoices(true);
                GetInvoices(false);
            }
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            frmInvoiceDetail fr = new frmInvoiceDetail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.id = txtID.Text;
                fr.Show();
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
        }
    }
}
