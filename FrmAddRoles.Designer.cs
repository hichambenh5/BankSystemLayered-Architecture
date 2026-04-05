namespace BANKSYSTEMWINDOWSFORMS
{
    partial class FrmAddRoles
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRolesName = new System.Windows.Forms.TextBox();
            this.txteManageClients = new System.Windows.Forms.TextBox();
            this.txteManageUsers = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txteTransactions = new System.Windows.Forms.TextBox();
            this.txteManageRegisters = new System.Windows.Forms.TextBox();
            this.txteUpdatePermissions = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rdeAll = new System.Windows.Forms.RadioButton();
            this.rdeNone = new System.Windows.Forms.RadioButton();
            this.Roles = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.Roles.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(368, 56);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(109, 25);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "add Roles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "RolesID";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(136, 120);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(31, 13);
            this.lblID.TabIndex = 18;
            this.lblID.Text = "????";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Role name";
            // 
            // txtRolesName
            // 
            this.txtRolesName.Location = new System.Drawing.Point(112, 152);
            this.txtRolesName.Name = "txtRolesName";
            this.txtRolesName.Size = new System.Drawing.Size(100, 20);
            this.txtRolesName.TabIndex = 20;
            // 
            // txteManageClients
            // 
            this.txteManageClients.Location = new System.Drawing.Point(112, 216);
            this.txteManageClients.Name = "txteManageClients";
            this.txteManageClients.Size = new System.Drawing.Size(100, 20);
            this.txteManageClients.TabIndex = 21;
            // 
            // txteManageUsers
            // 
            this.txteManageUsers.Location = new System.Drawing.Point(112, 272);
            this.txteManageUsers.Name = "txteManageUsers";
            this.txteManageUsers.Size = new System.Drawing.Size(100, 20);
            this.txteManageUsers.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "eManageClients";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "eManageUsers";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "eTransactions";
            // 
            // txteTransactions
            // 
            this.txteTransactions.Location = new System.Drawing.Point(112, 344);
            this.txteTransactions.Name = "txteTransactions";
            this.txteTransactions.Size = new System.Drawing.Size(100, 20);
            this.txteTransactions.TabIndex = 26;
            // 
            // txteManageRegisters
            // 
            this.txteManageRegisters.Location = new System.Drawing.Point(472, 288);
            this.txteManageRegisters.Name = "txteManageRegisters";
            this.txteManageRegisters.Size = new System.Drawing.Size(100, 20);
            this.txteManageRegisters.TabIndex = 27;
            // 
            // txteUpdatePermissions
            // 
            this.txteUpdatePermissions.Location = new System.Drawing.Point(472, 344);
            this.txteUpdatePermissions.Name = "txteUpdatePermissions";
            this.txteUpdatePermissions.Size = new System.Drawing.Size(100, 20);
            this.txteUpdatePermissions.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "eManageRegisters";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "eUpdatePermissions";
            // 
            // rdeAll
            // 
            this.rdeAll.AutoSize = true;
            this.rdeAll.Location = new System.Drawing.Point(24, 32);
            this.rdeAll.Name = "rdeAll";
            this.rdeAll.Size = new System.Drawing.Size(42, 17);
            this.rdeAll.TabIndex = 31;
            this.rdeAll.TabStop = true;
            this.rdeAll.Text = "eAll";
            this.rdeAll.UseVisualStyleBackColor = true;
            // 
            // rdeNone
            // 
            this.rdeNone.AutoSize = true;
            this.rdeNone.Location = new System.Drawing.Point(24, 56);
            this.rdeNone.Name = "rdeNone";
            this.rdeNone.Size = new System.Drawing.Size(57, 17);
            this.rdeNone.TabIndex = 32;
            this.rdeNone.TabStop = true;
            this.rdeNone.Text = "eNone";
            this.rdeNone.UseVisualStyleBackColor = true;
            // 
            // Roles
            // 
            this.Roles.Controls.Add(this.rdeAll);
            this.Roles.Controls.Add(this.rdeNone);
            this.Roles.Location = new System.Drawing.Point(360, 144);
            this.Roles.Name = "Roles";
            this.Roles.Size = new System.Drawing.Size(200, 100);
            this.Roles.TabIndex = 33;
            this.Roles.TabStop = false;
            this.Roles.Text = "Roles";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(344, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 40);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // FrmAddRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.Roles);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txteUpdatePermissions);
            this.Controls.Add(this.txteManageRegisters);
            this.Controls.Add(this.txteTransactions);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txteManageUsers);
            this.Controls.Add(this.txteManageClients);
            this.Controls.Add(this.txtRolesName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Name = "FrmAddRoles";
            this.Text = "FrmAddRoles";
            this.Load += new System.EventHandler(this.FrmAddRoles_Load);
            this.Roles.ResumeLayout(false);
            this.Roles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRolesName;
        private System.Windows.Forms.TextBox txteManageClients;
        private System.Windows.Forms.TextBox txteManageUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txteTransactions;
        private System.Windows.Forms.TextBox txteManageRegisters;
        private System.Windows.Forms.TextBox txteUpdatePermissions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdeAll;
        private System.Windows.Forms.RadioButton rdeNone;
        private System.Windows.Forms.GroupBox Roles;
        private System.Windows.Forms.Button btnSave;
    }
}