using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Class1
    {
        string _name;
        string _lastName;
        decimal _balance;

        public Class1(string name, string lastName, decimal balance)
        {

            _name = name;
            _lastName = lastName;
            _balance = balance;

        }
        public string Name
        {
            get{ 
                return _name; 
            }
            set {
                _name = value; 
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return _balance;
            }
            set { 
            _balance = value;
            }
        }










    }
}
