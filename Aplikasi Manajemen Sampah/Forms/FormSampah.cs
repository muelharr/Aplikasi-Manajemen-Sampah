using System;
using System.Drawing;
using System.Windows.Forms;
using Aplikasi_Manajemen_Sampah.Models;
using System.Threading.Tasks;
using MongoDB.Driver;
using Aplikasi_Manajemen_Sampah.Services;
using System.Collections.Generic;

namespace Aplikasi_Manajemen_Sampah.Forms
{
    public partial class FormSampah : Form
    {
        private User currentUser;
        private MongoService mongo;
        private string selectedId = "";
        private bool isViewOnly = false; // TAMBAHAN: mode view only

        // TAMBAHAN: Constructor dengan parameter viewOnly
        public FormSampah(User user, bool viewOnly = false)
        {
            this.currentUser = user;
            this.isViewOnly = viewOnly; // Set mode view only
            InitializeComponent();
            mongo = new MongoService();

            if (dgvSampah != null) UIHelper.SetGridStyle(dgvSampah);

            IsiDataLokasiJawaBarat();
            SetupEvents();
            LoadData();

            // TAMBAHAN: Jika view only, sembunyikan tombol edit
            if (isViewOnly)
            {
                SetViewOnlyMode();
            }
        }

        // TAMBAHAN: Method untuk set view only mode
        private void SetViewOnlyMode()
        {
            // Ubah judul
            this.Text = "Data Sampah (View Only)";
            this.lblTitle.Text = "Data Sampah 👁️";

            // Sembunyikan panel input (form input di kiri)
            if (panelInput != null)
            {
                panelInput.Visible = false;
            }

            // Perbesar DataGridView untuk fullscreen
            if (dgvSampah != null)
            {
                dgvSampah.Location = new Point(25, 70);
                dgvSampah.Size = new Size(1130, 500);
            }

            // Tambah label info
            Label lblInfo = new Label();
            lblInfo.Text = "ℹ️ Anda hanya dapat melihat data. Hubungi admin untuk perubahan data.";
            lblInfo.Font = new Font("Segoe UI", 10F);
            lblInfo.ForeColor = Color.Gray;
            lblInfo.Location = new Point(25, 580);
            lblInfo.Size = new Size(600, 20);
            this.Controls.Add(lblInfo);
        }

        private void IsiDataLokasiJawaBarat()
        {
            cboLokasi.Items.Clear();

            string[] wilayahJabar = {
                "Kota Bandung", "Kab. Bandung", "Kab. Bandung Barat",
                "Kota Bogor", "Kab. Bogor",
                "Kota Bekasi", "Kab. Bekasi",
                "Kota Depok",
                "Kota Cimahi",
                "Kota Tasikmalaya", "Kab. Tasikmalaya",
                "Kota Sukabumi", "Kab. Sukabumi",
                "Kota Cirebon", "Kab. Cirebon",
                "Kota Banjar",
                "Kab. Cianjur",
                "Kab. Garut",
                "Kab. Indramayu",
                "Kab. Karawang",
                "Kab. Kuningan",
                "Kab. Majalengka",
                "Kab. Pangandaran",
                "Kab. Purwakarta",
                "Kab. Subang",
                "Kab. Sumedang",
                "Kab. Ciamis"
            };

            cboLokasi.Items.AddRange(wilayahJabar);
            cboLokasi.SelectedIndex = 0;
        }

        private void SetupEvents()
        {
            btnSimpan.Click += BtnSimpan_Click;
            btnHapus.Click += BtnHapus_Click;
            btnClear.Click += (s, e) => ClearInputs();
            dgvSampah.CellClick += DgvSampah_CellClick;

            if (cboJenis.Items.Count > 0) cboJenis.SelectedIndex = 0;
        }

        private async void LoadData()
        {
            if (dgvSampah == null) return;

            try
            {
                var listSampah = await mongo.Sampah.Find(_ => true).ToListAsync();
                dgvSampah.DataSource = listSampah;

                if (dgvSampah.Columns["Id"] != null) dgvSampah.Columns["Id"].Visible = false;
                if (dgvSampah.Columns["TanggalMasuk"] != null)
                    dgvSampah.Columns["TanggalMasuk"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            catch (Exception ex) { MessageBox.Show($"Error loading data: {ex.Message}"); }
        }

        private async void BtnSimpan_Click(object sender, EventArgs e)
        {
            // TAMBAHAN: Cek jika view only, tidak boleh simpan
            if (isViewOnly)
            {
                MessageBox.Show("Anda tidak memiliki izin untuk mengubah data!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtBerat.Text) ||
                cboLokasi.SelectedIndex == -1)
            {
                MessageBox.Show("Nama, Berat, dan Lokasi wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtBerat.Text, out double beratKg))
            {
                MessageBox.Show("Berat harus berupa angka!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string jenis = cboJenis.SelectedItem?.ToString() ?? "Organik";
            string lokasiTerpilih = cboLokasi.SelectedItem.ToString();
            string catatanOtomatis = "";

            if (jenis == "B3")
            {
                var confirm = MessageBox.Show("⚠️ PERINGATAN LIMBAH B3!\nPastikan penanganan sesuai prosedur K3.\nLanjutkan?",
                    "Safety Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.No) return;
            }

            if (jenis == "DaurUlang")
            {
                catatanOtomatis = " Perlu Dipisahkan (Daur Ulang)";
            }

            if (beratKg >= 100)
            {
                MessageBox.Show("⚠️ KAPASITAS TINGGI DETEKSI!\nBerat > 100kg. Harap segera jadwalkan penjemputan.",
                    "Info Kapasitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            try
            {
                var sampah = new Sampah
                {
                    Id = string.IsNullOrEmpty(selectedId) ? MongoDB.Bson.ObjectId.GenerateNewId().ToString() : selectedId,
                    Nama = txtNama.Text,
                    Jenis = jenis,
                    BeratKg = beratKg,
                    Lokasi = lokasiTerpilih,
                    TanggalMasuk = DateTime.Now,
                    InputBy = currentUser.Username,
                    Catatan = catatanOtomatis
                };

                if (string.IsNullOrEmpty(selectedId))
                {
                    await mongo.Sampah.InsertOneAsync(sampah);
                    MessageBox.Show("✓ Data berhasil disimpan!");
                }
                else
                {
                    await mongo.Sampah.ReplaceOneAsync(x => x.Id == selectedId, sampah);
                    MessageBox.Show("✓ Data berhasil diupdate!");
                }

                ClearInputs();
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show("Gagal menyimpan: " + ex.Message); }
        }

        private async void BtnHapus_Click(object sender, EventArgs e)
        {
            // TAMBAHAN: Cek jika view only, tidak boleh hapus
            if (isViewOnly)
            {
                MessageBox.Show("Anda tidak memiliki izin untuk menghapus data!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedId))
            {
                MessageBox.Show("Pilih data dulu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cboJenis.SelectedItem?.ToString() == "B3")
            {
                if (MessageBox.Show("Hapus data B3 butuh verifikasi. Lanjutkan?", "Hapus B3", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }

            if (MessageBox.Show("Yakin hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await mongo.Sampah.DeleteOneAsync(x => x.Id == selectedId);
                ClearInputs();
                LoadData();
            }
        }

        private void DgvSampah_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // TAMBAHAN: Jika view only, tidak perlu isi form input
            if (isViewOnly) return;

            if (e.RowIndex < 0) return;

            var row = dgvSampah.Rows[e.RowIndex];
            selectedId = row.Cells["Id"].Value?.ToString();
            txtNama.Text = row.Cells["Nama"].Value?.ToString();
            txtBerat.Text = row.Cells["BeratKg"].Value?.ToString();

            string lokasiDb = row.Cells["Lokasi"].Value?.ToString();
            if (lokasiDb != null && cboLokasi.Items.Contains(lokasiDb))
            {
                cboLokasi.SelectedItem = lokasiDb;
            }
            else
            {
                cboLokasi.Text = lokasiDb;
            }

            string jenis = row.Cells["Jenis"].Value?.ToString();
            if (cboJenis.Items.Contains(jenis)) cboJenis.SelectedItem = jenis;

            btnSimpan.Text = "Update";
            btnSimpan.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void ClearInputs()
        {
            selectedId = "";
            txtNama.Clear();
            txtBerat.Clear();

            if (cboLokasi.Items.Count > 0) cboLokasi.SelectedIndex = 0;

            cboJenis.SelectedIndex = 0;
            btnSimpan.Text = "Simpan";
            btnSimpan.BackColor = Color.FromArgb(46, 204, 113);
            txtNama.Focus();
        }
    }
}