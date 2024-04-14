using Genspil2.Model;
using Genspil2.Model.Filehandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2.Gui.Editors
{
    internal class CustomerEditor
    {

        public static void EditCustomer(Overview overview,int id)
        {
            //find kunde der skal redigeres 
            Customer customer = overview.CustomerList.FirstOrDefault(c => c.Id == id);

            if (customer != null) //kunde fundet
            {
                //rediger navn
                Console.WriteLine("Indtast navn");
                Console.ForegroundColor = ConsoleColor.DarkGray; 
                Console.Write(customer.Name);
                int cursorheight = Console.CursorTop;
                Console.SetCursorPosition(0, cursorheight);
                Console.ForegroundColor = ConsoleColor.Gray; //sæt tekstfarve til standard
                string changeNameToo = Console.ReadLine().ToLower();
                if (string.IsNullOrWhiteSpace(changeNameToo) == false) 
                { 
                    customer.Name = changeNameToo; 
                }

                //rediger Tlf nr.
                Console.WriteLine("Indtast tlf nr.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(customer.Tlf);
                cursorheight = Console.CursorTop;
                Console.SetCursorPosition(0, cursorheight);
                Console.ForegroundColor = ConsoleColor.Gray; //sæt tekstfarve til standard
                string changePhoneTo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(changePhoneTo) == false)
                {
                    customer.Tlf = changePhoneTo;
                }

                //rediger e-mail
                Console.WriteLine("Indtast email");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(customer.Email);
                cursorheight = Console.CursorTop;
                Console.SetCursorPosition(0, cursorheight);
                Console.ForegroundColor = ConsoleColor.Gray; //sæt tekstfarve til standard
                string changeEmailTo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(changeEmailTo) == false)
                {
                    customer.Email = changeEmailTo;
                }

                CustomerFileHandler.DeleteCustomer(id);
                CustomerFileHandler.WriteCustomerToTextFile(customer.Name, customer.Tlf,customer.Email,customer.Id);


            } else // kunde ikke fundet
            {
                Console.WriteLine("Kunde findes ikke");
            }

        }
    }
}
