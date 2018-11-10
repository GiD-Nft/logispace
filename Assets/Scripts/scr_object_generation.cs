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
        GameObject current_obj = new GameObject();
        ObjectParamsSet(ref current_obj, "Earth", "spr_planet_earth", new Vector3((float)-2.52, (float)-0.3, (float)1), new Vector3(1,1,1));
        //Instantiate(current_obj);
		ObjectParamsSet(ref current_obj, "Moon", "spr_satellite_moon", new Vector3((float)2.92, (float)-0.12, (float)1), new Vector3(1,1,1));
        //Instantiate(current_obj);
		ObjectParamsSet(ref current_obj, "Station", "spr_station", new Vector3((float)-0.41, (float)1.27, (float)1), new Vector3(1,1,1));
        //Instantiate(current_obj);
		ObjectParamsSet(ref current_obj, "Players_ship", "spr_players_ship", new Vector3(0, 0, 0), new Vector3(1,1,1));
        //Instantiate(current_obj);
		ObjectParamsSet(ref current_obj, "Button_play", "spr_button_play", new Vector3((float)-0.01, (float)-2.21, (float)1), new Vector3(1,1,1));
        //Instantiate(current_obj);

    }

	public static void InhabitedFriendlyPlanetScreenGeneration(string planetName)
	{
		GameObject current_obj = new GameObject();
		//Надо бы сделать здесь расчёт положения и масштаба кнопок в зависимости от размеров камеры, чтобы всё всегда умещалось в экран
		ObjectParamsSet(ref current_obj, "Back_white", "spr_bkg_land_white", new Vector3((float)0, (float)0, (float)0), new Vector3(1,1,1));

		ObjectParamsSet(ref current_obj, "Button_quests", "spr_button_quests", new Vector3((float)-2.65, (float)1.59, (float)-1), new Vector3(1,1,1));
		ObjectParamsSet(ref current_obj, "Button_shop", "spr_button_shop", new Vector3((float)-2.65, (float)0.52, (float)-1), new Vector3(1,1,1));
		ObjectParamsSet(ref current_obj, "Button_ship", "spr_button_ship", new Vector3((float)-2.65, (float)-0.57, (float)-1), new Vector3(1,1,1));
		ObjectParamsSet(ref current_obj, "Button_menu", "spr_button_menu_onPlanet", new Vector3((float)-2.65, (float)-1.64, (float)-1), new Vector3(1,1,1));
		ObjectParamsSet(ref current_obj, "Button_takeoff", "spr_button_takeoff", new Vector3((float)2.37, (float)-2.15, (float)-1), new Vector3(1,1,1));

		string spr_planetpic = "", spr_planetname = "";
		switch (planetName) 
		{
		case "Earth":
			spr_planetpic = "spr_planetpic_earth";
			spr_planetname = "spr_planetname_earth";
			break;
		default:
			break;
		}

		///// Здесь надо поработать с масштабом, чтобы в дефолтном виде он был 1:1, тут костыльЮ так как картинка чуть больше чем надо. Вывод: надо уменьшить картинку.
		ObjectParamsSet (ref current_obj, "Back_planetpic", spr_planetpic, new Vector3 ((float)2.37, (float)0.04, (float)-1), new Vector3 ((float)0.674, (float)0.673, 1));
		ObjectParamsSet (ref current_obj, "Header_planetname", spr_planetname, new Vector3 ((float)2.34, (float)2.1, (float)-1), new Vector3 ((float)0.765, (float)0.703, 1));
	}

	public static void UninhabitedPlanetScreenGeneration(string planetName)
	{
		GameObject current_obj = new GameObject();
		//Надо бы сделать здесь расчёт положения и масштаба кнопок в зависимости от размеров камеры, чтобы всё всегда умещалось в экран
		ObjectParamsSet(ref current_obj, "Back_white", "spr_bkg_land_white", new Vector3((float)0, (float)0, (float)0), new Vector3(1,1,1));

		ObjectParamsSet(ref current_obj, "Button_explore", "spr_button_explore", new Vector3((float)-2.65, (float)1.26, (float)-1), new Vector3(1,1,1));
		ObjectParamsSet(ref current_obj, "Button_ship", "spr_button_ship", new Vector3((float)-2.65, (float)-0.55, (float)-1), new Vector3(1,1,1));
		ObjectParamsSet(ref current_obj, "Button_shop", "spr_button_shop", new Vector3((float)-2.65, (float)-1.65, (float)-1), new Vector3(1,1,1));
		ObjectParamsSet(ref current_obj, "Button_takeoff", "spr_button_takeoff", new Vector3((float)2.37, (float)-2.15, (float)-1), new Vector3(1,1,1));
	}

    static void ObjectParamsSet(ref GameObject current_obj, string objName, string spriteName, Vector3 objPosition, Vector3 objScale)
    {
        current_obj = new GameObject();
        //current_obj = obj_prefab_all;
        current_obj.name = objName;

		if (objName == "Earth" || objName == "Moon" || objName == "Station")
			current_obj.tag = "CanLand";
		else if (objName == "Players_ship")
			current_obj.tag = "PlayerShip";
		else if (objName == "Button_play")
			current_obj.tag = "SpaceButton";
		else if (objName == "Button_quests" || objName == "Button_shop" || objName == "Button_ship" || objName == "Button_menu" ||
		         objName == "Button_takeoff" || objName == "Button_explore")
			current_obj.tag = "OnPlanetButton";
		else if (objName == "Back_white")
			current_obj.tag = "OnPlanetBackground";
		else if (objName == "Back_planetpic" || objName == "Header_planetname")
			current_obj.tag = "OnPlanetOther";
		
        var spr = current_obj.AddComponent<SpriteRenderer>();
		spr.sprite = Resources.Load<Sprite>("Sprites/" + spriteName);

        var rig = current_obj.AddComponent<Rigidbody2D>();
        rig.gravityScale = 0;

		if (objName != "Players_ship" && objName != "Back_white" && objName != "Back_planetpic" && objName != "Header_planetname") // У этих объектов нет коллайдеров. Мб сделать их isTrigger 
		{
			var col = current_obj.AddComponent<CircleCollider2D>();
        	col.radius = (float)1.54; // Сюда вставить высоту спрайта
			if (objName == "Button_play" || objName == "Button_quests" || objName == "Button_shop" || objName == "Button_ship" || 
				objName == "Button_menu" || objName == "Button_takeoff" || objName == "Back_planetpic" || objName == "Header_planetname" || objName == "Button_explore")
				col.isTrigger = true;
		}
			
        current_obj.transform.position = objPosition;
        current_obj.transform.localScale = objScale; // Хз, не уверен насчёт localScale

		// Прихерачивание скриптов

		if (objName == "Players_ship") 
		{
			var scr = current_obj.AddComponent<scr_players_ship> ();
			scr.Speed = 2;
		}
		
    }
}
