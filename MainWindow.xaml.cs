using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TicTacToeLogic game;

        public MainWindow()
        {
            InitializeComponent();

            StartNewGame();
        }

        private void StartNewGame()
        {
            game = new TicTacToeLogic();

            ClearGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            if (button.Content.ToString().Length != 0)
            {
                return;
            }

            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);


            button.Content = game.GetPlayerChar();
            game.MakeMove(row, column);

            if(game.IsFull())
            {
                MessageBox.Show("It's a tie!");
                StartNewGame();
                return;
            }

            if(game.isGameOver)
            {
                game.SwitchPlayers();
                ColorWinningPositions();
                MessageBox.Show($"Player {game.GetPlayerChar()} wins!");
                StartNewGame();
            }
        }
        private void ClearGrid()
        {
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.Transparent;
            });
        }

        private void ColorWinningPositions()
        {
            int[] pos = game.winningPositions;
            
            foreach(int index in pos) {
                Container.Children.Cast<Button>().ToList()[index].Background = Brushes.Green;
            }
        }
    }
}
