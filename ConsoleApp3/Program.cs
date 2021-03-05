using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            string datum;

            datum = DateWeek();


            Console.WriteLine("Ahoj");
            Console.ReadKey();
        }

        public static string DateWeek()
        {
            string _datumYYWW;
            var d = DateTime.Today.AddDays(-6);
            string week;
            int weekNum = 0;
            //DateTime firstDay = new DateTime(d.Year, 1, 1);
            CultureInfo cul = CultureInfo.CurrentCulture;

            //int den = (int) firstDay.DayOfWeek;
            
            /*if (den <= 4)
            {
               weekNum = cul.Calendar.GetWeekOfYear(
                    d.AddDays(0),
                    CalendarWeekRule.FirstDay,
                    DayOfWeek.Sunday);
            }
            else
            {*/
                weekNum = cul.Calendar.GetWeekOfYear(
                    d.AddDays(0),
                    CalendarWeekRule.FirstFourDayWeek,
                    DayOfWeek.Sunday);
            //}

            /*var firstDayWeek = cul.Calendar.GetWeekOfYear(
                d,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday);
            */
            

            if (weekNum < 10)
                week = "0" + weekNum.ToString();
            else
                week = weekNum.ToString();

            int year = (weekNum == 52 || weekNum == 53) && d.Month == 1 ? d.Year - 1 : d.Year;
            _datumYYWW = year.ToString().Substring(year.ToString().Length - 2, 2) + week;


            return _datumYYWW;
        }
    }
}
