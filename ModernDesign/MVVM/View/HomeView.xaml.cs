using System;
using System.Collections.Generic;
using System.ComponentModel;
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

using System.IO;
using Path = System.IO.Path;

namespace ModernDesign.MVVM.View
{
    /// <summary>
    /// Logica di interazione per HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private int count;


        public HomeView()
        {
            InitializeComponent();
            count = 0;
            HomeView_Loaded();

        }
        private async void HomeView_Loaded()
        {
            try
            {
                using (var sr = new StreamReader("C:\\Users\\BIBY\\source\\repos\\applicazione desktop\\ModernDesign\\ModernDesign\\MVVM\\View\\pino.txt"))
                {
                    count = Int32.Parse(await sr.ReadToEndAsync());
                    Conta.Text = count.ToString();
                }
            }
            catch (FileNotFoundException ex)
            {
                Conta.Text = ex.Message;
            }
        }

        private void CambioColore(object sender, RoutedEventArgs e)
        {

            if (btnciao.Background == Brushes.Pink)
            {
                btnciao.Background = Brushes.Purple;
            }
            else { btnciao.Background = Brushes.Pink; }
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {


            count++;
            Conta.Text = count.ToString();
            // Create a string array with the lines of text
            string line = count.ToString();

            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "C:\\Users\\BIBY\\source\\repos\\applicazione desktop\\ModernDesign\\ModernDesign\\MVVM\\View\\pino.txt")))
            {

                outputFile.WriteLine(line);
            }
        }
    }
}
