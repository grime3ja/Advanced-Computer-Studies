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
using System.Windows.Threading;

namespace SpinnerUser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double countWins = 0;
        private double countLosses = 0;
        DispatcherTimer dispatcherTimer;
        private int turn = 0;
        private static int stakes = 0;
        private int bets = 0;
        private int goals = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        /**
         * activates when the Run Simulation Button is clicked
         */
        private void RunSimulation_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        /**
         * used to determine if a roll was a winner, loser, or if there needs to be another roll because neither case was true
         */
        private bool winner()
        {
            int[] winners = { 7, 11 };
            int[] losers = { 2, 3, 12 };
            int[] rollAgain = { 1, 4, 5, 6, 8, 9, 10 };

            int roll = rollDice();
            lastRoll.Content = "Last Roll: " + roll;

            if (winners.Contains(roll))
            {
                countWins++;
                won.Content = "# Won: " + countWins;
                turn++;
                bets = (int)loses.ControlValue;
                stakes += bets;
                stakeAmount.Content = "Money Left: " + stakes;
                percent.Content = "Win %: " + (countWins / (countWins + countLosses) * 100) + "%";
                result.Content = "Result: Win!";
                return true;
            }
            else if (losers.Contains(roll))
            {
                countLosses++;
                lost.Content = "# Lost: " + countLosses;
                turn++;
                bets = (int)loses.ControlValue;
                stakes -= bets;
                bets = (int)loses.ControlValue * 2;
                stakeAmount.Content = "Money Left: " + stakes;
                percent.Content = "Win %: " + (countWins / (countWins + countLosses) * 100) + "%";
                result.Content = "Result: Loss :(";
                return false;
            }
            else if (rollAgain.Contains(roll))
            {
                rollDice();
                result.Content = "Result: Roll Again";
                return false;
            }
            return false;
            
        }

        /**
         * runs the timer for the program until the user-specified number of rolls is reached
         */
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            winner();
            goals = (int)wins.ControlValue;
            int value = (int)simulations.ControlValue;
            if (turn == value || bets == goals)
            {
                DispatcherTimer dt = sender as DispatcherTimer;
                turn = 0;
                dt.Stop();
            }
        }

        /**
         * rolls the dice, returns a random number between 1 and 12
         * called in winner() method
         */
        private int rollDice()
        {
            Random r = new Random();
            int roll = r.Next(1, 12);
            return roll;
        }
    }
}
