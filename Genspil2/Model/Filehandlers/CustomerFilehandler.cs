using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genspil2.Model.Filehandlers
{
    internal class CustomerFileHandler
    {
        private const string CustomerFilepath = @"..\..\..\Storage\Customers.txt";

        public static void ReadCustomerFromTextFile(Overview customerOverview)
        {
            var lines = File.ReadLines(CustomerFilepath).ToList();
            lines.RemoveAt(0);
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                Customer customer = new Customer(values[0], values[1], values[2], int.Parse(values[3]));
                customerOverview.CustomerList.Add(customer);
            }
        }
        public static Customer WriteCustomerToTextFile(string Name, string tlf, string email, int ID)
        {
            var createText = Environment.NewLine + $"{Name},{tlf},{email},{ID}";
            File.AppendAllText(CustomerFilepath, createText);
            var customer = new Customer(Name, tlf, email, ID);
            return customer;
        }

        public static void DeleteCustomer(int id)
        {
            List<string> savedCustomer = new List<string>();
            List <string> lines = File.ReadLines(CustomerFilepath).ToList();
            lines.RemoveAt(0);
            foreach (string line in lines)
            {
                try
                {
                    string[] values = line.Split(',');
                    if (int.Parse(values[3]) != id)
                    {
                        savedCustomer.Add(line);
                    }
                }
                catch (IndexOutOfRangeException)    { }
            }

            File.WriteAllText(CustomerFilepath, "navn,tlf,e-mail,id");

            foreach (string line in savedCustomer)
            {
                File.AppendAllText(CustomerFilepath, Environment.NewLine + line );
            }
        }
    }
}
