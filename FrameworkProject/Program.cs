using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FrameworkProject
{
    class RegexModel
    {
        public string RegexName { get; set; }
        public string Text { get; set; }

        //public void CreateDate(DateTime date, int year, int month, int day)
        //{
        //    //  05/08/2023
        //    //  beforeDay   05/05/2023
        //    //  afterDay   05/11/2023

        //    var beforeDay = date;
        //    var afterDay = date;
        //    if (year > 0)
        //    {
        //        beforeDay = date.AddYears(year * -1);
        //        afterDay = date.AddYears(year);
        //    }
        //    else if (month > 0)
        //    {
        //        beforeDay = date.AddMonths(month * -1);
        //        afterDay = date.AddMonths(month);
        //    }
        //    else if (day > 0)
        //    {
        //        beforeDay = date.AddDays(day * -1);
        //        afterDay = date.AddDays(day);
        //    }
        //}
    }
    class Program
    {
        public static void Main(string[] args)
        {
            List<RegexModel> regexList = new List<RegexModel>();
            regexList.Add(new RegexModel { RegexName = "pattern1", Text = @"\b[M]\w+" });
            regexList.Add(new RegexModel { RegexName = "pattern2", Text = @"(son)(\s+|\n)(\d{1,2}|bir|iki|üç|dört|beş|altı|yedi|sekiz|dokuz|on|onbir|oniki)(\s+|\n)((ay|gün|yıl)([^\s]*))" });
            regexList.Add(new RegexModel { RegexName = "pattern3", Text = @"(son)(\s+|\n)([^\s]*)" });

            //string pattern = @"\b[M]\w+";
            //string pattern2 = @"(son)(\s+|\n)(\d{1,2}|bir|iki|üç|dört|beş|altı|yedi|sekiz|dokuz|on|onbir|oniki)(\s+|\n)((ay|gün|yıl)([^\s]*))";
            //string pattern3 = @"(son)(\s+|\n)([^\s]*))";
            //RegexTest("05/08/2023 tarihinden üç ay öncesi ve üç ay sonrasına ait hesap hareketlerini", pattern);
            //RegexTest("Son 10 yıla ilişkin kredi kartı sözleşme ve ekleri ile dosya masrafı, aidat ücreti, gecikme bildirim ücreti, basılı ekstre ücreti son 2 yıllık", pattern2);

            RegexTestMultiple("Son 10 yıla ilişkin kredi kartı sözleşme ve ekleri ile dosya masrafı, aidat ücreti, gecikme bildirim ücreti, basılı ekstre ücreti son 2 yıllık", regexList);

            Console.Read();
        }

        public static void RegexTest(string text, List<RegexModel> regexs)
        {
            //Regex regex1 = new Regex(regex, RegexOptions.IgnoreCase);   Büyük küçük harf 
            Regex regex1 = new Regex(text);
            var result = regex1.Matches(text);
            foreach (var regex in regexs)
            {
                Console.WriteLine(regex);
            }
            Console.WriteLine("------------------------------------------------");

        }
        public static void RegexTestMultiple(string text, List<RegexModel> regexs)
        {
            foreach (var regex in regexs)
            {
                Regex rg = new Regex(regex.Text);
                foreach (var match in rg.Matches(text))
                {
                    //var sonuc1 = "05/08/2023 tarihinden üç ay öncesi ve üç ay sonrasına";
                    //var tarih = "05/08/2023";
                    //var islem = "üç ay";

                    Console.WriteLine(regex.RegexName + "   -   " + match);
                   // regex.CreateDate(Convert.ToDateTime(match), 0, 3, 0);
                }
                Console.WriteLine("------------------------------------------------");
            }

        }
    }
}
