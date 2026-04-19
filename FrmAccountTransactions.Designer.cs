namespace BANKSYSTEMWINDOWSFORMS
{
    partial class FrmAccountTransactions
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
            this.dgvtransactionaccount = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtransactionaccount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvtransactionaccount
            // 
            this.dgvtransactionaccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtransactionaccount.Location = new System.Drawing.Point(8, 104);
            this.dgvtransactionaccount.Name = "dgvtransactionaccount";
            this.dgvtransactionaccount.Size = new System.Drawing.Size(816, 352);
            this.dgvtransactionaccount.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Manage Transaction Account";
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(752, 472);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 4;
            this.btnclose.Text = "close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.Btnclose_Click);
            // 
            // FrmAccountTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 501);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvtransactionaccount);
            this.Name = "FrmAccountTransactions";
            this.Text = "FrmAccountTransactions";
            this.Load += new System.EventHandler(this.FrmAccountTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvtransactionaccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvtransactionaccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnclose;
    }
}