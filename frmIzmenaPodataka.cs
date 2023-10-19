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
    public partial class frmIzmenaPodataka : Form
    {
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
        public frmIzmenaPodataka()
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
                cmbIzmenaKorisnika.Items.Add(k);

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

            if (File.Exists(putanjaprojekcije))
            {
                fs = File.OpenRead(putanjaprojekcije);
                bf = new BinaryFormatter();
                projekcije = bf.Deserialize(fs) as List<Projekcija>;
                for (int i = 0; i < projekcije.Count; i++)
                {
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

        private void cmbKorisnik_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void frmIzmenaPodataka_Load(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {


        }

        private void cmbFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            Film f = cmbFilm.SelectedItem as Film;
            txtNaziv.Text = f.Naziv;
            txtZanr.Text = f.Zanr;
            txtDuzinaTrajanja.Text = f.Duzina.ToString();
            txtGranicaGodina.Text = f.Granica.ToString();
        }

        private void cmbSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sala s = cmbSala.SelectedItem as Sala;
            txtBrojSale.Text = s.Brsl.ToString();
            txtBrojSedista.Text = s.Ukupan.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Projekcija p = cmbProjekcija.SelectedItem as Projekcija;
            cmbProjekcijaFilma.Items.Clear();
            cmbProjekcijaFilma.Items.Add(p.Film);
            cmbProjekcijaSala.Items.Clear();
            cmbProjekcijaSala.Items.Add(p.Sala);
            dtpProjekcije.Value = p.Pdatum;
            dtpPocetakVremena.Value = p.Vreme;
            txtCenaKarte.Text = p.Cena.ToString();
        }

        private void cmbIzmenaKorisnika_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kupac k = cmbIzmenaKorisnika.SelectedItem as Kupac;
            txtKorIme.Text = k.Korime;
            txtSifra.Text = k.Sifra;
            txtIme.Text = k.Ime;
            txtPrezime.Text = k.Prezime;
            dtpKorisnik.Value = k.Datum;
            txtTelefon.Text = k.Telefon;
            cmbPol.SelectedItem = k.Pol;
        }

        private void cmbRezervacija_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rezervacije r = cmbRezervacija.SelectedItem as Rezervacije;
            cmbKorisnik.Items.Clear();
            cmbKorisnik.Items.Add(r.Kid);
            cmbIDProjekcije.Items.Clear();
            cmbIDProjekcije.Items.Add(r.Pid);
            txtBrojMesta.Text = r.Brmst.ToString();
            txtUkupnaCena.Text = r.Ukupno.ToString();
        }

        private void btnIzmeniSalu_Click(object sender, EventArgs e)
        {
            int brsl, brsd;
            if(cmbSala.SelectedItem == null)
            {
                MessageBox.Show("Nijedna sala nije izabrana");
                return;
            }

            else if(txtBrojSale.Text.Trim().Length==0 || txtBrojSedista.Text.Trim().Length==0)
            {
                MessageBox.Show("Nisu popunjena sva polja za salu");
                return;
            }

            else if(!int.TryParse(txtBrojSale.Text, out brsl) || !int.TryParse(txtBrojSedista.Text, out brsd))
            {
                MessageBox.Show("Morate uneti brojeve za broj sale i broj sedista");
                return;
            }


            for (int i = 0; i < projekcije.Count; i++)
                if (projekcije[i].Sala.Sid == (cmbSala.SelectedItem as Sala).Sid)
                    projekcije[i].Slobodna = brsd;


            for (int i = 0; i < sale.Count; i++)
            {
                if (sale[i] == cmbSala.SelectedItem as Sala)
                {
                    sale[i].Brsl = brsl;
                    sale[i].Ukupan = brsd;

                    MessageBox.Show("Uspesno ste azurirali salu");
                    cmbSala.Items.Clear();
                    foreach (Sala s in sale)
                        cmbSala.Items.Add(s);
                    break;
                }
            }

            txtBrojSale.Clear();
            txtBrojSedista.Clear();
        }

        private void btnIzmeniFilm_Click(object sender, EventArgs e)
        {
            int duz, god;
            if(cmbFilm.SelectedItem == null)
            {
                MessageBox.Show("Nijedan film nije izabaran");
                return;
            }

            else if(txtNaziv.Text.Trim().Length == 0 || txtZanr.Text.Trim().Length == 0 || txtDuzinaTrajanja.Text.Trim().Length == 0 || txtGranicaGodina.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nisu popunjena sva polja za film");
                return;
            }

            else if (!int.TryParse(txtDuzinaTrajanja.Text, out duz) || !int.TryParse(txtGranicaGodina.Text, out god))
            {
                MessageBox.Show("Morate uneti brojeve za duzinu trajanja i granicu godina");
                return;
            }

            

            for (int i = 0; i < filmovi.Count; i++)
            {
                if (filmovi[i] == cmbFilm.SelectedItem as Film)
                {
                    foreach (Projekcija p in projekcije)
                        if (p.Film.Naziv == filmovi[i].Naziv)
                            p.Film.Naziv = txtNaziv.Text;

                    filmovi[i].Naziv = txtNaziv.Text;
                    filmovi[i].Zanr = txtZanr.Text;
                    filmovi[i].Duzina = duz;
                    filmovi[i].Granica = god;

                    
                    MessageBox.Show("Uspesno ste azurirali film");
                    cmbFilm.Items.Clear();
                    foreach (Film f in filmovi)
                    { 
                        cmbFilm.Items.Add(f);
                        cmbProjekcijaFilma.Items.Add(f);
                    }

                    

                    break;
                }
            }

            cmbProjekcija.Items.Clear();
            foreach (Projekcija p in projekcije)
            {
                cmbProjekcija.Items.Add(p);
            }

            txtNaziv.Clear();
            txtZanr.Clear();
            txtDuzinaTrajanja.Clear();
            txtGranicaGodina.Clear();

            fs = File.OpenWrite(putanjafilmovi);
            bf = new BinaryFormatter();
            bf.Serialize(fs, filmovi);
            fs.Close();
        }

        private void btnIzmeniKorisnika_Click(object sender, EventArgs e)
        {
            if(cmbIzmenaKorisnika.SelectedItem == null)
            {
                MessageBox.Show("Nijedan korisnik nije izabaran");
                return;
            }

            else if(txtKorIme.Text.Trim().Length == 0 || txtSifra.Text.Trim().Length == 0 || txtIme.Text.Trim().Length == 0 || txtPrezime.Text.Trim().Length == 0 || txtTelefon.Text.Trim().Length == 0 || cmbPol.SelectedItem == null)
            {
                MessageBox.Show("Nisu popunjena sva polja za korisnika");
                return;
            }

            for (int i = 0; i < kupci.Count; i++)
            {
                if(kupci[i] == cmbIzmenaKorisnika.SelectedItem as Kupac)
                {
                    kupci[i].Korime = txtKorIme.Text;
                    kupci[i].Sifra = txtSifra.Text;
                    kupci[i].Ime = txtIme.Text;
                    kupci[i].Prezime = txtPrezime.Text;
                    kupci[i].Datum = dtpKorisnik.Value;
                    kupci[i].Telefon = txtTelefon.Text;
                    kupci[i].Pol = cmbPol.SelectedItem.ToString();

                    MessageBox.Show("Uspešno ste ažurirali korisnika");
                    cmbIzmenaKorisnika.Items.Clear();
                    foreach (Kupac k in kupci)
                        cmbIzmenaKorisnika.Items.Add(k);
                    break;
                }
            }

            txtKorIme.Clear();
            txtSifra.Clear();
            txtIme.Clear();
            txtPrezime.Clear();
            txtTelefon.Clear();
        }

        private void btnIzmeniProjekciju_Click(object sender, EventArgs e)
        {
            double cena;
            if (cmbProjekcija.SelectedItem == null)
            {
                MessageBox.Show("Nijedna projekcija nije izabrana");
                return;
            }

            else if (cmbProjekcijaFilma.SelectedItem == null || cmbProjekcijaSala.SelectedItem == null  || txtCenaKarte.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nisu popunjena sva polja za projekciju");
                return;
            }

            else if(!double.TryParse(txtCenaKarte.Text, out cena))
            {
                MessageBox.Show("Morate uneti brojeve za cenu karata");
                return;
            }

            for (int i = 0; i < projekcije.Count; i++)
            {
                if (projekcije[i] == cmbProjekcija.SelectedItem as Projekcija)
                {
                    projekcije[i].Film = cmbProjekcijaFilma.SelectedItem as Film;
                    projekcije[i].Sala = cmbProjekcijaSala.SelectedItem as Sala;
                    projekcije[i].Pdatum = dtpProjekcije.Value;
                    projekcije[i].Vreme = dtpPocetakVremena.Value;
                    projekcije[i].Cena = cena;

                    MessageBox.Show("Uspešno ste ažurirali projekciju");
                    cmbProjekcija.Items.Clear();
                    foreach (Projekcija k in projekcije)
                        cmbProjekcija.Items.Add(k);
                    break;
                }
            }

            txtCenaKarte.Clear();
            cmbProjekcijaFilma.SelectedItem = null;
            cmbProjekcijaSala.SelectedItem = null;
        }

        private void btnIzmeniRezervaciju_Click(object sender, EventArgs e)
        {
            int brm;
            double ukupno;
            if (cmbRezervacija.SelectedItem == null)
            {
                MessageBox.Show("Nijedna rezervacija nije izabrana");
                return;
            }
            else if(cmbKorisnik.SelectedItem == null || cmbIDProjekcije.SelectedItem == null || txtBrojMesta.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nisu popunjena sva polja za rezervaciju");
                return;
            }
            else if(!int.TryParse(txtBrojMesta.Text, out brm) || !double.TryParse(txtUkupnaCena.Text, out ukupno))
            {
                MessageBox.Show("Morate uneti brojeve za broj mesta");
                return;
            }


            for (int i = 0; i < rezervacije.Count; i++)
            {
                if (rezervacije[i].Pid == (cmbRezervacija.SelectedItem as Rezervacije).Pid)
                {
                    Projekcija p;
                    p = cmbIDProjekcije.SelectedItem as Projekcija;
                    Kupac k;
                    k = cmbKorisnik.SelectedItem as Kupac;

                    rezervacije[i].Kid = (int)cmbKorisnik.SelectedItem;
                    rezervacije[i].Pid = (int)cmbIDProjekcije.SelectedItem;
                    
                    for(int j = 0; j<projekcije.Count;j++)
                    {
                        if(projekcije[j].Pid==rezervacije[i].Pid)
                        {
                            if (rezervacije[i].Brmst < brm)
                                projekcije[j].Slobodna -= Math.Abs(projekcije[j].Slobodna - brm);
                            else if (rezervacije[i].Brmst > brm)
                                projekcije[j].Slobodna += Math.Abs(projekcije[j].Slobodna - brm);

                        }
                    }
                    rezervacije[i].Brmst = brm;
                    rezervacije[i].Ukupno = ukupno;

                    MessageBox.Show("Uspešno ste ažurirali rezervacija");
                    cmbRezervacija.Items.Clear();
                    foreach (Rezervacije r in rezervacije)
                        cmbRezervacija.Items.Add(r);
                    break;
                }
            }

            cmbKorisnik.SelectedItem = null;
            txtUkupnaCena.Clear();
            txtBrojMesta.Clear();
        }

        private void txtBrojMesta_TextChanged(object sender, EventArgs e)
        {
            if (cmbRezervacija.SelectedItem == null)
                return;

            int broj;
            int id;
            double suma = 0;
            Rezervacije r = cmbRezervacija.SelectedItem as Rezervacije;
            id = r.Pid;
            int.TryParse(txtBrojMesta.Text, out broj);
            for (int i = 0; i < projekcije.Count; i++)
            {
                if (projekcije[i].Pid == id )
                {
                    suma += projekcije[i].Cena * broj;
                }
            }
            txtUkupnaCena.Text = suma.ToString();
        }

        private void frmIzmenaPodataka_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAdmin nova = new frmAdmin();
            nova.Show();

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
