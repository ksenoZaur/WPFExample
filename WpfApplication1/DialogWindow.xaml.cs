using System.Windows;

namespace WpfApplication1
{
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        public void btn1_click(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("Простое сообщение!");
        }

        public void btn2_click(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("Сообщение с заголовком", "Зато не пешком");
        }

        public void btn3_click(object sender, RoutedEventArgs args)
        {
            MessageBoxResult result = MessageBox.Show(
                "Сообщение с заголовком и возможностью выбора", 
                "Зато не пешком", 
                MessageBoxButton.OKCancel
                );

            switch (result)
            {
                case MessageBoxResult.Cancel : 
                    MessageBox.Show("Вы выбрали \"Отмена\"");
                    break;
                case MessageBoxResult.OK :
                    MessageBox.Show("Вы выбрали \"ОК\"");
                    break;
            }
        }

        public void btn4_click(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("Сообщение и иконка", "Смешной заголовок", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        public void btn5_click(object sender, RoutedEventArgs args)
        {
            MessageBox.Show(
                "Сообщение, иконка, и выбор по умолчанию", 
                "Смешной заголовок", 
                MessageBoxButton.YesNo,
                MessageBoxImage.Stop,
                MessageBoxResult.No
                );

        }

        public void btn6_click(object sender, RoutedEventArgs args)
        {
            MessageBox.Show(
                "Ничего особенного", 
                "Не суй нос", 
                MessageBoxButton.OKCancel
            );
        }
    }
}