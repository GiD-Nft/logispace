using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_numbers : MonoBehaviour 
{

	public int selGridInt = 0;
	public string[] selStrings = new string[] { "Grid 1", "Grid 2", "Grid 3", "Grid 4" };
	static int numbersCount = 25;
	static int tableLength = 9; //(int)Mathf.Sqrt(numbersCount);
	private string[] tableOfNumbers = new string[numbersCount];
	public int previousSelected = -1;
	bool check = false;
	int gridCellSide = 35; // Сторона ячейки в гриде в пикселях
	int gridWidth; // Ширина грида в пикселях
	int gridHeight; // Высота грида в пикселях, которая динамически меняется при добавлении и удалении строк, чтобы кнопки были постоянного размера.
	int deletedCells = 0; // Хранит количество ячеек, очищенных кнопкой "Скрыть пустые строки". Нужно для подсчёта процента исследования.


	List<string> abc = new List<string>();

	void Start()
	{
		placedNumbers();
	}

	void placedNumbers()
	{
		for (int i = 0; i < tableOfNumbers.Length; i++)
		{
			tableOfNumbers[i] = Random.Range(1, 9).ToString();
		}

		gridWidth = tableLength * gridCellSide;
		gridHeight = GridHeightUpdate ();
	}

	void OnGUI()
	{
		// Grid
		selGridInt = GUI.SelectionGrid(new Rect(100, 25, gridWidth, gridHeight), selGridInt, tableOfNumbers, tableLength);
		if (previousSelected == -1)
			previousSelected = selGridInt;
		if (selGridInt != previousSelected && previousSelected != -1)
		{
			checkRules(previousSelected, selGridInt);
			previousSelected = -1;
		}
		//		Debug.Log(previousSelected);
		//		Debug.Log(check);

		// Кнопки
		if (GUI.Button(new Rect(450, 25, 120, 50), "Добавить ещё"))
			AddNumber();

		if (GUI.Button (new Rect (450, 80, 120, 80), "Скрыть пустые\n строки")) 
			ClearEmpty ();

		if (GUI.Button (new Rect (450, 170, 120, 80), "Завершить\nисследование")) 
		{
			Control.PlanetObjectsAction ("activate");
			Destroy(GameObject.Find ("numbersObj"));
		}

		// Текст

		int allCells = tableOfNumbers.Length + deletedCells;
		int emptyCells = NumberOfEmptyCells() + deletedCells;
		int percent = Mathf.RoundToInt(((float)emptyCells / (float)allCells) * 100);

		GUI.TextArea (new Rect (600, 25, 300, 400), 
			"Всего ячеек: " + allCells +
			"\nИсследованных ячеек: " + emptyCells +
			"\nПроцент исследования: " + percent +"%" +
            "\n" + "\nЦель игры: «вычеркнуть» все цифры." + 
            "\nКак играть:" +
            "\n- Вычёркивать можно любые одинаковые или дающие в сумме 10 цифры, стоящие рядом по горизонтали или вертикали." +
            "\n- Вычёркивать можно последнее в строке с первым в следующей строке, если они одинаковые или дают в сумме 10." +
            "\n- Цифры, которые были вычеркнуты больше не учитывается. Пример: есть 1 * * 1, где * - вычеркнутая цифра, в данном случае считается, что единички стоят рядом и их можно вычеркивать." +
            "\n \nЕсли ходов больше нет, необходимо нажать на «Добавить ещё!», все цифры автоматически перепишутся вниз и можно продолжать играть.");
	}

	private void checkRules(int firstInd, int secondInd)
	{
		if (checkNeighbors(firstInd, secondInd))
		{
			if (tableOfNumbers[firstInd] == " " || tableOfNumbers[secondInd] == " ")
			{
				return;
			}
			if (tableOfNumbers[firstInd].Equals(tableOfNumbers[secondInd]))
			{
				Success(firstCell: firstInd, secondCell: secondInd);
				return;
			}
			if (int.Parse(tableOfNumbers[firstInd]) + int.Parse(tableOfNumbers[secondInd]) == 10)
			{
				Success(firstCell: firstInd, secondCell: secondInd);
				return;
			}
		}
	}

	private bool checkNeighbors(int firstInd, int secondInd) {
		if (Mathf.Abs(secondInd - firstInd) == tableLength)
		{
			return true;
		}
		if (Mathf.Abs(secondInd - firstInd) == 1)
		{
			return true;
		}
		if (checkEmptyesOnPath(firstInd, secondInd))
		{
			return true;
		}
		return false;
	}

	private bool checkEmptyesOnPath(int firstInd, int secondInd) {
		bool checkEmpty = true;
		if (firstInd > secondInd)
		{
			int a = secondInd;
			secondInd = firstInd;
			firstInd = a;
		}
		if (secondInd - firstInd < tableLength)
		{
			for (int i = firstInd + 1; i < secondInd; i++)
			{
				if (tableOfNumbers[i] != " ")
				{
					checkEmpty = false;
				}
			}
		}
		else {
			for (int i = firstInd + tableLength; i < secondInd; i+=tableLength)
			{
				if (tableOfNumbers[i] != " ")
				{
					checkEmpty = false;
				}
			}
		}
		return checkEmpty;
	}

	private void Success(int firstCell, int secondCell)
	{
		tableOfNumbers[firstCell] = " ";
		tableOfNumbers[secondCell] = " ";
	}

	private int GridHeightUpdate()
	{
		return Mathf.CeilToInt ((float)tableOfNumbers.Length / tableLength) * gridCellSide;
	}

	private void AddNumber()
	{
		List<string> addedNumbers = new List<string>();
		for (int i = 0; i < tableOfNumbers.Length; i++)
			if (tableOfNumbers [i] != " ")
				addedNumbers.Add (tableOfNumbers [i]);

		// Ща будут костыли
		string[] table = new string[tableOfNumbers.Length + addedNumbers.Count];
		for (int i = 0; i < tableOfNumbers.Length; i++)
			table [i] = tableOfNumbers [i];
		int ind = tableOfNumbers.Length;
		for (int i = 0; i < addedNumbers.Count; i++)
			table [ind + i] = addedNumbers [i];

		tableOfNumbers = table;

		gridHeight = GridHeightUpdate ();
	}

	private void ClearEmpty()
	{
		for (int i = 0; i < tableOfNumbers.Length; i += tableLength) 
		{
			bool isEmptyString = true;
			for (int j = 0; j < tableLength; j++)
				if (tableOfNumbers [i + j] != " ") 
				{
					isEmptyString = false;
					break;
				}
			if (isEmptyString) 
			{
				StringsShift (firstIndex: i, shift: tableLength);
				deletedCells += tableLength;
			}
		}

		gridHeight = GridHeightUpdate ();	
		previousSelected = -1;
	}

	private void StringsShift(int firstIndex, int shift) // firstIndex - индекс первого элемента, на который начинается сдвиг, т.е. первый элемент пустой строки
	{
		string[] table = new string[tableOfNumbers.Length - shift];
		for (int i = 0; i < firstIndex; i++)
			table [i] = tableOfNumbers [i];
		for (int i = firstIndex; i < tableOfNumbers.Length - shift; i++)
			table [i] = tableOfNumbers [i + shift];

		tableOfNumbers = table;
	}

	private int NumberOfEmptyCells()
	{
		int count = 0;
		for (int i = 0; i < tableOfNumbers.Length; i++)
			if (tableOfNumbers [i] == " ")
				count += 1;
		return count;
	}
}