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
    public partial class frmPocetna : Form
    {
        public delegate void prosledi(int podaci);
        public prosledi poziv;
        int pamtiKupca;
        FileStream fs;
        frmKupac f2;
        frmAdmin f3;
        string putanja;
        List<Kupac> kupci;
        Administrator admin;
        public frmPocetna()
        {
            InitializeComponent();
            putanja = "kupci.txt";
            if (File.Exists(putanja))
            {
                fs = File.OpenRead(putanja);
                BinaryFormatter bf = new BinaryFormatter();
                kupci = bf.Deserialize(fs) as List<Kupac>;
                fs.Close();
            }
            else
            {
                kupci = new List<Kupac>();
            }
            kupci = new List<Kupac>();
            txtKorisnicko.Focus();
            admin = new Administrator();

            dtpDatum.MaxDate = DateTime.UtcNow;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistracija_Click(object sender, EventArgs e)
        {
            if (kupci.Count > 0)
                pamtiKupca = kupci[kupci.Count - 1].Kid;
            else
                pamtiKupca = 0;

            if (txtKorisnicko.Text.Trim().Length == 0)
            {
                MessageBox.Show("Niste uneli korisnicko ime!");
                return;
            }
            else if (txtLozinka.Text.Trim().Length == 0)
            {
                MessageBox.Show("Niste uneli lozinku!");
                return;
            }
            else if (txtIme.Text.Trim().Length == 0)
            {
                MessageBox.Show("Niste uneli ime!");
                return;
            }
            else if (txtPrezime.Text.Trim().Length == 0)
            {
                MessageBox.Show("Niste uneli prezime!");
                return;
            }
            else if (txtTelefon.Text.Trim().Length == 0)
            {
                
                MessageBox.Show("Niste uneli broj telefona!");
                return;

            }
            else if (txtTelefon.Text.Trim().Length != 0)
            {
                char[] telefon = txtTelefon.Text.ToCharArray();
                foreach (char c in telefon)
                {
                    if (char.IsLetter(c))
                    {
                        MessageBox.Show("Telefon mora sadrzati samo brojeve!");
                        return;
                    }
                
                }
            }
            else if (!rbMuski.Checked && !rbZenski.Checked)
            {
                MessageBox.Show("Niste odabrali nijedan pol!");
                return;
            }

            string pol;
            if (rbMuski.Checked == true)
                pol = "Muski";
            else
                pol = "Zenski";

            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(putanja))
            {
                fs = File.OpenRead(putanja);
                kupci = bf.Deserialize(fs) as List<Kupac>;
                fs.Close();
            }

            foreach (Kupac k in kupci)
                if (k.Korime == txtKorisnicko.Text)
                {
                    MessageBox.Show("Korisnik je vec registrovan");
                    txtKorisnicko.Clear();
                    txtLozinka.Clear();
                    txtIme.Clear();
                    txtPrezime.Clear();
                    txtTelefon.Clear();
                    txtKorisnicko.Focus();
                    rbMuski.Checked = false;
                    rbZenski.Checked = false;
                    return;
                }

            if (File.Exists(putanja))
                fs = new FileStream(putanja, FileMode.Append, FileAccess.Write);
            else
                fs = new FileStream(putanja, FileMode.Create, FileAccess.Write);
            
            Kupac nov = new Kupac(kupci.Count+1,txtKorisnicko.Text.Trim(), txtLozinka.Text.Trim(), txtIme.Text.Trim(), txtPrezime.Text.Trim(), dtpDatum.Value, txtTelefon.Text.Trim(), pol);
            kupci.Add(nov);
            bf.Serialize(fs, kupci);
            fs.Dispose();

            //StreamWriter sw = new StreamWriter(fs);
            //sw.WriteLine(nov);
            //sw.Flush();
            //sw.Close();


            fs = File.OpenWrite(putanja);
            bf = new BinaryFormatter();
            bf.Serialize(fs, kupci);
            fs.Close();

            txtKorisnicko.Clear();
            txtLozinka.Clear();
            txtIme.Clear();
            txtPrezime.Clear();
            txtTelefon.Clear();
            txtKorisnicko.Focus();
            rbMuski.Checked = false;
            rbZenski.Checked = false;

            MessageBox.Show("Uspesno ste se registrovali!");
        }

        public void Ucitavanje(int  k)
        {
            pamtiKupca = k;
        }

        private void txtLozinka_TextChanged(object sender, EventArgs e)
        {
            //loz = txtLozinka.Text;
            //TextBox lozinka = sender as TextBox;
            //string s = "";
            //foreach (char c in txtLozinka.Text)
            //{
            //    loz += c;
            //    s += "*";
            //}
            //txtLozinka.Text = s;
        }


        private void txtPrijavaLozinka_TextChanged(object sender, EventArgs e)
        {
            //TextBox lozinka = sender as TextBox;
            //string s = "";
            //foreach (char c in txtPrijavaLozinka.Text)
            //{
            //    ploz += c;
            //    s += "*";
            //}
            //txtPrijavaLozinka.Text = s;
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            if (kupci.Count > 0)
                pamtiKupca = kupci[kupci.Count - 1].Kid;
            else
                pamtiKupca = 0;

            if (txtPrijavaKorisnicko.Text.Trim().Length == 0 || txtPrijavaLozinka.Text.Trim().Length == 0)
            {
                MessageBox.Show("Niste uneli nijedno polje");
                return;
            }
            else if(!File.Exists(putanja) && kupci.Count==0)
            {
                MessageBox.Show("Ne postoji korisnik u bazi");
                return;
            }

            if (txtPrijavaKorisnicko.Text == admin.Korime && txtPrijavaLozinka.Text.Trim() == admin.Sifra)
            {
                MessageBox.Show("Prijavili ste se kao admin");
                f3 = new frmAdmin();
                f3.Show();
            } 
            else
            {
                BinaryFormatter bf = new BinaryFormatter();
                fs = File.OpenWrite(putanja);
                if(kupci.Count>0)
                    bf.Serialize(fs, kupci);
                fs.Close();

                fs = File.OpenRead(putanja);
                kupci = bf.Deserialize(fs) as List<Kupac>;

                foreach (Kupac k in kupci)
                {
                    if (txtPrijavaKorisnicko.Text.Trim() == k.Korime && txtPrijavaLozinka.Text.Trim() == k.Sifra)
                    {
                        MessageBox.Show("Uspesno logovanje");
                        f2 = new frmKupac();
                        this.poziv = new prosledi(f2.ispisiPodatke);
                        poziv(k.Kid);
                        f2.Show();
                        fs.Close();
                        return;
                    }
                }
                MessageBox.Show("Korisnik ne postoji");
                fs.Close();
            }
            txtPrijavaKorisnicko.Clear();
            txtPrijavaLozinka.Clear();
        }
    }
}