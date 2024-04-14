using Genspil2.Gui.Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2.Model.Seachers
{
    internal class CustomerSearcher
    {
        public static void SeachForCustomer(Overview overview)
        {
            List<Customer> CustomerToSearchCriteria = new List<Customer>();

            Console.Clear();
            Console.WriteLine("Indtast helt eller delvist navn at søge efter: ");
            string searchFor = Console.ReadLine().ToLower();
            foreach (Customer customer in overview.CustomerList)
            {
                if (customer.Name.Contains(searchFor))
                {
                    CustomerToSearchCriteria.Add(customer);
                }
            }
            CustomerPrinter.PrintCustomerOverview(CustomerToSearchCriteria, "n",true,1);
        }
    }
}
