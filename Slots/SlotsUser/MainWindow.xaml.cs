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

namespace SlotsUser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer;
        private int spins = 0;
        private int firstTurn = 0;
        private int secondTurn = 0;
        private int thirdTurn = 0;
        
        private int jackpot = 0;
        private int jackpotCount = 0;

        private double countWins = 0;
        private double turns = 0;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void RunSimulation_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void winner()
        {
            if (firstTurn == 7 && secondTurn == 7 && thirdTurn == 7)
            {
                result.Text = "Result: Jackpot Earned!";
                jackpot = 0;
                jack.Text = "Jackpot: $" + jackpot;
                countWins++;
                turns++;
                wins.Text = "Win %: " + Math.Truncate(countWins / turns * 100) + "%";
                jackpotCount++;
                won.Text = "Jackpots Won: " + jackpotCount;
            }
            if (firstTurn == secondTurn && firstTurn == thirdTurn)
            {
                result.Text = "Result: Win!";
                jackpot += 10;
                jack.Text = "Jackpot: $" + jackpot;
                countWins++;
                turns++;
                wins.Text = "Win %: " + Math.Truncate(countWins / turns * 100) + "%";
                won.Text = "Jackpots Won: " + jackpotCount;
            }
            else if ((firstTurn == secondTurn && firstTurn != thirdTurn) || (secondTurn == thirdTurn && secondTurn != firstTurn))
            {
                result.Text = "Result: Basic Win!";
                jackpot += 10;
                jack.Text = "Jackpot: $" + jackpot;
                countWins++;
                turns++;
                wins.Text = "Win %: " + Math.Truncate(countWins / turns * 100) + "%";
                won.Text = "Jackpots Won: " + jackpotCount;
            }
            else
            {
                result.Text = "Result: Loss";
                jackpot += 10;
                jack.Text = "Jackpot: $" + jackpot;
                turns++;
                wins.Text = "Win %: " + Math.Truncate(countWins / turns * 100) + "%";
                won.Text = "Jackpots Won: " + jackpotCount;
            }
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Random r = new Random();

            int roll1 = r.Next(1, 9);
            int roll2 = r.Next(1, 9);
            int roll3 = r.Next(1, 9);
            
            firstNum.Text = roll1 + "";
            secondNum.Text = roll2 + "";
            thirdNum.Text = roll3 + "";
            
            firstTurn = int.Parse(firstNum.Text);
            secondTurn = int.Parse(secondNum.Text);
            thirdTurn = int.Parse(thirdNum.Text);

            spins++;
            
            if (spins == 3)
            {
                DispatcherTimer dt = sender as DispatcherTimer;
                spins = 0;
                winner();
                dt.Stop();
            }
        }
    }
}
