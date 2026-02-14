using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Aplikasi_Manajemen_Sampah.Models;

namespace Aplikasi_Manajemen_Sampah.Forms
{
    public partial class DashboardAdmin : Form
    {
        private User currentUser;
        private Form activeForm = null;

        public DashboardAdmin(User user)
        {
            this.currentUser = user;
            InitializeComponent();

            InitializeCustomDesign();

            // Setup Navigasi Sidebar
            SetupMenuByRole();

            if (btnLogoutHeader != null)
                btnLogoutHeader.Click += BtnLogout_Click;
        }

        private void InitializeCustomDesign()
        {
            // Set Username dan Role di Header
            if (Controls.Find("lblWelcome", true).Length > 0)
                ((Label)Controls.Find("lblWelcome", true)[0]).Text = $"Welcome, {currentUser.Username}";

            if (Controls.Find("lblRole", true).Length > 0)
                ((Label)Controls.Find("lblRole", true)[0]).Text = currentUser.Role;

            // Styling Tombol Sidebar
            if (btnSampah != null) { UIHelper.SetSidebarButton(btnSampah); SetupButtonHover(btnSampah); }
            if (btnPenjemputan != null) { UIHelper.SetSidebarButton(btnPenjemputan); SetupButtonHover(btnPenjemputan); }
            if (btnUsers != null) { UIHelper.SetSidebarButton(btnUsers); SetupButtonHover(btnUsers); }
            if (btnCetak != null)
            {
                UIHelper.SetSidebarButton(btnCetak);
                SetupButtonHover(btnCetak);
                btnCetak.Visible = true;
                btnCetak.BringToFront();
            }

            if (btnChatbot != null)
            {
                UIHelper.SetSidebarButton(btnChatbot);
                SetupButtonHover(btnChatbot);
                btnChatbot.Visible = true;
                btnChatbot.BringToFront();
            }

            // Styling tombol logout di header
            if (btnLogoutHeader != null)
            {
                btnLogoutHeader.MouseEnter += (s, e) =>
                {
                    btnLogoutHeader.BackColor = Color.FromArgb(192, 57, 43);
                    btnLogoutHeader.ForeColor = Color.White;
                };
                btnLogoutHeader.MouseLeave += (s, e) =>
                {
                    btnLogoutHeader.BackColor = Color.Transparent;
                    btnLogoutHeader.ForeColor = Color.FromArgb(192, 57, 43);
                };
            }
        }

        private void SetupButtonHover(Button btn)
        {
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(46, 204, 113);
            btn.MouseLeave += (s, e) => btn.BackColor = UIHelper.PrimaryColor;
        }

        // METHOD BARU: Setup akses menu berdasarkan role
        private void SetupMenuByRole()
        {
            switch (currentUser.Role)
            {
                case "Admin":
                    SetupAdminAccess();
                    break;
                case "Petugas":
                    SetupPetugasAccess();
                    break;
                case "Masyarakat":
                    SetupMasyarakatAccess();
                    break;
                default:
                    MessageBox.Show("Role tidak dikenali!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }
        }

        private void SetupAdminAccess()
        {
            // Admin: akses penuh semua menu
            if (btnSampah != null)
                btnSampah.Click += (s, e) => OpenChildForm(new FormSampah(currentUser));

            if (btnPenjemputan != null)
                btnPenjemputan.Click += (s, e) => OpenChildForm(new FormPenjemputan(currentUser));

            if (btnUsers != null)
                btnUsers.Click += (s, e) => OpenChildForm(new FormUsers(currentUser));

            if (btnCetak != null)
                btnCetak.Click += (s, e) => OpenChildForm(new FormLaporan());

            if (btnChatbot != null)
                btnChatbot.Click += (s, e) => OpenChildForm(new FormChatbot(currentUser));
        }

        private void SetupPetugasAccess()
        {
            // Petugas: sama seperti admin tapi tidak akses Kelola User
            if (btnSampah != null)
                btnSampah.Click += (s, e) => OpenChildForm(new FormSampah(currentUser));

            if (btnPenjemputan != null)
                btnPenjemputan.Click += (s, e) => OpenChildForm(new FormPenjemputan(currentUser));

            // Petugas tidak boleh akses Kelola User
            if (btnUsers != null) btnUsers.Visible = false;

            if (btnCetak != null)
                btnCetak.Click += (s, e) => OpenChildForm(new FormLaporan());

            if (btnChatbot != null)
                btnChatbot.Click += (s, e) => OpenChildForm(new FormChatbot(currentUser));
        }

        private void SetupMasyarakatAccess()
        {
            // Masyarakat: hanya bisa lihat (view-only), tidak boleh edit
            if (btnSampah != null)
            {
                btnSampah.Click += (s, e) => OpenChildForm(new FormSampah(currentUser, true)); // true = view only
            }

            if (btnPenjemputan != null)
            {
                btnPenjemputan.Click += (s, e) => OpenChildForm(new FormPenjemputan(currentUser, true)); // true = view only
            }

            // Masyarakat TIDAK boleh akses:
            if (btnUsers != null) btnUsers.Visible = false;
            if (btnCetak != null) btnCetak.Visible = false;

            if (btnChatbot != null)
                btnChatbot.Click += (s, e) => OpenChildForm(new FormChatbot(currentUser));
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new LoginForm().Show();
                this.Hide();
            }
        }
    }
}