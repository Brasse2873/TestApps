using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DateTimeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime();
            PrintDate(new DateTime(), "DateTime()");

            dt = new DateTime(2018, 4, 6);
            PrintDate(dt, "DateTime(2018, 4, 6)");

            dt = new DateTime(dt.Year, dt.Month, dt.Day);
            PrintDate(dt, "DateTime(dt.Year, dt.Month, dt.Day)");

            dt = new DateTime(dt.Year, dt.Month, 1);
            PrintDate(dt, "DateTime(dt.Year, dt.Month, 1)");

            dt = DateTime.Now;
            PrintDate(dt, "DateTime.Now");

            dt = DateTime.Today;
            PrintDate(dt, "DateTime.Today");

            dt = DateTime.UtcNow;
            PrintDate(dt, "DateTime.UtcNow");

            DateTime dtToday = DateTime.Today;
            DateTime dtFirstThisMonth = new DateTime(dtToday.Year, dtToday.Month, 1);
            PrintDate(dtFirstThisMonth, "dtFirstThisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)");

            DateTime dtNextMonth = dtFirstThisMonth.AddDays(31);
            DateTime dtFirstNextMonth = new DateTime(dtNextMonth.Year, dtNextMonth.Month, 1);
            PrintDate(dtFirstNextMonth, "dtFirstNextMonth ");

            DateTime dtLastPrevMonth = dtFirstThisMonth.AddDays(-1);
            PrintDate(dtLastPrevMonth, "dtLastPrevMonth ");

        }

        static void PrintDate(DateTime dt, string desc)
        {
            Console.WriteLine(Environment.NewLine + desc);
            Console.WriteLine("ToString\t:{0}", dt);
            Console.WriteLine(".Date\t\t:{0}", dt.Date);
            Console.WriteLine(".Day\t\t:{0}", dt.Day);
            Console.WriteLine(".DayOfWeek\t:{0}", dt.DayOfWeek);
            Console.WriteLine(".DayOfYear\t:{0}", dt.DayOfYear);
            Console.WriteLine(".Hour\t\t:{0}", dt.Hour);
            Console.WriteLine(".Kind\t\t:{0}", dt.Kind);
            Console.WriteLine(".Millisecond\t:{0}", dt.Millisecond);
            Console.WriteLine(".Minute\t\t:{0}", dt.Minute);
            Console.WriteLine(".Month\t\t:{0}", dt.Month);
            Console.WriteLine(".Second\t\t:{0}", dt.Second);
            Console.WriteLine(".Ticks\t\t:{0}", dt.Ticks);
            Console.WriteLine(".TimeOfDay\t:{0}", dt.TimeOfDay);
            Console.WriteLine(".Year\t\t:{0}", dt.Year);

            foreach( var df in dt.GetDateTimeFormats())
            {
                Console.WriteLine(".GetDateTimeFormats\t:{0}", df );
            }

            DateTimeFormatInfo fmt = (new CultureInfo("sv-SE")).DateTimeFormat;
            char[] formatSpecs = { 'd', 'D', 'f', 'F', 'g', 'G', 'm', 'o', 'r', 's', 't', 'T', 'u', 'U', 'y', 'Y' };
            foreach( var spec in formatSpecs)
            {
                var formats =  dt.GetDateTimeFormats(spec, fmt);
                foreach (var format in formats)
                {
                    Console.WriteLine("\t\t{0}:{1}",spec, format);
                }
            }

            /*
            Console.WriteLine("Format specifiers:\n");
            Console.WriteLine("\td\t:{0}", dt.ToString("d",fmt));
            Console.WriteLine("\tD\t:{0}", dt.ToString("D",fmt));
            Console.WriteLine("\tf\t:{0}", dt.ToString("f",fmt));
            Console.WriteLine("\tF\t:{0}", dt.ToString("F",fmt));
            Console.WriteLine("\tg\t:{0}", dt.ToString("g",fmt));
            Console.WriteLine("\tG\t:{0}", dt.ToString("G",fmt));
            Console.WriteLine("\tm\t:{0}", dt.ToString("m",fmt));
            Console.WriteLine("\tM\t:{0}", dt.ToString("M",fmt));
            Console.WriteLine("\tm\t:{0}", dt.ToString("o",fmt));
            Console.WriteLine("\tM\t:{0}", dt.ToString("O",fmt));
            Console.WriteLine("\tr\t:{0}", dt.ToString("r",fmt));
            Console.WriteLine("\tR\t:{0}", dt.ToString("R",fmt));
            Console.WriteLine("\ts\t:{0}", dt.ToString("s",fmt));
            Console.WriteLine("\tt\t:{0}", dt.ToString("t",fmt));
            Console.WriteLine("\tT\t:{0}", dt.ToString("T",fmt));
            Console.WriteLine("\tu\t:{0}", dt.ToString("u",fmt));
            Console.WriteLine("\tU\t:{0}", dt.ToString("U",fmt));
            Console.WriteLine("\ty\t:{0}", dt.ToString("y",fmt));
            Console.WriteLine("\tY\t:{0}", dt.ToString("Y",fmt));

            Console.WriteLine("\tyyyyMMdd\t:{0}", dt.ToString("tyyyyMMdd", fmt));
            Console.WriteLine("\tyyyy-MM-dd\t:{0}", dt.ToString("yyyy-MM-dd", fmt));
            */

        }

    }

}
