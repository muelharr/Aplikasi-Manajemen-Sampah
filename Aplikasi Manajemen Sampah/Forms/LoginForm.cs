using System;
using System.Drawing;
using System.Windows.Forms;
using Aplikasi_Manajemen_Sampah.Models;
using Aplikasi_Manajemen_Sampah.Services;

namespace Aplikasi_Manajemen_Sampah
{
    public partial class LoginForm : Form
    {
        private AuthService authService;
        private const string UserPlaceholder = "Username";
        private const string PassPlaceholder = "Password";
        private Color TextColor = Color.White;
        private Color PlaceholderColor = Color.DarkGray;

        public LoginForm()
        {
            InitializeComponent();
            authService = new AuthService();

            SetupEvents();
            InitializeCustomDesign();
        }

        private void InitializeCustomDesign()
        {
            // Warna latar input agar menyatu dengan Glass Panel
            Color inputBackground = Color.FromArgb(30, 30, 30);

            if (pnlUsernameContainer is BorderedPanel pnlUser) pnlUser.FillColor = inputBackground;
            if (pnlPasswordContainer is BorderedPanel pnlPass) pnlPass.FillColor = inputBackground;

            txtUsername.BackColor = inputBackground;
            txtPassword.BackColor = inputBackground;

            txtUsername.BorderStyle = BorderStyle.None;
            txtPassword.BorderStyle = BorderStyle.None;

            txtUsername.ForeColor = Color.White;
            txtPassword.ForeColor = Color.White;

            SetPlaceholder(txtUsername, UserPlaceholder);
            SetPlaceholder(txtPassword, PassPlaceholder);
            txtPassword.UseSystemPasswordChar = false;

            this.ActiveControl = lblTitle; // Fokus awal ke Label
        }

        private void SetupEvents()
        {
            this.Resize += (s, e) => CenterPanel();
            this.Load += (s, e) => CenterPanel();

            // Logika Placeholder
            txtUsername.Enter += (s, e) => { if (txtUsername.Text == UserPlaceholder) RemovePlaceholder(txtUsername); };
            txtUsername.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtUsername.Text)) SetPlaceholder(txtUsername, UserPlaceholder); };

            txtPassword.Enter += (s, e) =>
            {
                if (txtPassword.Text == PassPlaceholder)
                {
                    RemovePlaceholder(txtPassword);
                    txtPassword.UseSystemPasswordChar = true;
                }
            };

            txtPassword.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    txtPassword.UseSystemPasswordChar = false;
                    SetPlaceholder(txtPassword, PassPlaceholder);
                }
            };

            btnLogin.Click += btnLogin_Click;

            // Enter key shortcut
            txtUsername.KeyPress += Txt_KeyPress;
            txtPassword.KeyPress += Txt_KeyPress;
        }

        private void CenterPanel()
        {
            if (panelLogin != null)
            {
                panelLogin.Location = new Point(
                    (this.ClientSize.Width - panelLogin.Width) / 2,
                    (this.ClientSize.Height - panelLogin.Height) / 2
                );
            }
        }

        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = PlaceholderColor;
        }

        private void RemovePlaceholder(TextBox txt)
        {
            txt.Text = "";
            txt.ForeColor = TextColor;
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) btnLogin_Click(sender, e);
        }

        private async void btnLogin_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == UserPlaceholder || string.IsNullOrWhiteSpace(username) ||
                password == PassPlaceholder || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Harap isi Username dan Password!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "LOADING...";

            try
            {
                var user = await authService.LoginAsync(username, password);

                if (user != null)
                {
                    var dashboard = new Forms.DashboardAdmin(user);
                    dashboard.Show();
                    this.Hide();
                    dashboard.FormClosed += (s, args) => this.Close();
                }
                else
                {
                    MessageBox.Show("Username atau Password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan sistem: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "LOGIN";
            }
        }
    }
}