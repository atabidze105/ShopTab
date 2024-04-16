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
            LBox.ItemsSource = ProdsSttc._LBoxItems.Select(x => new
            {
                x.Name,
                x.Price,
                x.Quantity,
                x.Id,
                IsAdmin = ProdsSttc._PresentUser.Admin
            });

            btn_add.Content = ProdsSttc._PresentUser.Admin == true ? "Добавить товар" : "Перейти в корзину";
        }

        private void SearchingEvent(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            searching();
        }

        void searching()
        {
            if (TBox_Search.Text != null || TBox_Search.Text == "")
            {
                ProdsSttc._FoundProducts.Clear();
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
            if (ProdsSttc._PresentUser.Admin == true)
            {
                RedWindow redWindow = new RedWindow();

                redWindow.Show();
                this.Close();
            }
            else
            {

            }
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

        private void LogOut(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ProdsSttc._PresentUser = null;
            MainWindow mainWindow = new();

            mainWindow.Show();
            this.Close();
        }
    }
}