using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    public class BullAndCows
    {
        public static ArrayList list = new ArrayList();
        public static int count = 0;
        public int bull = 0;
        public int cow = 0;
        public static ArrayList userList = new ArrayList();
        public static int userCount = 0;


        static void Main(string[] args)
        {
            Battle(Console.ReadLine()); // Тут заменить Console.ReadLine() на ввод числа пользователя, отсюда начинается игра
            //Console.ReadKey();
        }

        public static void Battle(string userNumber)
        {
            Console.WriteLine("Write ur number");
            list = GenerateList();
            userList = GenerateList();
            bool userWin = false;
            bool comWin = false;
            int ansint = GenerateNumberFromList();


            while (!userWin && !comWin)
            {

                //Console.WriteLine(ansint);
                int[] ans = new int[4];

                ans[0] = ansint / 1000;
                ans[1] = (ansint / 100) % 10;
                ans[2] = (ansint / 10) % 10;
                ans[3] = ansint % 10;

                userWin = UserGame(ans, Console.ReadLine()); // тут заменить Console.ReadLine на число пользоваеля которое он вводит чтоб угадать
                if (userWin)
                {
                    break;
                }
                comWin = Game(userNumber); // Тут вызывается хо компа
                if (comWin)
                {
                    break;
                }
            }
        }

        public static ArrayList GenerateList()
        {
            ArrayList list = new ArrayList();

            for (int i = 123; i <= 9876; i++)
            {
                int d1 = i / 1000;
                int d2 = (i / 100) % 10;
                int d3 = (i / 10) % 10;
                int d4 = i % 10;

                if (d1 != d2 && d1 != d3 && d1 != d4 && d2 != d3 && d2 != d4 && d3 != d4)
                {
                    list.Add(i);
                }
            }

            return list;
        }

        public static bool Game(string userNumber)
        {
            int guess = GenerateNumberFromList();
            count++;
            string compGuess = guess.ToString();
            if (compGuess.Count() == 3)
            {
                compGuess = '0' + compGuess;
            }
            ArrayList ab = new ArrayList();
            ab = GetAB(Convert.ToInt32(userNumber), Convert.ToInt32(compGuess));
            Console.WriteLine("comp guess = " + compGuess);
            Console.WriteLine("Bulls = " + ab[0]);
            int bull = (int)ab[0]; // Количество быков которые угадал комп
            Console.WriteLine("Cows = " + ab[1]);
            int cow = (int)ab[1]; // Количество коров которые угадал комп
            if (bull == 4 && cow == 0)
            {
                Console.WriteLine("Comupter Win! Your secret number is " + compGuess);
                return true; // Комп победил
            }

            CheckList(bull, cow, guess, true);

            if (list.Count == 1)
            {
                compGuess = list[0].ToString();
                if (compGuess.Count() == 3)
                {
                    compGuess = '0' + compGuess;
                }
                ab = GetAB(Convert.ToInt32(userNumber), Convert.ToInt32(compGuess));
                Console.WriteLine("comp guess = " + compGuess);
                Console.WriteLine("Bulls = " + ab[0]);
                int a = (int)ab[0];
                Console.WriteLine("Cows = " + ab[1]);
                int b = (int)ab[1];
                if (a != 4 || b != 0)
                {
                    Console.WriteLine("You must type something wrong, try again...");
                }
                else if (a == 4 && b == 0)
                {
                    Console.WriteLine("Your secret number is " + compGuess);
                    return true;
                }
                return true;
            }
            else if (list.Count == 0)
            {
                Console.WriteLine("You must type something wrong, try again...");
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UserGame(int[] ans, string guess)
        {
            userCount++;
            Console.WriteLine("");
            Console.WriteLine("Guess a four digit number");

            char[] guessed = guess.ToCharArray();
            int bullsCount = 0;
            int cowsCount = 0;

            if (guessed.Length != 4 || (guessed[0] == guessed[1] || guessed[0] == guessed[2] || guessed[0] == guessed[3]) || guessed[1] == guessed[2] || guessed[1] == guessed[3] || guessed[2] == guessed[3])
            {
                Console.WriteLine("Not a valid guess. Try again");
                return false;
            }

            int curAns = 0;
            int curGuess = 0;
            for (int i = 0; i < 4; i++)
            {
                double dec = Math.Pow(10, 3 - i);
                curAns = (int)(curAns + ans[i] * dec);
                curGuess = (int)(curGuess + (int)char.GetNumericValue(guessed[i]) * dec);
            }
            
            ArrayList ab = new ArrayList();
            ab = GetAB(curGuess, curAns);

            CheckList(bullsCount, cowsCount, Convert.ToInt32(guess), false);

            if ((int)ab[0] == 4)
            {
                Console.WriteLine("Congratulations! You have won!");
                return true;
            }
            else
            {
                Console.WriteLine("{0} bulls and {1} cows", (int)ab[0], (int)ab[1]);
                return false;
            }
        }

        public static int GenerateNumberFromList()
        {
            int number = 0;
            //Random rnd = new Random();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int index = rnd.Next(1, list.Count);
            number = (int)list[index];
            return number;
        }

        public static void CheckList(int bull, int cow, int guess, bool isCOM)
        {
            ArrayList newList = new ArrayList();

            if (isCOM)
            {
                for (int i = 0; i < list.Count; i++)
                {

                    ArrayList ab = new ArrayList();
                    ab = GetAB(guess, (int)list[i]);

                    if (bull == (int)ab[0] && cow == (int)ab[1])
                    {
                        newList.Add(list[i]);
                    }

                }

                list = newList;
            }
            else
            {
                for (int i = 0; i < userList.Count; i++)
                {

                    ArrayList ab = new ArrayList();
                    ab = GetAB(guess, (int)userList[i]);

                    if (bull == (int)ab[0] && cow == (int)ab[1])
                    {
                        newList.Add(userList[i]);
                    }

                }

                userList = newList;
            }


        }

        public static ArrayList GetAB(int guess, int ans)
        {
            ArrayList ab = new ArrayList();
            int a = 0;
            int b = 0;
            int[] listArr = new int[4];
            int[] guessArr = new int[4];
            listArr[0] = ans / 1000;
            listArr[1] = (ans / 100) % 10;
            listArr[2] = (ans / 10) % 10;
            listArr[3] = ans % 10;

            guessArr[0] = guess / 1000;
            guessArr[1] = (guess / 100) % 10;
            guessArr[2] = (guess / 10) % 10;
            guessArr[3] = guess % 10;

            for (int i = 0; i < 4; i++)
            {
                if (guessArr[i] == listArr[i])
                {
                    a++;
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (guessArr[j] == listArr[i])
                        {
                            b++;
                        }
                    }
                }
            }

            ab.Add(a);
            ab.Add(b);

            return ab;
        }
    }

