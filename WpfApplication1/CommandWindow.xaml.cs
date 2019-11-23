using System.Windows;
using System.Windows.Input;

namespace WpfApplication1
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand(
            "Exit",
            "Exit",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F4, ModifierKeys.Alt)
            }
        );
    }


    public partial class CommandWindow : Window
    {

        public bool IsCan { get; set; }

        public CommandWindow()
        {
            IsCan = true;
            InitializeComponent();
        }

        public void CanExecute_ExitCommand(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            eventArgs.CanExecute = true;
        }
        
        public void Exceute_ExitCommand(object sender, ExecutedRoutedEventArgs eventArgs)
        {
            Application.Current.Shutdown();
        }
        
    }
}