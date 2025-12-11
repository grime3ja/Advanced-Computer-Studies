using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Spinner
{
    /// <summary>
    /// Interaction logic for SpinnerControl.xaml
    /// </summary>
    public partial class SpinnerControl : UserControl, INotifyPropertyChanged
    {
        /* To get your data binding working, you need a few things:
         * 
         * 1.  Create a public event for PropertyChanged, just like below.
         * 2.  Follow the new event with an OnPropertyChanged nmethod, also like below.
         * 3.  Make sure the MainWindow class inherits from INotifyPropertyChanged.
         * 4.  After the component is initialized, the data context must be set with something like "this.DataContext = this".
         * 5.  Properties can now be bound by XAML such as "{Binding MyProperty, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}".
         * 6.  All bound properties must have a public set that calls this.OnPropertyChanged("MyProperty").
         */
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SpinnerControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (minValue > maxValue)
            {
                maxValue = minValue;
            }
            if (defaultValue < minValue)
            {
                ControlValue = minValue;
            }
            else if (defaultValue > maxValue)
            {
                ControlValue = maxValue;
            }
            else
            {
                ControlValue = defaultValue;
            }
        }

        private long controlValue = 0;
        public long ControlValue
        {
            get
            {
                return controlValue;
            }
            set
            {
                controlValue = value;
                OnPropertyChanged("ControlValue");
            }
        }

        //button height
        private double height = 20;
        public double ControlHeight
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                OnPropertyChanged("height");
            }
        }
        private double width = 40;
        public double ControlWidth
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                OnPropertyChanged("width");
            }
        }
        public double ArrowHeight
        {
            get
            {
                return height / 2.0;
            }
        }

        private long increment = 1;
        public long Increment
        {
            get
            {
                return increment;
            }
            set
            {
                increment = value;
            }
        }

        private long maxValue = 100;
        public long MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = value;
            }
        }

        private long minValue = 1;
        public long MinValue
        {
            get
            {
                return minValue;
            }
            set
            {
                minValue = value;
            }
        }

        private long defaultValue = 0;
        public long DefaultValue
        {
            get
            {
                return defaultValue;
            }
            set
            {
                defaultValue = value;
            }
        }
        private void DownArrow_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ControlValue - increment > minValue)
            {
                ControlValue -= increment;
            }
            else
            {
                ControlValue = 1;
            }
        }
        private void UpArrow_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ControlValue + increment < maxValue)
            {
                ControlValue += increment;
            }
            else
            {
                ControlValue = 100000;
            }
        }
    }
}