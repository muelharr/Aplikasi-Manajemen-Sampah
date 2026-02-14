namespace Aplikasi_Manajemen_Sampah.Forms
{
    partial class DashboardAdmin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnChatbot = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnPenjemputan = new System.Windows.Forms.Button();
            this.btnSampah = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblTitleSidebar = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelUserInfo = new System.Windows.Forms.Panel();
            this.btnLogoutHeader = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.picUserIcon = new System.Windows.Forms.PictureBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSidebar (TANPA btnLogout)
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            this.panelSidebar.Controls.Add(this.btnChatbot);
            this.panelSidebar.Controls.Add(this.btnCetak);
            this.panelSidebar.Controls.Add(this.btnUsers);
            this.panelSidebar.Controls.Add(this.btnPenjemputan);
            this.panelSidebar.Controls.Add(this.btnSampah);
            this.panelSidebar.Controls.Add(this.panelLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(240, 673);
            this.panelSidebar.TabIndex = 0;

            // 
            // btnChatbot
            // 
            this.btnChatbot.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChatbot.FlatAppearance.BorderSize = 0;
            this.btnChatbot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChatbot.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnChatbot.ForeColor = System.Drawing.Color.White;
            this.btnChatbot.Location = new System.Drawing.Point(0, 300);
            this.btnChatbot.Name = "btnChatbot";
            this.btnChatbot.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnChatbot.Size = new System.Drawing.Size(240, 50);
            this.btnChatbot.TabIndex = 6;
            this.btnChatbot.Text = "🤖 Asisten AI";
            this.btnChatbot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChatbot.UseVisualStyleBackColor = true;

            // 
            // btnCetak
            // 
            this.btnCetak.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCetak.FlatAppearance.BorderSize = 0;
            this.btnCetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCetak.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCetak.ForeColor = System.Drawing.Color.White;
            this.btnCetak.Location = new System.Drawing.Point(0, 250);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnCetak.Size = new System.Drawing.Size(240, 50);
            this.btnCetak.TabIndex = 5;
            this.btnCetak.Text = "📄 Cetak Laporan";
            this.btnCetak.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCetak.UseVisualStyleBackColor = true;
            // 
            // btnUsers
            // 
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Location = new System.Drawing.Point(0, 200);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnUsers.Size = new System.Drawing.Size(240, 50);
            this.btnUsers.TabIndex = 4;
            this.btnUsers.Text = "👥 Kelola User";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.UseVisualStyleBackColor = true;
            // 
            // btnPenjemputan
            // 
            this.btnPenjemputan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPenjemputan.FlatAppearance.BorderSize = 0;
            this.btnPenjemputan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPenjemputan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPenjemputan.ForeColor = System.Drawing.Color.White;
            this.btnPenjemputan.Location = new System.Drawing.Point(0, 150);
            this.btnPenjemputan.Name = "btnPenjemputan";
            this.btnPenjemputan.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnPenjemputan.Size = new System.Drawing.Size(240, 50);
            this.btnPenjemputan.TabIndex = 3;
            this.btnPenjemputan.Text = "🚛 Jadwal Penjemputan";
            this.btnPenjemputan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPenjemputan.UseVisualStyleBackColor = true;
            // 
            // btnSampah
            // 
            this.btnSampah.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSampah.FlatAppearance.BorderSize = 0;
            this.btnSampah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSampah.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSampah.ForeColor = System.Drawing.Color.White;
            this.btnSampah.Location = new System.Drawing.Point(0, 100);
            this.btnSampah.Name = "btnSampah";
            this.btnSampah.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSampah.Size = new System.Drawing.Size(240, 50);
            this.btnSampah.TabIndex = 2;
            this.btnSampah.Text = "📦 Data Sampah";
            this.btnSampah.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSampah.UseVisualStyleBackColor = true;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.lblTitleSidebar);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(240, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // lblTitleSidebar
            // 
            this.lblTitleSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleSidebar.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitleSidebar.ForeColor = System.Drawing.Color.White;
            this.lblTitleSidebar.Location = new System.Drawing.Point(0, 0);
            this.lblTitleSidebar.Name = "lblTitleSidebar";
            this.lblTitleSidebar.Size = new System.Drawing.Size(240, 100);
            this.lblTitleSidebar.TabIndex = 0;
            this.lblTitleSidebar.Text = "BANK SAMPAH";
            this.lblTitleSidebar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHeader (Dengan user info di kanan)
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.panelUserInfo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(240, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(922, 60);
            this.panelHeader.TabIndex = 1;
            // 
            // panelUserInfo (Panel untuk user info + logout di kanan)
            // 
            this.panelUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUserInfo.Controls.Add(this.btnLogoutHeader);
            this.panelUserInfo.Controls.Add(this.lblRole);
            this.panelUserInfo.Controls.Add(this.lblWelcome);
            this.panelUserInfo.Controls.Add(this.picUserIcon);
            this.panelUserInfo.Location = new System.Drawing.Point(550, 5);
            this.panelUserInfo.Name = "panelUserInfo";
            this.panelUserInfo.Size = new System.Drawing.Size(360, 50);
            this.panelUserInfo.TabIndex = 0;
            // 
            // btnLogoutHeader (Tombol logout di pojok kanan)
            // 
            this.btnLogoutHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogoutHeader.BackColor = System.Drawing.Color.Transparent;
            this.btnLogoutHeader.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnLogoutHeader.FlatAppearance.BorderSize = 2;
            this.btnLogoutHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogoutHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogoutHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnLogoutHeader.Location = new System.Drawing.Point(280, 8);
            this.btnLogoutHeader.Name = "btnLogoutHeader";
            this.btnLogoutHeader.Size = new System.Drawing.Size(75, 35);
            this.btnLogoutHeader.TabIndex = 3;
            this.btnLogoutHeader.Text = "🚪 Logout";
            this.btnLogoutHeader.UseVisualStyleBackColor = false;
            // 
            // lblRole (Label role di bawah username)
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblRole.ForeColor = System.Drawing.Color.Gray;
            this.lblRole.Location = new System.Drawing.Point(45, 28);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(30, 15);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "Role";
            // 
            // lblWelcome (Label username)
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWelcome.Location = new System.Drawing.Point(45, 8);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(75, 20);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome";
            // 
            // picUserIcon (Ikon user di sebelah kiri teks)
            // 
            this.picUserIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.picUserIcon.Location = new System.Drawing.Point(5, 5);
            this.picUserIcon.Name = "picUserIcon";
            this.picUserIcon.Size = new System.Drawing.Size(35, 40);
            this.picUserIcon.TabIndex = 0;
            this.picUserIcon.TabStop = false;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(240, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(922, 613);
            this.panelContent.TabIndex = 2;
            // 
            // DashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 673);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "DashboardAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Admin";
            this.panelSidebar.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelUserInfo.ResumeLayout(false);
            this.panelUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblTitleSidebar;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnPenjemputan;
        private System.Windows.Forms.Button btnSampah;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Button btnChatbot;

        // Header components (baru)
        private System.Windows.Forms.Panel panelUserInfo;
        private System.Windows.Forms.PictureBox picUserIcon;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnLogoutHeader;
    }
}