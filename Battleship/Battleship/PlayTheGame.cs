using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Torpedo;

/* The purpose of this file is to show you all how to have multiple files hold the code
 * for a common class.  What you do is create a new file as a brand new class, with the
 * file name you desire.  You can leave its initial class as Class1.cs, because you will
 * be deleting that.  After you get the new file in your IDE, change its class definition
 * to:
        public partial class MainWindow : Window
 * 
 * "Partial" classes are how WPF lets you spread code for the same class over multiple files.
 * Consider you original MainWindow.xaml.cs file.  It starts with a partial class.  This is
 * because it shares a code file with MainWindow.xaml! */
namespace Battleship
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {

        private int shipsSinked;
        /* This is the main method for handling each player's shot */
        private void PlayNextShot()
        {

            /* Get the next shot */
            if (turn % 2 == 0)
            {
                torpedoShot = oceania.NextMove();
            }
            else
            {
                torpedoShot = eurasia.NextMove();
            }
            ShowShot(torpedoShot);  // Record and display the shot

            /* If there is a winner, end the game */
            if (Winner(oceaniaShipHits))
            {
                whosTurn.Visibility = Visibility.Hidden;
                whoWon.Content = "EURASIA WINS!";
                whoWon.Visibility = Visibility.Visible;
                winnerFound = true;
            }
            else if (Winner(eurasiaShipHits))
            {
                whosTurn.Visibility = Visibility.Hidden;
                whoWon.Content = "OCEANIA WINS!";
                whoWon.Visibility = Visibility.Visible;
                winnerFound = true;
            }

            /* Switch the turn label.  Note, even though this executes whether or
             * not someone won, it will only be visible if no one has won.  I could
             * make it conditional on no victor, but I just didn't feel like it! */
            //turn += 1;
            OnPropertyChanged("whosTurn");
        }

        /* There is a winner if all ships have their maximum number of hits */
        private bool Winner(Dictionary<Ships, List<string>> shipHits)
        {
            if (shipsSinked == 5)
            {
                winnerFound = true;
                return true;
            }
            winnerFound = false;
            return false;
        }

        /* Show the shot "splash", figure if there's a hit or miss, whether a ship has been sunk,
         * and send the result back to the player. */
        private void ShowShot(TorpedoShot torpedo)
        {

            Label targetLabel;
            Grid targetGrid;
            string shotAsString = torpedo.Row + torpedo.Column;
            bool alreadyTaken = false;

            if (turn % 2 == 0)
            {
                targetLabel = lblShotAtEurasia;
                targetGrid = EurasiaBoard;
                if (oceaniaShotsTaken.Contains(shotAsString))
                    alreadyTaken = true;
                else
                    oceaniaShotsTaken.Add(shotAsString);
            }
            else
            {
                targetLabel = lblShotAtOceania;
                targetGrid = OceaniaBoard;
                if (eurasiaShotsTaken.Contains(shotAsString))
                    alreadyTaken = true;
                else
                    eurasiaShotsTaken.Add(shotAsString);
            }

            /* Display the shot square */
            targetLabel.Content = torpedoShot.Row + torpedoShot.Column + (alreadyTaken ? "\n(shot\nalready\ntaken)" : "");
            Ellipse shot = new Ellipse();
            shot.Height = 30;
            shot.Width = 30;
            shot.Stroke = new SolidColorBrush(Colors.Black);
            shot.StrokeThickness = 1;

            if (IsHit(torpedoShot)) //find out if there's a hit
                shot.Fill = new SolidColorBrush(Colors.Red);
            else
            {
                shot.Fill = new SolidColorBrush(Colors.Blue);
                torpedoResult = new TorpedoResult(torpedoShot, false, "");
                if (targetGrid == OceaniaBoard) //if there is no hit, TorpedoResult can be sent back here
                    eurasia.ResultOfShot(torpedoResult);
                else
                    oceania.ResultOfShot(torpedoResult);
            }
            int row = torpedo.Row[0] - 'A' + 1;
            int column = Int32.Parse(torpedo.Column);
            Grid.SetRow(shot, row);
            Grid.SetColumn(shot, column);
            targetGrid.Children.Add(shot);

            // now animate the shrink to the center circle border
            DoubleAnimation daH = new DoubleAnimation(30, 10, TimeSpan.FromMilliseconds(1000));
            shot.BeginAnimation(Ellipse.HeightProperty, daH);

            DoubleAnimation daW = new DoubleAnimation(30, 10, TimeSpan.FromMilliseconds(1000));
            shot.BeginAnimation(Canvas.WidthProperty, daW);
        }

        /* Determines if there is a hit.  If there is a hit, determines is anything was sunk
         * and returns the TorpedoResult with the hit/sunk information. */
        private bool IsHit(TorpedoShot torpedo)
        {
            Dictionary<Ships, string[]> shipLocations = new Dictionary<Ships, string[]>();
            Dictionary<Ships, List<string>> shotsTaken = new Dictionary<Ships, List<string>>();
            string shotAsString = torpedo.Row + torpedo.Column;
            Label lblSunk;

            if (turn % 2 == 0)
            {
                shipLocations = eurasiaShipLocations;

                shotsTaken = eurasiaShipHits;

                lblSunk = lblEurasiaSunk;
            }
            else
            {
                shipLocations = oceaniaShipLocations;

                shotsTaken = oceaniaShipHits;

                lblSunk = lblOceaniaSunk;
            }

            /* Check each ship one-by-one.  If any of them is hit by this shot, see
             * if it is sunk.  Then call the proper ResultOfShot() method, with the
             * Sunk property set accordingly. */
            string[] aircraftcarrier = shipLocations[Ships.AircraftCarrier];
            for (int i = 0; i < shipLocations[Ships.AircraftCarrier].Length; i++)
            {
                if (shipLocations[Ships.AircraftCarrier][i] == torpedo.Row + torpedo.Column)
                {
                    if (!shotsTaken[Ships.AircraftCarrier].Contains(shotAsString))
                    {
                        shotsTaken[Ships.AircraftCarrier].Add(shotAsString);
                        if (shotsTaken[Ships.AircraftCarrier].Count == 5)
                        {
                            shipsSinked++;
                            lblSunk.Content = lblSunk.Content + "Aircraft Carrier\n";
                            torpedoResult = new TorpedoResult(torpedoShot, true, "Aircraft Carrier");
                            if (turn % 2 == 0)
                                oceania.ResultOfShot(torpedoResult);
                            else
                                eurasia.ResultOfShot(torpedoResult);
                        }
                        else
                        {
                            torpedoResult = new TorpedoResult(torpedoShot, true, "");
                            if (turn % 2 == 0)
                                oceania.ResultOfShot(torpedoResult);
                            else
                                eurasia.ResultOfShot(torpedoResult);
                        }
                    }
                    return true;
                }
            }

            string[] battleship = shipLocations[Ships.Battleship];
            for (int i = 0; i < battleship.Length; i++)
            {
                if (battleship[i] == torpedo.Row + torpedo.Column)
                {
                    if (!shotsTaken[Ships.Battleship].Contains(shotAsString))
                    {
                        shotsTaken[Ships.Battleship].Add(shotAsString);
                        if (shotsTaken[Ships.Battleship].Count == 4)
                        {
                            shipsSinked++;
                            lblSunk.Content = lblSunk.Content + "Battleship\n";
                            torpedoResult = new TorpedoResult(torpedoShot, true, "Battleship");
                            if (turn % 2 == 0)
                                oceania.ResultOfShot(torpedoResult);
                            else
                                eurasia.ResultOfShot(torpedoResult);
                        }
                        else
                        {
                            torpedoResult = new TorpedoResult(torpedoShot, true, "");
                            if (turn % 2 == 0)
                                oceania.ResultOfShot(torpedoResult);
                            else
                                eurasia.ResultOfShot(torpedoResult);
                        }
                    }
                    return true;
                }
            }

            string[] cruiser = shipLocations[Ships.Cruiser];
            for (int i = 0; i < cruiser.Length; i++)
            {
                if (cruiser[i] == torpedo.Row + torpedo.Column)
                {
                    if (!shotsTaken[Ships.Cruiser].Contains(shotAsString))
                    {
                        shotsTaken[Ships.Cruiser].Add(shotAsString);
                        if (shotsTaken[Ships.Cruiser].Count == 3)
                        {
                            shipsSinked++;
                            lblSunk.Content = lblSunk.Content + "Cruiser\n";
                            torpedoResult = new TorpedoResult(torpedoShot, true, "Cruiser");
                            if (turn % 2 == 0)
                                oceania.ResultOfShot(torpedoResult);
                            else
                                eurasia.ResultOfShot(torpedoResult);
                        }
                        else
                        {
                            torpedoResult = new TorpedoResult(torpedoShot, true, "");
                            if (turn % 2 == 0)
                                oceania.ResultOfShot(torpedoResult);
                            else
                                eurasia.ResultOfShot(torpedoResult);
                        }
                    }
                    return true;
                }
            }

            string[] submarine = shipLocations[Ships.Submarine];
            for (int i = 0; i < submarine.Length; i++)
            {
                if (submarine[i] == torpedo.Row + torpedo.Column)
                {
                    if (!shotsTaken[Ships.Submarine].Contains(shotAsString))
                    {
                        shotsTaken[Ships.Submarine].Add(shotAsString);
                        if (shotsTaken[Ships.Submarine].Count == 3)
                        {
                            shipsSinked++;
                            lblSunk.Content = lblSunk.Content + "Submarine\n";
                            torpedoResult = new TorpedoResult(torpedoShot, true, "Submarine");
                            if (turn % 2 == 0)
                                oceania.ResultOfShot(torpedoResult);
                            else
                                eurasia.ResultOfShot(torpedoResult);
                        }
                        else
                        {
                            torpedoResult = new TorpedoResult(torpedoShot, true, "");
                            if (turn % 2 == 0)
                                oceania.ResultOfShot(torpedoResult);
                            else
                                eurasia.ResultOfShot(torpedoResult);
                        }
                    }
                    return true;
                }
            }

            string[] destroyer = shipLocations[Ships.Destroyer];
            for (int i = 0; i < destroyer.Length; i++)
            {
                if (destroyer[i] == torpedo.Row + torpedo.Column)
                {
                    if (!shotsTaken[Ships.Destroyer].Contains(shotAsString))
                    {
                        shotsTaken[Ships.Destroyer].Add(shotAsString);
                        if (shotsTaken[Ships.Destroyer].Count == 2)
                        {
                            shipsSinked++;
                            lblSunk.Content = lblSunk.Content + "Destroyer\n";
                            torpedoResult = new TorpedoResult(torpedoShot, true, "Destroyer");
                            if (turn % 2 == 0)
                                oceania.ResultOfShot(torpedoResult);
                            else
                                eurasia.ResultOfShot(torpedoResult);
                        }
                        else
                        {
                            torpedoResult = new TorpedoResult(torpedoShot, true, "");
                            if (turn % 2 == 0)
                                oceania.ResultOfShot(torpedoResult);
                            else
                                eurasia.ResultOfShot(torpedoResult);
                        }
                    }
                    return true;
                }
            }
            return false;
        }
    }
}