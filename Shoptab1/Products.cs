using System;
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
        public static List<Product> _LBoxItems = [new Product("помидор", 15, 2, 0), new Product("покрыжка", 2, 12, 1), new Product("приветки", 34, 3, 2), new Product("огурей", 96, 45, 3)];
        public static List<User> _Users = [new User("admin","admin", true), new User("user", "user", false)];
        public static List<Product> _FoundProducts = new();
        public static Product _redProduct = null;
        public static User _PresentUser = null;
    }
}
