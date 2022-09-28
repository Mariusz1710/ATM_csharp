using System;
using System.IO;
using System.Media;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = 0;
            int y = 5;

            StreamReader counter = new StreamReader("cards.txt");

            while (counter.ReadLine() != null)
            {
                x++;
            }

            counter.Close();

            string[,] cards = new string[x, y];

            if (File.Exists("cards.txt"))
            {
                    
                StreamReader file = new StreamReader("cards.txt");
                string line = file.ReadLine();
                int i = 0;
                bool exit = false;
                bool exit2 = false;
                bool exit3 = false;

                while (line != null)
                {
                    string[] array = line.Split();

                    for (int j = 0; j < 5; j++)
                    {
                        cards[i, j] = array[j];
                    }

                    line = file.ReadLine();

                    i++;
                }

                file.Close();

                while (true)
                {
                    if (exit2 == true)
                    {
                        Console.Clear();
                        Console.WriteLine("Thank you for using our ATM");
                        break;
                    }

                    SoundPlayer victory = new SoundPlayer("yes.wav");
                    SoundPlayer defeat = new SoundPlayer("no.wav");

                    Console.Clear();
                    Console.Write("Enter a number of the card (99 -  Exit) : ");
                    int card = Convert.ToInt32(Console.ReadLine());

                    if (card == 99)
                    {
                        exit2 = true;
                        break;
                    }

                    if (card < 0 || card > 4)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have entered the wrong number. Press enter.");
                        Console.ReadKey();
                        Console.ResetColor();
                        continue;
                    }

                    

                    if (cards[card, 4] != "Blocked")
                    {
                        int tries = 3;

                        exit = false;

                        while (tries > 0)
                        {
                            if (exit) break;
                            Console.Clear();
                            Console.Write("Enter the PIN: ");
                            string pin = Console.ReadLine();

                            if (cards[card, 2] == pin)
                            {
                                int amount = 0;
                                int balance = Convert.ToInt32(cards[card, 3]);
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("You are logged. Press Enter.");
                                victory.Play();
                                Console.ReadKey();

                                while (true)
                                {
                                    if (exit) break;
                                    Console.Clear();
                                    Console.WriteLine("1. Widthdraw\n2. Deposit\n3. Check a balance of the account\n4. Change the data\n5. Exit");
                                    int choice = Convert.ToInt32(Console.ReadLine());

                                    switch (choice)
                                    {
                                        case 1:

                                            while (true)
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Enter the amount: ");
                                                amount = Convert.ToInt32(Console.ReadLine());

                                                if (amount % 10 != 0)
                                                {
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("The amount must be a multiplication by 10. Press enter.");
                                                    defeat.Play();
                                                    Console.ReadKey();
                                                    Console.ResetColor();
                                                    continue;
                                                }

                                                if (amount <= balance)
                                                {
                                                    balance -= amount;
                                                    Console.Clear();
                                                    Console.WriteLine("You have withdrawn money. Press Enter");
                                                    victory.Play();
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("You have not got enough money. Press Enter");
                                                    defeat.Play();
                                                    Console.ReadKey();
                                                    Console.ResetColor();
                                                    continue;
                                                }
                                            }

                                            break;

                                        case 2:

                                            while (true)
                                            {
                                                Console.Clear();
                                                Console.Write("Enter the amount: ");
                                                amount = Convert.ToInt32(Console.ReadLine());

                                                if (amount % 10 != 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("The amount must be a multiplication by 10. Press enter.");
                                                    defeat.Play();
                                                    Console.ReadKey();
                                                    Console.ResetColor();
                                                    continue;
                                                }
                                                else
                                                {
                                                    balance += amount;
                                                    Console.Clear();
                                                    Console.WriteLine("You have deposited money. Press enter.");
                                                    victory.Play();
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            }

                                            break;

                                        case 3:

                                            Console.Clear();
                                            Console.WriteLine("The balance of your account is {0}. Press enter.", balance);
                                            Console.ReadKey();
                                            break;

                                        case 4:

                                            while (true)
                                            {
                                                if (exit3)
                                                {
                                                    exit3 = false;
                                                    break;
                                                }

                                                Console.Clear();
                                                Console.WriteLine("1. Change a name.\n2. Change a surname.\n3. Change PIN.\n4. Check your data.\n5. Exit");
                                                int choice2 = Convert.ToInt32(Console.ReadLine());

                                                switch (choice2)
                                                {

                                                    case 1:

                                                        Console.Clear();
                                                        Console.WriteLine("Enter your new name: ");
                                                        cards[card, 0] = Console.ReadLine();
                                                        Console.Clear();
                                                        Console.WriteLine("You have entered a new name. Press enter.");
                                                        Console.ReadKey();

                                                        break;

                                                    case 2:

                                                        Console.Clear();
                                                        Console.WriteLine("Enter your new surname: ");
                                                        cards[card, 1] = Console.ReadLine();
                                                        Console.Clear();
                                                        Console.WriteLine("You have entered a new name. Press enter.");
                                                        Console.ReadKey();

                                                        break;

                                                    case 3:

                                                        while (true)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Enter your new PIN: ");
                                                            string new_pin = Console.ReadLine();

                                                            /*if (new_pin.Length == 4)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("You have just changed your PIN. Press enter.");
                                                                cards[card, 2] = new_pin;
                                                                Console.ReadKey();
                                                                break;
                                                            }*/

                                                            if(new_pin.Length != 4)
                                                            {
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("PIN has to be four numbers. Press enter.");
                                                                Console.ReadKey();
                                                                Console.ResetColor();
                                                                continue;
                                                            }

                                                            Console.WriteLine("Confirm your PIN: ");
                                                            string new_pin2 = Console.ReadLine();

                                                            if(new_pin != new_pin2)
                                                            {
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Both PINs have to be the same. Press enter");
                                                                Console.ReadKey();
                                                                Console.ResetColor();
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("You have just changed your PIN. Press enter.");
                                                                cards[card, 2] = new_pin;
                                                                Console.ReadKey();
                                                                break;
                                                            }
                                                        }

                                                        break;

                                                    case 4:

                                                        Console.Clear();
                                                        Console.WriteLine("Your name is {0}.\nYour surname is {1}.\nYour PIN is {2}. Press enter", cards[card, 0], cards[card, 1], cards[card, 2]);
                                                        Console.ReadKey();

                                                        break;

                                                    case 5:

                                                        exit3 = true;
                                                        break;
                                                }
                                            }
                                            break;

                                        case 5:

                                            cards[card, 3] = balance.ToString();

                                            Console.Clear();
                                            Console.WriteLine("You just logged out!. Press enter.");
                                            Console.ReadKey();
                                            Console.ResetColor();
                                            exit = true;
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine("Wrong PIN. Press Enter.");
                                defeat.Play();
                                tries--;
                                Console.ReadKey();

                                if (tries == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Your card is blocked. Press Enter.");
                                    defeat.Play();
                                    Console.ReadKey();
                                    cards[card, 4] = "Blocked";
                                }

                                Console.ResetColor();
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your card is blocked! Press enter.");
                        defeat.Play();
                        Console.ReadKey();
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                Console.WriteLine("Failed to open the file");
            }

            StreamWriter sw = new StreamWriter("cards.txt");

            for(int i=0; i<x; i++)
            {
                for(int j=0; j<5; j++)
                {
                    sw.Write(cards[i, j]);

                    if(j < 4)
                    {
                        sw.Write(" ");
                    }
                }

                if(i < (x-1) )
                {
                    sw.Write("\n");
                }

            }

            sw.Close();

        }
    }
}





