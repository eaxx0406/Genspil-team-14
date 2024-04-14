using Genspil2.Model.Filehandlers;
using Genspil2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2.Gui.Creators
{
    internal class CustomerCreator
    {
        public static Customer CreateCustomer(Overview customerOverview)
        {
            bool customerNameEntered = false, phoneEntered = false, emailEntered = false, contactsEntered = false;
            int id = 0;
            string name = "", tlf = "", email = "";

            Console.WriteLine("Opret en kunde");

            //kundenavn
            while (customerNameEntered == false)
            {
                Console.WriteLine("Indtast navn: ");
                name = Console.ReadLine().ToLower();
                if (string.IsNullOrWhiteSpace(name) == false) { customerNameEntered = true; }
            }

            while (contactsEntered == false)
            {
                // kundetelefon nr.
                Console.WriteLine("Indtast telefonnummer: ");
                tlf = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tlf) == false) { phoneEntered = true; }
                else { tlf = "ikke angivet"; emailEntered = false; }

                //email
                Console.WriteLine("Indtast email: ");
                email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(email) == false) { emailEntered = true; }
                else { email = "ikke angivet"; emailEntered = false; }

                if (phoneEntered == false && emailEntered == false) 
                { 
                    Console.WriteLine("Du har hverken indtastet email eller tlf, vil du fortsætte? (tryk y for at bekræfte)");
                    string userAnswer = Console.ReadLine();
                    if (userAnswer == "y") { contactsEntered = true; }
                }
                else { contactsEntered = true; }
            }

            //id
            id = customerOverview.CustomerList.Max(x => x.Id) + 1;

            Customer newCustomer = CustomerFileHandler.WriteCustomerToTextFile(name, tlf, email, id);
            customerOverview.CustomerList.Add(newCustomer);
            return newCustomer;
        }
    }
}