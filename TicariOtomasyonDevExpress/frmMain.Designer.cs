
namespace TicariOtomasyonDevExpress
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraBars.BarButtonItem btnProducts;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl2 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnHome = new DevExpress.XtraBars.BarButtonItem();
            this.btnStocks = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomers = new DevExpress.XtraBars.BarButtonItem();
            this.btnCompanies = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmployees = new DevExpress.XtraBars.BarButtonItem();
            this.btnExpenses = new DevExpress.XtraBars.BarButtonItem();
            this.btnCase = new DevExpress.XtraBars.BarButtonItem();
            this.btnNotes = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddresses = new DevExpress.XtraBars.BarButtonItem();
            this.btnInvoices = new DevExpress.XtraBars.BarButtonItem();
            this.btnSettings = new DevExpress.XtraBars.BarButtonItem();
            this.skinPaletteRibbonGalleryBarItem2 = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            this.btnBanks = new DevExpress.XtraBars.BarButtonItem();
            this.btnActions = new DevExpress.XtraBars.BarButtonItem();
            this.btnReports = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            btnProducts = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProducts
            // 
            btnProducts.Caption = "ÜRÜNLER";
            btnProducts.Id = 2;
            btnProducts.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProducts.ImageOptions.Image")));
            btnProducts.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProducts.ImageOptions.LargeImage")));
            btnProducts.Name = "btnProducts";
            btnProducts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProducts_ItemClick);
            // 
            // ribbonControl2
            // 
            this.ribbonControl2.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.DarkBlue;
            this.ribbonControl2.ExpandCollapseItem.Id = 0;
            this.ribbonControl2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl2.ExpandCollapseItem,
            this.ribbonControl2.SearchEditItem,
            this.btnHome,
            btnProducts,
            this.btnStocks,
            this.btnCustomers,
            this.btnCompanies,
            this.btnEmployees,
            this.btnExpenses,
            this.btnCase,
            this.btnNotes,
            this.btnAddresses,
            this.btnInvoices,
            this.btnSettings,
            this.skinPaletteRibbonGalleryBarItem2,
            this.btnBanks,
            this.btnActions,
            this.btnReports});
            this.ribbonControl2.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl2.MaxItemId = 17;
            this.ribbonControl2.Name = "ribbonControl2";
            this.ribbonControl2.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonControl2.Size = new System.Drawing.Size(1904, 186);
            // 
            // btnHome
            // 
            this.btnHome.Caption = "ANA SAYFA";
            this.btnHome.Id = 1;
            this.btnHome.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.ImageOptions.Image")));
            this.btnHome.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHome.ImageOptions.LargeImage")));
            this.btnHome.Name = "btnHome";
            // 
            // btnStocks
            // 
            this.btnStocks.Caption = "STOKLAR";
            this.btnStocks.Id = 3;
            this.btnStocks.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStocks.ImageOptions.Image")));
            this.btnStocks.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnStocks.ImageOptions.LargeImage")));
            this.btnStocks.Name = "btnStocks";
            // 
            // btnCustomers
            // 
            this.btnCustomers.Caption = "MÜŞTERİLER";
            this.btnCustomers.Id = 4;
            this.btnCustomers.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomers.ImageOptions.Image")));
            this.btnCustomers.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCustomers.ImageOptions.LargeImage")));
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomers_ItemClick);
            // 
            // btnCompanies
            // 
            this.btnCompanies.Caption = "FİRMALAR";
            this.btnCompanies.Id = 5;
            this.btnCompanies.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCompanies.ImageOptions.SvgImage")));
            this.btnCompanies.Name = "btnCompanies";
            this.btnCompanies.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCompanies_ItemClick);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Caption = "PERSONELLER";
            this.btnEmployees.Id = 6;
            this.btnEmployees.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployees.ImageOptions.Image")));
            this.btnEmployees.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEmployees.ImageOptions.LargeImage")));
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployees_ItemClick);
            // 
            // btnExpenses
            // 
            this.btnExpenses.Caption = "GİDERLER";
            this.btnExpenses.Id = 7;
            this.btnExpenses.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExpenses.ImageOptions.Image")));
            this.btnExpenses.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExpenses.ImageOptions.LargeImage")));
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExpenses_ItemClick);
            // 
            // btnCase
            // 
            this.btnCase.Caption = "KASA";
            this.btnCase.Id = 8;
            this.btnCase.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCase.ImageOptions.SvgImage")));
            this.btnCase.Name = "btnCase";
            // 
            // btnNotes
            // 
            this.btnNotes.Caption = "NOTLAR";
            this.btnNotes.Id = 9;
            this.btnNotes.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNotes.ImageOptions.Image")));
            this.btnNotes.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNotes.ImageOptions.LargeImage")));
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNotes_ItemClick);
            // 
            // btnAddresses
            // 
            this.btnAddresses.Caption = "REHBER";
            this.btnAddresses.Id = 10;
            this.btnAddresses.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddresses.ImageOptions.Image")));
            this.btnAddresses.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAddresses.ImageOptions.LargeImage")));
            this.btnAddresses.Name = "btnAddresses";
            this.btnAddresses.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddresses_ItemClick);
            // 
            // btnInvoices
            // 
            this.btnInvoices.Caption = "FATURALAR";
            this.btnInvoices.Id = 11;
            this.btnInvoices.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInvoices.ImageOptions.Image")));
            this.btnInvoices.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnInvoices.ImageOptions.LargeImage")));
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInvoices_ItemClick);
            // 
            // btnSettings
            // 
            this.btnSettings.Caption = "AYARLAR";
            this.btnSettings.Id = 12;
            this.btnSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.ImageOptions.Image")));
            this.btnSettings.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSettings.ImageOptions.LargeImage")));
            this.btnSettings.Name = "btnSettings";
            // 
            // skinPaletteRibbonGalleryBarItem2
            // 
            this.skinPaletteRibbonGalleryBarItem2.Caption = "skinPaletteRibbonGalleryBarItem2";
            this.skinPaletteRibbonGalleryBarItem2.Id = 13;
            this.skinPaletteRibbonGalleryBarItem2.Name = "skinPaletteRibbonGalleryBarItem2";
            // 
            // btnBanks
            // 
            this.btnBanks.Caption = "BANKALAR";
            this.btnBanks.Id = 14;
            this.btnBanks.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBanks.ImageOptions.Image")));
            this.btnBanks.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBanks.ImageOptions.LargeImage")));
            this.btnBanks.Name = "btnBanks";
            this.btnBanks.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBanks_ItemClick);
            // 
            // btnActions
            // 
            this.btnActions.Caption = "HAREKETLER";
            this.btnActions.Id = 15;
            this.btnActions.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActions.ImageOptions.Image")));
            this.btnActions.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnActions.ImageOptions.LargeImage")));
            this.btnActions.Name = "btnActions";
            this.btnActions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActions_ItemClick);
            // 
            // btnReports
            // 
            this.btnReports.Caption = "RAPORLAR";
            this.btnReports.Id = 16;
            this.btnReports.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.ImageOptions.Image")));
            this.btnReports.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnReports.ImageOptions.LargeImage")));
            this.btnReports.Name = "btnReports";
            this.btnReports.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReports_ItemClick);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "TİCARİ OTOMASYON";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnHome);
            this.ribbonPageGroup1.ItemLinks.Add(btnProducts);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnStocks);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCustomers);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCompanies);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEmployees);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExpenses);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCase);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNotes);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnBanks);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAddresses);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnInvoices);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnActions);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnReports);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSettings);
            this.ribbonPageGroup1.ItemLinks.Add(this.skinPaletteRibbonGalleryBarItem2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.ribbonControl2);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl2;
        private DevExpress.XtraBars.BarButtonItem btnHome;
        private DevExpress.XtraBars.BarButtonItem btnStocks;
        private DevExpress.XtraBars.BarButtonItem btnCustomers;
        private DevExpress.XtraBars.BarButtonItem btnCompanies;
        private DevExpress.XtraBars.BarButtonItem btnEmployees;
        private DevExpress.XtraBars.BarButtonItem btnExpenses;
        private DevExpress.XtraBars.BarButtonItem btnCase;
        private DevExpress.XtraBars.BarButtonItem btnNotes;
        private DevExpress.XtraBars.BarButtonItem btnAddresses;
        private DevExpress.XtraBars.BarButtonItem btnInvoices;
        private DevExpress.XtraBars.BarButtonItem btnSettings;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem btnBanks;
        private DevExpress.XtraBars.BarButtonItem btnActions;
        private DevExpress.XtraBars.BarButtonItem btnReports;
    }
}