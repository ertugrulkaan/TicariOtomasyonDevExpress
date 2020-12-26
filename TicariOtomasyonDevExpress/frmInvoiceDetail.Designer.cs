
namespace TicariOtomasyonDevExpress
{
    partial class frmInvoiceDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoiceDetail));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.btnCalc = new DevExpress.XtraEditors.SimpleButton();
            this.txtProductName = new DevExpress.XtraEditors.TextEdit();
            this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
            this.txtUnitPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoiceID = new DevExpress.XtraEditors.TextEdit();
            this.txtProductID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.lblIDHelper = new DevExpress.XtraEditors.LabelControl();
            this.btnInvoiceDetailUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnInvoiceDetailDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnInvoiceDetailSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(975, 524);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "FATURA ID";
            this.gridColumn2.FieldName = "InvoiceID";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ÜRÜN ADI";
            this.gridColumn3.FieldName = "ProductName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "MİKTAR";
            this.gridColumn4.FieldName = "Quantity";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "BİRİM FİYAT";
            this.gridColumn5.FieldName = "UnitPrice";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "TOPLAM FİYAT";
            this.gridColumn6.FieldName = "TotalPrice";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.btnCalc);
            this.groupControl5.Controls.Add(this.txtProductName);
            this.groupControl5.Controls.Add(this.txtQuantity);
            this.groupControl5.Controls.Add(this.txtUnitPrice);
            this.groupControl5.Controls.Add(this.txtTotalPrice);
            this.groupControl5.Controls.Add(this.txtInvoiceID);
            this.groupControl5.Controls.Add(this.txtProductID);
            this.groupControl5.Controls.Add(this.labelControl13);
            this.groupControl5.Controls.Add(this.labelControl14);
            this.groupControl5.Controls.Add(this.labelControl15);
            this.groupControl5.Controls.Add(this.lblIDHelper);
            this.groupControl5.Controls.Add(this.btnInvoiceDetailUpdate);
            this.groupControl5.Controls.Add(this.btnInvoiceDetailDelete);
            this.groupControl5.Controls.Add(this.btnInvoiceDetailSave);
            this.groupControl5.Controls.Add(this.labelControl8);
            this.groupControl5.Controls.Add(this.labelControl11);
            this.groupControl5.Controls.Add(this.labelControl5);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl5.Location = new System.Drawing.Point(984, 0);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.ShowCaption = false;
            this.groupControl5.Size = new System.Drawing.Size(316, 524);
            this.groupControl5.TabIndex = 1;
            this.groupControl5.Text = "groupControl5";
            // 
            // btnCalc
            // 
            this.btnCalc.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCalc.ImageOptions.SvgImage")));
            this.btnCalc.Location = new System.Drawing.Point(119, 159);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(137, 30);
            this.btnCalc.TabIndex = 83;
            this.btnCalc.Text = "Hesapla";
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(120, 47);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtProductName.Properties.Appearance.Options.UseFont = true;
            this.txtProductName.Size = new System.Drawing.Size(136, 26);
            this.txtProductName.TabIndex = 82;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(120, 87);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtQuantity.Properties.Appearance.Options.UseFont = true;
            this.txtQuantity.Size = new System.Drawing.Size(136, 26);
            this.txtQuantity.TabIndex = 81;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(120, 124);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUnitPrice.Properties.Appearance.Options.UseFont = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(136, 26);
            this.txtUnitPrice.TabIndex = 80;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(120, 199);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTotalPrice.Properties.Appearance.Options.UseFont = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(136, 26);
            this.txtTotalPrice.TabIndex = 79;
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.Location = new System.Drawing.Point(120, 238);
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtInvoiceID.Properties.Appearance.Options.UseFont = true;
            this.txtInvoiceID.Size = new System.Drawing.Size(136, 26);
            this.txtInvoiceID.TabIndex = 78;
            this.txtInvoiceID.Visible = false;
            // 
            // txtProductID
            // 
            this.txtProductID.Enabled = false;
            this.txtProductID.Location = new System.Drawing.Point(120, 12);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtProductID.Properties.Appearance.Options.UseFont = true;
            this.txtProductID.Size = new System.Drawing.Size(136, 26);
            this.txtProductID.TabIndex = 77;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(22, 202);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(92, 20);
            this.labelControl13.TabIndex = 74;
            this.labelControl13.Text = "Toplam Tutar:";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Location = new System.Drawing.Point(58, 15);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(53, 20);
            this.labelControl14.TabIndex = 76;
            this.labelControl14.Text = "Ürün ID:";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(38, 127);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(73, 20);
            this.labelControl15.TabIndex = 75;
            this.labelControl15.Text = "Birim Fiyat:";
            // 
            // lblIDHelper
            // 
            this.lblIDHelper.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIDHelper.Appearance.Options.UseFont = true;
            this.lblIDHelper.Location = new System.Drawing.Point(66, 399);
            this.lblIDHelper.Name = "lblIDHelper";
            this.lblIDHelper.Size = new System.Drawing.Size(0, 20);
            this.lblIDHelper.TabIndex = 40;
            this.lblIDHelper.Visible = false;
            // 
            // btnInvoiceDetailUpdate
            // 
            this.btnInvoiceDetailUpdate.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnInvoiceDetailUpdate.Appearance.Options.UseFont = true;
            this.btnInvoiceDetailUpdate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnInvoiceDetailUpdate.ImageOptions.SvgImage")));
            this.btnInvoiceDetailUpdate.Location = new System.Drawing.Point(109, 444);
            this.btnInvoiceDetailUpdate.Name = "btnInvoiceDetailUpdate";
            this.btnInvoiceDetailUpdate.Size = new System.Drawing.Size(105, 39);
            this.btnInvoiceDetailUpdate.TabIndex = 73;
            this.btnInvoiceDetailUpdate.Text = "Güncelle";
            this.btnInvoiceDetailUpdate.Click += new System.EventHandler(this.btnInvoiceDetailUpdate_Click);
            // 
            // btnInvoiceDetailDelete
            // 
            this.btnInvoiceDetailDelete.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnInvoiceDetailDelete.Appearance.Options.UseFont = true;
            this.btnInvoiceDetailDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnInvoiceDetailDelete.ImageOptions.SvgImage")));
            this.btnInvoiceDetailDelete.Location = new System.Drawing.Point(173, 399);
            this.btnInvoiceDetailDelete.Name = "btnInvoiceDetailDelete";
            this.btnInvoiceDetailDelete.Size = new System.Drawing.Size(105, 39);
            this.btnInvoiceDetailDelete.TabIndex = 72;
            this.btnInvoiceDetailDelete.Text = "Sil";
            this.btnInvoiceDetailDelete.Click += new System.EventHandler(this.btnInvoiceDetailDelete_Click);
            // 
            // btnInvoiceDetailSave
            // 
            this.btnInvoiceDetailSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnInvoiceDetailSave.Appearance.Options.UseFont = true;
            this.btnInvoiceDetailSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnInvoiceDetailSave.ImageOptions.SvgImage")));
            this.btnInvoiceDetailSave.Location = new System.Drawing.Point(41, 399);
            this.btnInvoiceDetailSave.Name = "btnInvoiceDetailSave";
            this.btnInvoiceDetailSave.Size = new System.Drawing.Size(105, 39);
            this.btnInvoiceDetailSave.TabIndex = 71;
            this.btnInvoiceDetailSave.Text = "Kaydet";
            this.btnInvoiceDetailSave.Click += new System.EventHandler(this.btnInvoiceDetailSave_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(54, 50);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(57, 20);
            this.labelControl8.TabIndex = 54;
            this.labelControl8.Text = "Ürün Ad:";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(66, 90);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(45, 20);
            this.labelControl11.TabIndex = 67;
            this.labelControl11.Text = "Miktar:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(51, 241);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(63, 20);
            this.labelControl5.TabIndex = 66;
            this.labelControl5.Text = "Fatura ID:";
            this.labelControl5.Visible = false;
            // 
            // frmInvoiceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 524);
            this.Controls.Add(this.groupControl5);
            this.Controls.Add(this.gridControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1316, 563);
            this.Name = "frmInvoiceDetail";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fatura Detayı";
            this.Load += new System.EventHandler(this.frmInvoiceDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.SimpleButton btnCalc;
        private DevExpress.XtraEditors.TextEdit txtProductName;
        private DevExpress.XtraEditors.TextEdit txtQuantity;
        private DevExpress.XtraEditors.TextEdit txtUnitPrice;
        private DevExpress.XtraEditors.TextEdit txtTotalPrice;
        private DevExpress.XtraEditors.TextEdit txtInvoiceID;
        private DevExpress.XtraEditors.TextEdit txtProductID;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl lblIDHelper;
        private DevExpress.XtraEditors.SimpleButton btnInvoiceDetailUpdate;
        private DevExpress.XtraEditors.SimpleButton btnInvoiceDetailDelete;
        private DevExpress.XtraEditors.SimpleButton btnInvoiceDetailSave;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}