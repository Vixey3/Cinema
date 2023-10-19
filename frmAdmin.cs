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
    public partial class frmAdmin : Form
    {
        public delegate void saljidalje(int f, int s, int p, int k);
        public saljidalje proslediDoUpisa;

        public delegate void pocetna(int k);
        public pocetna PocetnaKorisnik;

        int pamtfiFilm, pamtiSalu, pamtiKupca, pamtiProjekciju;
        FileStream fs;
        BinaryFormatter bf;
        List<Film> filmovi;
        List<Sala> sale;
        List<Projekcija> projekcije;
        List<Kupac> kupci;
        List<Rezervacije> rezervacije;
        frmUpisPodataka upis;
        frmPocetna pop;
        string putanjafilmovi = "filmovi.txt";
        string putanjakupci = "kupci.txt";
        string putanjasale = "sale.txt";
        string putanjaprojekcije = "projekcije.txt";
        string putanjarezervacije = "rezervacije.txt";
        public frmAdmin()
        {
           
            InitializeComponent();

            if (File.Exists(putanjafilmovi))
            {
                fs = File.OpenRead(putanjafilmovi);
                bf = new BinaryFormatter();
                filmovi = bf.Deserialize(fs) as List<Film>;
                for (int i = 0; i < filmovi.Count; i++)
                {
                    pamtfiFilm = filmovi[filmovi.Count - 1].Fid;
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
                    pamtiSalu = sale[sale.Count - 1].Sid;
                }
                fs.Close();
            }

            if (File.Exists(putanjaprojekcije))
            {
                fs = File.OpenRead(putanjaprojekcije);
                bf = new BinaryFormatter();
                projekcije = bf.Deserialize(fs) as List<Projekcija>;
                for (int i = 0; i < projekcije.Count; i++)
                {
                    pamtiProjekciju = projekcije[projekcije.Count - 1].Pid;
                }
                fs.Close();
            }

            if (File.Exists(putanjakupci))
            {
                fs = File.OpenRead(putanjakupci);
                bf = new BinaryFormatter();
                kupci = bf.Deserialize(fs) as List<Kupac>;
                for (int i = 0; i < kupci.Count; i++)
                {
                    pamtiKupca = kupci[kupci.Count - 1].Kid;
                    cmbKorisnik.Items.Add(kupci[i]);
                }
                fs.Close();
            }

            //MessageBox.Show("DAL IMA KUPCA UOPSTE "+ kupci[kupci.Count-1].Kid.ToString());

            if (kupci.Count > 0)
                pamtiKupca = kupci[kupci.Count - 1].Kid;
            else
                pamtiKupca = 0;

            if (File.Exists(putanjarezervacije))
            {
                fs = File.OpenRead(putanjarezervacije);
                bf = new BinaryFormatter();
                rezervacije = bf.Deserialize(fs) as List<Rezervacije>;
                fs.Close();
            }

           
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            pop = new frmPocetna();
            pop.Close();

            if (lstRezervacije.SelectedItem == null)
                return;

            if (File.Exists(putanjarezervacije))
            {
                fs = File.OpenRead(putanjarezervacije);
                bf = new BinaryFormatter();
                rezervacije = bf.Deserialize(fs) as List<Rezervacije>;

                fs.Close();
            }

            for (int i = 0; i < rezervacije.Count; i++)
            {
                if (rezervacije[i].Kid == (lstRezervacije.SelectedItem as Kupac).Kid)
                    lstRezervacije.Items.Add(rezervacije[i]);
            }
        }

        private void btnUpis_Click(object sender, EventArgs e)
        {
            upis = new frmUpisPodataka();
            this.proslediDoUpisa = new saljidalje(upis.Prosledi);
            proslediDoUpisa(pamtfiFilm, pamtiSalu, pamtiKupca, pamtiProjekciju);
            upis.Show();
            this.Close();
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            
            frmIzmenaPodataka izmena = new frmIzmenaPodataka();
            izmena.Show();
            this.Close();
        }

        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            pop = new frmPocetna();
            this.PocetnaKorisnik = new pocetna(pop.Ucitavanje);
            PocetnaKorisnik(pamtiKupca);
            this.Close();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            frmBrisanjePodataka brisanje = new frmBrisanjePodataka();
            brisanje.Show();
            this.Close();
        }

        public void Prosledi(int f, int s, int p, int k)
        {
            pamtfiFilm = f;
            pamtiKupca = k;
            pamtiProjekciju = p;
            pamtiSalu = s;
        }

        private void cmbKorisnik_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstRezervacije.Items.Clear();
            Kupac k = cmbKorisnik.SelectedItem as Kupac;
            foreach(Rezervacije r in rezervacije)
                if (r.Kid == k.Kid)
                    lstRezervacije.Items.Add(r);
        }
    }
}