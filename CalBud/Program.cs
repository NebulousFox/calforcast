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

        public void WriteBills()
        {
            if (paid == true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            Console.WriteLine("\tName:{0}\tDate:{1}\t\tAmmount:{2}\tPaid:{3}", name, day, ammount, paid);
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }

    class Program
    {


        static void Main(string[] args)
        {
            /* ::::::::::::FILE CREATE / IMPORT:::::::::::: */
            /* ::::::::::::FILE CREATE / IMPORT:::::::::::: */
            /* ::::::::::::FILE CREATE / IMPORT:::::::::::: */

            //CREATE FILE WITH DEFAULT VALUES
            if (!System.IO.File.Exists(@"C:\Users\douglas\Documents\GitHub\calforcast\bills.txt"))
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\douglas\Documents\GitHub\calforcast\bills.txt", true))
                {
                    Bills[] billArray2 = new Bills[18];
                    //create bills
                    billArray2[0] = new Bills(1, 121.73, "Hanover");
                    billArray2[1] = new Bills(2, 323, "Citizens");
                    billArray2[2] = new Bills(2, 58, "Cap9481");
                    billArray2[3] = new Bills(2, 358, "Wells");
                    billArray2[4] = new Bills(2, 70, "TWC");
                    billArray2[5] = new Bills(3, 84, "Cap3971");
                    billArray2[6] = new Bills(5, 170, "BPU");
                    billArray2[7] = new Bills(8, 60, "NatFuel");
                    billArray2[8] = new Bills(10, 77, "Cap7090");
                    billArray2[9] = new Bills(11, 62, "UHEAA");
                    billArray2[10] = new Bills(13, 50, "AdWords");
                    billArray2[11] = new Bills(13, 70, "Verizon");
                    billArray2[12] = new Bills(17, 150, "IRS");
                    billArray2[13] = new Bills(19, 30, "Planet");
                    billArray2[14] = new Bills(19, 50, "NelNet");
                    billArray2[15] = new Bills(19, 150, "Amazon");
                    billArray2[16] = new Bills(19, 25, "Cap KC");
                    billArray2[17] = new Bills(29, 70, "Big Lots");

                    foreach (Bills q in billArray2)
                    {
                        file.Write("{0};{1};{2};{3}:", q.day, q.ammount, q.name, q.paid);
                    }
                    
                }
            }
            //PULL FILE AND INPUT INTO OBJECT ARRAY
            Bills[] billArray;
            string billsInput = System.IO.File.ReadAllText(@"C:\Users\douglas\Documents\GitHub\calforcast\bills.txt");
            string[] billsInputLine = billsInput.Split(':').ToArray();
            billArray = new Bills[billsInputLine.Length-1];
            for (int i = 0; i < billsInputLine.Length-1; i++)
            {

                string[] q = billsInputLine[i].Split(';').ToArray();

                billArray[i] = new Bills(Convert.ToInt32(q[0]), Convert.ToDouble(q[1]), Convert.ToString(q[2]));
                billArray[i].day2 = billArray[i].day + 30;
                billArray[i].paid = Convert.ToBoolean(q[3]);
            }
            /* ~~~~~~END~~~~~~ FILE CREATE / IMPORT:::::::::::: */
            /* ~~~~~~END~~~~~~ FILE CREATE / IMPORT:::::::::::: */
            /* ~~~~~~END~~~~~~ FILE CREATE / IMPORT:::::::::::: */



            /* ::::::: INCOME FILE CREATE / IMPORT:::::::::::: */
            /* ::::::: INCOME FILE CREATE / IMPORT:::::::::::: */
            /* ::::::: INCOME FILE CREATE / IMPORT:::::::::::: */
            //CREATE FILE WITH DEFAULT VALUES
            if (!System.IO.File.Exists(@"C:\Users\douglas\Documents\GitHub\calforcast\income.txt"))
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\douglas\Documents\GitHub\calforcast\income.txt", true))
                {
                    //CREATE DEFAULT INCOME
                    double incMain2 = 500;
                    int incMDay2 = 4;
                    double incCom2 = 200;
                    int incCDay2 = 30;


                    file.Write("{0};{1};{2};{3}", incMain2, incMDay2, incCom2, incCDay2);


                }
            }
            //PULL FILE AND INPUT INTO OBJECT ARRAY
            string incomeString = System.IO.File.ReadAllText(@"C:\Users\douglas\Documents\GitHub\calforcast\income.txt");
            string[] incomeStringSplit = incomeString.Split(';').ToArray();
            double incMain = Convert.ToDouble(incomeStringSplit[0]);
            int incMDay = Convert.ToInt32(incomeStringSplit[1]);
            double incCom = Convert.ToDouble(incomeStringSplit[2]);
            double incCDay = Convert.ToInt32(incomeStringSplit[3]);

            int[] incMDayArray = new int[10];

            for (int i = 0; i < 10; i++)
            {
                incMDayArray[i] = incMDay + (7 * i);
            }

            /* ~~~~~~END~~~~~~ INCOME FILE CREATE / IMPORT:::::::::::: */
            /* ~~~~~~END~~~~~~ INCOME FILE CREATE / IMPORT:::::::::::: */
            /* ~~~~~~END~~~~~~ INCOME FILE CREATE / IMPORT:::::::::::: */




            //other variables
            bool doRepeat = true;

            /* ::::::::::::MENU START:::::::::::: */
            /* ::::::::::::MENU START:::::::::::: */
            /* ::::::::::::MENU START:::::::::::: */
            do
            {
                Console.WriteLine(":::::MAIN MENU:::::");
                Console.WriteLine("1. View Bill List");
                Console.WriteLine("2. Edit Bills");
                Console.WriteLine("3. Mark Bills as paid");
                Console.WriteLine("4. Modify Income");
                Console.WriteLine("5. View Forecast");
                Console.WriteLine("9. Quit");
                int menu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (menu) {
                    case 1:
                        /* :::VIEW BILL LIST::::
                         * ::::::::::::::::::::: */
                        for (int i = 0; i < billArray.Length; i++)
                        {
                            Console.Write(i);
                            billArray[i].WriteBills();
                        }
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 2:
                        for(int i = 0; i < billArray.Length; i++)
                        {
                            Console.Write(i);
                            billArray[i].WriteBills();
                        }
                        Console.Write("\nPlease choose a bill to edit: ");
                        int case2Edit = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter New Name: ");
                        string case2Name = Console.ReadLine();
                        Console.Write("Enter New Date: ");
                        int case2Date = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter New Ammount: ");
                        double case2Ammount = Convert.ToDouble(Console.ReadLine());
                        billArray[case2Edit] = new Bills(case2Date, case2Ammount, case2Name);
                        Console.Write("\n" + case2Edit);
                        billArray[case2Edit].WriteBills();
                        Console.WriteLine("\nBill has been edited.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 3:
                        /* ::: MARK BILLS PAID::: */
                        /* ::: MARK BILLS PAID::: */
                        Console.WriteLine("\nInput IDs to mark as Paid\\Unpaid\n");
                        for (int i = 0; i < billArray.Length; i++)
                        {
                            Console.Write(i);
                            billArray[i].WriteBills();
                        }
                        string numbs = Console.ReadLine();
                        try
                        {
                            int[] billsPaid = numbs.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
                            foreach (int q in billsPaid)
                            {
                                Console.WriteLine(q);
                                billArray[q].paid = !billArray[q].paid;
                            }
                        }
                        catch (Exception)
                        {

                        }
                        break;
                    case 4:
                        /* ::: MODIFY INCOME ::: */
                        /* ::: MODIFY INCOME ::: */
                        Console.WriteLine("Main: {0} /t Day: {1} /t Com:{2} /t Day: {3}", incMain, incMDay, incCom, incCDay);
                        Console.Write("Enter new weekly income estimate: ");
                        incMain = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter new weekly day money appears (ex. 7): ");
                        incMDay = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new monthly Commission estimate: ");
                        incCom = Convert.ToDouble(Console.ReadLine());
                        for (int i = 0; i < 10; i++)
                        {
                            incMDayArray[i] = incMDay + (7 * i);
                        }
                        Console.WriteLine("\nNew inputs recorded. Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 5: 
                        /* ::: BANK AMT & FORECAST ::: */
                        /* ::: BANK AMT & FORECAST ::: */
                        Console.Write("Enter current bank ammount: ");
                        double bank = Convert.ToDouble(Console.ReadLine());
                        double bankBalance = bank;

                        //create current date
                        Console.Write("\nEnter current day number: ");
                        int dayCur = Convert.ToInt32(Console.ReadLine());

                        /* MAIN PROCESSING :::::::::::::: */
                        //list balance of today +/- bills & income
                        for (int i = dayCur; i < 60; i++)
                        {
                            //string for changes made
                            string changes = "";
                            string incomeChanges = "";

                            //check if bills paid for first month, if not change balance. Change balance for second month bills too
                            foreach (Bills q in billArray)
                            {
                                if (q.day < i && q.paid == false && i == dayCur)
                                {
                                    bankBalance -= q.ammount;
                                    changes += q.name + ", ";
                                }
                                else if ((q.day == i && q.paid == false) || q.day2 == i)
                                {
                                    bankBalance -= q.ammount;
                                    changes += q.name + ", ";
                                }
                            }

                            //add income for days matching
                            if (incCDay == i || incCDay + 30 == i)
                            {
                                bankBalance += incCom;
                                incomeChanges += "IncomeC, ";
                            }

                            foreach (int p in incMDayArray)
                            {
                                if (i == p)
                                {
                                    bankBalance += incMain;
                                    incomeChanges += "IncomeM, ";
                                }
                            }

                            string lineEqual = " ";
                            if (bankBalance <= 0)
                            {
                                lineEqual = "";
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else if (bankBalance <= 200)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }

                            Console.WriteLine("Day: {0}   Balance: {1}    " + lineEqual + "||  {2} {3}", String.Format("{0:00}", i>30 ? i-30 : i), String.Format("{0:0,000.00}", bankBalance), incomeChanges, changes);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        Console.ReadKey();
                        break;
                    case 9: /* ::: EXIT ::: */
                        doRepeat = false;
                        System.IO.File.WriteAllText(@"C:\Users\douglas\Documents\GitHub\calforcast\income.txt", "");
                        using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"C:\Users\douglas\documents\github\calforcast\income.txt", true))
                        {
                            file.Write("{0};{1};{2};{3}", incMain, incMDay, incCom, incCDay);
                        }

                            System.IO.File.WriteAllText(@"C:\Users\douglas\Documents\GitHub\calforcast\bills.txt", "");
                        using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"C:\Users\douglas\Documents\GitHub\calforcast\bills.txt", true))
                        {
                            foreach (Bills q in billArray)
                            {
                                file.Write("{0};{1};{2};{3}:", q.day, q.ammount, q.name, q.paid);
                            }
                        }
                            break;
                    default:
                        break;

                }


                Console.Clear();



            } while (doRepeat);
            /* ::::::::::::: MENU END ::::::::::::: */
        }
    }
}
