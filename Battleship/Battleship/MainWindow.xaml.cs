using Eurasia;
using Oceania;
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
using Torpedo;
using System.Collections;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Battleship
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PlayerOceania oceania = new PlayerOceania();
        private PlayerEurasia eurasia = new PlayerEurasia();
        private TorpedoShot torpedoShot;
        private int turn;
        private Ellipse destroyer = new Ellipse();
        private Ellipse submarine = new Ellipse();
        private Ellipse cruiser = new Ellipse();
        private Ellipse battleship = new Ellipse();
        private Ellipse carrier = new Ellipse();
        DispatcherTimer dispatcherTimer;
        List<string> oceaniaShotsTaken = new List<string>();
        List<string> eurasiaShotsTaken = new List<string>();
        Boolean winnerFound = false;
        private TorpedoResult torpedoResult;
        private Dictionary<Ships, string[]> oceaniaShipLocations = new Dictionary<Ships, string[]>();
        private Dictionary<Ships, string[]> eurasiaShipLocations = new Dictionary<Ships, string[]>();
        private Dictionary<Ships, List<string>> eurasiaShipHits = new Dictionary<Ships, List<string>>();
        private Dictionary<Ships, List<string>> oceaniaShipHits = new Dictionary<Ships, List<string>>();
        private string[,] oceaniaState = new string[10, 10];
        private string[,] eurasiaState = new string[10, 10];
        private List<Ships> oceaniaShipsSunk;
        private List<Ships> eurasiaShipsSunk;
        List<string[]> oceaniaMoves;
        List<string[]> eurasiaMoves;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public MainWindow()
        {
            InitializeComponent();
            eurasiaShipLocations.Add(Ships.AircraftCarrier, eurasia.GetAircraftCarrier());
            eurasiaShipLocations.Add(Ships.Battleship, eurasia.GetBattleship());
            eurasiaShipLocations.Add(Ships.Cruiser, eurasia.GetCruiser());
            eurasiaShipLocations.Add(Ships.Submarine, eurasia.GetSubmarine());
            eurasiaShipLocations.Add(Ships.Destroyer, eurasia.GetDestroyer());

            eurasiaShipHits.Add(Ships.AircraftCarrier, eurasiaShotsTaken);
            eurasiaShipHits.Add(Ships.Battleship, eurasiaShotsTaken);
            eurasiaShipHits.Add(Ships.Cruiser, eurasiaShotsTaken);
            eurasiaShipHits.Add(Ships.Submarine, eurasiaShotsTaken);
            eurasiaShipHits.Add(Ships.Destroyer, eurasiaShotsTaken);

            oceaniaShipLocations.Add(Ships.AircraftCarrier, oceania.GetAircraftCarrier());
            oceaniaShipLocations.Add(Ships.Battleship, oceania.GetBattleship());
            oceaniaShipLocations.Add(Ships.Cruiser, oceania.GetCruiser());
            oceaniaShipLocations.Add(Ships.Submarine, oceania.GetSubmarine());
            oceaniaShipLocations.Add(Ships.Destroyer, oceania.GetDestroyer());

            oceaniaShipHits.Add(Ships.AircraftCarrier, oceaniaShotsTaken);
            oceaniaShipHits.Add(Ships.Battleship, oceaniaShotsTaken);
            oceaniaShipHits.Add(Ships.Cruiser, oceaniaShotsTaken);
            oceaniaShipHits.Add(Ships.Submarine, oceaniaShotsTaken);
            oceaniaShipHits.Add(Ships.Destroyer, oceaniaShotsTaken);
            ellipse();
            displayTurn();
        }
        private void ellipse()
        {
            List<Border> borders = new List<Border>();
            foreach (FrameworkElement border in EurasiaBoard.Children)
            {
                if (border is Border && border.Name != "")
                {
                    borders.Add(border as Border);
                }
            }
            foreach (FrameworkElement border in OceaniaBoard.Children)
            {
                if (border is Border && border.Name != "")
                {
                    borders.Add(border as Border);
                }
            }
            foreach (Border b in borders)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Width = 10;
                ellipse.Height = 10;
                ellipse.Stroke = new SolidColorBrush(Colors.Black);
                ellipse.Fill = new SolidColorBrush(Colors.White);
                ellipse.HorizontalAlignment = HorizontalAlignment.Center;
                ellipse.VerticalAlignment = VerticalAlignment.Center;
                b.Child = ellipse;
            }
        }
        private void displayTurn()
        {
            if (turn % 2 == 0)
            {
                whosTurn.Content = "Eurasia's Turn";
            }
            else
            {
                whosTurn.Content = "Oceania's Turn";
            }
        }
        private Ellipse getShip(int x)
        {
            if (x == 0)
            {
                return destroyer;
            }
            else if (x == 1)
            {
                return submarine;
            }
            else if (x == 2)
            {
                return cruiser;
            }
            else if (x == 3)
            {
                return battleship;
            }
            else
            {
                return carrier;
            }
        }

        private int getWidth(Ellipse ship)
        {
            if (ship == destroyer)
            {
                return 60;
            }
            else if (ship == submarine)
            {
                return 90;
            }
            else if (ship == cruiser)
            {
                return 90;
            }
            else if (ship == battleship)
            {
                return 120;
            }
            else
            {
                return 150;
            }
        }

        private int getColSpan(Ellipse ship)
        {
            if (ship == destroyer)
            {
                return 2;
            }
            else if (ship == submarine)
            {
                return 3;
            }
            else if (ship == cruiser)
            {
                return 3;
            }
            else if (ship == battleship)
            {
                return 4;
            }
            else
            {
                return 5;
            }
        }
        private int setX(Ellipse ship)
        {
            if (ship == destroyer)
            {
                return 2;
            }
            else if (ship == submarine)
            {
                return 6;
            }
            else if (ship == cruiser)
            {
                return 5;
            }
            else if (ship == battleship)
            {
                return 7;
            }
            else
            {
                return 3;
            }
        }
        private int setY(Ellipse ship)
        {
            if (ship == destroyer)
            {
                return 4;
            }
            else if (ship == submarine)
            {
                return 8;
            }
            else if (ship == cruiser)
            {
                return 2;
            }
            else if (ship == battleship)
            {
                return 9;
            }
            else
            {
                return 6;
            }
        }
        private void btnWarPeace_Click(object sender, RoutedEventArgs e)
        {
            showShips(OceaniaBoard);
            showShips(EurasiaBoard);

            PlayTheGame.Visibility = Visibility.Hidden;
            whosTurn.Visibility = Visibility.Visible;

            /* Note that the DispatcherTimer must be recreated at the beginning of every game
             * or else the timer will get "wonky". */
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        /* In order for the torpedo splash graphics to display properly, they had to
         * be rendered off the main thread. */
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            PlayNextShot();
            turn++;

            if (winnerFound)
            {
                DispatcherTimer dt = sender as DispatcherTimer;
                dt.Stop();
                playAgain.Visibility = Visibility.Visible;
            }
        }

        private void showShips(Grid g)
        {
            if (g == OceaniaBoard)
            {
                int x = 0;
                int y = 0;
                for (int i = 0; i < 5; i++)
                {
                    Ellipse e = new Ellipse();
                    x = setX(e);
                    y = setY(e);
                    e.Width = getWidth(getShip(i));
                    e.Height = 25;
                    e.Stroke = new SolidColorBrush(Colors.Red);
                    e.StrokeThickness = 3;
                    Grid.SetColumnSpan(e, getColSpan(getShip(i)));
                    Grid.SetColumn(e, setX(getShip(i)));
                    Grid.SetRow(e, setY(getShip(i)));
                    OceaniaBoard.Children.Add(e);
                }
            }
            else
            {
                int x = 0;
                int y = 0;
                for (int i = 0; i < 5; i++)
                {
                    Ellipse e = new Ellipse();
                    x = setX(e);
                    y = setY(e);
                    e.Width = getWidth(getShip(i));
                    e.Height = 25;
                    e.Stroke = new SolidColorBrush(Colors.Blue);
                    e.StrokeThickness = 3;
                    Grid.SetColumnSpan(e, getColSpan(getShip(i)));
                    Grid.SetColumn(e, setX(getShip(i)));
                    Grid.SetRow(e, setY(getShip(i)));
                    EurasiaBoard.Children.Add(e);
                }
            }
        }
        /* Reset from the current game to be in a state to start the next game, in case we ever wanted to do 2 out of 3. */
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            SetupBoard();
        }
        private void SetupBoard()
        {
            /* Set all gameboard spaces to empty */
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    oceaniaState[i, j] = "";
                    eurasiaState[i, j] = "";
                }
            }

            /* Clear list of sunken ships */
            oceaniaShipsSunk = new List<Ships>();
            eurasiaShipsSunk = new List<Ships>();

            /* Clear list of ship locations */
            oceaniaShipLocations = new Dictionary<Ships, string[]>();
            eurasiaShipLocations = new Dictionary<Ships, string[]>();

            /* Get Oceania's ship locations */
            oceania.Reset();
            oceaniaShipLocations[Ships.AircraftCarrier] = oceania.GetAircraftCarrier();
            oceaniaShipLocations[Ships.Battleship] = oceania.GetBattleship();
            oceaniaShipLocations[Ships.Cruiser] = oceania.GetCruiser();
            oceaniaShipLocations[Ships.Submarine] = oceania.GetSubmarine();
            oceaniaShipLocations[Ships.Destroyer] = oceania.GetDestroyer();

            /* Get Eurasia's ship locations */
            eurasia.Reset();
            eurasiaShipLocations[Ships.AircraftCarrier] = eurasia.GetAircraftCarrier();
            eurasiaShipLocations[Ships.Battleship] = eurasia.GetBattleship();
            eurasiaShipLocations[Ships.Cruiser] = eurasia.GetCruiser();
            eurasiaShipLocations[Ships.Submarine] = eurasia.GetSubmarine();
            eurasiaShipLocations[Ships.Destroyer] = eurasia.GetDestroyer();

            /* Reset game state */
            winnerFound = false;
            turn = 0;
            OnPropertyChanged("TurnLabel");
            PlayTheGame.Visibility = Visibility.Visible;
            whosTurn.Visibility = Visibility.Hidden;
            whoWon.Visibility = Visibility.Hidden;
            playAgain.Visibility = Visibility.Hidden;
            lblShotAtEurasia.Content = "";
            lblShotAtOceania.Content = "";
            lblEurasiaSunk.Content = "";
            lblOceaniaSunk.Content = "";

            /* Reset game history */
            oceaniaMoves = new List<string[]>();
            eurasiaMoves = new List<string[]>();
            oceaniaShotsTaken = new List<string>();
            eurasiaShotsTaken = new List<string>();
            oceaniaShipHits = new Dictionary<Ships, List<string>>();
            eurasiaShipHits = new Dictionary<Ships, List<string>>();
            oceaniaShipHits[Ships.AircraftCarrier] = new List<string>();
            oceaniaShipHits[Ships.Battleship] = new List<string>();
            oceaniaShipHits[Ships.Cruiser] = new List<string>();
            oceaniaShipHits[Ships.Submarine] = new List<string>();
            oceaniaShipHits[Ships.Destroyer] = new List<string>();
            eurasiaShipHits[Ships.AircraftCarrier] = new List<string>();
            eurasiaShipHits[Ships.Battleship] = new List<string>();
            eurasiaShipHits[Ships.Cruiser] = new List<string>();
            eurasiaShipHits[Ships.Submarine] = new List<string>();
            eurasiaShipHits[Ships.Destroyer] = new List<string>();

            /* Empty torpedo holes */
            List<FrameworkElement> shots = new List<FrameworkElement>();
            foreach (FrameworkElement shot in OceaniaBoard.Children)
                if (shot is Ellipse)
                    shots.Add(shot);
            foreach (FrameworkElement shot in shots)
                OceaniaBoard.Children.Remove(shot);
            shots = new List<FrameworkElement>();
            foreach (FrameworkElement shot in EurasiaBoard.Children)
                if (shot is Ellipse)
                    shots.Add(shot);
            foreach (FrameworkElement shot in shots)
                EurasiaBoard.Children.Remove(shot);
        }
    }
}
