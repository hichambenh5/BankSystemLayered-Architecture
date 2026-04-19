namespace BANKSYSTEMWINDOWSFORMS
{
    partial class FrmDeposit
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnnext = new System.Windows.Forms.Button();
            this.ctrlAccountCardWithFilter1 = new BANKSYSTEMWINDOWSFORMS.ctrlAccountCardWithFilter();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nmAmount = new System.Windows.Forms.NumericUpDown();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(824, 648);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnnext);
            this.tabPage1.Controls.Add(this.ctrlAccountCardWithFilter1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(816, 622);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnnext
            // 
            this.btnnext.Location = new System.Drawing.Point(648, 376);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 39);
            this.btnnext.TabIndex = 23;
            this.btnnext.Text = "Next";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.Btnnext_Click);
            // 
            // ctrlAccountCardWithFilter1
            // 
            this.ctrlAccountCardWithFilter1.FilterEnabled = true;
            this.ctrlAccountCardWithFilter1.Location = new System.Drawing.Point(8, 8);
            this.ctrlAccountCardWithFilter1.Name = "ctrlAccountCardWithFilter1";
            this.ctrlAccountCardWithFilter1.Size = new System.Drawing.Size(736, 567);
            this.ctrlAccountCardWithFilter1.TabIndex = 0;
            this.ctrlAccountCardWithFilter1.OnAccountSelected += new System.Action<int>(this.CtrlAccountCardWithFilter1_OnAccountSelected);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnBack);
            this.tabPage2.Controls.Add(this.btnclose);
            this.tabPage2.Controls.Add(this.btnsave);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.nmAmount);
            this.tabPage2.Controls.Add(this.lblTitle);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(816, 622);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.TabPage2_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(352, 264);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(184, 256);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 5;
            this.btnclose.Text = "close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.Btnclose_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(40, 256);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 4;
            this.btnsave.Text = "save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.Btnsave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Amount";
            // 
            // nmAmount
            // 
            this.nmAmount.Location = new System.Drawing.Point(88, 152);
            this.nmAmount.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.nmAmount.Name = "nmAmount";
            this.nmAmount.Size = new System.Drawing.Size(120, 20);
            this.nmAmount.TabIndex = 2;
            this.nmAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(344, 48);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(92, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Deposit";
            // 
            // FrmDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 674);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmDeposit";
            this.Text = "FrmDeposit";
            this.Load += new System.EventHandler(this.FrmDeposit_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ctrlAccountCardWithFilter ctrlAccountCardWithFilter1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nmAmount;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnBack;
    }
}