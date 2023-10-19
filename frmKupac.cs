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
    public partial class frmKupac : Form
    {
        public delegate void prosledi(int podaci);
        public prosledi poziv;

        FileStream fs;
        BinaryFormatter bf;
        int idk;
        string putanjarezervacije = "rezervacije.txt";
        string putanjaprojekcije = "projekcije.txt";
        List<Rezervacije> rezervacije;
        List<Projekcija> projekcije;
        public frmKupac()
        {
            InitializeComponent();
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

        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            frmRezervacija fr = new frmRezervacija();
            this.poziv = new prosledi(fr.ispisiPodatke);
            poziv(idk);
            fr.Show();
            this.Close();
        }

        public void ispisiPodatke(int podaci)
        {
            idk = podaci;
            label1.Text += podaci;
        }

        private void frmKupac_Load(object sender, EventArgs e)
        {
            if (File.Exists(putanjarezervacije))
            {
                fs = File.OpenRead(putanjarezervacije);
                bf = new BinaryFormatter();
                rezervacije = bf.Deserialize(fs) as List<Rezervacije>;

                fs.Close();
            }

            for (int i = 0; i < rezervacije.Count; i++)
            {
                if (rezervacije[i].Kid == idk)
                    lblRezervisani.Items.Add(rezervacije[i]);
            }
        }

        private void btnObrisi(object sender, EventArgs e)
        {
            if(lblRezervisani.SelectedItem == null)
            {
                MessageBox.Show("Nije izabrana rezervacija");
                return;
            }

            for (int i = 0; i < rezervacije.Count; i++)
            {
                
                if(lblRezervisani.SelectedItem as Rezervacije == rezervacije[i])
                {
                    lblRezervisani.Items.Clear();
                    rezervacije.RemoveAt(i);
                    for (int j = 0; j < rezervacije.Count; j++)
                    {
                        if (rezervacije[j].Kid == idk)
                            lblRezervisani.Items.Add(rezervacije[j]);
                    }

                    fs = File.OpenWrite(putanjarezervacije);
                    bf.Serialize(fs, rezervacije);
                    fs.Close();

                    MessageBox.Show("Uspesno ste obrisali rezervacijui");
                    return;
                }    
            }
        }

        private void lblRezervisani_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = (lblRezervisani.SelectedItem as Rezervacije).Brmst;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int broj = (int)numericUpDown1.Value;
            if (lblRezervisani.SelectedItem == null)
            {
                MessageBox.Show("Niste izabrali rezervaciju");
                numericUpDown1.Value = 0;
                return;
            }
            int id;
            id = (lblRezervisani.SelectedItem as Rezervacije).Pid;
            foreach (Projekcija p in projekcije)
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

            //foreach(Rezervacije r in rezervacije)
            //{
            //    foreach (Projekcija p in projekcije)
            //    {
            //        if ((lblRezervisani.SelectedItem as Rezervacije).Pid == p.Pid)
            //        {
            //            txtUkupno.Text = (p.Cena * broj).ToString();
            //            if (broj>=p.Slobodna)
            //            {
            //                MessageBox.Show("Premasili ste broj mesta");
            //                numericUpDown1.Value -= 1;
            //                return;
            //            }
            //        }
            //        r.Kid = idk;
            //        r.Pid = p.Pid;
            //        r.Brmst = broj;
            //        r.Ukupno = double.Parse(txtUkupno.Text);
            //        return;
            //    }

            //}

        }

        private void btnAzurirajRezervaciju(object sender, EventArgs e)
        {
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {

            double ukupno;
            if (lblRezervisani.SelectedItem == null)
            {
                MessageBox.Show("Nijedna rezervacija nije izabrana");
                return;
            }
            else if (!double.TryParse(txtUkupno.Text, out ukupno))
            {
                MessageBox.Show("Morate uneti brojeve za broj mesta");
                return;
            }

            for (int i = 0; i < rezervacije.Count; i++)
            {
                if (rezervacije[i] == lblRezervisani.SelectedItem as Rezervacije)
                {
                    rezervacije[i].Brmst = (int)numericUpDown1.Value;
                    rezervacije[i].Ukupno = ukupno;

                    MessageBox.Show("Uspešno ste ažurirali rezervacija");
                    lblRezervisani.Items.Clear();
                    for (int j = 0; j < rezervacije.Count; j++)
                    {
                        if (rezervacije[j].Kid == idk)
                            lblRezervisani.Items.Add(rezervacije[j]);
                    }

                    fs = File.OpenWrite(putanjarezervacije);
                    bf.Serialize(fs, rezervacije);
                    fs.Close();
                    break;
                }
            }
        }
    }
}
