
namespace TicariOtomasyonDevExpress
{
    partial class frmMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMail));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMailAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtMailSubject = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMailMessage = new System.Windows.Forms.RichTextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnSendMail = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailSubject.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 164);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 21);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mail Adresi:";
            // 
            // txtMailAddress
            // 
            this.txtMailAddress.Location = new System.Drawing.Point(111, 161);
            this.txtMailAddress.Name = "txtMailAddress";
            this.txtMailAddress.Size = new System.Drawing.Size(255, 28);
            this.txtMailAddress.TabIndex = 1;
            // 
            // txtMailSubject
            // 
            this.txtMailSubject.Location = new System.Drawing.Point(111, 195);
            this.txtMailSubject.Name = "txtMailSubject";
            this.txtMailSubject.Size = new System.Drawing.Size(255, 28);
            this.txtMailSubject.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(66, 196);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 21);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Konu:";
            // 
            // txtMailMessage
            // 
            this.txtMailMessage.Location = new System.Drawing.Point(111, 229);
            this.txtMailMessage.Name = "txtMailMessage";
            this.txtMailMessage.Size = new System.Drawing.Size(255, 265);
            this.txtMailMessage.TabIndex = 5;
            this.txtMailMessage.Text = "";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(62, 229);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(43, 21);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Detay:";
            // 
            // btnSendMail
            // 
            this.btnSendMail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnSendMail.Location = new System.Drawing.Point(146, 501);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(188, 33);
            this.btnSendMail.TabIndex = 7;
            this.btnSendMail.Text = "Gönder";
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 144);
            this.panel1.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(48, 88);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(328, 37);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "MAİL GÖNDERME PANELİ";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(12, 549);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(379, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "*** Genel Ayarlardan smtp mail adresi ve şifre bölümünü doldurmadığınız ";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(12, 568);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(150, 13);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "sürece mail gönderemezsiniz.";
            // 
            // frmMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 595);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtMailMessage);
            this.Controls.Add(this.txtMailSubject);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtMailAddress);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mail";
            this.Load += new System.EventHandler(this.frmMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMailAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailSubject.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMailAddress;
        private DevExpress.XtraEditors.TextEdit txtMailSubject;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.RichTextBox txtMailMessage;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnSendMail;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}