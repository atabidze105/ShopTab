using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ShopTab1;

namespace ShopTab1;

public partial class RedWindow : Window
{
    public RedWindow()
    {
        InitializeComponent();
        if (ProdsSttc._redProduct != null)
        {
            TBox_Name.Text = ProdsSttc._redProduct.Name;
            NUD_Price.Text = Convert.ToString(ProdsSttc._redProduct.Price);
            NUD_Count.Text = Convert.ToString(ProdsSttc._redProduct.Quantity);
        }
        btn_Add.Content = ProdsSttc._redProduct != null ? "Сохранить" : "Добавить";
    }

    private void AddItem(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            var button = (sender as Button)!;
            switch (button.Name)
            {
                case "btn_Add":
                    {
                        if (ProdsSttc._redProduct == null)
                        {
                            ProdsSttc._LBoxItems.Add(new Product(TBox_Name.Text, Convert.ToDouble(NUD_Price.Text), Convert.ToInt32(NUD_Count.Text), ProdsSttc._LBoxItems.Count));
                        }
                        else
                        {
                            ProdsSttc._redProduct.Name = TBox_Name.Text;
                            ProdsSttc._redProduct.Price = Convert.ToDouble(NUD_Price.Text);
                            ProdsSttc._redProduct.Quantity = Convert.ToInt32(NUD_Count.Text);
                            ProdsSttc._LBoxItems[ProdsSttc._redProduct.Id] = ProdsSttc._redProduct;
                        }
                    }
                    break;
            }
            ProdsSttc._redProduct = null;
            ListWindow listWindow = new();
            listWindow.Show();
            this.Close();
        } 
        catch 
        {
            ProdsSttc._redProduct = null;
            ListWindow listWindow = new();
            listWindow.Show();
            this.Close();
        }
    }

    private void numbersCheck(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        try
        {
            var textbox = sender as TextBox;
            textbox.Text = textbox.Text.EndsWith("1") || textbox.Text.EndsWith("2") || textbox.Text.EndsWith("3") ||
                textbox.Text.EndsWith("4") || textbox.Text.EndsWith("5") || textbox.Text.EndsWith("6") || textbox.Text.EndsWith("7") ||
                textbox.Text.EndsWith("8") || textbox.Text.EndsWith("9") || textbox.Text.EndsWith("0") ?
                textbox.Text : textbox.Text.Remove(textbox.Text.Length - 1, 1);
        }
        catch
        {}
    }
}