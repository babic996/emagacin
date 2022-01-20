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
using MySql.Data.MySqlClient;
using System.IO;
using Microsoft.Win32;

namespace eMagacin19_5_2017
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection connection;

        public MainWindow()
        {
            InitializeComponent();
            inicijalizujKutije();
        }

        private void inicijalizujKutije()
        {
            connection = new MySqlConnection(Properties.Settings.Default.connectionString);
            try
            {
                connection.Open();
                wpPanelMagacin.Children.Clear();
                string query = "SELECT * FROM magacin;";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {                                                                                                                                                                                                                                                //Metode sa Action delegatom se prosljedjuju na ovaj nacin                                                                                                                                                                                                                                              // s tim da su po potrebi u zagradama mogli biti argumenti npr: ()=>NekaMetoda(nekiBroj,nekiString)
                    Kutija kutija = new Kutija(Convert.ToInt32(reader["LadicaBroj"].ToString()), reader["Sadrzaj"].ToString(), reader["Slika"].ToString(), Convert.ToInt32(reader["Kolicina"].ToString()), Convert.ToInt32(reader["ID"].ToString()), () => inicijalizujKutije());
                    wpPanelMagacin.Children.Add(kutija);
                }
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

        //Pomjeranje prozora.
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            gridMeni.Visibility = Visibility.Hidden;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMeni_Click(object sender, RoutedEventArgs e)
        {
            if (gridMeni.Visibility == Visibility.Hidden)
            {
                gridMeni.Visibility = Visibility.Visible;
            }
            else
            {
                gridMeni.Visibility = Visibility.Hidden;
            }
        }

        private void btnKomponenteNaStanju_Click(object sender, RoutedEventArgs e)
        {
            if (btnKomponenteNaStanju.Content == "Pregled komponenti na stanju")
            {
                if (procitajOdredjeneKomponenteIzMagacina("SELECT * FROM magacin WHERE Kolicina>0"))
                {
                    btnKomponenteNaStanju.Content = "Pregled svih komponenti";
                    btnKomponenteKojihNema.Content = "Pregled komponenti kojih nema na stanju";
                }
            }
            else
            {
                inicijalizujKutije();
                btnKomponenteNaStanju.Content = "Pregled komponenti na stanju";
                btnKomponenteKojihNema.Content = "Pregled komponenti kojih nema na stanju";
            }
            gridMeni.Visibility = Visibility.Hidden;
        }

        private bool procitajOdredjeneKomponenteIzMagacina(string query)
        {
            bool uspjesno = false;
            try
            {
                connection.Open();
                wpPanelMagacin.Children.Clear();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Kutija kutija = new Kutija(Convert.ToInt32(reader["LadicaBroj"].ToString()), reader["Sadrzaj"].ToString(), reader["Slika"].ToString(), Convert.ToInt32(reader["Kolicina"].ToString()), Convert.ToInt32(reader["ID"].ToString()), () => inicijalizujKutije());
                    wpPanelMagacin.Children.Add(kutija);
                }
                uspjesno= true;
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
            return uspjesno;
        }

        private void btnKomponenteKojihNema_Click(object sender, RoutedEventArgs e)
        {
            if (btnKomponenteKojihNema.Content == "Pregled komponenti kojih nema na stanju")
            {
                if (procitajOdredjeneKomponenteIzMagacina("SELECT * FROM magacin WHERE Kolicina=0"))
                {
                    btnKomponenteKojihNema.Content = "Pregled svih komponenti";
                    btnKomponenteNaStanju.Content = "Pregled komponenti na stanju";
                }
            }
            else
            {
                inicijalizujKutije();
                btnKomponenteNaStanju.Content = "Pregled komponenti na stanju";
                btnKomponenteKojihNema.Content = "Pregled komponenti kojih nema na stanju";
            }
            gridMeni.Visibility = Visibility.Hidden;
        }

        private void btnStanjeTxt_Click(object sender, RoutedEventArgs e)
        {
           SaveFileDialog savefd= new SaveFileDialog();
            savefd.Filter = "Text document (*.txt)|*.txt";
            if (savefd.ShowDialog()==true)
            {
                try
                {
                    File.WriteAllLines(savefd.FileName, procitajUStringKomponenteIzMagacina().Split('\n'));
                    MessageBox.Show(procitajUStringKomponenteIzMagacina());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

            gridMeni.Visibility = Visibility.Hidden;
        }

        private string procitajUStringKomponenteIzMagacina()
        {
            string ispis = "";
            try
            {
                connection.Open();
                string query = "SELECT * FROM magacin;";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ispis += "Ladica broj: " + reader["LadicaBroj"].ToString() + ". " + reader["Sadrzaj"].ToString() + "  Kolicina: " + reader["Kolicina"].ToString() + "\n";
                }
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
            return ispis;
        }
    }
}

