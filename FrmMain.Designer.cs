namespace BANKSYSTEMWINDOWSFORMS
{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePassordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depositToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withdrawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frmManageTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listClientToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addClientToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.findClientToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewAccountTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewAccountTypeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listAccountTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePassordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.rolesToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.clientsToolStripMenuItem,
            this.accountToolStripMenuItem,
            this.accountSettingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listUserToolStripMenuItem,
            this.addUserToolStripMenuItem,
            this.changePassordToolStripMenuItem});
            this.usersToolStripMenuItem.Image = global::BANKSYSTEMWINDOWSFORMS.Properties.Resources.Users_2_64;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(71, 23);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // listUserToolStripMenuItem
            // 
            this.listUserToolStripMenuItem.Name = "listUserToolStripMenuItem";
            this.listUserToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.listUserToolStripMenuItem.Text = "List User";
            this.listUserToolStripMenuItem.Click += new System.EventHandler(this.ListUserToolStripMenuItem_Click);
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.addUserToolStripMenuItem.Text = "Update User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.AddUserToolStripMenuItem_Click);
            // 
            // changePassordToolStripMenuItem
            // 
            this.changePassordToolStripMenuItem.Name = "changePassordToolStripMenuItem";
            this.changePassordToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.changePassordToolStripMenuItem.Text = "change passord";
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listRolesToolStripMenuItem,
            this.addRolesToolStripMenuItem});
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.rolesToolStripMenuItem.Text = "Roles";
            // 
            // listRolesToolStripMenuItem
            // 
            this.listRolesToolStripMenuItem.Name = "listRolesToolStripMenuItem";
            this.listRolesToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.listRolesToolStripMenuItem.Text = "List Roles";
            this.listRolesToolStripMenuItem.Click += new System.EventHandler(this.ListRolesToolStripMenuItem_Click);
            // 
            // addRolesToolStripMenuItem
            // 
            this.addRolesToolStripMenuItem.Name = "addRolesToolStripMenuItem";
            this.addRolesToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.addRolesToolStripMenuItem.Text = "Add Roles";
            this.addRolesToolStripMenuItem.Click += new System.EventHandler(this.AddRolesToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.depositToolStripMenuItem,
            this.withdrawToolStripMenuItem,
            this.transferToolStripMenuItem,
            this.frmManageTransactionsToolStripMenuItem});
            this.transactionsToolStripMenuItem.Image = global::BANKSYSTEMWINDOWSFORMS.Properties.Resources.money_transfer;
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(112, 23);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // depositToolStripMenuItem
            // 
            this.depositToolStripMenuItem.Name = "depositToolStripMenuItem";
            this.depositToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.depositToolStripMenuItem.Text = "Deposit";
            this.depositToolStripMenuItem.Click += new System.EventHandler(this.DepositToolStripMenuItem_Click);
            // 
            // withdrawToolStripMenuItem
            // 
            this.withdrawToolStripMenuItem.Name = "withdrawToolStripMenuItem";
            this.withdrawToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.withdrawToolStripMenuItem.Text = "Withdraw";
            this.withdrawToolStripMenuItem.Click += new System.EventHandler(this.WithdrawToolStripMenuItem_Click);
            // 
            // transferToolStripMenuItem
            // 
            this.transferToolStripMenuItem.Name = "transferToolStripMenuItem";
            this.transferToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.transferToolStripMenuItem.Text = "Transfer";
            this.transferToolStripMenuItem.Click += new System.EventHandler(this.TransferToolStripMenuItem_Click);
            // 
            // frmManageTransactionsToolStripMenuItem
            // 
            this.frmManageTransactionsToolStripMenuItem.Name = "frmManageTransactionsToolStripMenuItem";
            this.frmManageTransactionsToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.frmManageTransactionsToolStripMenuItem.Text = "ManageTransactions";
            this.frmManageTransactionsToolStripMenuItem.Click += new System.EventHandler(this.FrmManageTransactionsToolStripMenuItem_Click);
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listClientToolStripMenuItem1,
            this.addClientToolStripMenuItem1,
            this.findClientToolStripMenuItem1});
            this.clientsToolStripMenuItem.Image = global::BANKSYSTEMWINDOWSFORMS.Properties.Resources.People_64;
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(72, 23);
            this.clientsToolStripMenuItem.Text = "Client";
            // 
            // listClientToolStripMenuItem1
            // 
            this.listClientToolStripMenuItem1.Name = "listClientToolStripMenuItem1";
            this.listClientToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.listClientToolStripMenuItem1.Text = "List Client";
            this.listClientToolStripMenuItem1.Click += new System.EventHandler(this.ListClientToolStripMenuItem1_Click);
            // 
            // addClientToolStripMenuItem1
            // 
            this.addClientToolStripMenuItem1.Name = "addClientToolStripMenuItem1";
            this.addClientToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.addClientToolStripMenuItem1.Text = "Add Client";
            this.addClientToolStripMenuItem1.Click += new System.EventHandler(this.AddClientToolStripMenuItem1_Click);
            // 
            // findClientToolStripMenuItem1
            // 
            this.findClientToolStripMenuItem1.Name = "findClientToolStripMenuItem1";
            this.findClientToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.findClientToolStripMenuItem1.Text = "Find client";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewAccountTypeToolStripMenuItem,
            this.addToolStripMenuItem});
            this.accountToolStripMenuItem.Image = global::BANKSYSTEMWINDOWSFORMS.Properties.Resources.compte_bancaire;
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(87, 23);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // addNewAccountTypeToolStripMenuItem
            // 
            this.addNewAccountTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewAccountTypeToolStripMenuItem1,
            this.listAccountTypeToolStripMenuItem});
            this.addNewAccountTypeToolStripMenuItem.Name = "addNewAccountTypeToolStripMenuItem";
            this.addNewAccountTypeToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.addNewAccountTypeToolStripMenuItem.Text = " Account Type";
            // 
            // addNewAccountTypeToolStripMenuItem1
            // 
            this.addNewAccountTypeToolStripMenuItem1.Name = "addNewAccountTypeToolStripMenuItem1";
            this.addNewAccountTypeToolStripMenuItem1.Size = new System.Drawing.Size(220, 24);
            this.addNewAccountTypeToolStripMenuItem1.Text = "Add New Account Type";
            this.addNewAccountTypeToolStripMenuItem1.Click += new System.EventHandler(this.AddNewAccountTypeToolStripMenuItem1_Click);
            // 
            // listAccountTypeToolStripMenuItem
            // 
            this.listAccountTypeToolStripMenuItem.Name = "listAccountTypeToolStripMenuItem";
            this.listAccountTypeToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.listAccountTypeToolStripMenuItem.Text = "List Account Type";
            this.listAccountTypeToolStripMenuItem.Click += new System.EventHandler(this.ListAccountTypeToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem,
            this.listToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.addToolStripMenuItem.Text = " Account";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.addNewToolStripMenuItem.Text = "Add New";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.AddNewToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.listToolStripMenuItem.Text = "List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.ListToolStripMenuItem_Click);
            // 
            // accountSettingToolStripMenuItem
            // 
            this.accountSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePassordToolStripMenuItem1,
            this.signOutToolStripMenuItem});
            this.accountSettingToolStripMenuItem.Image = global::BANKSYSTEMWINDOWSFORMS.Properties.Resources.account_settings_64;
            this.accountSettingToolStripMenuItem.Name = "accountSettingToolStripMenuItem";
            this.accountSettingToolStripMenuItem.Size = new System.Drawing.Size(134, 23);
            this.accountSettingToolStripMenuItem.Text = "Account Setting";
            // 
            // changePassordToolStripMenuItem1
            // 
            this.changePassordToolStripMenuItem1.Name = "changePassordToolStripMenuItem1";
            this.changePassordToolStripMenuItem1.Size = new System.Drawing.Size(187, 24);
            this.changePassordToolStripMenuItem1.Text = "Change Password";
            this.changePassordToolStripMenuItem1.Click += new System.EventHandler(this.ChangePassordToolStripMenuItem1_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.SignOutToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BANKSYSTEMWINDOWSFORMS.Properties.Resources.bank;
            this.pictureBox1.Location = new System.Drawing.Point(104, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 567);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depositToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withdrawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listClientToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addClientToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem findClientToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem changePassordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewAccountTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewAccountTypeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listAccountTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePassordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frmManageTransactionsToolStripMenuItem;
    }
}