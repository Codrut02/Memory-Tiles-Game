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
using System.Windows.Threading;

namespace Memory_Tiles_Game
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public Game GameBoard { get; set; }
        public GameWindow(int rows,int columns)
        {
            InitializeComponent();
            GameBoard = new Game(rows, columns);
            InitializeGrid(rows,columns);
        }

        public void InitializeGrid(int Rows,int Columns)
        {
            Grid grid = new();
            for (int i = 0; i < Rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int j = 0; j < Columns; j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            Button firstButton = null;
            Button secondButton = null;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    int row = i;
                    int col = j;
                    Button button = new Button();
                    Image image = new Image();
                    image.Source = new BitmapImage(new Uri(GameBoard.BoardMatrix[row, col].ImagePath, UriKind.Absolute));
                    if (!GameBoard.BoardMatrix[row, col].Shown)
                    {
                        image.Visibility = Visibility.Hidden;
                    }
                    button.Content = image;
                    button.Click += (s, e) =>
                    {
                        if (firstButton == null)
                        {
                            firstButton = button;
                            GameBoard.BoardMatrix[row, col].ChangeShown();
                            image.Visibility = Visibility.Visible;
                        }
                        else if (secondButton == null)
                        {
                            secondButton = button;
                            GameBoard.BoardMatrix[row, col].ChangeShown();
                            image.Visibility = Visibility.Visible;

                            if (((Image)firstButton.Content).Source.ToString() == ((Image)secondButton.Content).Source.ToString())
                            {
                                firstButton.IsEnabled = false;
                                secondButton.IsEnabled = false;
                                firstButton = null;
                                secondButton = null;
                            }
                            else
                            {
                                var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
                                timer.Tick += (o, args) =>
                                {
                                    ((Image)firstButton.Content).Visibility = Visibility.Hidden;
                                    ((Image)secondButton.Content).Visibility = Visibility.Hidden;

                                    GameBoard.BoardMatrix[Grid.GetRow(firstButton), Grid.GetColumn(firstButton)].ChangeShown();
                                    GameBoard.BoardMatrix[Grid.GetRow(secondButton), Grid.GetColumn(secondButton)].ChangeShown();

                                    firstButton = null;
                                    secondButton = null;

                                    timer.Stop();
                                };
                                timer.Start();
                            }
                        }

                        bool allTilesWereShown = true;
                        foreach (Tile tile in GameBoard.BoardMatrix)
                        {
                            if (!tile.Shown)
                            {
                                allTilesWereShown = false;
                            }
                        }
                        if (allTilesWereShown)
                        {
                            App.Current.MainWindow.Visibility = Visibility.Visible;
                            this.Close();
                        }
                    };
                    grid.Children.Add(button);
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                }
            }
            MyGrid.Children.Add(grid);
        }
    }
}
