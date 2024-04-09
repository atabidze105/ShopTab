using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ShopTab1;

namespace ShopTab1;

public partial class RedWindow : Window
{
    Product _selectedProduct = null;
    public RedWindow(int privet)
    {
        InitializeComponent();
        if (privet >= 0)
        {
            foreach (Product prod in ProdsSttc._LBoxItems)
            {
                if (prod.Id == privet)
                {
                    _selectedProduct = prod;
                }
            }
            TBox_Name.Text = _selectedProduct.Name;
            NUD_Price.Text = Convert.ToString(_selectedProduct.Price);
            NUD_Count.Text = Convert.ToString(_selectedProduct.Quantity);
        }
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
                        if (_selectedProduct == null)
                        {
                            ProdsSttc._LBoxItems.Add(new Product(TBox_Name.Text, Convert.ToDouble(NUD_Price.Text), Convert.ToInt32(NUD_Count.Text), ProdsSttc._LBoxItems.Count));
                        }
                        else
                        {
                            _selectedProduct.Name = TBox_Name.Text;
                            _selectedProduct.Price = Convert.ToDouble(NUD_Price.Text);
                            _selectedProduct.Quantity = Convert.ToInt32(NUD_Count.Text);
                            ProdsSttc._LBoxItems[_selectedProduct.Id] = _selectedProduct;
                            _selectedProduct = null;
                        }
                    }
                    break;
            }
            ListWindow listWindow = new ListWindow();
            listWindow.Show();
            this.Close();
        } 
        catch 
        {
            ListWindow listWindow = new ListWindow();
            listWindow.Show();
            this.Close();
        }
    }
}