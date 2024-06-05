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

    class inputModel
    {
        public string inputText { get; set; }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            List<RegexModel> regexList = new List<RegexModel>();
            //regexList.Add(new RegexModel { RegexName = "pattern1", Text = @"\b[M]\w+" });
            //regexList.Add(new RegexModel { RegexName = "pattern2", Text = @"(son)(\s+|\n)(\d{1,2}|bir|iki|üç|dört|beş|altı|yedi|sekiz|dokuz|on|onbir|oniki)(\s+|\n)((ay|gün|yıl)([^\s]*))" });
            regexList.Add(new RegexModel { RegexName = "pattern3", Text = "\\d{1,2}[\\/|\\.|-|,]{1}\\d{1,2}[\\/|\\.|-|,]{1}\\d{4}(\\)|)(\\s+|\\n)(((suç([^\\s]*)|den|dan|ten|tan)(\\s+|\\n))|)(tarih([^\\s]*)(\\s+|\\n)|)(((itibari ile|itibariyla)(\\s+|\\n))|)(\\d{1,2}|bir|iki|üç|dört|beş|altı|yedi|sekiz|dokuz|on|onbir|oniki)(\\s+|\\n)(ay|gün|yıl)(\\s+|\\n)(önce([^\\s]*))(\\s+|\\n)(ve|ile)(\\s+|\\n)(((tarih|suç tarih)([^\\s]*)(\\s+|\\n))|)(\\d{1,2}|bir|iki|üç|dört|beş|altı|yedi|sekiz|dokuz|on|onbir|oniki)(\\s+|\\n)(ay|gün|yıl)(\\s+|\\n)(sonra([^\\s]*))" });
            List <inputModel> inputList = new List<inputModel>();

            inputList.Add(new inputModel {inputText = "01/03/2022 tarihinden 10 gün önce ve 10 gün sonrasına" });
            inputList.Add(new inputModel {inputText = "07.07.2023 tarihinden 6 ay öncesi ve 6 ay sonrasına ait tüm hesap hareketlerinin" });
            inputList.Add(new inputModel {inputText = "14/07/2023 tarihinden 2 ay öncesi ve 2 ay sonrasına ait hesap hareketlerinin i" });
            inputList.Add(new inputModel {inputText = "04/02/2024 tarihinden 2 ay öncesi ve 2 ay sonrasına ait" });
            inputList.Add(new inputModel {inputText = "11/09/2023 tarihinden 2 ay öncesi ve 2 ay sonrasına ait " });
            inputList.Add(new inputModel {inputText = "24/11/2021 tarihinden üç ay öncesi ve üç ay sonrasına ait hesap hareketlerini" });
            inputList.Add(new inputModel {inputText = "03/02/2023 tarihinin 1 ay öncesi ve 1 ay sonrasına ilişkin ayrıntılı" });
            inputList.Add(new inputModel {inputText = "(06/06/2023) bir ay önce ve bir ay sonrasına ilişkin" });
            inputList.Add(new inputModel {inputText = "suça konu olay tarihi olan 22/01/2019 tarihi itibari ile 6 ay öncesi ve 6 ay sonrasına" });
            inputList.Add(new inputModel {inputText = "28/06/2019 dan on gün öncesi ve on gün sonrasına " });

            //string pattern = @"\b[M]\w+";
            //string pattern2 = @"(son)(\s+|\n)(\d{1,2}|bir|iki|üç|dört|beş|altı|yedi|sekiz|dokuz|on|onbir|oniki)(\s+|\n)((ay|gün|yıl)([^\s]*))";
            //string pattern3 = @"(son)(\s+|\n)([^\s]*))";
            //RegexTest("05/08/2023 tarihinden üç ay öncesi ve üç ay sonrasına ait hesap hareketlerini", pattern);
            //RegexTest("Son 10 yıla ilişkin kredi kartı sözleşme ve ekleri ile dosya masrafı, aidat ücreti, gecikme bildirim ücreti, basılı ekstre ücreti son 2 yıllık", pattern2);

            //RegexTestMultiple(inputList, regexList);

            RegexTest(inputList,regexList);

            Console.Read();
        }

        public static void RegexTest(List<inputModel> texts, List<RegexModel> regexs)
        {

            foreach (var regex in regexs)
            {

                foreach (var  text in texts)
                {
                    //Console.WriteLine(text.inputText);
                    var textInput = text.inputText;
                    var regexPattern = regex.Text;
                    //Console.WriteLine(regex.Text);
                    Regex rg2 = new Regex(regexPattern);

                    var results = rg2.Matches(textInput);

                    //Console.WriteLine(results);
                    
                    if (results.Count > 0)
                    {

                        foreach (var result in results)
                        {
                            // büyük metinden aranan cümlenin consola yazdırıldığı kısım
                            //Console.WriteLine(result);
                            // Console.WriteLine("iştebu");

                            //result içerisinden (Tarih), (ay,gün,yıl),(Miktar) bilgilerini alabilmek için 3 farklı regex çalıştır ve değerleri parçalayıp değişkenlere ver.

                            var tarihPattern = "\\d{1,2}[\\/|\\.|-|,]{1}\\d{1,2}[\\/|\\.|-|,]{1}\\d{4}(\\)|)";
                            var miktarVeTurPattern = "(\\d{1,2}|bir|iki|üç|dört|beş|altı|yedi|sekiz|dokuz|on|onbir|oniki)(\\s+|\\n)(ay|gün|yıl)(\\s+|\\n)";
                            
                            
                           Regex tarihRegex = new Regex(tarihPattern);
                           Regex miktarVeTutarRegex = new Regex(miktarVeTurPattern);

                            var tarihResult = tarihRegex.Matches(result.ToString());
                            var miktarVeTutarResult = miktarVeTutarRegex.Matches(result.ToString());

                           foreach (var tarih in tarihResult)
                            {
                                Console.WriteLine(tarih);
                            }
                            
                           foreach(var miktarVeTutar in miktarVeTutarResult)
                            {
                                Console.WriteLine(miktarVeTutar);

                                var tutarPattern = "(ay|gün|yıl)(\\s+|\\n)";

                                Regex tutarRegex = new Regex(tutarPattern);

                                var tutarResult = tutarRegex.Matches(result.ToString());
                                
                                foreach(var tutar in tutarResult)
                                {
                                    Console.WriteLine(tutar);
                                }
                            }
                        }

                        //tüm datalar normal bi şekilde geliyor şuan 
                    }
                    else
                    {
                        Console.WriteLine("Yapamadim");
                    }

                   // Console.WriteLine("burdayim");
                }

              //  Console.WriteLine("deniyorum");
            }


            //var regexTest = "@\"(((hesap | hesab)([^\\s] *))(\\s +|\\n)(ilk(\\s +|\\n) |)(açı([^\\s] *))(\\s +|\\n)((tarih | itibar | iddianame)([^\\s] *))) | (tüm(\\s +|\\n)(hesap([^\\s] *))(\\s +|\\n)((hareket | döküm)([^\\s] *)))\" });\r\n";
            //Regex regex1 = new Regex(regex, RegexOptions.IgnoreCase);   Büyük küçük harf 
            Regex regex1 = new Regex(regexs[0].Text.ToString());
           // var results = regex1.Matches(text[3].inputText.ToString());
            //foreach (var result in results)
            //{
            //    Console.WriteLine(result);
            //}
            //Console.WriteLine("------------------------------------------------");

        }


        public static void RegexTestMultiple(List<inputModel> texts, List<RegexModel> regexs)
        {
            foreach (var regex in regexs)
            {

                Console.WriteLine(regex.RegexName);
                //Console.WriteLine(regex.Text);
                Regex rg = new Regex(regex.Text);
                foreach (var match in rg.Matches(texts.ToString()))
                {
                    //var sonuc1 = "05/08/2023 tarihinden üç ay öncesi ve üç ay sonrasına";
                    //var tarih = "05/08/2023";
                    //var islem = "üç ay";

                    Console.WriteLine(regex.RegexName + "   -   " + match);
                   // regex.CreateDate(Convert.ToDateTime(match), 0, 3, 0);

                }
                Console.WriteLine("------------------------------------------------");
            }

            foreach(var text in texts)
            {
                //Regex rg = new Regex(regex.Text);
                //foreach (var match in rg.Matches(text.inputText.ToString()))
                //{
                //    //var sonuc1 = "05/08/2023 tarihinden üç ay öncesi ve üç ay sonrasına";
                //    //var tarih = "05/08/2023";
                //    //var islem = "üç ay";

                //    Console.WriteLine(regex.RegexName + "   -   " + match);
                //    // regex.CreateDate(Convert.ToDateTime(match), 0, 3, 0);
                //}

            }

        }
    }
}
