using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomasyonDevExpress
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void btnProducts_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmProducts fr;
            fr = new frmProducts();
            fr.MdiParent = this;
            fr.Show();

        }
        private void btnCustomers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCustomers fr;
            fr = new frmCustomers();
            fr.MdiParent = this;
            fr.Show();
        }
        private void btnCompanies_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCompanies fr;
            fr = new frmCompanies();
            fr.MdiParent = this;
            fr.Show();
        }
        private void btnEmployees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEmployees fr;
            fr = new frmEmployees();
            fr.MdiParent = this;
            fr.Show();
        }
        private void btnAddresses_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmContacts fr;
            fr = new frmContacts();
            fr.MdiParent = this;
            fr.Show();
        }
        private void btnExpenses_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmExpenses fr;
            fr = new frmExpenses();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnBanks_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBanks fr;
            fr = new frmBanks();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnInvoices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmInvoices fr;
            fr = new frmInvoices();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnNotes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNotes fr;
            fr = new frmNotes();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnActions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmActions fr;
            fr = new frmActions();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnReports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReports fr;
            fr = new frmReports();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnStocks_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmStocks fr;
            fr = new frmStocks();
            fr.MdiParent = this;
            fr.Show();
        }
    }
}
