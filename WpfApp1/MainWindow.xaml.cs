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
using WpfApp1.Model;
using WpfApp1.ViewModel;
using System.IO;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void s_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
    
            if (sender is ListBoxItem)
            {
                ListBoxItem draggedItem = sender as ListBoxItem;
                DragDrop.DoDragDrop(draggedItem, draggedItem.DataContext, DragDropEffects.Move);
                draggedItem.IsSelected = true;
            }
        }

        void listbox_Drop(object sender, DragEventArgs e)
        {
            Element droppedData = e.Data.GetData(typeof(Element)) as Element;
            Element target = ((ListBoxItem)(sender)).DataContext as Element;

            int removedIdx = listBox.Items.IndexOf(droppedData);
            int targetIdx = listBox.Items.IndexOf(target);


            if (removedIdx < targetIdx)
            {
                MainViewModel.Elements.Insert(targetIdx + 1, droppedData);
                MainViewModel.Elements.RemoveAt(removedIdx);
            }
            else
            {
                int remIdx = removedIdx + 1;
                if (MainViewModel.Elements.Count + 1 > remIdx)
                {
                    MainViewModel.Elements.Insert(targetIdx, droppedData);
                    MainViewModel.Elements.RemoveAt(remIdx);
                }
            }
        }
    }
}
