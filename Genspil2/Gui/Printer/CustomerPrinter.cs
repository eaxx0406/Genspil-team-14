using Genspil2.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Genspil2.Gui.Printer
{
    internal class CustomerPrinter
    {

        private static int _columnWidth = 25;
        private static int _wideColumnWidth = 35;
        private static double showPrPage = 10;
        private static TextInfo textCulture = new CultureInfo("da-DK", false).TextInfo; // Change the culture to Danish

        public static void PrintCustomerOverview(List<Customer> customerList, string sortBy,  bool ascending, int pageNumber)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Kundeliste:");

            //toplinje
            Console.WriteLine("┌".PadRight(_wideColumnWidth, '─') + "┬".PadRight(_columnWidth, '─') + "┬".PadRight(_columnWidth, '─') + "┬".PadRight(_columnWidth, '─') + "┐");

            PrintSorting(sortBy, ascending);

            //sorter efter navn
            if (sortBy == "n" && ascending == true)
            {
                int i = 0;
                foreach (Customer customer in customerList.OrderBy(x => x.Name))
                {
                    if (i < (showPrPage * pageNumber) && i >= (showPrPage * pageNumber) - showPrPage)
                    {
                        PrintCustomer(customer);
                    }
                    i++;
                }
            }
            else if (sortBy == "n" && ascending == false)
            {
                int i = 0;
                foreach (Customer customer in customerList.OrderByDescending(x => x.Name))
                {
                    if (i < (showPrPage * pageNumber) && i >= (showPrPage * pageNumber) - showPrPage)
                    {
                        PrintCustomer(customer);
                    }
                    i++;
                }
            }

            //sorter efter id
            if (sortBy == "i" && ascending == true)
            {
                int i = 0;
                foreach (Customer customer in customerList.OrderBy(x => x.Id))
                {
                    if (i < (showPrPage * pageNumber) && i >= (showPrPage * pageNumber) - showPrPage)
                    {
                        PrintCustomer(customer);
                    }
                    i++;
                }
            }
            else if (sortBy == "i" && ascending == false)
            {
                int i = 0;
                foreach (Customer customer in customerList.OrderByDescending(x => x.Id))
                {
                    if (i < (showPrPage * pageNumber) && i >= (showPrPage * pageNumber) - showPrPage)
                    {
                        PrintCustomer(customer);
                    }
                    i++;
                }
            }


            //Bund linje
            Console.WriteLine("└".PadRight(_wideColumnWidth, '─') + "┴".PadRight(_columnWidth, '─') + "┴".PadRight(_columnWidth, '─') + "┴".PadRight(_columnWidth, '─') + "┘");

            Instructionprinter.PrintPagening(customerList.Count, showPrPage, pageNumber);

            //instruktioner 
            Instructionprinter.PrintInstructions("kunde");
            Instructionprinter.PrintSorteringInstruktions("n: sorter efter navn, i:sorter efter ID ");
        }

        public static void PrintSorting(string sortBy,bool ascending)
        {
          StringBuilder sb = new StringBuilder();

            //sorteret efter navn
            if (sortBy == "n" && ascending == true)
            {
                sb.Append("│Navn ∆".PadRight(_wideColumnWidth));
            }
            else if (sortBy == "n" && ascending == false)
            {
                sb.Append("│Navn ∇".PadRight(_wideColumnWidth));
            }
            else { sb.Append("│Navn ".PadRight(_wideColumnWidth)); }

            sb.Append("│telefon".PadRight(_columnWidth) + "│email".PadRight(_columnWidth));

            //sorteret efter id
            if (sortBy == "i" && ascending == true)
            {
                sb.Append("│ID ∆".PadRight(_columnWidth) + "│");
            }
            else if (sortBy == "i" && ascending == false)
            {
                sb.Append("│ID ∇".PadRight(_columnWidth) + "│");
            }
            else { sb.Append("│ID ".PadRight(_columnWidth) + "│"); }

            Console.WriteLine(sb);
        }
        private static void PrintCustomer(Customer customer) 
        {
            string name = textCulture.ToTitleCase(customer.Name);
            Console.WriteLine("├".PadRight(_wideColumnWidth, '─') + "┼".PadRight(_columnWidth, '─') + "┼".PadRight(_columnWidth, '─') + "┼".PadRight(_columnWidth, '─') + "┤");
            Console.WriteLine($"│{name}".PadRight(_wideColumnWidth) + $"│{customer.Tlf}".PadRight(_columnWidth) + $"│{customer.Email}".PadRight(_columnWidth) + $"│{customer.Id}".PadRight(_columnWidth) + "│");
        }
    }
}
