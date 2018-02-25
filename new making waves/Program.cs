using System;

namespace CommandLineDateRange
{
    class Display
    {
        // fields
        private DateTime date1, date2;
        public string[] args;

        public void GetConsoleInput()
        {
            try
            {

                date1 = Convert.ToDateTime(args[0]);
                date2 = Convert.ToDateTime(args[1]);
            }
            catch (Exception)
            {
                // display indication of invalid input from command line
                Console.WriteLine(@"Invalid Input, please insert two dates in a format of dd.mm.yyyy for example 'Program 01.01.2016 04.05.2017");
                Console.ReadLine();
                return;
            }
        }

        public static void DisplayIF(ref DateTime date1, ref DateTime date2)

        {
            if (date1.Year == date2.Year && date1.Month == date2.Month)
            {
                Console.WriteLine("{0:dd} - {1:dd.MM.yyyy}", date1, date2);

                Console.ReadKey();
            }
            else if (date1.Year == date2.Year && date1.Month != date2.Month)
            {
                Console.WriteLine("{0:dd.MM} - {1:dd.MM.yyyy}", date1, date2);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("{0:dd.MM.yyyy} - {1:dd.MM.yyyy}", date1, date2);
                Console.ReadKey();
            }
        }

        static DateTime tempswap;

        public void SwapDatesM(ref DateTime ndate1, ref DateTime ndate2)
        {
            tempswap = ndate1;
            ndate1 = ndate2;
            ndate2 = tempswap;

        }

        public void DisplayWhenOrder()
        {
            if (date1 <= date2)
            {
                DisplayIF(ref date1, ref date2);
            }
            else
            {
                SwapDatesM(ref date1, ref date2);

                DisplayIF(ref date1, ref date2);
            }
        }

    }



    class Program
    {
        // 
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter two dates.");

            }


            Display display = new Display();
            display.args = args;
            display.GetConsoleInput();

            display.DisplayWhenOrder();

        }
    }

}

/* left here on purpose by J. Kamirski - the very first version w/o globalization
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    
    namespace DateRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date1, date2;


            // try-catch  used for error handling
            try  
            {
                date1 = Convert.ToDateTime(args[0]);
                date2 = Convert.ToDateTime(args[1]);

                //this method displays results in format depending on Year or Month are the same or not

                void Display(ref DateTime sdate1, ref DateTime sdate2)
                {
                    if (date1.Year == date2.Year && date1.Month == date2.Month)
                    {
                        Console.WriteLine("{0:dd} - {1:dd.MM.yyyy}", date1, date2);
                    }
                    else if (date1.Year == date2.Year && date1.Month != date2.Month)
                    {
                        Console.WriteLine("{0:dd.MM} - {1:dd.MM.yyyy}", date1, date2);
                    }
                    else
                    {
                        Console.WriteLine("{0:dd.MM.yyyy} - {1:dd.MM.yyyy}", date1, date2);
                    }
                }
                //this conditional if checks whether the order of dates is right if not - the method SwapDates swaps referenced variables
                if (date1 <= date2)
                {
                    Display(ref date1, ref date2);
                }
                else
                {
                    void SwapDates(ref DateTime ndate1, ref DateTime ndate2)
                    {
                        DateTime tempswap = ndate1;
                        ndate1 = ndate2;
                        ndate2 = tempswap;
                    }
                    SwapDates(ref date1, ref date2);

                    Display(ref date1, ref date2);
                }
            }
            catch (Exception)
            {
                // display indication of invalid input from command line
                Console.WriteLine(@"Invalid Input, please insert two dates in a format of dd.mm.yyyy for example 'Program 01.01.2016 04.05.2017");
                Console.ReadLine();
                return;
            }
        }
    }
}

    */


/* wyslane do making waves
 using System;
using System.Globalization;
using System.Threading;

namespace DateRanges
{
class Program
{
    static void Main(string[] args)
    {

        DateTime date1, date2;

        // Sets the CurrentCulture property to DE
        Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");

        const string formatfull = "dd.MM.yyyy";
        const string formatmo = "dd.MM";
        const string formatday = "dd";

        // try-catch  used for error handling
        try
        {
            date1 = Convert.ToDateTime(args[0]);
            date2 = Convert.ToDateTime(args[1]);

            //this method displays results in format depending on Year or Month are the same or not

            void Display(ref DateTime sdate1, ref DateTime sdate2)
            {
                var str1d = date1.ToString(formatday);
                var str1m = date1.ToString(formatmo);
                var str1f = date1.ToString(formatfull);
                var str2 = date2.ToString(formatfull);

                if (date1.Year == date2.Year && date1.Month == date2.Month)
                {

                    Console.WriteLine(str1d + "-" + str2);
                }
                else if (date1.Year == date2.Year && date1.Month != date2.Month)
                {
                    Console.WriteLine(str1m + "-" + str2);
                }
                else
                {
                    Console.WriteLine(str1f + "-" + str2);
                }
            }
            //this conditional if checks whether the order of dates is right if not - the method SwapDates swaps referenced variables
            if (date1 <= date2)
            {
                Display(ref date1, ref date2);
            }
            else
            {
                void SwapDates(ref DateTime ndate1, ref DateTime ndate2)
                {
                    var tempswap = ndate1;
                    ndate1 = ndate2;
                    ndate2 = tempswap;
                }
                SwapDates(ref date1, ref date2);

                Display(ref date1, ref date2);
            }
        }
        catch (Exception)
        {
            // display indication of invalid input from command line
            Console.WriteLine(@"Invalid Input, please insert two dates in a format of dd.mm.yyyy for example 'Program 01.01.2016 04.05.2017'");
            Console.ReadLine();
            return;
        }
    }
}
}
/* left here on purpose by J. Kamirski - the very first version w/o globalization

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateRanges
{
class Program
{
    static void Main(string[] args)
    {
        DateTime date1, date2;


        // try-catch  used for error handling
        try  
        {
            date1 = Convert.ToDateTime(args[0]);
            date2 = Convert.ToDateTime(args[1]);

            //this method displays results in format depending on Year or Month are the same or not

            void Display(ref DateTime sdate1, ref DateTime sdate2)
            {
                if (date1.Year == date2.Year && date1.Month == date2.Month)
                {
                    Console.WriteLine("{0:dd} - {1:dd.MM.yyyy}", date1, date2);
                }
                else if (date1.Year == date2.Year && date1.Month != date2.Month)
                {
                    Console.WriteLine("{0:dd.MM} - {1:dd.MM.yyyy}", date1, date2);
                }
                else
                {
                    Console.WriteLine("{0:dd.MM.yyyy} - {1:dd.MM.yyyy}", date1, date2);
                }
            }
            //this conditional if checks whether the order of dates is right if not - the method SwapDates swaps referenced variables
            if (date1 <= date2)
            {
                Display(ref date1, ref date2);
            }
            else
            {
                void SwapDates(ref DateTime ndate1, ref DateTime ndate2)
                {
                    DateTime tempswap = ndate1;
                    ndate1 = ndate2;
                    ndate2 = tempswap;
                }
                SwapDates(ref date1, ref date2);

                Display(ref date1, ref date2);
            }
        }
        catch (Exception)
        {
            // display indication of invalid input from command line
            Console.WriteLine(@"Invalid Input, please insert two dates in a format of dd.mm.yyyy for example 'Program 01.01.2016 04.05.2017");
            Console.ReadLine();
            return;
        }
    }
}
}

*/

