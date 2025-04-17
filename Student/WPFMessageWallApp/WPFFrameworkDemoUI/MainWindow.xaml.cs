using System.ComponentModel;
using System.Windows;


namespace WPFFrameworkDemoUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BindingList<string> messages = new BindingList<string>();

        public MainWindow()
        {
            InitializeComponent();
            MessageList.ItemsSource = messages;
        }

        private void addMessage_Click(object sender, RoutedEventArgs e)
        {
            messages.Add(messageText.Text);
            messageText.Text = "";
        }
    }
}
