using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] cisla = {4, 8, 8, 10, 148, 158, 160, 172, 178, 50};

            

            if (SudaLicha(cisla) == true)
                Console.WriteLine("ano");
            else
                Console.WriteLine("ne");
            Console.ReadLine();
        }

        private static bool SudaLicha(int[] cisla)
        {
            int suda = 0;
            int licha = 0;

                for (int x = 0; x < cisla.Length; x++)
                {
                   

                        if ((cisla[x] % 2) == 0)
                            suda++;
                        else
                            licha++;
                if ((suda != 0 && licha != 0))
                    return true;

                }
            //if ((suda == 0 || licha == 0))
                   //     return false;

            return false;           
        }



        public void vyrobky()
        {
            string[] vyrobky = {"X15","X16","X17","X18","X19","X20","X21","X22","X23","X24","X25","X26","X27","X28","X29","X30","X31","X32","X33","X34","X35","X36","X37","X38","X39","X40","X41","X42",};
            string[] obchod = {"1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28",};

            string[][] nabidka;


            for (int j = 0; j < 560; j++)
            {
                Random rnd = new Random();
                int nahV = rnd.Next(0, vyrobky.Length);
                int nahO = rnd.Next(0, obchod.Length);
                int cena = rnd.Next(90, 1500);

                for (int k = 0; k < 3; k++)
                {
                   /* nabidka[j][k] = nahV;*/
                }
            }

        }
    }
}
