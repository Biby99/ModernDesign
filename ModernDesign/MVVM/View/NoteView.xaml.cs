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
    /// Logica di interazione per NoteView.xaml
    /// </summary>
    public partial class NoteView : UserControl
    {
        private string testo;
        public NoteView()
        {
            InitializeComponent();
            testo = "";
            NoteView_Loaded();
        }
        private async void NoteView_Loaded()
        {
            try
            {
                using (var sr = new StreamReader("C:\\Users\\BIBY\\source\\repos\\applicazione desktop\\ModernDesign\\ModernDesign\\MVVM\\View\\nota.txt"))
                {
                    testo = await sr.ReadToEndAsync();
                    if (testo.Length > 80)
                    {
                        TBprovagrande.Text = testo.Substring(0, 80) + "......";
                    }
                    else { TBprovagrande.Text = testo; }
                }
            }
            catch (FileNotFoundException ex)
            {
                TBprovagrande.Text = ex.Message.Substring(0, 50);
                if (ex.Message.Length > 80)
                {
                    TBprovagrande.Text = ex.Message.Substring(0, 80);
                }
                else { TBprovagrande.Text = ex.Message; }
            }
        }
        private void txtProvatesto(object sender, RoutedEventArgs e)
        {

        }

        private void provatesto(object sender, RoutedEventArgs e)
        {
            if (TBtestoprova.Text == "Ciao")
            {
                TBtestoprova.Text = "Va cagar";
            }
            else { TBtestoprova.Text = "Ciao"; }
        }

        private void scritturatesto(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                testo = piccolotestoprova.Text;
                TBprovagrande.Text = testo;
                // Create a string array with the lines of text
                string line = testo;

                // Set a variable to the Documents path.
                string docPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "C:\\Users\\BIBY\\source\\repos\\applicazione desktop\\ModernDesign\\ModernDesign\\MVVM\\View\\nota.txt")))
                {

                    outputFile.WriteLine(line);
                }
            }

        }
    }
}
