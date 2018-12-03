using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control // Класс для глобальных переменных и методов. Мб потом стоит вынести в отдельный скрипт
{
    public static bool playerNeedToFly = false; // Когда она true - корабль игрока готовится лететь
    public static Vector2 playerVectorTarget; // Точка, в которую должен полететь корабль игрока
    public static string playerTargetName; // Название объекта, к которому летит игрок. Нужно для посадки в скрипте scr_player_ship метод SpaceshipMovement
    public static bool buttonPlay = false; // Состояние кнопки btn_play. Если false - все стоят, если true - двигаются
	public static string currentSystemStatus; // Состояние текущей системы. {Принадлежит пришельцам; Пограничная; Принадлежит людям} (alien, border, human)
    public static int currentPlanetIndex = 3; //Порядковый номер текущей планеты

	public static float systemHeight; // Высота космоса в относительных координатах (пиксели / 100), с центром в середине экрана.
	public static float systemWidth; // Ширина
    public static Vector4 borders; // Границы космоса (л, в, п, н) (Нужно для предотвращения вылета за пределы кораблём, врагами и камерой)

    public static List<GameObject> space_objects_for_action; // Список космических объектов для различных действий - активации/деактивации
    public static List<GameObject> planet_objects_for_action; // Список планетарных объектов для различных действий, например уничтожения

    public static void SpaceObjectsActivate(bool active) //Так как окно планеты появляется поверх космического, надо деактивировать объекты космоса.
    {

        if (active)
            Debug.Log("Активируем объекты космоса");
        else
        {
            Debug.Log("Деактивируем объекты космоса");
            space_objects_for_action = new List<GameObject>(); // Переинициируем список
        }

        space_objects_for_action.AddRange(GameObject.FindGameObjectsWithTag("CanLand"));
        space_objects_for_action.AddRange(GameObject.FindGameObjectsWithTag("PlayerShip"));
        space_objects_for_action.AddRange(GameObject.FindGameObjectsWithTag("SpaceButton"));
        space_objects_for_action.AddRange(GameObject.FindGameObjectsWithTag("AliensShip"));
        foreach (GameObject g in space_objects_for_action)
        {
            g.SetActive(active);
        }
    }

	public static void PlanetObjectsAction(string action) // При взлёте с планеты - уничтожаем все планетарные объекты
    {
		if (action == "destroy") 
		{
			planet_objects_for_action = new List<GameObject> (); // Переинициируем список
			Debug.Log ("Уничтожаем планетарные объекты");
			planet_objects_for_action.AddRange (GameObject.FindGameObjectsWithTag ("OnPlanetButton"));
			planet_objects_for_action.AddRange (GameObject.FindGameObjectsWithTag ("OnPlanetBackground"));
			planet_objects_for_action.AddRange (GameObject.FindGameObjectsWithTag ("OnPlanetOther"));
			foreach (GameObject g in planet_objects_for_action) {
				MonoBehaviour.Destroy (g);
			}
		}
        else if (action == "destroy2layer")
        {
            planet_objects_for_action = new List<GameObject>(); // Переинициируем список
            planet_objects_for_action.AddRange(GameObject.FindGameObjectsWithTag("OnPlanetButton2"));
            foreach (GameObject g in planet_objects_for_action)
            {
                MonoBehaviour.Destroy(g);
            }
        }
        else if (action == "deactivate") 
		{
			planet_objects_for_action = new List<GameObject> (); // Переинициируем список
			planet_objects_for_action.AddRange (GameObject.FindGameObjectsWithTag ("OnPlanetButton"));
            planet_objects_for_action.AddRange(GameObject.FindGameObjectsWithTag("OnPlanetOther"));

            foreach (GameObject g in planet_objects_for_action) 
			{
				g.SetActive (false);
			}
		} 
		else if (action == "activate") 
		{
			foreach (GameObject g in planet_objects_for_action) 
			{
				g.SetActive (true);
			}
		}
    }
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
//        Debug.Log("Загрузка корабля игрока");
//        Instantiate(obj_players_ship, new Vector3(0, 0, 0), Quaternion.identity);
//        
//        Debug.Log("Загрузка остальных космических объектов");
//        foreach (Transform t in space_objects)
//        {
//            Instantiate(t, new Vector3(t.position.x, t.position.y, t.position.z), Quaternion.identity);
//            Debug.Log("      Готово");
//        }
//
//        Debug.Log("Загрузка кнопок");
//        foreach (Transform t in buttons)
//        {
//            Instantiate(t, new Vector3(t.position.x, t.position.y, t.position.z), Quaternion.identity);
//            Debug.Log("      Готово");
//        }
		Vector2 size = GameObject.Find ("bkg_EarthArea").GetComponent<SpriteRenderer> ().sprite.rect.size;
		Control.systemWidth = size.x / 100;
		Control.systemHeight = size.y / 100;

        Control.borders = new Vector4(size.x / 100 / -2, size.y / 100 / -2, size.x / 100 / 2, size.y / 100 / 2);

		Control.currentSystemStatus = "border";
        scr_object_generating.PlanetAreaObjectGeneration(); //Вызываем метод создания объектов космоса
		scr_object_generating.AlienShipObjectGeneration();
        scr_object_generating.PirateShipObjectGeneration();

		obj_players_ship = GameObject.Find("Players_ship").GetComponent<Transform>();
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
                Debug.Log(rayHit.transform.name);
                //Debug.Log("Selected object: " + rayHit.transform.name);
                //Debug.Log("Selected object's tag: " + rayHit.transform.tag);
				if (rayHit.transform.tag == "CanLand") // CanLand - тэг объекта, который ставится тем объектам, на которые можно приземлиться
                {
					Debug.Log ("Цель выбрана");
                    Control.playerNeedToFly = true;
                    //Control.playerVectorTarget = CurMousePos;
                    Control.playerVectorTarget = new Vector2(rayHit.transform.position.x, rayHit.transform.position.y); // Конечная точка - центр объекта
                    Control.playerTargetName = rayHit.transform.name;
                }
                else if (rayHit.transform.name == "Button_play"/*"btn_play(Clone)"*/) //Здесь надо пофиксить нажатие кнопки play в состоянии покоя, иначе будет трэш
                {
                    Control.buttonPlay = !Control.buttonPlay; // Если все двигались - то стоп. Если стояли - то начитают движение в сторону весны (с)
                    if (Control.buttonPlay)
                        Debug.Log("Горит зелёный свет. Пролёт разрешён");
                    else Debug.Log("Горит красный свет. Все стоят (Нажмите Play)");
                }
                else if (rayHit.transform.name == "Button_takeoff")
                {
					Debug.Log ("Взлёт");
                    Control.PlanetObjectsAction("destroy");
                    Control.SpaceObjectsActivate(true);
                }
				else if (rayHit.transform.name == "Button_explore")
				{
					Control.PlanetObjectsAction ("deactivate");
					scr_object_generating.NumbersGameObjectsGeneration ();
				}
                else if (rayHit.transform.name == "Aliens_ship" || rayHit.transform.name == "Pirates_ship")
                {
                    Debug.Log("Цель выбрана");
                    Control.playerNeedToFly = true;
                    Control.playerVectorTarget = new Vector2(rayHit.transform.position.x, rayHit.transform.position.y); // Конечная точка - центр объекта
                    Control.playerTargetName = rayHit.transform.name;
                }
                else if (rayHit.transform.tag == "OnPlanetButton2")
                {
                    Control.PlanetObjectsAction("activate");
                    Control.PlanetObjectsAction("destroy2layer");
                }
                else if (rayHit.transform.tag == "OnPlanetButton")
                {
                    Control.PlanetObjectsAction("deactivate");
                    scr_object_generating.OnPlanetButtonClick(new Button(rayHit.transform.name, "spr_"+ rayHit.transform.name.ToLower()));
                }

            }
        }
	}
}
