using System;
using System.Collections.Generic;
using System.IO;
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

namespace RicercaOrdinamento
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<string> elenco = new List<string>();
        private void txt_inserisci_Click(object sender, RoutedEventArgs e)
        {
            string ragazzo = txt_ragazzo.Text;
            elenco.Add(ragazzo);
            elenco.Sort();
            lbl_lista.Content = "";
            foreach(string r in elenco)
            {
              lbl_lista.Content += $"{r} \n"; 
            }
            txt_ragazzo.Clear();
        }

        private void btn_salva_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("file.txt", false, Encoding.UTF8))
            {
                foreach (string r in elenco)
                {
                    sw.WriteLine(r);
                }
                
            }
            MessageBox.Show("L'elenco è stato salvato", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btn_ricerca_Click(object sender, RoutedEventArgs e)
        {
            bool stato = false;
            string ric = txt_ricerca.Text;
            for (int i = 0;i<elenco.Count;i++)
            {
                if(elenco[i] == ric)
                {
                    stato = true;
                    break;
                }
                
            }
            if (stato == true)
            {
                MessageBox.Show("il nome fa parte della lista", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }else
            {

                MessageBox.Show("il nome non fa parte della lista", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            txt_ricerca.Clear();
        }
    }
}
