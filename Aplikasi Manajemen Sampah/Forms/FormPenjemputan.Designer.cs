namespace Aplikasi_Manajemen_Sampah.Forms
{
    partial class FormPenjemputan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelInput = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCatatan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTanggalJadwal = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new Aplikasi_Manajemen_Sampah.RoundedButton();
            this.btnHapus = new Aplikasi_Manajemen_Sampah.RoundedButton();
            this.btnSimpan = new Aplikasi_Manajemen_Sampah.RoundedButton();
            this.cboPetugas = new System.Windows.Forms.ComboBox();
            this.lblPetugas = new System.Windows.Forms.Label();
            this.cboSampah = new System.Windows.Forms.ComboBox();
            this.lblSampah = new System.Windows.Forms.Label();
            this.lblTitleInput = new System.Windows.Forms.Label();
            this.dgvPenjemputan = new System.Windows.Forms.DataGridView();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenjemputan)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.White;
            this.panelInput.Controls.Add(this.label5);
            this.panelInput.Controls.Add(this.txtCatatan);
            this.panelInput.Controls.Add(this.label4);
            this.panelInput.Controls.Add(this.cboStatus);
            this.panelInput.Controls.Add(this.label3);
            this.panelInput.Controls.Add(this.dtpTanggalJadwal);
            this.panelInput.Controls.Add(this.btnClear);
            this.panelInput.Controls.Add(this.btnHapus);
            this.panelInput.Controls.Add(this.btnSimpan);
            this.panelInput.Controls.Add(this.cboPetugas);
            this.panelInput.Controls.Add(this.lblPetugas);
            this.panelInput.Controls.Add(this.cboSampah);
            this.panelInput.Controls.Add(this.lblSampah);
            this.panelInput.Controls.Add(this.lblTitleInput);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInput.Location = new System.Drawing.Point(0, 0);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(340, 600);
            this.panelInput.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(20, 350);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Catatan";
            // 
            // txtCatatan
            // 
            this.txtCatatan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCatatan.Location = new System.Drawing.Point(20, 370);
            this.txtCatatan.Multiline = true;
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.Size = new System.Drawing.Size(290, 60);
            this.txtCatatan.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(20, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Status";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] { "Terjadwal", "Selesai", "Dibatalkan" });
            this.cboStatus.Location = new System.Drawing.Point(20, 305);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(290, 25);
            this.cboStatus.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(20, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tanggal Jadwal";
            // 
            // dtpTanggalJadwal
            // 
            this.dtpTanggalJadwal.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpTanggalJadwal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTanggalJadwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTanggalJadwal.Location = new System.Drawing.Point(20, 240);
            this.dtpTanggalJadwal.Name = "dtpTanggalJadwal";
            this.dtpTanggalJadwal.Size = new System.Drawing.Size(290, 25);
            this.dtpTanggalJadwal.TabIndex = 8;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(230, 450);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 40);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHapus.FlatAppearance.BorderSize = 0;
            this.btnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHapus.ForeColor = System.Drawing.Color.White;
            this.btnHapus.Location = new System.Drawing.Point(125, 450);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(90, 40);
            this.btnHapus.TabIndex = 6;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimpan.FlatAppearance.BorderSize = 0;
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Location = new System.Drawing.Point(20, 450);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(90, 40);
            this.btnSimpan.TabIndex = 5;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            // 
            // cboPetugas
            // 
            this.cboPetugas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPetugas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPetugas.FormattingEnabled = true;
            this.cboPetugas.Location = new System.Drawing.Point(20, 175);
            this.cboPetugas.Name = "cboPetugas";
            this.cboPetugas.Size = new System.Drawing.Size(290, 25);
            this.cboPetugas.TabIndex = 4;
            // 
            // lblPetugas
            // 
            this.lblPetugas.AutoSize = true;
            this.lblPetugas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPetugas.Location = new System.Drawing.Point(20, 155);
            this.lblPetugas.Name = "lblPetugas";
            this.lblPetugas.Size = new System.Drawing.Size(51, 15);
            this.lblPetugas.TabIndex = 3;
            this.lblPetugas.Text = "Petugas";
            // 
            // cboSampah
            // 
            this.cboSampah.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSampah.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSampah.FormattingEnabled = true;
            this.cboSampah.Location = new System.Drawing.Point(20, 110);
            this.cboSampah.Name = "cboSampah";
            this.cboSampah.Size = new System.Drawing.Size(290, 25);
            this.cboSampah.TabIndex = 2;
            // 
            // lblSampah
            // 
            this.lblSampah.AutoSize = true;
            this.lblSampah.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSampah.Location = new System.Drawing.Point(20, 90);
            this.lblSampah.Name = "lblSampah";
            this.lblSampah.Size = new System.Drawing.Size(77, 15);
            this.lblSampah.TabIndex = 1;
            this.lblSampah.Text = "Pilih Sampah";
            // 
            // lblTitleInput
            // 
            this.lblTitleInput.AutoSize = true;
            this.lblTitleInput.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTitleInput.Location = new System.Drawing.Point(20, 30);
            this.lblTitleInput.Name = "lblTitleInput";
            this.lblTitleInput.Size = new System.Drawing.Size(188, 25);
            this.lblTitleInput.TabIndex = 0;
            this.lblTitleInput.Text = "Atur Penjemputan 🚛";
            // 
            // dgvPenjemputan
            // 
            this.dgvPenjemputan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPenjemputan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPenjemputan.Location = new System.Drawing.Point(340, 0);
            this.dgvPenjemputan.Name = "dgvPenjemputan";
            this.dgvPenjemputan.Size = new System.Drawing.Size(660, 600);
            this.dgvPenjemputan.TabIndex = 1;
            // 
            // FormPenjemputan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvPenjemputan);
            this.Controls.Add(this.panelInput);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormPenjemputan";
            this.Text = "Jadwal Penjemputan";
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenjemputan)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label lblTitleInput;
        private System.Windows.Forms.Label lblSampah;
        private System.Windows.Forms.ComboBox cboSampah;
        private System.Windows.Forms.Label lblPetugas;
        private System.Windows.Forms.ComboBox cboPetugas;
        private RoundedButton btnSimpan;
        private RoundedButton btnHapus;
        private RoundedButton btnClear;
        private System.Windows.Forms.DateTimePicker dtpTanggalJadwal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCatatan;
        private System.Windows.Forms.DataGridView dgvPenjemputan;
    }
}