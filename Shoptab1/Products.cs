﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTab1
{
    public class User
    {
        private string _name;
        private string _password;
        private bool _admin;

        public User(string name, string password, bool admin)
        {
            _name = name;
            _password = password;
            _admin = admin;
        }

        public string Name
        { 
            get { return _name; }
            set { _name = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public bool Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }
    }
    public class Product
    {
        private string _name;
        private double _price;
        private int _quantity;
        private int _id;

        public Product(string name, double price, int quantity, int id)
        {
            _name = name;
            _price = price;
            _quantity = quantity;
            _id = id;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }

    static class ProdsSttc
    {
        public static List<Product> _LBoxItems = new();
        public static List<User> _Users = new() { new User("admin","admin", true), new User("user", "user", false) };
    }
}