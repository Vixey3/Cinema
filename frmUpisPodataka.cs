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
    public partial class frmUpisPodataka : Form
    {
        int pamtfiFilm, pamtiSalu, pamtiKupca, pamtiProjekciju;
        FileStream fs;
        BinaryFormatter bf;
        List<Film> filmovi;
        List<Sala> sale;
        List<Projekcija> projekcije;
        List<Kupac> kupci;
        List<Rezervacije> rezervacije;
        string putanjafilmovi = "filmovi.txt";
        string putanjakupci = "kupci.txt";
        string putanjasale = "sale.txt";
        string putanjaprojekcije = "projekcije.txt";
        string putanjarezervacije = "rezervacije.txt";

        public frmUpisPodataka()
        {
            InitializeComponent();
            filmovi = new List<Film>();
            sale = new List<Sala>();
            projekcije = new List<Projekcija>();
            rezervacije = new List<Rezervacije>();
            
            fs = File.OpenRead(putanjakupci);
            bf = new BinaryFormatter();
            kupci = bf.Deserialize(fs) as List<Kupac>;

            for (int i = 0; i < kupci.Count; i++)
            {
                pamtiKupca = kupci[kupci.Count - 1].Kid;
                
                cmbKorisnik.Items.Add(kupci[i]);
            }
            fs.Close();
            

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
                    cmbIDProjekcije.Items.Add(projekcije[i]);
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDodajFilm_Click(object sender, EventArgs e)
        {
            if (filmovi.Count > 0)
                pamtfiFilm = filmovi[filmovi.Count - 1].Fid;
            else
                pamtfiFilm = 0;

            int duz, god;
            if (txtNaziv.Text.Trim().Length == 0 || txtZanr.Text.Trim().Length == 0 || txtDuzinaTrajanja.Text.Trim().Length == 0 || txtGranicaGodina.Text.Trim().Length == 0)
            {
                MessageBox.Show("Niste uneli sva polja za film");
                return;
            }
            else if (!int.TryParse(txtDuzinaTrajanja.Text, out duz) || !int.TryParse(txtGranicaGodina.Text, out god))
            {
                MessageBox.Show("Morate uneti brojeve za duzinu trajanja i granicu godina");
                return;
            }

            filmovi.Add(new Film(pamtfiFilm+1,txtNaziv.Text, txtZanr.Text, duz, god));
            cmbFilm.Items.Add(filmovi[filmovi.Count - 1]);
            MessageBox.Show("Uspesno ste dodali film");
            txtNaziv.Clear();
            txtZanr.Clear();
            txtDuzinaTrajanja.Clear();
            txtGranicaGodina.Clear();

            fs = File.OpenWrite(putanjafilmovi);
            bf = new BinaryFormatter();
            bf.Serialize(fs, filmovi);
            fs.Close();
        }

        private void btnDodajSalu_Click(object sender, EventArgs e)
        {
            if (sale.Count > 0)
                pamtiSalu = sale[sale.Count - 1].Sid;
            else
                pamtiSalu = 0;

            int brsl, brsd;
            if(txtBrojSale.Text.Trim().Length==0 || txtBrojSedista.Text.Trim().Length == 0)
            {
                MessageBox.Show("Niste uneli sva polja za salu");
                return;
            }
            else if (!int.TryParse(txtBrojSale.Text, out brsl) || !int.TryParse(txtBrojSedista.Text, out brsd))
            {
                MessageBox.Show("Morate uneti brojeve za broj sale i broj sedista");
                return;
            }

            sale.Add(new Sala(pamtiSalu+1, brsl, brsd));
            cmbSala.Items.Add(sale[sale.Count - 1]);
            MessageBox.Show("Uspesno ste dodali salu");
            txtBrojSale.Clear();
            txtBrojSedista.Clear();

            fs = File.OpenWrite(putanjasale);
            bf = new BinaryFormatter();
            bf.Serialize(fs, sale);
            fs.Close();
        }

        private void btnDodajProjekciju_Click(object sender, EventArgs e)
        {
            if (projekcije.Count > 0)
                pamtiProjekciju = projekcije[projekcije.Count - 1].Pid;
            else
                pamtiProjekciju = 0;

            int cena;
            if(cmbFilm.SelectedItem == null || cmbSala.SelectedItem == null  || txtCenaKarte.Text.Trim().Length==0)
            {
                MessageBox.Show("Niste uneli sva polja za projekciju");
                return;
            }
            else if (!int.TryParse(txtCenaKarte.Text, out cena) )
            {
                MessageBox.Show("Morate uneti brojeve za cenu");
                return;
            }

            projekcije.Add(new Projekcija(pamtiProjekciju+1, dateTimePicker1.Value, cmbSala.SelectedItem as Sala, cena, dtpVremePocetka.Value, cmbFilm.SelectedItem as Film));
            cmbIDProjekcije.Items.Add(projekcije[projekcije.Count - 1]);
            MessageBox.Show("Uspesno ste dodali projekciju");
            txtCenaKarte.Clear();

            fs = File.OpenWrite(putanjaprojekcije);
            bf = new BinaryFormatter();
            bf.Serialize(fs, projekcije);
            fs.Close();
        }

        private void btnDodajRezervaciju_Click(object sender, EventArgs e)
        {
            int brm;
            double ukupno;

            if(cmbIDProjekcije.SelectedItem == null || cmbKorisnik.SelectedItem == null || txtBrojMesta.Text.Trim().Length==0 || txtUkupno.Text.Trim().Length==0)
            {
                MessageBox.Show("Niste uneli sva polja za rezervaciju");
                return;
            }
            else if (!int.TryParse(txtBrojMesta.Text, out brm) || !double.TryParse(txtUkupno.Text, out ukupno))
            {
                MessageBox.Show("Morate uneti brojeve za broj mesta i cenu!");
                return;
            }
            Projekcija p;
            p = cmbIDProjekcije.SelectedItem as Projekcija;
            Kupac k;
            k = cmbKorisnik.SelectedItem as Kupac;
            rezervacije.Add(new Rezervacije(p.Pid, k.Kid, brm, ukupno));
            MessageBox.Show("Uspesno ste dodali rezervaciju");
            txtBrojMesta.Clear();
            txtUkupno.Clear();

            for (int i = 0; i < projekcije.Count; i++)
                if (projekcije[i].Pid == (cmbIDProjekcije.SelectedItem as Projekcija).Pid)
                    projekcije[i].Slobodna -= brm;

            fs = File.OpenWrite(putanjarezervacije);
            bf = new BinaryFormatter();
            bf.Serialize(fs, rezervacije);
            fs.Close();
        }

        private void btnDodajKorisnika_Click(object sender, EventArgs e)
        {

            if (kupci.Count > 0)
                pamtiKupca = kupci[kupci.Count - 1].Kid;
            else
                pamtiKupca = 0;

            if (txtKorIme.Text.Trim().Length == 0 || txtSifra.Text.Trim().Length == 0 || txtIme.Text.Trim().Length == 0 || txtPrezime.Text.Trim().Length == 0 || txtTelefon.Text.Trim().Length == 0 || cmbPol.SelectedItem == null)
            {
                MessageBox.Show("Niste uneli sva polja za korisnika");
                return;
            }
            kupci.Add(new Kupac(pamtiKupca+1,txtKorIme.Text, txtSifra.Text, txtIme.Text, txtPrezime.Text, dtpKorisnik.Value, txtTelefon.Text, cmbPol.SelectedItem.ToString()));
            MessageBox.Show("Uspesno ste dodali korisnika");
            txtKorIme.Clear();
            txtSifra.Clear();
            txtIme.Clear();
            txtPrezime.Clear();
            txtTelefon.Clear();

            fs = File.OpenWrite(putanjakupci);
            bf = new BinaryFormatter();
            bf.Serialize(fs, kupci);
            fs.Close();
        }

        private void cmbKorisnik_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Prosledi(int f, int s, int p, int k)
        {
            pamtfiFilm = f;
            pamtiKupca = k;
            pamtiProjekciju = p;
            pamtiSalu = s;
        }

        private void frmUpisPodataka_Load(object sender, EventArgs e)
        {
            
        }

        private void txtBrojMesta_TextChanged(object sender, EventArgs e)
        {
            TextBox ukupno = sender as TextBox;
            int broj;
            int id;
            double suma = 0;
            id = cmbIDProjekcije.SelectedIndex;
            int.TryParse(txtBrojMesta.Text, out broj);
            for (int i = 0; i < projekcije.Count; i++)
            {
                if (projekcije[i].Pid == id+1)
                {
                    suma += projekcije[i].Cena * broj;
                }
            }

            txtUkupno.Text = suma.ToString();

        }

        private void cmbIDProjekcije_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmUpisPodataka_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAdmin admin = new frmAdmin();
            admin.Show();

            fs = File.OpenWrite(putanjakupci);
            bf.Serialize(fs, kupci);
            fs.Close();

            fs = File.OpenWrite(putanjarezervacije);
            bf.Serialize(fs, rezervacije);
            fs.Close();

            fs = File.OpenWrite(putanjaprojekcije);
            bf.Serialize(fs, projekcije);
            fs.Close();

            fs = File.OpenWrite(putanjasale);
            bf.Serialize(fs, sale);
            fs.Close();

            fs = File.OpenWrite(putanjafilmovi);
            bf.Serialize(fs, filmovi);
            fs.Close();
        }
    }
}