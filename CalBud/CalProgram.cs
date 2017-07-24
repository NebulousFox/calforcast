using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalBud
{
    class Bills
    {
        public int day;
        public int day2;
        public double ammount;
        public string name;
        public bool paid = false;

        public Bills(int d, double a, string n)
        {
            day = d;
            day2 = d + 30;
            ammount = a;
            name = n;
        }
    }

    class Program
    {


        static void Main(string[] args)
        {
            /* Starting Info */
            //create bills
            Bills[] billArray = new Bills[3];
            billArray[0] = new Bills(3, 356.0, "Wells");
            billArray[1] = new Bills(11, 75.0, "Cap1");
            billArray[2] = new Bills(21, 300.0, "UHEA");

            //create income
            double incMain = 500;
            int incMDay = 4;
            double incCom = 200;
            int incCDay = 30;


            /* Get user input for start of command */
            //create start bank
            Console.Write("Enter current bank ammount: ");
            double bank = Convert.ToInt32(Console.ReadLine());
            double bankBalance = bank;

            //create current date
            Console.Write("\nEnter current day number: ");
            int dayCur = Convert.ToInt32(Console.ReadLine());

            //Ask for bills paid
            Console.WriteLine("\nAre any of the following bills paid? Enter Numbers with spaces.\n");
            for (int i = 0; i < billArray.Length; i++)
            {
                if (billArray[i].day >= dayCur){
                    Console.WriteLine("({3})  Name:{0}  Date:{1}  Ammount:{2}", billArray[i].name, billArray[i].day, billArray[i].ammount, i);
                }
            }
            string numbs = Console.ReadLine();
            try
            {
                int[] billsPaid = numbs.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
                foreach (int q in billsPaid)
                {
                    Console.WriteLine(q);
                    billArray[q].paid = true;
                }
            }
            catch(Exception)
            {

            }

            //repeat income every 7 days
            int[] incMDayArray = new int[10];
            for (int i = 0; i < 10; i++) {
                incMDayArray[i] = incMDay + (7 * i);
            }




            //list balance of today +/- bills & income
            for (int i = dayCur; i < 60; i++)
            {
                //string for changes made
                string changes = "";

                //check if bills paid for first month, if not change balance. Change balance for second month bills too
                foreach (Bills q in billArray)
                {
                    if((q.day == i && q.paid == false) || q.day2 == i)
                    {
                        bankBalance -= q.ammount;
                        changes += q.name + " ";
                    }
                }

                //add income for days matching
                if(incCDay == i || incCDay + 30 == i)
                {
                    bankBalance += incCom;
                    changes += "Income";
                }

                foreach(int p in incMDayArray)
                {
                    if(i == p)
                    {
                        bankBalance += incMain;
                    }
                }

                if (bankBalance <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (bankBalance <= 200)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                } 
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }


                Console.WriteLine("Day: {0}   Balance: {1}    ||  {2}", String.Format("{0:00}",i), String.Format("{0:0,000.00}",bankBalance), changes);
            }

            Console.ReadKey();
        }
    }
}
