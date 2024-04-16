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
        ProdsSttc._PresentUser = null;
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
                        ProdsSttc._PresentUser = user;
                        ListWindow listWindow = new();
                        listWindow.Show();
                        this.Close();
                    }
                    PasswordIncorrect.IsVisible = TBox_Login.Text == user.Password ? false : true;
                }
                LoginIncorrect.IsVisible = TBox_Login.Text == user.Name ? false : true;
                PasswordIncorrect.IsVisible = TBox_Login.Text == user.Password ? false : true;
            }
        }
        PasswordIncorrect.IsVisible = TBox_Password.Text == "" || TBox_Password.Text == null ? true : false;
        //LoginIncorrect.IsVisible = true;
        //PasswordIncorrect.IsVisible = true;
    }
}