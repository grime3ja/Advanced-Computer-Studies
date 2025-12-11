using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace _4D_Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for GamePiece.xaml
    /// </summary>
    public partial class GamePiece : UserControl
    {
        public GamePiece()
        {
            InitializeComponent();
        }

        private String source;
        public String Source
        {
            get
            {
                return source;
            }
            set
            {
                this.imgPiece.Source = new BitmapImage(new Uri(value, UriKind.Relative));
                source = value;
            }
        }

        private bool isPlaced = false;
        public bool IsPlaced
        {
            get
            {
                return isPlaced;
            }
            set
            {
                this.isPlaced = value;
            }
        }
    }
}