using Genspil2.Model;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace Genspil2.Gui.Printer
{
    internal class ReservationPrinter
    {
        private static int _columnWidth = 15;
        private static int _wideColumnWidth = 20;
        private static int narrowColumnWidth = 5;
        private static double showPrPage = 10;
        private static TextInfo textCulture = new CultureInfo("da-DK", false).TextInfo;
        public static void PrintReservations(List<Reservation> reservationList, List<Genre> genres, string sortBy, bool ascending, int pageNumber)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Reservationsliste:");

            //Top line
            Console.WriteLine("┌".PadRight(_wideColumnWidth, '─') + "┬".PadRight(_columnWidth, '─') + "┬".PadRight(_columnWidth, '─') + "┬".PadRight(narrowColumnWidth, '─') +
                "┬".PadRight(_wideColumnWidth, '─') + "┬".PadRight(_columnWidth, '─') + "┬".PadRight(_columnWidth, '─') + "┬".PadRight(narrowColumnWidth, '─') + "┬".PadRight(_columnWidth, '─') + "┬".PadRight(narrowColumnWidth, '─') + "┐");

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

            sb.Append("│telefon".PadRight(_columnWidth) + "│email".PadRight(_columnWidth) + "│K.ID".PadRight(narrowColumnWidth) +
            "│Spilnavn".PadRight(_wideColumnWidth) + "│Spilgenre".PadRight(_columnWidth) + "│stand".PadRight(_columnWidth) + "│Pris".PadRight(narrowColumnWidth) + "│Noter".PadRight(_columnWidth) + "│R.ID".PadRight(narrowColumnWidth, '─') + "│");
            Console.WriteLine(sb);

            //print reservationer
            if (sortBy == "n" && ascending == true)
            {
                int i = 0;
                foreach (Reservation reservation in reservationList.OrderBy(x => x.Customer.Name))
                {
                    if (i < (showPrPage * pageNumber) && i >= (showPrPage * pageNumber) - showPrPage)
                    {
                        PrintReservation(reservation,genres);
                    }
                    i++;
                }
            }
            else if (sortBy == "n" && ascending == false)
            {
                int i = 0;
                foreach (Reservation reservation in reservationList.OrderByDescending(x => x.Customer.Name))
                {
                    if (i < (showPrPage * pageNumber) && i >= (showPrPage * pageNumber) - showPrPage)
                    {
                        PrintReservation(reservation, genres);
                    }
                    i++;
                }
            }


            //Bund linje
            Console.WriteLine("└".PadRight(_wideColumnWidth, '─') + "┴".PadRight(_columnWidth, '─') + "┴".PadRight(_columnWidth, '─') + "┴".PadRight(narrowColumnWidth, '─') +
                    "┴".PadRight(_wideColumnWidth, '─') + "┴".PadRight(_columnWidth, '─') + "┴".PadRight(_columnWidth, '─') + "┴".PadRight(narrowColumnWidth, '─') + "┴".PadRight(_columnWidth, '─') + "┴".PadRight(narrowColumnWidth, '─') + "┘");

            Instructionprinter.PrintPagening(reservationList.Count, showPrPage, pageNumber);

            //instruktioner 
            Instructionprinter.PrintInstructions("reservation");
            Instructionprinter.PrintSorteringInstruktions("n: sorter efter navn");
        }
        private static void PrintReservation(Reservation reservation,List<Genre> genres)
        {
            string genreName = textCulture.ToTitleCase(genres.Find(x => x.ID == int.Parse(reservation.BoardGame.Genre)).Name);
            string name = textCulture.ToTitleCase(reservation.Customer.Name);

            Console.WriteLine("├".PadRight(_wideColumnWidth, '─') + "┼".PadRight(_columnWidth, '─') + "┼".PadRight(_columnWidth, '─') + "┼".PadRight(narrowColumnWidth, '─') +
                   "┼".PadRight(_wideColumnWidth, '─') + "┼".PadRight(_columnWidth, '─') + "┼".PadRight(_columnWidth, '─') + "┼".PadRight(narrowColumnWidth, '─') + "┼".PadRight(_columnWidth, '─') + "┼".PadRight(narrowColumnWidth, '─') + "┤");


            Console.WriteLine($"│{name}".PadRight(_wideColumnWidth) + $"│{reservation.Customer.Tlf}".PadRight(_columnWidth) + $"│{reservation.Customer.Email}".PadRight(_columnWidth) + $"│{reservation.Customer.Id}".PadRight(narrowColumnWidth) +
                $"│{reservation.BoardGame.Name}".PadRight(_wideColumnWidth) + $"│{genreName}".PadRight(_columnWidth) + $"│{reservation.BoardGame.State}".PadRight(_columnWidth) + $"│{reservation.BoardGame.Price}".PadRight(narrowColumnWidth) + $"│{reservation.Notes}".PadRight(_columnWidth) + $"│{reservation.ReservationId}".PadRight(narrowColumnWidth) + "│");

        }
    }
    }

