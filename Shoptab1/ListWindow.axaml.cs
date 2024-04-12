using Avalonia.Controls;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopTab1
{
    public partial class ListWindow : Window
    {

        public ListWindow()
        {
            InitializeComponent();
            LBox.ItemsSource = ProdsSttc._LBoxItems.ToList();
            TBox_Search.AddHandler(TextInputEvent, searching, Avalonia.Interactivity.RoutingStrategies.Tunnel);
        }

        void searching(object sender, TextInputEventArgs e) //Метод для поиска товаров по имени
        {
            if (TBox_Search.Text != null || TBox_Search.Text != "")
            {
                ProdsSttc._LBoxItems.Clear();
                foreach (Product product in ProdsSttc._LBoxItems)
                {
                    if (product.Name.Contains(TBox_Search.Text))
                    {
                        ProdsSttc._FoundProducts.Add(product);
                    }
                }
                LBox.ItemsSource = ProdsSttc._FoundProducts.ToList();
            }
            else
            {
                LBox.ItemsSource = ProdsSttc._LBoxItems.ToList();
            }
        }

        private void AddItem(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            RedWindow redWindow = new RedWindow();

            redWindow.Show();
            this.Close();
        }

        private void ItemManipulation(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

            var button = (sender as Button)!;
            switch (button.Name)
            {
                case "btn_del":
                    {
                        ProdsSttc._LBoxItems.RemoveAt((int)(sender as Button)!.Tag!);
                        for (int i = 0; i < ProdsSttc._LBoxItems.Count; i++)
                        {
                            ProdsSttc._LBoxItems[i].Id = i;
                        }
                        LBox.ItemsSource = ProdsSttc._LBoxItems.ToList();
                    }
                    break;
                case "btn_red":
                    {
                        ProdsSttc._redProduct = ProdsSttc._LBoxItems.ElementAt((int)(sender as Button)!.Tag!);
                        RedWindow redWindow = new RedWindow();

                        redWindow.Show();
                        this.Close();
                    }
                    break;
            }
        }
    }
}