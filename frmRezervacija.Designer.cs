
namespace tvpprojekat
{
    partial class frmRezervacija
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnRezervisi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUkupno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cmbSala = new System.Windows.Forms.ComboBox();
            this.dtpPocetni = new System.Windows.Forms.DateTimePicker();
            this.dtpKrajnji = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFilm = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbRepertoar = new System.Windows.Forms.ListBox();
            this.btnDostupne = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(184, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "REZERVACIJA PROJEKCIJE";
            // 
            // btnRezervisi
            // 
            this.btnRezervisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRezervisi.Location = new System.Drawing.Point(485, 364);
            this.btnRezervisi.Name = "btnRezervisi";
            this.btnRezervisi.Size = new System.Drawing.Size(303, 74);
            this.btnRezervisi.TabIndex = 1;
            this.btnRezervisi.Text = "Rezerviši";
            this.btnRezervisi.UseVisualStyleBackColor = true;
            this.btnRezervisi.Click += new System.EventHandler(this.btnRezervisi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Broj mesta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(155, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ukupna cena:";
            // 
            // txtUkupno
            // 
            this.txtUkupno.Location = new System.Drawing.Point(160, 419);
            this.txtUkupno.Multiline = true;
            this.txtUkupno.Name = "txtUkupno";
            this.txtUkupno.ReadOnly = true;
            this.txtUkupno.Size = new System.Drawing.Size(140, 20);
            this.txtUkupno.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Filteri:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(11, 419);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // cmbSala
            // 
            this.cmbSala.FormattingEnabled = true;
            this.cmbSala.Location = new System.Drawing.Point(437, 97);
            this.cmbSala.Name = "cmbSala";
            this.cmbSala.Size = new System.Drawing.Size(173, 21);
            this.cmbSala.TabIndex = 7;
            this.cmbSala.SelectedIndexChanged += new System.EventHandler(this.cmbSala_SelectedIndexChanged);
            // 
            // dtpPocetni
            // 
            this.dtpPocetni.Location = new System.Drawing.Point(12, 98);
            this.dtpPocetni.MinDate = new System.DateTime(2021, 4, 10, 0, 0, 0, 0);
            this.dtpPocetni.Name = "dtpPocetni";
            this.dtpPocetni.Size = new System.Drawing.Size(200, 20);
            this.dtpPocetni.TabIndex = 8;
            this.dtpPocetni.Value = new System.DateTime(2021, 4, 22, 0, 0, 0, 0);
            // 
            // dtpKrajnji
            // 
            this.dtpKrajnji.Location = new System.Drawing.Point(224, 98);
            this.dtpKrajnji.MaxDate = new System.DateTime(2021, 5, 1, 0, 0, 0, 0);
            this.dtpKrajnji.MinDate = new System.DateTime(2021, 4, 24, 0, 0, 0, 0);
            this.dtpKrajnji.Name = "dtpKrajnji";
            this.dtpKrajnji.Size = new System.Drawing.Size(200, 20);
            this.dtpKrajnji.TabIndex = 9;
            this.dtpKrajnji.Value = new System.DateTime(2021, 4, 25, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Početni datum";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(220, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Krajnji datum";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(433, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Sala";
            // 
            // cmbFilm
            // 
            this.cmbFilm.FormattingEnabled = true;
            this.cmbFilm.Location = new System.Drawing.Point(616, 97);
            this.cmbFilm.Name = "cmbFilm";
            this.cmbFilm.Size = new System.Drawing.Size(173, 21);
            this.cmbFilm.TabIndex = 13;
            this.cmbFilm.SelectedIndexChanged += new System.EventHandler(this.cmbFilm_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(616, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Naziv";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 24);
            this.label9.TabIndex = 15;
            this.label9.Text = "Repertoar bioskopa";
            // 
            // lbRepertoar
            // 
            this.lbRepertoar.FormattingEnabled = true;
            this.lbRepertoar.Location = new System.Drawing.Point(13, 207);
            this.lbRepertoar.Name = "lbRepertoar";
            this.lbRepertoar.Size = new System.Drawing.Size(775, 147);
            this.lbRepertoar.TabIndex = 16;
            this.lbRepertoar.SelectedIndexChanged += new System.EventHandler(this.lbRepertoar_SelectedIndexChanged);
            // 
            // btnDostupne
            // 
            this.btnDostupne.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDostupne.Location = new System.Drawing.Point(11, 124);
            this.btnDostupne.Name = "btnDostupne";
            this.btnDostupne.Size = new System.Drawing.Size(777, 52);
            this.btnDostupne.TabIndex = 17;
            this.btnDostupne.Text = "Prikaži dostupne projekcije";
            this.btnDostupne.UseVisualStyleBackColor = true;
            this.btnDostupne.Click += new System.EventHandler(this.btnDostupne_Click);
            // 
            // frmRezervacija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDostupne);
            this.Controls.Add(this.lbRepertoar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbFilm);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpKrajnji);
            this.Controls.Add(this.dtpPocetni);
            this.Controls.Add(this.cmbSala);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUkupno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRezervisi);
            this.Controls.Add(this.label1);
            this.Name = "frmRezervacija";
            this.Text = "Rezervacija projekcije";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRezervacija_FormClosing);
            this.Load += new System.EventHandler(this.frmRezervacija_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRezervisi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUkupno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox cmbSala;
        private System.Windows.Forms.DateTimePicker dtpPocetni;
        private System.Windows.Forms.DateTimePicker dtpKrajnji;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFilm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lbRepertoar;
        private System.Windows.Forms.Button btnDostupne;
    }
}