namespace BANKSYSTEMWINDOWSFORMS
{
    partial class FrmAddEditAccountType
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAccounttypeID = new System.Windows.Forms.Label();
            this.txtNameType = new System.Windows.Forms.TextBox();
            this.nmMinimumbalance = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinimumbalance)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "accounttypeid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "TypeName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "MinimumBalance";
            // 
            // lblAccounttypeID
            // 
            this.lblAccounttypeID.AutoSize = true;
            this.lblAccounttypeID.Location = new System.Drawing.Point(120, 64);
            this.lblAccounttypeID.Name = "lblAccounttypeID";
            this.lblAccounttypeID.Size = new System.Drawing.Size(25, 13);
            this.lblAccounttypeID.TabIndex = 3;
            this.lblAccounttypeID.Text = "???";
            // 
            // txtNameType
            // 
            this.txtNameType.Location = new System.Drawing.Point(120, 104);
            this.txtNameType.Name = "txtNameType";
            this.txtNameType.Size = new System.Drawing.Size(100, 20);
            this.txtNameType.TabIndex = 4;
            // 
            // nmMinimumbalance
            // 
            this.nmMinimumbalance.Location = new System.Drawing.Point(120, 152);
            this.nmMinimumbalance.Name = "nmMinimumbalance";
            this.nmMinimumbalance.Size = new System.Drawing.Size(120, 20);
            this.nmMinimumbalance.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(184, 264);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 39);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(64, 264);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 39);
            this.btnclose.TabIndex = 7;
            this.btnclose.Text = "close";
            this.btnclose.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(128, 32);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(118, 13);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Add New AccountType";
            // 
            // FrmAddEditAccountType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 384);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.nmMinimumbalance);
            this.Controls.Add(this.txtNameType);
            this.Controls.Add(this.lblAccounttypeID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmAddEditAccountType";
            this.Text = "FrmAddEditAccountType";
            this.Load += new System.EventHandler(this.FrmAddEditAccountType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmMinimumbalance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAccounttypeID;
        private System.Windows.Forms.TextBox txtNameType;
        private System.Windows.Forms.NumericUpDown nmMinimumbalance;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label lblTitle;
    }
}