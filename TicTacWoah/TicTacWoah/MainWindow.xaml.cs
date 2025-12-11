using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace _4D_Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool allowMove = false;
        private Point m_point;
        private Vector m_vector;
        private GamePiece m_piece;
        private Border m_Border;
        private List<Border> borders = new List<Border>();
        private int turn = 0;
        private int[,] state = new int[3, 3];
        private int xScore;
        private int oScore;
        private int tieScore;

        public MainWindow()
        {
            InitializeComponent();

            borders.Add(b00);
            borders.Add(b01);
            borders.Add(b02);
            borders.Add(b10);
            borders.Add(b11);
            borders.Add(b12);
            borders.Add(b20);
            borders.Add(b21);
            borders.Add(b22);
        }

        private void GamePiece_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            GamePiece piece = sender as GamePiece;
            if (!piece.IsPlaced && (piece.Name[0] == 'x' == (turn % 2 == 0)))
            {
                allowMove = true;
                m_point = Mouse.GetPosition(piece);
                m_vector = VisualTreeHelper.GetOffset(piece);
            }
        }

        private void GamePiece_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            GamePiece piece = sender as GamePiece;
            if (piece.IsPlaced)
                return;

            if (e.LeftButton == MouseButtonState.Pressed && (piece.Name[0] == 'x' == (turn % 2 == 0)) && allowMove)
            {
                Mouse.Capture(piece);
                Point temp = Mouse.GetPosition((FrameworkElement)(piece.Parent));
                TranslateTransform transform = new TranslateTransform();

                transform.X = temp.X - m_vector.X - m_point.X;
                transform.Y = temp.Y - m_vector.Y - m_point.Y;

                piece.RenderTransform = transform;

                Border border;
                if ((border = OverGridSquare(temp)) != null && SquareNotTaken(border))
                {
                    b00.BorderBrush = Brushes.Black;
                    b01.BorderBrush = Brushes.Black;
                    b02.BorderBrush = Brushes.Black;
                    b10.BorderBrush = Brushes.Black;
                    b11.BorderBrush = Brushes.Black;
                    b12.BorderBrush = Brushes.Black;
                    b20.BorderBrush = Brushes.Black;
                    b21.BorderBrush = Brushes.Black;
                    b22.BorderBrush = Brushes.Black;
                    border.BorderBrush = Brushes.Gold;
                }
                else
                {
                    b00.BorderBrush = Brushes.Black;
                    b01.BorderBrush = Brushes.Black;
                    b02.BorderBrush = Brushes.Black;
                    b10.BorderBrush = Brushes.Black;
                    b11.BorderBrush = Brushes.Black;
                    b12.BorderBrush = Brushes.Black;
                    b20.BorderBrush = Brushes.Black;
                    b21.BorderBrush = Brushes.Black;
                    b22.BorderBrush = Brushes.Black;
                }
            }
        }

        private bool SquareNotTaken(Border border)
        {
            int row = border.Name[1] - '0';
            int column = border.Name[2] - '0';
            return (state[row, column] == 0);  // in state is zero, the square is not
        }

        private Border OverGridSquare(Point point)
        {
            if (point.X >= 150 && point.X <= 250 && point.Y >= 150 && point.Y <= 250)
            {
                return b00;
            }
            if (point.X >= 250 && point.X <= 350 && point.Y >= 150 && point.Y <= 250)
            {
                return b01;
            }
            if (point.X >= 350 && point.X <= 450 && point.Y >= 150 && point.Y <= 250)
            {
                return b02;
            }
            if (point.X >= 150 && point.X <= 250 && point.Y >= 250 && point.Y <= 350)
            {
                return b10;
            }
            if (point.X >= 250 && point.X <= 350 && point.Y >= 250 && point.Y <= 350)
            {
                return b11;
            }
            if (point.X >= 350 && point.X <= 450 && point.Y >= 250 && point.Y <= 350)
            {
                return b12;
            }
            if (point.X >= 150 && point.X <= 250 && point.Y >= 350 && point.Y <= 450)
            {
                return b20;
            }
            if (point.X >= 250 && point.X <= 350 && point.Y >= 350 && point.Y <= 450)
            {
                return b21;
            }
            if (point.X >= 350 && point.X <= 450 && point.Y >= 350 && point.Y <= 450)
            {
                return b22;
            }
            else
            {
                return null;
            }
        }
        
        private void whoseTurn()
        {
            //finds whose turn it is
            if (turn % 2 == 0)
            {
                findTurn.Content= "X's Turn";
            }
            else if (turn % 2 == 1 && turn <= 9)
            {
                findTurn.Content = "O's Turn";
            }
        }

        private bool found = false;
        private int winnerFound()
        {
            //first row
            if ((state[0, 0] == 1 || state[0, 0] == 2) && state[0, 0] == state[0, 1] && state[0, 0] == state[0, 2])
            {
                r1.Visibility = Visibility.Visible;
                found = true;
                return state[0, 0];
            }
            //second row
            if ((state[1, 0] == 1 || state[1, 0] == 2) && state[1, 0] == state[1, 1] && state[1, 0] == state[1, 2])
            {
                r2.Visibility = Visibility.Visible;
                found = true;
                return state[1, 0];
            }
            //third row
            if ((state[2, 0] == 1 || state[2, 0] == 2) && state[2, 0] == state[2, 1] && state[2, 0] == state[2, 2])
            {
                r3.Visibility = Visibility.Visible;
                found = true;
                return state[2, 0];
            }
            //first column
            if ((state[0, 0] == 1 || state[0, 0] == 2) && state[0, 0] == state[1, 0] && state[0, 0] == state[2, 0])
            {
                c1.Visibility = Visibility.Visible;
                found = true;
                return state[0, 0];
            }
            //second column
            if ((state[0, 1] == 1 || state[0, 1] == 2) && state[0, 1] == state[1, 1] && state[0, 1] == state[2, 1])
            {
                c2.Visibility = Visibility.Visible;
                found = true;
                return state[0, 1];
            }
            //third column
            if ((state[0, 2] == 1 || state[0, 2] == 2) && state[0, 2] == state[1, 2] && state[0, 2] == state[2, 2])
            {
                c3.Visibility = Visibility.Visible;
                found = true;
                return state[0, 2];
            }
            //diagnal
            if ((state[0, 0] == 1 || state[0, 0] == 2) && state[0, 0] == state[1, 1] && state[0, 0] == state[2, 2])
            {
                d2.Visibility = Visibility.Visible;
                found = true;
                return state[0, 0];
            }
            if ((state[2, 0] == 1 || state[2, 0] == 2) && state[2, 0] == state[1, 1] && state[2, 0] == state[0, 2])
            {
                d1.Visibility = Visibility.Visible;
                found = true;
                return state[2, 0];
            }
            else if (turn >= 9 && found == false)
            {
                return 0;
            }
            return 3;
        }

        private void determineWinner()
        {
            //if a winner is found, find who it is and display that
            if (found == true)
            {
                if (winnerFound() == 1)
                {
                    xScore += 1;
                    score1.Content = "X's Score: " + xScore;
                    findTurn.Content = "X Wins!";
                    PlayAgain.Visibility = Visibility.Visible;
                }
                else if (winnerFound() == 2)
                {
                    oScore += 1;
                    score2.Content = "O's Score: " + oScore;
                    findTurn.Content = "O Wins!";
                    PlayAgain.Visibility = Visibility.Visible;
                }
            }
            //otherwise display tie
            else if (winnerFound() == 0)
            {
                tieScore += 1;
                score3.Content = "Ties: " + tieScore;
                findTurn.Content = "Tie";
                PlayAgain.Visibility = Visibility.Visible;
            }
        }

        private void GamePiece_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);

            m_piece = sender as GamePiece;
            if (m_piece.IsPlaced)  // if a piece is already placed, it is not allowed to move again
                return;

            // If a grid square is gold, animate amove there
            foreach (Border border in borders)
            {
                if (border.BorderBrush == Brushes.Gold)
                {
                    m_Border = border;
                    int setVal = m_piece.Name[0] == 'x' ? 1 : 2;
                    double newTop;
                    double newLeft;

                    if (border == b00)
                    {
                        state[0, 0] = setVal;
                        newTop = 175;
                        newLeft = 175;
                    }
                    else if (border == b01)
                    {
                        state[0, 1] = setVal;
                        newTop = 175;
                        newLeft = 275;
                    }
                    else if (border == b02)
                    {
                        state[0, 2] = setVal;
                        newTop = 175;
                        newLeft = 375;
                    }
                    else if (border == b10)
                    {
                        state[1, 0] = setVal;
                        newTop = 275;
                        newLeft = 175;
                    }
                    else if (border == b11)
                    {
                        state[1, 1] = setVal;
                        newTop = 275;
                        newLeft = 275;
                    }
                    else if (border == b12)
                    {
                        state[1, 2] = setVal;
                        newTop = 275;
                        newLeft = 375;
                    }
                    else if (border == b20)
                    {
                        state[2, 0] = setVal;
                        newTop = 375;
                        newLeft = 175;
                    }
                    else if (border == b21)
                    {
                        state[2, 1] = setVal;
                        newTop = 375;
                        newLeft = 275;
                    }
                    else
                    {
                        state[2, 2] = setVal;
                        newTop = 375;
                        newLeft = 375;
                    }

                    Point topLeft = m_piece.TranslatePoint(new Point(0, 0), myCanvas);
                    m_piece.RenderTransform = null;

                    DoubleAnimation daL = new DoubleAnimation(topLeft.X, newLeft, TimeSpan.FromMilliseconds(500));
                    daL.Completed += new EventHandler(da_Completed);
                    m_piece.BeginAnimation(Canvas.LeftProperty, daL);

                    DoubleAnimation daT = new DoubleAnimation(topLeft.Y, newTop, TimeSpan.FromMilliseconds(500));
                    daT.Completed += new EventHandler(da_Completed);
                    m_piece.BeginAnimation(Canvas.TopProperty, daT);

                    m_piece.IsPlaced = true;

                    turn++;
                    whoseTurn();
                    winnerFound();
                    determineWinner();
                    break;
                }
                else  // Else animate a move back to the character's starting position
                {
                    Point topLeft = m_piece.TranslatePoint(new Point(0, 0), myCanvas);
                    m_piece.RenderTransform = null;

                    DoubleAnimation daL = new DoubleAnimation(topLeft.X, Canvas.GetLeft(m_piece), TimeSpan.FromMilliseconds(500));
                    m_piece.BeginAnimation(Canvas.LeftProperty, daL);

                    DoubleAnimation daT = new DoubleAnimation(topLeft.Y, Canvas.GetTop(m_piece), TimeSpan.FromMilliseconds(500));
                    m_piece.BeginAnimation(Canvas.TopProperty, daT);
                }
                allowMove = false;
            }
        }

        private void da_Completed(object sender, EventArgs e)
        {
            b00.BorderBrush = Brushes.Black;
            b01.BorderBrush = Brushes.Black;
            b02.BorderBrush = Brushes.Black;
            b10.BorderBrush = Brushes.Black;
            b11.BorderBrush = Brushes.Black;
            b12.BorderBrush = Brushes.Black;
            b20.BorderBrush = Brushes.Black;
            b21.BorderBrush = Brushes.Black;
            b22.BorderBrush = Brushes.Black;
        }

        private void PlayAgain_Click(Object Sender, RoutedEventArgs e)
        {
            turn = 0;
            found = false;
            //resetting game
            findTurn.Content = "X's Turn";
            r1.Visibility = Visibility.Hidden;
            r2.Visibility = Visibility.Hidden;
            r3.Visibility = Visibility.Hidden;

            c1.Visibility = Visibility.Hidden;
            c2.Visibility = Visibility.Hidden;
            c3.Visibility = Visibility.Hidden;

            d1.Visibility = Visibility.Hidden;
            d2.Visibility = Visibility.Hidden;

            PlayAgain.Visibility = Visibility.Hidden;
            
            x1.IsPlaced = false;
            x2.IsPlaced = false;
            x3.IsPlaced = false;
            x4.IsPlaced = false;
            x5.IsPlaced = false;
            o1.IsPlaced = false;
            o2.IsPlaced = false;
            o3.IsPlaced = false;
            o4.IsPlaced = false;

            state = new int[3, 3];
            resetXs();
            resetOs();
        }

        private void resetXs()
        {
            //puts every X to its original spot
            GamePiece[] pieces = new GamePiece[5] { x1, x2, x3, x4, x5 };
            int[] locations = new int[5] { 180, 260, 340, 420, 500 };
            for (int i = 0; i < 5; i++)
            {
                DoubleAnimation dL = new DoubleAnimation(Canvas.GetLeft(pieces[i]), 30, TimeSpan.FromMilliseconds(500));
                pieces[i].BeginAnimation(Canvas.LeftProperty, dL);
                DoubleAnimation dT = new DoubleAnimation(Canvas.GetTop(pieces[i]), locations[i], TimeSpan.FromMilliseconds(500));
                pieces[i].BeginAnimation(Canvas.TopProperty, dT);
            }
        }

        private void resetOs()
        {
            //puts every O to its original spot
            GamePiece[] pieces = new GamePiece[4] { o1, o2, o3, o4 };
            int[] locations = new int[4] { 260, 340, 420, 500 };
            for (int i = 0; i < 4; i++)
            {
                DoubleAnimation dL = new DoubleAnimation(Canvas.GetLeft(pieces[i]), 530, TimeSpan.FromMilliseconds(500));
                pieces[i].BeginAnimation(Canvas.LeftProperty, dL);
                DoubleAnimation dT = new DoubleAnimation(Canvas.GetTop(pieces[i]), locations[i], TimeSpan.FromMilliseconds(500));
                pieces[i].BeginAnimation(Canvas.TopProperty, dT);
            }
        }

    }
}