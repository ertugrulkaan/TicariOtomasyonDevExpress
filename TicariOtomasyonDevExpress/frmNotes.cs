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
    public partial class frmNotes : Form
    {
        DBCon localdb = new DBCon();
        public RichTextBox textbox1;
        public frmNotes()
        {
            InitializeComponent();
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
        private void frmNotes_Load(object sender, EventArgs e)
        {
            GetNotes();
        }
        void GetNotes()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Execute spGetAllNotes", localdb.DB());
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void InsertNotes()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Insert into Notes (Date,Name,Detail,Creator,Addressed) values (@Date,@Name,@Detail,@Creator,@Addressed)", localdb.DB());
                sql.Parameters.AddWithValue("@Name", txtName.Text);
                sql.Parameters.AddWithValue("@Date", deditDate.EditValue);
                sql.Parameters.AddWithValue("@Detail", txtDetail.Text);
                sql.Parameters.AddWithValue("@Creator", txtCreator.Text);
                sql.Parameters.AddWithValue("@Addressed", txtAddressed.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Not Sisteme Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void DeleteNotes()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Delete from Notes where ID=@ID", localdb.DB());
                sql.Parameters.AddWithValue("@ID", txtID.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Not Sistemden Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void UpdateNotes()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Update Notes set Date=@Date,Name=@Name,Detail=@Detail,Creator=@Creator,Addressed=@Addressed where ID=@ID", localdb.DB());
                sql.Parameters.AddWithValue("@Name", txtName.Text);
                sql.Parameters.AddWithValue("@Date", deditDate.EditValue);
                sql.Parameters.AddWithValue("@Detail", txtDetail.Text);
                sql.Parameters.AddWithValue("@Creator", txtCreator.Text);
                sql.Parameters.AddWithValue("@Addressed", txtAddressed.Text);
                sql.Parameters.AddWithValue("@ID", txtID.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Not Sistemde Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void btnNotesSave_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Notu kaydetmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                InsertNotes();
                GetNotes();
            }
        }
        private void btnNotesDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Notu silmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteNotes();
                GetNotes();
            }
        }
        private void btnNotesUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Notu güncellemek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateNotes();
                GetNotes();
            }
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //TODO: burdaki null olayını heryere ekle tablo boşalırsa hata veriyor.
                //TODO: BU FORMDAKİ GRİDDE DATETİME FORMATINI HER YERE AYNI ŞEKİLDE AYARLA ÖBÜR TÜRLÜ 12SAAT FORMATINDA OLUYOR.
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (dr != null)
                {
                    txtID.Text = dr["ID"].ToString();
                    txtCreator.Text = dr["Creator"].ToString();
                    txtDetail.Text = dr["Detail"].ToString();
                    txtAddressed.Text = dr["Addressed"].ToString();
                    txtName.Text = dr["Name"].ToString();
                    deditDate.Text = dr["Date"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Form fr = new Form(); 
            textbox1 = new RichTextBox();
            textbox1.Size = new Size(285, 260);
            textbox1.Location = new Point(0, 0);
            textbox1.Text = txtDetail.Text = dr["Detail"].ToString();
            fr.Controls.Add(textbox1);
            fr.Size = new Size(300, 300);
            fr.Show();
        }
    }
}
