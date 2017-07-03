using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using GalaSoft.MvvmLight;

namespace Imagediff
{
    public class Imagediffs : ObservableCollection<ImagediffViewModel> { }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
  //      Imagediffs names;

        public MainWindow()
        {
            InitializeComponent();

            //this.toggleButton.Click += toggleButton_Click;

   //         this.names = new Imagediffs();

            //dockPanel.DataContext = this.names;
        }

        //void toggleButton_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
