namespace SalesWinApp
{
    partial class frmMembers
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
            this.dgv_members = new System.Windows.Forms.DataGridView();
            this.tbx_UserId = new System.Windows.Forms.TextBox();
            this.tbx_CompanyName = new System.Windows.Forms.TextBox();
            this.tbx_Email = new System.Windows.Forms.TextBox();
            this.tbx_City = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_Country = new System.Windows.Forms.TextBox();
            this.mtbx_Password = new System.Windows.Forms.MaskedTextBox();
            this.mtbx_RepeatPassword = new System.Windows.Forms.MaskedTextBox();
            this.lbl_PasswordTip = new System.Windows.Forms.Label();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_GoBack = new System.Windows.Forms.Button();
            this.tbx_search = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_members)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_members
            // 
            this.dgv_members.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_members.Location = new System.Drawing.Point(14, 260);
            this.dgv_members.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_members.Name = "dgv_members";
            this.dgv_members.RowHeadersWidth = 51;
            this.dgv_members.RowTemplate.Height = 25;
            this.dgv_members.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_members.Size = new System.Drawing.Size(646, 301);
            this.dgv_members.TabIndex = 0;
            this.dgv_members.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tbx_UserId
            // 
            this.tbx_UserId.Location = new System.Drawing.Point(135, 17);
            this.tbx_UserId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_UserId.Name = "tbx_UserId";
            this.tbx_UserId.Size = new System.Drawing.Size(196, 27);
            this.tbx_UserId.TabIndex = 1;
            // 
            // tbx_CompanyName
            // 
            this.tbx_CompanyName.Location = new System.Drawing.Point(135, 95);
            this.tbx_CompanyName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_CompanyName.Name = "tbx_CompanyName";
            this.tbx_CompanyName.Size = new System.Drawing.Size(196, 27);
            this.tbx_CompanyName.TabIndex = 3;
            // 
            // tbx_Email
            // 
            this.tbx_Email.Location = new System.Drawing.Point(135, 56);
            this.tbx_Email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_Email.Name = "tbx_Email";
            this.tbx_Email.Size = new System.Drawing.Size(196, 27);
            this.tbx_Email.TabIndex = 4;
            // 
            // tbx_City
            // 
            this.tbx_City.Location = new System.Drawing.Point(135, 133);
            this.tbx_City.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_City.Name = "tbx_City";
            this.tbx_City.Size = new System.Drawing.Size(196, 27);
            this.tbx_City.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "User Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "User Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Company Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "City";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Country";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "New Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(346, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Repeat Password";
            // 
            // tbx_Country
            // 
            this.tbx_Country.Location = new System.Drawing.Point(463, 17);
            this.tbx_Country.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_Country.Name = "tbx_Country";
            this.tbx_Country.Size = new System.Drawing.Size(196, 27);
            this.tbx_Country.TabIndex = 14;
            // 
            // mtbx_Password
            // 
            this.mtbx_Password.Location = new System.Drawing.Point(463, 95);
            this.mtbx_Password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtbx_Password.Name = "mtbx_Password";
            this.mtbx_Password.PasswordChar = '*';
            this.mtbx_Password.Size = new System.Drawing.Size(196, 27);
            this.mtbx_Password.TabIndex = 15;
            // 
            // mtbx_RepeatPassword
            // 
            this.mtbx_RepeatPassword.Location = new System.Drawing.Point(463, 133);
            this.mtbx_RepeatPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtbx_RepeatPassword.Name = "mtbx_RepeatPassword";
            this.mtbx_RepeatPassword.PasswordChar = '*';
            this.mtbx_RepeatPassword.Size = new System.Drawing.Size(196, 27);
            this.mtbx_RepeatPassword.TabIndex = 16;
            // 
            // lbl_PasswordTip
            // 
            this.lbl_PasswordTip.AutoSize = true;
            this.lbl_PasswordTip.Location = new System.Drawing.Point(413, 60);
            this.lbl_PasswordTip.Name = "lbl_PasswordTip";
            this.lbl_PasswordTip.Size = new System.Drawing.Size(270, 20);
            this.lbl_PasswordTip.TabIndex = 17;
            this.lbl_PasswordTip.Text = "(Leave empty for unchanged password)";
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(218, 173);
            this.btn_New.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(113, 31);
            this.btn_New.TabIndex = 18;
            this.btn_New.Text = "New Member";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(439, 173);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(86, 31);
            this.btn_Update.TabIndex = 19;
            this.btn_Update.Text = "Update...";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(561, 172);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(86, 31);
            this.btn_Delete.TabIndex = 20;
            this.btn_Delete.Text = "Delete...";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_GoBack
            // 
            this.btn_GoBack.Location = new System.Drawing.Point(21, 173);
            this.btn_GoBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_GoBack.Name = "btn_GoBack";
            this.btn_GoBack.Size = new System.Drawing.Size(86, 31);
            this.btn_GoBack.TabIndex = 21;
            this.btn_GoBack.Text = "Go back";
            this.btn_GoBack.UseVisualStyleBackColor = true;
            this.btn_GoBack.Click += new System.EventHandler(this.btn_GoBack_Click);
            // 
            // tbx_search
            // 
            this.tbx_search.Location = new System.Drawing.Point(14, 221);
            this.tbx_search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_search.Name = "tbx_search";
            this.tbx_search.Size = new System.Drawing.Size(402, 27);
            this.tbx_search.TabIndex = 22;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(423, 221);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(86, 31);
            this.btn_Search.TabIndex = 23;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // frmMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(675, 571);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.tbx_search);
            this.Controls.Add(this.btn_GoBack);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.lbl_PasswordTip);
            this.Controls.Add(this.mtbx_RepeatPassword);
            this.Controls.Add(this.mtbx_Password);
            this.Controls.Add(this.tbx_Country);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_City);
            this.Controls.Add(this.tbx_Email);
            this.Controls.Add(this.tbx_CompanyName);
            this.Controls.Add(this.tbx_UserId);
            this.Controls.Add(this.dgv_members);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMembers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMembers";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_members)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgv_members;
        private TextBox tbx_UserId;
        private TextBox tbx_CompanyName;
        private TextBox tbx_Email;
        private TextBox tbx_City;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox tbx_Country;
        private MaskedTextBox mtbx_Password;
        private MaskedTextBox mtbx_RepeatPassword;
        private Label lbl_PasswordTip;
        private Button btn_New;
        private Button btn_Update;
        private Button btn_Delete;
        private Button btn_GoBack;
        private TextBox tbx_search;
        private Button btn_Search;
    }
}