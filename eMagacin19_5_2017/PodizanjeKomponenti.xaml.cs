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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace eMagacin19_5_2017
{
    public partial class PodizanjeKomponenti : Window
    {
        public delegate void MyEventHandler();
        public event MyEventHandler Podignuto;

        Kutija kutijaZaPodizanje;
        public PodizanjeKomponenti(Kutija kutija)
        {
            InitializeComponent();
           imgSadrzaj.Source= new ImageSourceConverter().ConvertFromString(@kutija.Slika) as ImageSource;
            lbSadrzaj.Content = kutija.Sadrzaj;
            for (int i = 0; i <kutija.Kolicina; i++)
            {
                cbKolicinaSadrzaja.Items.Add((i+1));
            }
            cbKolicinaSadrzaja.SelectedIndex=kutija.Kolicina-1;
            kutijaZaPodizanje = kutija;
        }

        private void btnVrati_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPodigni_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connectionString);
            try
            {
                connection.Open();
                //Preostala kolicna komponenti.
                string query = "UPDATE magacin SET Kolicina=" + (Convert.ToInt32(kutijaZaPodizanje.Kolicina) - Convert.ToInt32(cbKolicinaSadrzaja.SelectedItem)) + " WHERE ID=" + kutijaZaPodizanje.ID+";";
                MySqlCommand command = new MySqlCommand(query,connection);
                command.ExecuteNonQuery();

                //Podizanje event-a Podignuto.
                Podignuto();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
