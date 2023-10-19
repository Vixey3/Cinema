using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tvpprojekat
{
    public partial class frmRezervacija : Form
    {
        public delegate void prosledi(int podaci);
        public prosledi poziv;

        int idk;
        FileStream fs;
        BinaryFormatter bf;
        List<Film> filmovi;
        List<Sala> sale;
        List<Projekcija> projekcije;
        List<Kupac> kupci;
        List<Rezervacije> rezervacije;
        string putanjafilmovi = "filmovi.txt";
        string putanjakupci = "registracija.txt";
        string putanjasale = "sale.txt";
        string putanjaprojekcije = "projekcije.txt";
        string putanjarezervacije = "rezervacije.txt";
        public frmRezervacija()
        {
            InitializeComponent();
            projekcije = new List<Projekcija>();
            rezervacije = new List<Rezervacije>();
            //filmovi = new List<Film>();
            //fs = File.OpenRead(putanjafilmovi);
            //BinaryFormatter bf = new BinaryFormatter();
            //filmovi = bf.Deserialize(fs) as List<Film>;
            //fs.Close();

            if (File.Exists(putanjafilmovi))
            {
                fs = File.OpenRead(putanjafilmovi);
                bf = new BinaryFormatter();
                filmovi = bf.Deserialize(fs) as List<Film>;
                for (int i = 0; i < filmovi.Count; i++)
                {
                    cmbFilm.Items.Add(filmovi[i]);
                }
                fs.Close();
            }

            if (File.Exists(putanjasale))
            {
                fs = File.OpenRead(putanjasale);
                bf = new BinaryFormatter();
                sale = bf.Deserialize(fs) as List<Sala>;
                for (int i = 0; i < sale.Count; i++)
                {
                    cmbSala.Items.Add(sale[i]);
                }
                fs.Close();
            }

            if (File.Exists(putanjarezervacije))
            {
                fs = File.OpenRead(putanjarezervacije);
                bf = new BinaryFormatter();
                rezervacije = bf.Deserialize(fs) as List<Rezervacije>;
                fs.Close();
            }

            if (File.Exists(putanjaprojekcije))
            {
                fs = File.OpenRead(putanjaprojekcije);
                bf = new BinaryFormatter();
                projekcije = bf.Deserialize(fs) as List<Projekcija>;
                fs.Close();
            }
        }

        private void btnDostupne_Click(object sender, EventArgs e)
        {
            if (dtpPocetni.Value > dtpKrajnji.Value)
            {
                MessageBox.Show("Ospeg nema smisla");
                return;
            }

            lbRepertoar.Items.Clear();
            if (File.Exists(putanjaprojekcije))
            {
                fs = File.OpenRead(putanjaprojekcije);
                bf = new BinaryFormatter();
                projekcije = bf.Deserialize(fs) as List<Projekcija>;
                fs.Close();
            }
                for (int i = 0; i < projekcije.Count; i++)
                { 
                    if (projekcije[i].Pdatum >= dtpPocetni.Value && projekcije[i].Pdatum <=dtpKrajnji.Value)
                        lbRepertoar.Items.Add(projekcije[i]);
                    else
                        MessageBox.Show("Nema dostupnih projekcija za izabrani opseg");
                }
                
            
            //btnDostupne.Enabled = false;
        }

        public void ispisiPodatke(int podaci)
        {
            idk = podaci;
            label1.Text += podaci;
        }

        private void frmRezervacija_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            int a;
            double cena;
            if(!double.TryParse(txtUkupno.Text, out cena))
            {
                MessageBox.Show("Greska");
                return;
            }

            a = (lbRepertoar.SelectedItem as Projekcija).Pid;
            foreach (Projekcija p in projekcije)
                if (p.Pid == a)
                    a = p.Pid;
            rezervacije.Add(new Rezervacije(a, idk, (int)numericUpDown1.Value, cena));
            MessageBox.Show("Uspesno ste dodali rezervaciju");


            for (int i = 0; i < projekcije.Count; i++)
            {
                if (projekcije[i].Pid == rezervacije[rezervacije.Count - 1].Pid)
                {
                    projekcije[i].Slobodna -= rezervacije[rezervacije.Count - 1].Brmst;
                }
            }

            fs = File.OpenWrite(putanjaprojekcije);
            bf = new BinaryFormatter();
            bf.Serialize(fs, projekcije);
            fs.Close();

            fs = File.OpenWrite(putanjarezervacije);
            bf = new BinaryFormatter();
            bf.Serialize(fs, rezervacije);
            fs.Close();

            frmKupac nazad = new frmKupac();

            this.poziv += new prosledi(nazad.ispisiPodatke);
            poziv(idk);
            nazad.Show();
            this.Close();
        }

        private void cmbSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbRepertoar.Items.Clear();

            fs = File.OpenRead(putanjaprojekcije);
            bf = new BinaryFormatter();
            projekcije = bf.Deserialize(fs) as List<Projekcija>;
            for (int i = 0; i < projekcije.Count; i++)
            {
                if (projekcije[i].Sala.Sid == (cmbSala.SelectedItem as Sala).Sid)
                    lbRepertoar.Items.Add(projekcije[i]);
            }
            fs.Close();
            btnDostupne.Enabled = true;
        }

        private void cmbFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbRepertoar.Items.Clear();
            fs = File.OpenRead(putanjaprojekcije);
            BinaryFormatter bf = new BinaryFormatter();
            projekcije = bf.Deserialize(fs) as List<Projekcija>;
            for (int i = 0; i < projekcije.Count; i++)
            {
                if (projekcije[i].Film.Fid == (cmbFilm.SelectedItem as Film).Fid)
                    lbRepertoar.Items.Add(projekcije[i]);
            }
            fs.Close();
            btnDostupne.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (lbRepertoar.SelectedItem == null)
                return;
            int broj = (int)numericUpDown1.Value;
            int id;
            id = (lbRepertoar.SelectedItem as Projekcija).Pid;
            foreach(Projekcija p in projekcije)
            {
                if (p.Pid == id)
                {
                    txtUkupno.Text = (p.Cena * broj).ToString();
                    if (broj >= p.Slobodna)
                    {
                        MessageBox.Show("Dostigli ste maximalan broj slobodnih mesta");
                        numericUpDown1.Value -= 1;
                        return;
                    }
                }
                    
            }
        }

        private void lbRepertoar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmRezervacija_FormClosing(object sender, FormClosingEventArgs e)
        {
            fs = File.OpenWrite(putanjarezervacije);
            bf.Serialize(fs, rezervacije);
            fs.Close();

            fs = File.OpenWrite(putanjaprojekcije);
            bf.Serialize(fs, projekcije);
            fs.Close();
           
        }
    }
}