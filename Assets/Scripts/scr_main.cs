using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control // Класс для глобальных переменных и методов. Мб потом стоит вынести в отдельный скрипт
{
    public static bool playerNeedToFly = false; // Когда она true - корабль игрока готовится лететь
    public static Vector2 playerVectorTarget; // Точка, в которую должен полететь корабль игрока
    public static bool buttonPlay = false; // Состояние кнопки btn_play. Если false - все стоят, если true - двигаются
}


public class scr_main : MonoBehaviour 
{

    public Transform obj_players_ship;
    //public Transform obj_planet; // Планета в этой зоне (экране). На каждом экране своя
    //public List<Transform> obj_satellites; // Спутники (их может быть несколько)
    public List<Transform> space_objects; // Здесь объединил все космические объекты в один список чтоб не захламлять
    public List<Transform> buttons; // Кнопки на этом экране

	// Use this for initialization
	void Start () 
    {
        Debug.Log("Загрузка корабля игрока");
        Instantiate(obj_players_ship, new Vector3(0, 0, 0), Quaternion.identity);
        
        Debug.Log("Загрузка остальных космических объектов");
        foreach (Transform t in space_objects)
        {
            Instantiate(t, new Vector3(t.position.x, t.position.y, t.position.z), Quaternion.identity);
            Debug.Log("      Готово");
        }

        Debug.Log("Загрузка кнопок");
        foreach (Transform t in buttons)
        {
            Instantiate(t, new Vector3(t.position.x, t.position.y, t.position.z), Quaternion.identity);
            Debug.Log("      Готово");
        }

        Debug.Log("Горит красный свет. Все стоят (Нажмите Play)");
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Считываем левый клик мыши, когда кнопка была отжата
        if (Input.GetMouseButtonUp(0) == true)
        {
            /*Raycast и проверка на какой именно объект кликнули. Взависимости от этого - действия*/
            //https://bunkerbook.ru/unity-lessons/kak-rabotat-s-raycast-2d-v-unity-5/ - хорошая статья про Raycast

            //Debug.Log("Кастуем луч в точку клика мыши");
            Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log("Позиция мыши в этом вопросе: " + CurMousePos.x + " " + CurMousePos.y);
            RaycastHit2D rayHit = Physics2D.Raycast(CurMousePos, Vector2.zero);
            if (rayHit.transform != null)
            {
                //Debug.Log("Selected object: " + rayHit.transform.name);
                //Debug.Log("Selected object's tag: " + rayHit.transform.tag);
                if (rayHit.transform.tag == "CanLand") // CanLand - тэг объекта, который ставится тем объектам, на которые можно приземлиться
                {
                    Control.playerNeedToFly = true;
                    //Control.playerVectorTarget = CurMousePos;
                    Control.playerVectorTarget = new Vector2(rayHit.transform.position.x, rayHit.transform.position.y); // Конечная точка - центр объекта
                }
                else if (rayHit.transform.name == "btn_play(Clone)") //Здесь надо пофиксить нажатие кнопки play в состоянии покоя, иначе будет трэш
                {
                    Control.buttonPlay = !Control.buttonPlay; // Если все двигались - то стоп. Если стояли - то начитают движение в сторону весны (с)
                    if (Control.buttonPlay)
                        Debug.Log("Горит зелёный свет. Пролёт разрешён");
                    else Debug.Log("Горит красный свет. Все стоят (Нажмите Play)");
                }
            }
        }
	}
}
