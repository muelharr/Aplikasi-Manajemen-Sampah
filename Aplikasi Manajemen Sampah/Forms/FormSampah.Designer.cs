namespace Aplikasi_Manajemen_Sampah.Forms
{
    partial class FormSampah
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
            this.panelInput = new System.Windows.Forms.Panel();
            this.txtLokasi = new System.Windows.Forms.TextBox();
            this.lblLokasi = new System.Windows.Forms.Label();
            this.btnClear = new Aplikasi_Manajemen_Sampah.RoundedButton();
            this.btnHapus = new Aplikasi_Manajemen_Sampah.RoundedButton();
            this.btnSimpan = new Aplikasi_Manajemen_Sampah.RoundedButton();
            this.txtBerat = new System.Windows.Forms.TextBox();
            this.lblBerat = new System.Windows.Forms.Label();
            this.cboJenis = new System.Windows.Forms.ComboBox();
            this.lblJenis = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.lblNama = new System.Windows.Forms.Label();
            this.lblTitleInput = new System.Windows.Forms.Label();
            this.dgvSampah = new System.Windows.Forms.DataGridView();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSampah)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.White;
            this.panelInput.Controls.Add(this.txtLokasi);
            this.panelInput.Controls.Add(this.lblLokasi);
            this.panelInput.Controls.Add(this.btnClear);
            this.panelInput.Controls.Add(this.btnHapus);
            this.panelInput.Controls.Add(this.btnSimpan);
            this.panelInput.Controls.Add(this.txtBerat);
            this.panelInput.Controls.Add(this.lblBerat);
            this.panelInput.Controls.Add(this.cboJenis);
            this.panelInput.Controls.Add(this.lblJenis);
            this.panelInput.Controls.Add(this.txtNama);
            this.panelInput.Controls.Add(this.lblNama);
            this.panelInput.Controls.Add(this.lblTitleInput);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInput.Location = new System.Drawing.Point(0, 0);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(320, 600);
            this.panelInput.TabIndex = 0;
            // 
            // txtLokasi
            // 
            this.txtLokasi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLokasi.Location = new System.Drawing.Point(20, 310);
            this.txtLokasi.Name = "txtLokasi";
            this.txtLokasi.Size = new System.Drawing.Size(280, 25);
            this.txtLokasi.TabIndex = 11;
            // 
            // lblLokasi
            // 
            this.lblLokasi.AutoSize = true;
            this.lblLokasi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLokasi.Location = new System.Drawing.Point(20, 290);
            this.lblLokasi.Name = "lblLokasi";
            this.lblLokasi.Size = new System.Drawing.Size(42, 15);
            this.lblLokasi.TabIndex = 10;
            this.lblLokasi.Text = "Lokasi";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(220, 370);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 40);
            this.btnClear.TabIndex = 9;
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
            this.btnHapus.Location = new System.Drawing.Point(120, 370);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(90, 40);
            this.btnHapus.TabIndex = 8;
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
            this.btnSimpan.Location = new System.Drawing.Point(20, 370);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(90, 40);
            this.btnSimpan.TabIndex = 7;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            // 
            // txtBerat
            // 
            this.txtBerat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBerat.Location = new System.Drawing.Point(20, 240);
            this.txtBerat.Name = "txtBerat";
            this.txtBerat.Size = new System.Drawing.Size(280, 25);
            this.txtBerat.TabIndex = 6;
            // 
            // lblBerat
            // 
            this.lblBerat.AutoSize = true;
            this.lblBerat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBerat.Location = new System.Drawing.Point(20, 220);
            this.lblBerat.Name = "lblBerat";
            this.lblBerat.Size = new System.Drawing.Size(65, 15);
            this.lblBerat.TabIndex = 5;
            this.lblBerat.Text = "Berat (Kg)";
            // 
            // cboJenis
            // 
            this.cboJenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJenis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboJenis.FormattingEnabled = true;
            this.cboJenis.Items.AddRange(new object[] {
            "Organik",
            "Anorganik",
            "B3",
            "DaurUlang"});
            this.cboJenis.Location = new System.Drawing.Point(20, 170);
            this.cboJenis.Name = "cboJenis";
            this.cboJenis.Size = new System.Drawing.Size(280, 25);
            this.cboJenis.TabIndex = 4;
            // 
            // lblJenis
            // 
            this.lblJenis.AutoSize = true;
            this.lblJenis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblJenis.Location = new System.Drawing.Point(20, 150);
            this.lblJenis.Name = "lblJenis";
            this.lblJenis.Size = new System.Drawing.Size(35, 15);
            this.lblJenis.TabIndex = 3;
            this.lblJenis.Text = "Jenis";
            // 
            // txtNama
            // 
            this.txtNama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNama.Location = new System.Drawing.Point(20, 100);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(280, 25);
            this.txtNama.TabIndex = 2;
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNama.Location = new System.Drawing.Point(20, 80);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(83, 15);
            this.lblNama.TabIndex = 1;
            this.lblNama.Text = "Nama Sampah";
            // 
            // lblTitleInput
            // 
            this.lblTitleInput.AutoSize = true;
            this.lblTitleInput.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTitleInput.Location = new System.Drawing.Point(20, 30);
            this.lblTitleInput.Name = "lblTitleInput";
            this.lblTitleInput.Size = new System.Drawing.Size(126, 25);
            this.lblTitleInput.TabIndex = 0;
            this.lblTitleInput.Text = "Input Data 📦";
            // 
            // dgvSampah
            // 
            this.dgvSampah.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSampah.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSampah.Location = new System.Drawing.Point(320, 0);
            this.dgvSampah.Name = "dgvSampah";
            this.dgvSampah.Size = new System.Drawing.Size(480, 600);
            this.dgvSampah.TabIndex = 1;
            // 
            // FormSampah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dgvSampah);
            this.Controls.Add(this.panelInput);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormSampah";
            this.Text = "Data Sampah";
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSampah)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label lblTitleInput;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.ComboBox cboJenis;
        private System.Windows.Forms.Label lblJenis;
        private System.Windows.Forms.TextBox txtBerat;
        private System.Windows.Forms.Label lblBerat;
        private System.Windows.Forms.TextBox txtLokasi;
        private System.Windows.Forms.Label lblLokasi;
        private RoundedButton btnSimpan;
        private RoundedButton btnHapus;
        private RoundedButton btnClear;
        private System.Windows.Forms.DataGridView dgvSampah;
    }
}