using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ShopTab1;

namespace ShopTab1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void LogIn(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        LoginIncorrect.IsVisible = false;
        PasswordIncorrect.IsVisible = false;
        if (TBox_Login.Text != "" || TBox_Login.Text != null || TBox_Password.Text != "" || TBox_Password.Text != null)
        {
            foreach (User user in ProdsSttc._Users)
            {
                if (TBox_Login.Text == user.Name)
                {
                    if (TBox_Password.Text == user.Password)
                    {
                        ListWindow listWindow = new ListWindow();
                        listWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        PasswordIncorrect.IsVisible = true;
                    }
                }
                LoginIncorrect.IsVisible = true;
            }
        }
        LoginIncorrect.IsVisible = true;
        PasswordIncorrect.IsVisible = true;
    }
}