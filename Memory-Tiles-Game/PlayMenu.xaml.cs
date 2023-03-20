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

namespace Memory_Tiles_Game
{
    /// <summary>
    /// Interaction logic for PlayMenu.xaml
    /// </summary>
    public partial class PlayMenu : Window
    {
        public PlayMenu()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Visibility = Visibility.Visible;
            this.Close();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(rowsBox.Text) && !string.IsNullOrEmpty(columnsBox.Text) && 
                (int.Parse(rowsBox.Text) * int.Parse(columnsBox.Text)) <= 40 &&
                (int.Parse(rowsBox.Text) * int.Parse(columnsBox.Text)) >= 2 &&
                (int.Parse(rowsBox.Text) * int.Parse(columnsBox.Text)) %2 != 1)
            {
                GameWindow gameWindow = new(int.Parse(rowsBox.Text), int.Parse(columnsBox.Text));
                this.Visibility = Visibility.Hidden;
                gameWindow.Owner = this;
                gameWindow.ShowDialog();
            }
            else
            {
                OutputRowsColumnsError.IsOpen = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (OutputRowsColumnsError.IsOpen)
            {
                OutputRowsColumnsError.IsOpen = false;
            }
        }
    }
}
