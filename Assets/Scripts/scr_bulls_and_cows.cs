using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;


public class scr_bulls_and_cows : MonoBehaviour {
    public string textField = "1234";
    public static string textAreaString = "Игрок";
    public static ArrayList list = new ArrayList();
    public static int count = 0;
    public int bull = 0;
    public int cow = 0;
    public static ArrayList userList = new ArrayList();
    public static int userCount = 0;
    public bool userWin = false;
    public bool comWin = false;
    public int ansint;
    public bool turn = false;
    string number;
    public static string textAreaComp;
    // Use this for initialization
    void Start () 
    {
        list = GenerateList();
        userList = GenerateList();
        writeToUser("Write ur number");
        ansint = GenerateNumberFromList();
    }

    // Update is called once per frame
    void Update () 
    {
		
	}

    void OnGUI()
    {
        
        
    textField = GUI.TextField(new Rect(444, 10, 55, 30), textField);
    GUI.skin.textField.fontSize = 20;
        if (GUI.Button(new Rect(425, 250, 100, 30), "Выйти")) {
            Control.SpaceObjectsActivate(true);
            Control.setLandCameraSize(false);
            Destroy(GameObject.Find("bullsAndCowsObj"));
        }

        textAreaString = GUI.TextArea(new Rect(640, 25, 300, 280), textAreaString);
        textAreaComp = GUI.TextArea(new Rect(10, 25, 300, 280), textAreaComp);
        if (GUI.Button(new Rect(425, 100, 100, 30), "Задать число")) {
             number = textField;
        }
            
        if (GUI.Button(new Rect(425, 150, 100, 30), "Угадать"))
        {
            //Console.WriteLine(ansint);
            int[] ans = new int[4];

            ans[0] = ansint / 1000;
            ans[1] = (ansint / 100) % 10;
            ans[2] = (ansint / 10) % 10;
            ans[3] = ansint % 10;
            UserGame(ans, textField); // тут заменить Console.ReadLine на число пользоваеля которое он вводит чтоб угадать
            Game(number); // Тут вызывается хо компа
        }
    }
    public static void writeToUser(string text) {
        textAreaString = textAreaString + "\n" + text;
    }

    public static void writeToComp(string text)
    {
        textAreaComp = textAreaComp + "\n" + text;
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
        writeToUser("comp guess = " + compGuess);
        writeToUser("Bulls = " + ab[0]);
        int bull = (int)ab[0]; // Количество быков которые угадал комп
        writeToUser("Cows = " + ab[1]);
        int cow = (int)ab[1]; // Количество коров которые угадал комп
        if (bull == 4 && cow == 0)
        {
            writeToUser("Comupter Win! Your secret number is " + compGuess);
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
            writeToUser("comp guess = " + compGuess);
            writeToUser("Bulls = " + ab[0]);
            int a = (int)ab[0];
            writeToUser("Cows = " + ab[1]);
            int b = (int)ab[1];
            if (a != 4 || b != 0)
            {
                writeToUser("You must type something wrong, try again...");
            }
            else if (a == 4 && b == 0)
            {
                writeToUser("Your secret number is " + compGuess);
                return true;
            }
            return true;
        }
        else if (list.Count == 0)
        {
            writeToUser("You must type something wrong, try again...");
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool UserGame(int[] ans, string guess)
    {
        Debug.Log("WORK!!!!!!!!");
        userCount++;
        writeToComp("");
        writeToComp("Guess a four digit number");

        char[] guessed = guess.ToCharArray();
        int bullsCount = 0;
        int cowsCount = 0;

        if (guessed.Length != 4 || (guessed[0] == guessed[1] || guessed[0] == guessed[2] || guessed[0] == guessed[3]) || guessed[1] == guessed[2] || guessed[1] == guessed[3] || guessed[2] == guessed[3])
        {
            writeToComp("Not a valid guess. Try again");
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
        Debug.Log(curAns);
        ArrayList ab = new ArrayList();
        ab = GetAB(curGuess, curAns);

        CheckList(bullsCount, cowsCount, Convert.ToInt32(guess), false);

        if ((int)ab[0] == 4)
        {
            writeToComp("Congratulations! You have won!");
            return true;
        }
        else
        {
            writeToComp((int)ab[0]+ " bulls and " + (int)ab[1] + " cows");
            return false;
        }
    }

    public static int GenerateNumberFromList()
    {
        int number = 0;
        //Random rnd = new Random();
        System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
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
