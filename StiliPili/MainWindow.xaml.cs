using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace StiliPili
{

    public partial class MainWindow : Window, INotifyPropertyChanged
    {


        public MainWindow()
        {
            InitializeComponent();
            newchel = new Chel();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        private Chel newchel;

        public Chel chel
        {
            get => newchel;
            set
            {
                newchel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(chel)));
            }
        }


        public class Chel
        {
            public byte[] Fotka { get; set; }
        }

        private void ClickAddFotka (object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var path = openFileDialog.FileName;
            chel.Fotka = File.ReadAllBytes(path);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof (chel)));

        }




    }
}



