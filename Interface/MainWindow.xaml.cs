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
using System.Windows.Threading;

namespace Interface
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filename = "";
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(TimerReadFile);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
            resultBolck.Text = "";
        }

        private void TimerReadFile(object sender, EventArgs e)
        {
            //string path = @"c:\temp\MyTest.txt";
            string path = @"C:\Users\Eliott\source\repos\jaber-project\TestFile.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadToEnd();
                    resultBolck.Text = line;
                }
            }
            catch (Exception ex)
            {
                resultBolck.Text = "En attente du resultat";
            }
        }


        private void BrowseBT_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";
            dlg.Filter = "TXT Files (*.txt)|*.txt|PNG Files (*.png)|*.png";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                filename = dlg.FileName;
                textBox1.Text = filename;
            }
        }

        private void sendBT_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\Eliott\source\repos\jaber-project\DNAFile.txt";
            /*
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
            */
            File.Copy(filename, path, true);
        }
    }
}
