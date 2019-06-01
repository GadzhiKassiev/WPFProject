using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;

namespace WpfApp1.ViewModel
{
    class MainViewModel
    {
        public static ObservableCollection<Element> Elements { get; set; }

        public MainViewModel()
        {
            try
            {
              Elements = new ObservableCollection<Element>(InputClass.GetElementsByOrderFromFile(InputClass.GetSortingElementsFromFile()));            
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void WriteDate()
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\Asus\\source\\repos\\WpfApp1\\TextFileWPF.txt");
                foreach (Element el in Elements)
                {
                    sw.WriteLine(el.ID);
                }
                sw.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
    }
}
