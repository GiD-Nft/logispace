using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_object_generating : MonoBehaviour 
{
	void Start () {}
	void Update () {}

    static GameObject obj_prefab_all;

    public static void EarthAreaObjectGeneration()
    {
        objectParamsSet(new Planet("Earth", "spr_planet_earth"), new Vector3((float)-2.52, (float)-0.3, (float)1), new Vector3(1,1,1));
        //Instantiate(current_obj);
		objectParamsSet(new Planet("Moon", "spr_satellite_moon"), new Vector3((float)2.92, (float)-0.12, (float)1), new Vector3(1,1,1));
        //Instantiate(current_obj);
		objectParamsSet(new Planet("Station", "spr_station"), new Vector3((float)-0.41, (float)1.27, (float)1), new Vector3(1,1,1));
        //Instantiate(current_obj);
		objectParamsSet(new Planet("Military_base", "spr_military_base"), new Vector3((float)3, (float)-0.3, (float)1), new Vector3(1,1,1));
		//Instantiate(current_obj);
		objectParamsSet(new Ship("Players_ship", "spr_players_ship"), new Vector3(0, 0, 0), new Vector3(1,1,1));
        //Instantiate(current_obj);
		objectParamsSet(new Button("Button_play", "spr_button_play"), new Vector3((float)-0.01, (float)-2, (float)1), new Vector3(1,1,1));
        //Instantiate(current_obj);

    }

	public static void InhabitedFriendlyPlanetScreenGeneration(Planet planet)
	{
		//Надо бы сделать здесь расчёт положения и масштаба кнопок в зависимости от размеров камеры, чтобы всё всегда умещалось в экран
		objectParamsSet(new OtherObects("Back_white", "spr_bkg_land_white"), new Vector3((float)0, (float)0, (float)0), new Vector3(1,1,1));
		objectParamsSet(new Button("Button_quests", "spr_button_quests"), new Vector3((float)-2.65, (float)1.59, (float)-1), new Vector3(1,1,1));
		objectParamsSet(new Button("Button_shop", "spr_button_shop"), new Vector3((float)-2.65, (float)0.52, (float)-1), new Vector3(1,1,1));
		objectParamsSet(new Button("Button_ship", "spr_button_ship"), new Vector3((float)-2.65, (float)-0.57, (float)-1), new Vector3(1,1,1));
		objectParamsSet(new Button("Button_menu", "spr_button_menu_onPlanet"), new Vector3((float)-2.65, (float)-1.64, (float)-1), new Vector3(1,1,1));
		objectParamsSet(new Button("Button_takeoff", "spr_button_takeoff"), new Vector3((float)2.37, (float)-2.15, (float)-1), new Vector3(1,1,1));

		string spr_planetpic = "", spr_planetname = "";
		switch (planet.Name) 
		{
		case "Earth":
			spr_planetpic = "spr_planetpic_earth";
			spr_planetname = "spr_planetname_earth";
			break;
		}

        ///// Здесь надо поработать с масштабом, чтобы в дефолтном виде он был 1:1, тут костыльЮ так как картинка чуть больше чем надо. Вывод: надо уменьшить картинку.
        ///// Здесь надо поработать с масштабом, чтобы в дефолтном виде он был 1:1, тут костыльЮ так как картинка чуть больше чем надо. Вывод: надо уменьшить картинку.
        objectParamsSet(new Planet("Back_planetpic", spr_planetpic), new Vector3((float)2.37, (float)0.04, (float)-1), new Vector3((float)0.674, (float)0.673, 1));
        objectParamsSet(new Planet("Header_planetname", spr_planetname), new Vector3((float)2.34, (float)2.1, (float)-1), new Vector3((float)0.765, (float)0.703, 1));
    }

    public static void UninhabitedPlanetScreenGeneration(Planet planet)
    {
        //Надо бы сделать здесь расчёт положения и масштаба кнопок в зависимости от размеров камеры, чтобы всё всегда умещалось в экран
        objectParamsSet(new OtherObects("Back_white", "spr_bkg_land_white"), new Vector3((float)0, (float)0, (float)0), new Vector3(1, 1, 1));

        objectParamsSet(new Button("Button_explore", "spr_button_explore"), new Vector3((float)-2.4, (float)1.26, (float)-1), new Vector3(1, 1, 1));
        objectParamsSet(new Button("Button_ship", "spr_button_ship"), new Vector3((float)-2.4, (float)-0.55, (float)-1), new Vector3(1, 1, 1));
        objectParamsSet(new Button("Button_shop", "spr_button_shop"), new Vector3((float)-2.4, (float)-1.65, (float)-1), new Vector3(1, 1, 1));
        objectParamsSet(new Button("Button_takeoff", "spr_button_takeoff"), new Vector3((float)2.37, (float)-1.8, (float)-1), new Vector3(1, 1, 1));
    }

	public static void NumbersGameObjectsGeneration()
	{
		GameObject current_obj = new GameObject();
		current_obj.name = "numbersObj";
		current_obj.AddComponent<numbers_experiments> ();
	}

    public static void objectParamsSet(LogispaceObject logispaceObject, Vector3 objPosition, Vector3 objScale)
    {
        GameObject current_obj = new GameObject();
        //current_obj = obj_prefab_all;
        current_obj.name = logispaceObject.Name;
        switch (logispaceObject.Name) {
			case "Earth":  case "Moon": case "Station": case "Military_base":
                current_obj.tag = "CanLand";
                break;
            case "Players_ship":
                current_obj.tag = "PlayerShip";
                break;
            case "Button_play":
                current_obj.tag = "SpaceButton";
                break;
            case "Button_quests": case "Button_shop": case "Button_ship": case "Button_menu": case "Button_takeoff": case "Button_explore":
                current_obj.tag = "OnPlanetButton";
                break;
            case "Back_white":
                current_obj.tag = "OnPlanetBackground";
                break;
            case "Back_planetpic": case "Header_planetname":
                current_obj.tag = "OnPlanetOther";
                break;
        }

        var spriteComponent = current_obj.AddComponent<SpriteRenderer>();
		spriteComponent.sprite = Resources.Load<Sprite>("Sprites/" + logispaceObject.SpriteName);

        var rigidbodyComponent = current_obj.AddComponent<Rigidbody2D>();
        rigidbodyComponent.gravityScale = 0;

		if (logispaceObject.Name != "Players_ship" && logispaceObject.Name != "Back_white" && logispaceObject.Name != "Back_planetpic" && logispaceObject.Name != "Header_planetname") // У этих объектов нет коллайдеров. Мб сделать их isTrigger 
		{
			var circleCollider = current_obj.AddComponent<CircleCollider2D>();
        	circleCollider.radius = (float)1.54; // Сюда вставить высоту спрайта
			if (logispaceObject.objectType == "Button")
				circleCollider.isTrigger = true;
		}
			
        current_obj.transform.position = objPosition;
        current_obj.transform.localScale = objScale; // Хз, не уверен насчёт localScale

		// Прихерачивание скриптов

		if (logispaceObject.Name == "Players_ship") 
		{
			var scr = current_obj.AddComponent<scr_players_ship> ();
			scr.Speed = 2;
		}
		
    }
}
