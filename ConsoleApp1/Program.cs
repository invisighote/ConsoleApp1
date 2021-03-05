using GemBox.Document;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //Nejde pro 7 znaku u predposledniho pismene pri poslednim Y, nejde Z
        
        const int abc = 26;
        const int pocetGenerovanychZnaku = 3;
        int maxLT = (int)Math.Pow((double)abc, (double)pocetGenerovanychZnaku);
        // První písmeno v abecede = (A = 1) => ASCII (A = 65-1)
        const int prvniPismeno = 64;

        static void Main(string[] args)
        {
            // zada operator pri tisku
            // RY string znak = "06028882AGRXSJ";
            // MSR
            string znak = "06028882AGRYRL";

            char[] posledniKom2 = znak.ToCharArray();
            //DateTime dnes = DateTime.Now.ToString("YY/MM/DD HH:mm:ss");
            int pocet = 1;

            string datum = DateTime.Now.ToString("yy/MM/dd HH:mm:ss");
            datum = datum.Replace(".", "").Replace(" ", "").Replace(":", "");

            // kvuli oprave 
            //List<string> lines = File.ReadLines("C:\\Users\\TE283219\\OneDrive - TE Connectivity\\Documents\\Projekty\\MIELE\\Opravy060920\\REL90010.txt").ToList();


            int pocetstitku = 42;

            while (pocetstitku > 0)
            {
                string pathLT = " /F=\"C:\\_Disk_D\\Miele\\BT_form\\Miel_lbl.btw\"";
                // RY string pathFile = "/D=\"D:\\RP-labels\\Miele\\test\\Data\\";
                //MSR
                string pathFile = "/D=\"C:\\_Disk_D\\Miele\\Data\\";
                string fileName = "MIELE_R_" + DateTime.Now.ToString("yyMMddHHmmss");

                // oprva 0709
                /*
                 for (int p = 0; p < lines.Count;p++)
                 {
                
                    string rada2 = lines[p].Substring(lines[p].Length - 30, 8) + lines[p].Substring(0, 6);

                    string zakazka = lines[p].Substring(lines[p].Length - 16, 6);
                    string tyden = lines[p].Substring(lines[p].Length - 21, 4);
                    string pack = lines[p].Substring(lines[p].Length - 5, 5);
                    */
                
                
                string rada2 = GenRada2(posledniKom2, pocetGenerovanychZnaku, abc);

                string tyden = "2109";

                string pack = "SC064";
                string zakazka = "587307";

               
                
                string text1 = "%BTW%" + pathLT + " " + pathFile + fileName + ".dat\" /prn=\"P710ZEBRA001\" /P /FP /C=001 /DbTextHeader=3 /R=3" + Environment.NewLine
                       + "%END%" + Environment.NewLine + "MIELE NUMBER,DATE,PACKCODE,ORDER NUMBER, QTY, PART NUMBER,PART DESCRIPTION" + Environment.NewLine
                        + rada2 + "," + tyden + "," + pack + "," + zakazka + ",576,1-1416010-0,REL90009,";
                    string text2 = rada2.Substring((rada2.Length - 6), 6) + "|" + rada2.Substring(0, 8) + "|" + tyden + "|" + zakazka.Replace(" ", "") + "|576|" + pack + "|TYCO TRUTNOV" + Environment.NewLine;
                //string text2 = rada2.Substring((rada2.Length - 6), 6) + "|" + rada2.Substring(0, 8) + "|" + tyden + "|" + zakazka.Replace(" ", "") + "|408|" + pack + "|TYCO TRUTNOV" + Environment.NewLine;



                /*  using (System.IO.StreamWriter file =
                   new System.IO.StreamWriter(@"C:\Users\TE283219\test\print.txt", true))
                  {
                      file.WriteLine(rada2);
                  }
                  Thread.Sleep(4000);
                /*
             if (pocetstitku > 42)
                {
                    File.WriteAllText(@"C:\Users\TE283219\OneDrive - TE Connectivity\Documents\Projekty\MIELE\RY\TiskEtiket2200904\label\prvni\" + pocet + ".dd", text1);
                    File.AppendAllText(@"C: \Users\TE283219\OneDrive - TE Connectivity\Documents\Projekty\MIELE\RY\TiskEtiket2200904\seznam\MIELE_REL_200904_A.txt", text2);
                }/*} else if (pocetstitku > 42)
                {
                    File.WriteAllText(@"C:\Users\TE283219\OneDrive - TE Connectivity\Documents\Projekty\MIELE\RY\TiskEtiket2200818\label\druhy\" + pocet + ".dd", text1);
                    File.AppendAllText(@"C: \Users\TE283219\OneDrive - TE Connectivity\Documents\Projekty\MIELE\RY\TiskEtiket2200818\seznam\MIELE_REL_200818_B.txt", text2);
                }
                else
                {
                    File.WriteAllText(@"C:\Users\TE283219\OneDrive - TE Connectivity\Documents\Projekty\MIELE\RY\TiskEtiket2200904\label\druhy\" + pocet + ".dd", text1);
                    File.AppendAllText(@"C: \Users\TE283219\OneDrive - TE Connectivity\Documents\Projekty\MIELE\RY\TiskEtiket2200904\seznam\MIELE_REL_200904_B.txt", text2);
                }

  */

                if (pocetstitku > 0)
                {
                    //File.WriteAllText(@"C:\Users\te283219\OneDrive - TE Connectivity\Documents\Projekty\TiskStitku\RY\TiskEtiket2210305\label\1\" + pocet + ".dd", text1);
                    //File.WriteAllText(@"\\cz710ap10\RP-labels\Miele\Data\" + pocet + ".dd", text1);
                    File.WriteAllText(@"\\cz710wst209325\c$\_Disk_D\Miele\Data\" + pocet + ".dd", text1);
                    Thread.Sleep(1000);
                    //File.AppendAllText(@"C:\Users\te283219\OneDrive - TE Connectivity\Documents\Projekty\TiskStitku\RY\TiskEtiket2210305\seznam\MIELE_REL_2100305_A.txt", text2);
                    //File.AppendAllText(@"\\cz710fs02v\RY2_ShiftBook_Miele_Data_Exp\seznam\MIELE_REL_200906_Opravy.txt", text2);

                }
                else 
                 {
                    //File.WriteAllText(@"C:\Users\te283219\OneDrive - TE Connectivity\Documents\Projekty\TiskStitku\RY\TiskEtiket2210303\label\2\" + pocet + ".dd", text1);
                    //File.WriteAllText(@"\\cz710ap10\RP-labels\Miele\Data\" + pocet + ".dd", text1);
                    //File.WriteAllText(@"\\cz710wst209325\c$\_Disk_D\Miele\Data\" + pocet + ".dd", text1);
                    //Thread.Sleep(1000);
                    //File.AppendAllText(@"C:\Users\te283219\OneDrive - TE Connectivity\Documents\Projekty\TiskStitku\RY\TiskEtiket2210303\seznam\MIELE_REL_2100303_B.txt", text2);
                    //File.AppendAllText(@"\\cz710fs02v\RY2_ShiftBook_Miele_Data_Exp\seznam\MIELE_REL_200906_Opravy.txt", text2);
                }
                /*else
                {
                    //File.WriteAllText(@"C:\Users\TE283219\OneDrive - TE Connectivity\Documents\Projekty\TiskStitku\RY\TiskEtiket2210121\label\3\" + pocet + ".dd", text1);
                    //File.WriteAllText(@"\\cz710ap10\RP-labels\Miele\Data\" + pocet + ".dd", text1);
                    File.WriteAllText(@"\\cz710wst209325\c$\_Disk_D\Miele\Data\" + pocet + ".dd", text1);
                    //File.AppendAllText(@"C:\Users\TE283219\OneDrive - TE Connectivity\Documents\Projekty\TiskStitku\RY\TiskEtiket2210121\seznam\MIELE_REL_210121_C.txt", text2);
                    //File.AppendAllText(@"\\cz710fs02v\RY2_ShiftBook_Miele_Data_Exp\seznam\MIELE_REL_200906_Opravy.txt", text2);
                }

                */


                //File.WriteAllText(@"\\cz710wst209325\c$\_Disk_D\Miele\Data\" + pocet + ".dd", text1);


                //Thread.Sleep(2000);
                // File.WriteAllText(@"\\cz710ap10\RP - Labels\Miele\test\print" + pocetstitku + ".dd", text1);
                /*if (pocetstitku > 0)
                {
                    //File.WriteAllText(@"C:\Users\TE283219\Documents\Projekty\MIELE\RY\TiskEtiket2200218\label\prvni\" + pocet + ".dd", text1);
                    File.AppendAllText(@"C:\Users\TE283219\OneDrive - TE Connectivity\Documents\Projekty\MIELE\RY\TiskEtiket2200720\seznam\MIELE_REL_200720_C.txt", text2);
                    File.AppendAllText(@"\\cz710fs02v\RY2_ShiftBook_Miele_Data_Exp\MIELE_REL_200720_C.txt", text2);

                }
                else
                {
                    //File.WriteAllText(@"C:\Users\TE283219\Documents\Projekty\MIELE\RY\TiskEtiket2200218\label\druhy\" + pocet + ".dd", text1);
                    //File.AppendAllText(@"C:\Users\TE283219\OneDrive - TE Connectivity\Documents\Projekty\MIELE\RY\TiskEtiket2200720\seznam\MIELE_REL_200720_B.txt", text2);

                }
                */

                //Console.WriteLine("nova řada: " + rada2 + "\n" + text1);
                // Console.ReadLine();
                pocetstitku--;
                    pocet++;
                
                    znak = rada2;
                    // oprava for spodni zavorka
                //}
                
            }

        

        // Console.WriteLine("Enter Date");
        // string date = Console.ReadLine();
        // DateTime inputDate = DateTime.Parse(dnes);
        /*   var d = dnes;
           string week;

           CultureInfo cul = CultureInfo.CurrentCulture;

           var firstDayWeek = cul.Calendar.GetWeekOfYear(
               d,
               CalendarWeekRule.FirstDay,
               DayOfWeek.Monday);

           int weekNum = cul.Calendar.GetWeekOfYear(
               d.AddDays(3),
               CalendarWeekRule.FirstDay,
               DayOfWeek.Sunday);

           if (weekNum < 10)
               week = "0" + weekNum.ToString();
           else
               week = weekNum.ToString();

           int year = weekNum == 52 && d.Month == 1 ? d.Year - 1 : d.Year;
           Console.WriteLine( year.ToString().Substring(year.ToString().Length - 2, 2)+ week);

           //Console.WriteLine("konec");
           Console.ReadLine();
*/


    }

        private static string GenRada2(char[] posledniKom, int cislo, int cislo2)
        {   
            for (int x = posledniKom.Length; x >= cislo; x--)
            {

                int temp = (int)(posledniKom[x-1]) + 1;
                
                if (temp <= 90)
                {
                    posledniKom[x-1] = (char)temp;
                    break;
                }
                else
                {
                    temp -= cislo2;
                    posledniKom[x-1] = (char)temp;
                }
            }
            
            string novaGenRada = new string(posledniKom);

            return novaGenRada;
        }

        

       /* public static string karta(long cislo)
        {
           string newText;
            //long cislo = 36120701443713028;
            string t;
            long result;

          t = Convert.ToString(cislo);
            if (t.Length > 0 & long.TryParse(t, out result))
            {
            int startIndex = 0;
              newText = Convert.ToInt64(cislo).ToString("X");
              string HexSum = "";
            foreach (char ch in newText.ToCharArray())
                {
                   startIndex += Convert.ToInt32(Convert.ToString(ch), 16);
                  //Console.WriteLine(startIndex);
                    //Console.ReadKey();
                }
            // převod na hex
          HexSum = startIndex.ToString("X");
               
                startIndex = 8;
            if (newText.Length < 8)
                startIndex = newText.Length;
           newText = newText.Substring(startIndex) + HexSum;
            }
            return null;

        }*/
    }
}
