using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using MongoDB.Driver;
using Aplikasi_Manajemen_Sampah.Models;
using System.Linq;
using System.Collections.Generic;
using Aplikasi_Manajemen_Sampah.Services;
using System.IO;

namespace Aplikasi_Manajemen_Sampah.Forms
{
    public partial class FormPenjemputan : Form
    {
        private User currentUser;
        private MongoService mongo;
        private List<Sampah> listSampah = new List<Sampah>();
        private List<User> listPetugas = new List<User>();
        private List<Penjemputan> listPenjemputan = new List<Penjemputan>();
        private string selectedId = "";
        private bool isViewOnly = false;
        private Dictionary<string, Image> iconCache = new Dictionary<string, Image>();

        public FormPenjemputan(User user, bool viewOnly = false)
        {
            this.currentUser = user;
            this.isViewOnly = viewOnly;
            this.mongo = new MongoService();

            InitializeComponent();

            if (dgvPenjemputan != null) UIHelper.SetGridStyle(dgvPenjemputan);

            SetupEvents();
            LoadComboData();
            LoadData();

            if (isViewOnly)
            {
                SetViewOnlyMode();
            }
        }

        private void SetViewOnlyMode()
        {
            this.Text = "Jadwal Penjemputan (View Only)";

            if (panelInput != null)
            {
                panelInput.Visible = false;
            }

            if (dgvPenjemputan != null)
            {
                dgvPenjemputan.Dock = DockStyle.Fill;
            }

            Label lblInfo = new Label();
            lblInfo.Text = "ℹ️ Anda hanya dapat melihat data. Hubungi admin untuk perubahan data.";
            lblInfo.Font = new Font("Segoe UI", 10F);
            lblInfo.ForeColor = Color.Gray;
            lblInfo.Dock = DockStyle.Bottom;
            lblInfo.Height = 30;
            lblInfo.TextAlign = ContentAlignment.MiddleLeft;
            lblInfo.Padding = new Padding(25, 0, 0, 0);
            this.Controls.Add(lblInfo);
        }

        private void SetupEvents()
        {
            btnSimpan.Click += BtnSimpan_Click;
            btnHapus.Click += BtnHapus_Click;
            btnClear.Click += (s, e) => ClearInputs();
            dgvPenjemputan.CellClick += DgvPenjemputan_CellClick;
            cboStatus.SelectedIndexChanged += CboStatus_SelectedIndexChanged;

            cboStatus.SelectedIndex = 0;
            this.FormClosing += (s, e) => DisposeIcons();
        }

        private async void LoadComboData()
        {
            try
            {
                if (isViewOnly) return;

                listSampah = await mongo.Sampah.Find(_ => true).ToListAsync();
                cboSampah.Items.Clear();
                foreach (var s in listSampah) cboSampah.Items.Add($"{s.Nama} ({s.BeratKg} kg)");

                listPetugas = await mongo.Users.Find(u => u.Role == "Petugas" || u.Role == "Admin").ToListAsync();
                cboPetugas.Items.Clear();
                foreach (var p in listPetugas) cboPetugas.Items.Add(p.Username);

                if (currentUser.Role == "Petugas")
                {
                    var idx = listPetugas.FindIndex(p => p.Id == currentUser.Id);
                    if (idx >= 0) cboPetugas.SelectedIndex = idx;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void LoadData()
        {
            try
            {
                listPenjemputan = await mongo.Penjemputan.Find(_ => true).ToListAsync();

                foreach (var item in listPenjemputan)
                {
                    var s = await mongo.Sampah.Find(x => x.Id == item.SampahID).FirstOrDefaultAsync();
                    var p = await mongo.Users.Find(x => x.Id == item.PetugasID).FirstOrDefaultAsync();

                    item.NamaSampah = s?.Nama ?? "-";
                    item.LokasiSampah = s?.Lokasi ?? "-";
                    item.NamaPetugas = p?.Username ?? "-";
                }

                if (currentUser.Role == "Petugas")
                {
                    listPenjemputan = listPenjemputan.Where(p => p.PetugasID == currentUser.Id).ToList();
                }

                SetupDataGridViewWithIcons(listPenjemputan);
            }
            catch (Exception ex) { MessageBox.Show("Gagal load data: " + ex.Message); }
        }

        private void SetupDataGridViewWithIcons(List<Penjemputan> data)
        {
            dgvPenjemputan.Columns.Clear();
            dgvPenjemputan.AutoGenerateColumns = false;

            dgvPenjemputan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "No",
                HeaderText = "No",
                Width = 40,
                ReadOnly = true
            });

            dgvPenjemputan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TanggalJadwal",
                HeaderText = "Tanggal Jadwal",
                DataPropertyName = "TanggalJadwal",
                Width = 130,
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
            });

            // KOLOM ICON (BARU)
            dgvPenjemputan.Columns.Add(new DataGridViewImageColumn
            {
                Name = "IconStatus",
                HeaderText = "",
                Width = 40,
                ReadOnly = true,
                DefaultCellStyle = {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    NullValue = null
                },
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });

            dgvPenjemputan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 100
            });

            dgvPenjemputan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Catatan",
                HeaderText = "Catatan",
                DataPropertyName = "Catatan",
                Width = 150
            });

            dgvPenjemputan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NamaPetugas",
                HeaderText = "Petugas",
                DataPropertyName = "NamaPetugas",
                Width = 120
            });

            dgvPenjemputan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NamaSampah",
                HeaderText = "Jenis Sampah",
                DataPropertyName = "NamaSampah",
                Width = 120
            });

            dgvPenjemputan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LokasiSampah",
                HeaderText = "Lokasi",
                DataPropertyName = "LokasiSampah",
                Width = 150
            });

            int no = 1;
            foreach (var item in data)
            {
                int rowIndex = dgvPenjemputan.Rows.Add();
                var row = dgvPenjemputan.Rows[rowIndex];

                row.Cells["No"].Value = no++;
                row.Cells["TanggalJadwal"].Value = item.TanggalJadwal;
                row.Cells["Status"].Value = item.Status;
                row.Cells["Catatan"].Value = item.Catatan;
                row.Cells["NamaPetugas"].Value = item.NamaPetugas;
                row.Cells["NamaSampah"].Value = item.NamaSampah;
                row.Cells["LokasiSampah"].Value = item.LokasiSampah;

                // ===== SET ICON =====
                Image icon = GetCachedIcon(item.Status);
                row.Cells["IconStatus"].Value = icon;

                // ===== SET WARNA & STYLING =====
                Color statusColor = GetStatusColor(item.Status);
                Color bgColor = GetStatusBackgroundColor(item.Status);

                row.Cells["Status"].Style.ForeColor = statusColor;
                row.Cells["Status"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                row.Cells["Status"].Style.BackColor = bgColor;
                row.DefaultCellStyle.BackColor = bgColor;

                // ===== SET TOOLTIP =====
                row.Cells["IconStatus"].ToolTipText = GetStatusDescription(item.Status);
            }

            dgvPenjemputan.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 204, 113);
            dgvPenjemputan.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPenjemputan.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvPenjemputan.ColumnHeadersHeight = 40;
            dgvPenjemputan.EnableHeadersVisualStyles = false;
            dgvPenjemputan.RowTemplate.Height = 40;
        }

        // ===== ICON HELPER METHODS (Langsung di FormPenjemputan, tidak perlu file lain) =====

        private Image GetCachedIcon(string status)
        {
            if (!iconCache.ContainsKey(status))
            {
                iconCache[status] = GetStatusIcon(status, 24);
            }
            return iconCache[status];
        }

        private Image GetStatusIcon(string status, int size = 24)
        {
            try
            {
                // Coba load dari file
                string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Icons");
                string iconFile = status switch
                {
                    "Selesai" => Path.Combine(iconPath, "check-circle.png"),
                    "Dibatalkan" => Path.Combine(iconPath, "x-circle.png"),
                    "Terjadwal" => Path.Combine(iconPath, "calendar-clock.png"),
                    _ => Path.Combine(iconPath, "clock-circle.png")
                };

                if (File.Exists(iconFile))
                {
                    Bitmap icon = new Bitmap(iconFile);
                    return new Bitmap(icon, new Size(size, size));
                }
                else
                {
                    // Fallback ke emoji jika file tidak ada
                    return GetFallbackEmoji(status);
                }
            }
            catch
            {
                return GetFallbackEmoji(status);
            }
        }

        private Image GetFallbackEmoji(string status)
        {
            string emoji = status switch
            {
                "Selesai" => "✅",
                "Dibatalkan" => "❌",
                "Terjadwal" => "📅",
                _ => "⏳"
            };

            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.DrawString(emoji, new Font("Segoe UI Emoji", 20), Brushes.Black, new PointF(0, 0));
            }
            return bmp;
        }

        private Color GetStatusColor(string status)
        {
            return status switch
            {
                "Selesai" => Color.FromArgb(46, 204, 113),      // Hijau
                "Dibatalkan" => Color.FromArgb(231, 76, 60),    // Merah
                "Terjadwal" => Color.FromArgb(52, 152, 219),    // Biru
                _ => Color.FromArgb(149, 165, 166)              // Abu-abu
            };
        }

        private Color GetStatusBackgroundColor(string status)
        {
            return status switch
            {
                "Selesai" => Color.FromArgb(230, 255, 230),
                "Dibatalkan" => Color.FromArgb(255, 230, 230),
                "Terjadwal" => Color.FromArgb(230, 240, 255),
                _ => Color.FromArgb(240, 240, 240)
            };
        }

        private string GetStatusDescription(string status)
        {
            return status switch
            {
                "Selesai" => "Penjemputan telah selesai",
                "Dibatalkan" => "Penjemputan dibatalkan",
                "Terjadwal" => "Penjemputan dijadwalkan",
                _ => "Status tidak diketahui"
            };
        }

        private void DisposeIcons()
        {
            foreach (var icon in iconCache.Values)
            {
                icon?.Dispose();
            }
            iconCache.Clear();
        }

        // ===== END ICON HELPER METHODS =====

        private async void BtnSimpan_Click(object sender, EventArgs e)
        {
            if (isViewOnly)
            {
                MessageBox.Show("Anda tidak memiliki izin untuk mengubah data!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboSampah.SelectedIndex < 0 || cboPetugas.SelectedIndex < 0)
            {
                MessageBox.Show("Lengkapi data!"); return;
            }

            var sId = listSampah[cboSampah.SelectedIndex].Id;
            var pId = listPetugas[cboPetugas.SelectedIndex].Id;

            bool overlap = await CheckOverlap(pId, dtpTanggalJadwal.Value, selectedId);
            if (overlap)
            {
                MessageBox.Show("❌ GAGAL: Petugas ini sudah ada jadwal di jam tersebut (Bentrokan)!");
                return;
            }

            var item = new Penjemputan
            {
                Id = string.IsNullOrEmpty(selectedId) ? MongoDB.Bson.ObjectId.GenerateNewId().ToString() : selectedId,
                SampahID = sId,
                PetugasID = pId,
                TanggalJadwal = dtpTanggalJadwal.Value,
                Status = cboStatus.SelectedItem.ToString(),
                Catatan = txtCatatan.Text
            };

            if (string.IsNullOrEmpty(selectedId))
                await mongo.Penjemputan.InsertOneAsync(item);
            else
                await mongo.Penjemputan.ReplaceOneAsync(x => x.Id == selectedId, item);

            MessageBox.Show("Berhasil disimpan!");
            ClearInputs();
            LoadData();
        }

        private async void BtnHapus_Click(object sender, EventArgs e)
        {
            if (isViewOnly)
            {
                MessageBox.Show("Anda tidak memiliki izin untuk menghapus data!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedId)) return;
            if (MessageBox.Show("Hapus?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await mongo.Penjemputan.DeleteOneAsync(x => x.Id == selectedId);
                ClearInputs();
                LoadData();
            }
        }

        private void DgvPenjemputan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isViewOnly) return;

            if (e.RowIndex < 0) return;
            var row = dgvPenjemputan.Rows[e.RowIndex];

            var item = listPenjemputan[e.RowIndex];

            selectedId = item.Id;

            cboSampah.SelectedIndex = listSampah.FindIndex(x => x.Id == item.SampahID);
            cboPetugas.SelectedIndex = listPetugas.FindIndex(x => x.Id == item.PetugasID);

            dtpTanggalJadwal.Value = item.TanggalJadwal;
            cboStatus.SelectedItem = item.Status;
            txtCatatan.Text = item.Catatan;

            btnSimpan.Text = "Update";
        }

        private async Task<bool> CheckOverlap(string pId, DateTime date, string currentId)
        {
            try
            {
                var list = await mongo.Penjemputan.Find(x => x.PetugasID == pId).ToListAsync();

                if (!string.IsNullOrEmpty(currentId))
                {
                    list = list.Where(x => x.Id != currentId).ToList();
                }

                return list.Any(x => Math.Abs((x.TanggalJadwal - date).TotalHours) < 2);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error CheckOverlap: " + ex.Message);
                return true;
            }
        }

        private void CboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isViewOnly) return;

            if (cboStatus.SelectedItem?.ToString() == "Selesai")
                txtCatatan.Text += " [Tugas Selesai]";
        }

        private void ClearInputs()
        {
            if (isViewOnly) return;

            selectedId = "";
            cboSampah.SelectedIndex = -1;
            if (currentUser.Role == "Admin") cboPetugas.SelectedIndex = -1;
            txtCatatan.Clear();
            btnSimpan.Text = "Simpan";
        }
    }
}