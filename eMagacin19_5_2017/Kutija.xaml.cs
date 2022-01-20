using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eMagacin19_5_2017
{
    /// <summary>
    /// Interaction logic for Kutija.xaml
    /// </summary>
    public partial class Kutija : UserControl
    {
        private int id;
        private string slika;
        private string sadrzaj;
        private int kolicina;
        public int ID
        {
            get { return id; }
        }
        public int Kolicina
        {
            get { return kolicina; }
        }
        public string Slika
        {
            get { return slika; }
        }
        public string Sadrzaj
        {
            get { return sadrzaj; }
        }

        private Action metodaUKojuSeProsljedjuje;
        public Kutija(int brojKutije, string sadrzaj, string slika, int kolicina, int id,Action metodaZaPonovnoUcitavanjewpPanelMagacin)
        {
            InitializeComponent();
            this.id = id;
            this.kolicina = kolicina;
            this.sadrzaj = sadrzaj;
            this.slika = slika;
            lbRedniBroj.Content = brojKutije.ToString();
            lbSadrzaj.Content = sadrzaj;
            imgKutije.Source = new ImageSourceConverter().ConvertFromString(@"Resources\"+slika) as ImageSource;
            if (kolicina > 0)
            {
                rectPozadina.Fill =  Brushes.Green;
            }
            else
            {
                rectPozadina.Fill = Brushes.Red;
            }
            metodaUKojuSeProsljedjuje = metodaZaPonovnoUcitavanjewpPanelMagacin;
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.Kolicina > 0)
            {
                //prosljedjuje Kutiju
                PodizanjeKomponenti podizanjeKomp = new PodizanjeKomponenti(this);

                //Kada podigne komponente ponovo iscitaj iz baze podataka u wrap panel.
                podizanjeKomp.Podignuto += () => { metodaUKojuSeProsljedjuje(); };

                podizanjeKomp.ShowDialog();

            }
            else
            {
                MessageBox.Show("Nema komponenti na raspolaganju za podizanje.");
            }
        }
    }
}
