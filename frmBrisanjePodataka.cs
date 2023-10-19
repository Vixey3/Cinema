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
    public partial class frmBrisanjePodataka : Form
    {
        public delegate void prosledi(int f, int s, int p, int k);
        public prosledi prosledjivanje;

        int pamtfiFilm, pamtiSalu, pamtiKupca, pamtiProjekciju;
        FileStream fs;
        BinaryFormatter bf;
        List<Film> filmovi;
        List<Sala> sale;
        List<Projekcija> projekcije;
        List<Kupac> kupci;
        List<Rezervacije> rezervacije;
        frmAdmin frma;
        string putanjafilmovi = "filmovi.txt";
        string putanjakupci = "kupci.txt";
        string putanjasale = "sale.txt";
        string putanjaprojekcije = "projekcije.txt";
        string putanjarezervacije = "rezervacije.txt";

        public frmBrisanjePodataka()
        {
            InitializeComponent();
            filmovi = new List<Film>();
            sale = new List<Sala>();
            projekcije = new List<Projekcija>();
            rezervacije = new List<Rezervacije>();

            fs = File.OpenRead(putanjakupci);
            bf = new BinaryFormatter();
            kupci = bf.Deserialize(fs) as List<Kupac>;
            fs.Close();


            foreach (Kupac k in kupci)
                cmbKorisnik.Items.Add(k);

            if (kupci.Count > 0)
                pamtiKupca = kupci[kupci.Count - 1].Kid;
            else
                pamtiKupca = 0;

            if (File.Exists(putanjafilmovi))
            {
                fs = File.OpenRead(putanjafilmovi);
                bf = new BinaryFormatter();
                filmovi = bf.Deserialize(fs) as List<Film>;
                for (int i = 0; i < filmovi.Count; i++)
                {
                    pamtfiFilm = filmovi[filmovi.Count - 1].Fid;
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
                    pamtiSalu = sale[sale.Count - 1].Sid;
                    cmbSala.Items.Add(sale[i]);
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
                    cmbProjekcija.Items.Add(projekcije[i]);
                }
                fs.Close();
            }

            if (File.Exists(putanjarezervacije))
            {
                fs = File.OpenRead(putanjarezervacije);
                bf = new BinaryFormatter();
                rezervacije = bf.Deserialize(fs) as List<Rezervacije>;
                for (int i = 0; i < rezervacije.Count; i++)
                {
                    cmbRezervacija.Items.Add(rezervacije[i]);
                }
                fs.Close();
            }
        }

        private void frmBrisanjePodataka_Load(object sender, EventArgs e)
        {

        }

        private void btnObrisiProjekciju_Click(object sender, EventArgs e)
        {
            int a;
            Projekcija p = cmbProjekcija.SelectedItem as Projekcija;
            a = p.Pid;
            foreach(Rezervacije r in rezervacije)
            {
                if(r.Pid == a)
                {
                    MessageBox.Show("Ne mozete obrisati projekciju jer postoji rezervacija vezana za nju!");
                    return;
                }
            }

            if (cmbProjekcija.SelectedItem == null)
            {
                MessageBox.Show("Niste nista selektovali");
                return;
            }

            for (int i = 0; i < projekcije.Count; i++)
            {
                if (projekcije[i] == cmbProjekcija.SelectedItem as Projekcija)
                {
                    projekcije.RemoveAt(i);
                    i--;
                }
            }

            //for (int i = 0; i < projekcije.Count; i++)
            //{
            //    projekcije[i].Pid = i + 1;
            //}

            cmbProjekcija.Items.Clear();
            foreach (Projekcija proj in projekcije)
                cmbProjekcija.Items.Add(proj);
            MessageBox.Show("Uspesno ste obrisali projekciju");

            fs = File.OpenWrite(putanjaprojekcije);
            bf = new BinaryFormatter();
            bf.Serialize(fs, projekcije);
            fs.Close();

        }

        private void btnObrisiFilm_Click(object sender, EventArgs e)
        {

            if (cmbFilm.SelectedItem == null)
            {
                MessageBox.Show("Niste nista selektovali");
                return;
            }

            int a;
            Film f = cmbFilm.SelectedItem as Film;
            a = f.Fid;
            foreach (Projekcija p in projekcije)
            {
                if (p.Film.Fid == a)
                {
                    MessageBox.Show("Ne mozete obrisati film jer postoji projekcija vezana za taj film!");
                    return;
                }
            }

            for (int i = 0; i < filmovi.Count; i++)
            {
                if (filmovi[i] == cmbFilm.SelectedItem as Film)
                {
                    filmovi.RemoveAt(i);
                    i--;
                }
            }

            
            //for (int i = 0; i < filmovi.Count; i++)
            //{
            //    filmovi[i].Fid = i + 1;
            //}

            MessageBox.Show("Uspesno ste obrisali film");

            fs = File.OpenWrite(putanjafilmovi);
            bf = new BinaryFormatter();
            bf.Serialize(fs, filmovi);
            fs.Close();

            cmbFilm.Items.Clear();
            foreach (Film film in filmovi)
                cmbFilm.Items.Add(film);
        }

        private void btnObrisiSalu_Click(object sender, EventArgs e)
        {

            int a;
            Sala s = cmbSala.SelectedItem as Sala;
            a = s.Sid;
            foreach (Projekcija p in projekcije)
            {
                if (p.Sala.Sid == a)
                {
                    MessageBox.Show("Ne mozete obrisati salu jer postoji projekcija vezana za tu salu!");
                    return;
                }
            }

            if (cmbSala.SelectedItem == null)
            {
                MessageBox.Show("Niste nista selektovali");
                return;
            }

            for (int i = 0; i < sale.Count; i++)
            {
                if (sale[i] == cmbSala.SelectedItem as Sala)
                {
                    sale.RemoveAt(i);
                    i--;
                }
            }

            //for (int i = 0; i < sale.Count; i++)
            //{
            //    sale[i].Sid = i + 1;
            //}

            MessageBox.Show("Uspesno ste obrisali salu");
            fs = File.OpenWrite(putanjasale);
            bf = new BinaryFormatter();
            bf.Serialize(fs, sale);
            fs.Close();

            cmbSala.Items.Clear();
            foreach (Sala sala in sale)
                cmbSala.Items.Add(sala);
        }

        private void frmBrisanjePodataka_FormClosing(object sender, FormClosingEventArgs e)
        {
            frma = new frmAdmin();
            this.prosledjivanje = new prosledi(frma.Prosledi);
            prosledjivanje(pamtfiFilm, pamtiSalu, pamtiKupca, pamtiProjekciju);
            frma.Show();
        }

        private void btnObrisiRezervaciju_Click(object sender, EventArgs e)
        {
            if (cmbRezervacija.SelectedItem == null)
            {
                MessageBox.Show("Niste nista selektovali");
                return;
            }

            for (int i = 0; i < rezervacije.Count; i++)
            {
                if (rezervacije[i] == cmbRezervacija.SelectedItem as Rezervacije)
                {
                    for (int j = 0; j < projekcije.Count; j++)
                        if(projekcije[j].Pid == (cmbRezervacija.SelectedItem as Rezervacije).Pid)
                            projekcije[j].Slobodna += rezervacije[i].Brmst;
                    rezervacije.RemoveAt(i);
                    i--;
                }
            }

            MessageBox.Show("Uspesno ste obrisali rezervaciju");

            fs = File.OpenWrite(putanjarezervacije);
            bf = new BinaryFormatter();
            bf.Serialize(fs, rezervacije);
            fs.Close();

            cmbRezervacija.Items.Clear();
            foreach (Rezervacije r in rezervacije)
                cmbRezervacija.Items.Add(r);
        }

        private void btnObrisiKorisnika_Click(object sender, EventArgs e)
        {

            int a;
            Kupac k = cmbKorisnik.SelectedItem as Kupac;
            a = k.Kid;
            foreach (Rezervacije r in rezervacije)
            {
                if (r.Kid == a)
                {
                    MessageBox.Show("Ne mozete obrisati korisnika jer on ima rezervaciju!");
                    return;
                }
            }


            if (cmbKorisnik.SelectedItem == null)
            {
                MessageBox.Show("Niste nista selektovali");
                return;
            }

            for (int i = 0; i < kupci.Count; i++)
            {
                if (kupci[i] == cmbKorisnik.SelectedItem as Kupac)
                {
                    kupci.RemoveAt(i);
                    i--;
                }
            }

            MessageBox.Show("Uspesno ste obrisali korisnika");

            //for (int i = 0; i < kupci.Count; i++)
            //{
            //    kupci[i].Kid = i + 1;
            //}

            fs = File.OpenWrite(putanjakupci);
            bf = new BinaryFormatter();
            bf.Serialize(fs, kupci);
            fs.Close();

            cmbKorisnik.Items.Clear();
            foreach (Kupac Kupac in kupci)
                cmbKorisnik.Items.Add(Kupac);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}