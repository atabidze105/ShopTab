using Avalonia.Controls;
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
        }

        private void AddItem(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            RedWindow redWindow = new RedWindow(-1);

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
                        RedWindow redWindow = new RedWindow((int)(sender as Button)!.Tag!);

                        redWindow.Show();
                        this.Close();
                    }
                    break;
            }
        }
    }
}