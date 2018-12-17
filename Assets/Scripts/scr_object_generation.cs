using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_object_generating : MonoBehaviour 
{
	void Start () {}
	void Update () {}

    static GameObject obj_prefab_all;

    public static void PlanetAreaObjectGeneration()
    {
        float arrow_x = Control.borders.z - 0.1f;
        if (Control.currentPlanetIndex < 8)
            objectParamsSet(new Button("button_right", "spr_button_right"), new Vector3((float)arrow_x, (float)0, (float)1), new Vector3(1, 1, 1));
        if (Control.currentPlanetIndex > 1)
            objectParamsSet(new Button("button_left", "spr_button_left"), new Vector3((float)-arrow_x, (float)0.0, (float)1), new Vector3(1, 1, 1));
        
        switch (Control.currentPlanetIndex)
        {
            case 1:
                MercuryAreaObjectGeneration();
                break;
            case 2:
                VenusAreaObjectGeneration();
                break;
            case 3:
                EarthAreaObjectGeneration();
                break;
            case 4:
                MarsAreaObjectGeneration();
                break;
            case 5:
                JupiterAreaObjectGeneration();
                break;
            case 6:
                SaturnAreaObjectGeneration();
                break;
            case 7:
                UranusAreaObjectGeneration();
                break;
            case 8:
                NeptuneAreaObjectGeneration();
                break;
            default:
                EarthAreaObjectGeneration();
                break;
        }

    }

    // Земля
    public static void EarthAreaObjectGeneration()
    {
        objectParamsSet(new Planet("Earth", "spr_planet_earth"), new Vector3((float)-2.52, (float)-0.3, (float)1), new Vector3(1,1,1));
		objectParamsSet(new Planet("Moon", "spr_satellite_moon"), new Vector3((float)2.92, (float)-0.12, (float)1), new Vector3(1,1,1));
		objectParamsSet(new Planet("Station", "spr_station"), new Vector3((float)-0.41, (float)1.27, (float)1), new Vector3(1,1,1));
		objectParamsSet(new Planet("Military_base", "spr_military_base"), new Vector3((float)3, (float)-1.5, (float)1), new Vector3(1,1,1));
		objectParamsSet(new Ship("Players_ship", "spr_players_ship"), new Vector3(0, 0, 0), new Vector3(1,1,1));
		//objectParamsSet(new Button("Button_play", "spr_button_play"), new Vector3((float)-0.01, (float)-2, (float)1), new Vector3(1,1,1));

    }

    // Меркурий (0 спутников)
    public static void MercuryAreaObjectGeneration()
    {
        objectParamsSet(new Planet("Mercury", "spr_planet_mercury"), new Vector3((float)-2.52, (float)-0.3, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Station", "spr_station"), new Vector3((float)-1.9, (float)1.9, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Military_base", "spr_military_base"), new Vector3((float)4.3, (float)1.5, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Ship("Players_ship", "spr_players_ship"), new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        //objectParamsSet(new Button("Button_play", "spr_button_play"), new Vector3((float)-0.01, (float)-2, (float)1), new Vector3(1, 1, 1));
    }

    // Венера (0 спутников)
    public static void VenusAreaObjectGeneration()
    {
        objectParamsSet(new Planet("Venus", "spr_planet_venus"), new Vector3((float)-2.52, (float)1.3, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Station", "spr_station"), new Vector3((float)0.6, (float)1.3, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Military_base", "spr_military_base"), new Vector3((float)4, (float)-1.9, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Ship("Players_ship", "spr_players_ship"), new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        //objectParamsSet(new Button("Button_play", "spr_button_play"), new Vector3((float)-0.01, (float)-2, (float)1), new Vector3(1, 1, 1));
    }

    // Марс (2 спутника)
    public static void MarsAreaObjectGeneration()
    {
        objectParamsSet(new Planet("Mars", "spr_planet_mars"), new Vector3((float)-1.0, (float)2.0, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Phobos", "spr_satellite_phobos"), new Vector3((float)2.95, (float)2.95, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Deimos", "spr_satellite_deimos"), new Vector3((float)5.31, (float)-1.99, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Station", "spr_station"), new Vector3((float)-3.2, (float)0.5, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Military_base", "spr_military_base"), new Vector3((float)-5.36, (float)2.32, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Ship("Players_ship", "spr_players_ship"), new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        //objectParamsSet(new Button("Button_play", "spr_button_play"), new Vector3((float)-0.01, (float)-2, (float)1), new Vector3(1, 1, 1));
    }

    // Юпитер (4 спутника)
    public static void JupiterAreaObjectGeneration()
    {
        objectParamsSet(new Planet("Jupiter", "spr_planet_jupiter"), new Vector3((float)-2.94, (float)1.13, (float)1), new Vector3((float)0.8, (float)0.8, (float)0.8));
        objectParamsSet(new Planet("Io", "spr_satellite_io"), new Vector3((float)1.66, (float)1.15, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Europa", "spr_satellite_europa"), new Vector3((float)-3.98, (float)-2.84, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Ganymede", "spr_satellite_ganymede"), new Vector3((float)3.08, (float)-1.55, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Callisto", "spr_satellite_callisto"), new Vector3((float)5.44, (float)-2.12, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Station", "spr_station"), new Vector3((float)-0.41, (float)1.27, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Military_base", "spr_military_base"), new Vector3((float)4.5, (float)2.5, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Ship("Players_ship", "spr_players_ship"), new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        //objectParamsSet(new Button("Button_play", "spr_button_play"), new Vector3((float)-0.01, (float)-2, (float)1), new Vector3(1, 1, 1));
    }

    // Сатурн (4 спутника)
    public static void SaturnAreaObjectGeneration()
    {
        objectParamsSet(new Planet("Saturn", "spr_planet_saturn"), new Vector3((float)3.64, (float)1.64, (float)1), new Vector3((float)0.5, (float)0.5, (float)0.5));
        objectParamsSet(new Planet("Mimas", "spr_satellite_mimas"), new Vector3((float)2.76, (float)-0.09, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Enceladus", "spr_satellite_enceladus"), new Vector3((float)-1.36, (float)1.28, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Tethys", "spr_satellite_tethys"), new Vector3((float)-4.41, (float)1.99, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Dione", "spr_satellite_dione"), new Vector3((float)-4.92, (float)-2.12, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Station", "spr_station"), new Vector3((float)1.51, (float)2.67, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Military_base", "spr_military_base"), new Vector3((float)3, (float)-2.5, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Ship("Players_ship", "spr_players_ship"), new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        objectParamsSet(new Button("Button_play", "spr_button_play"), new Vector3((float)-0.01, (float)-2, (float)1), new Vector3(1, 1, 1));
    }

    // Уран (3 спутника)
    public static void UranusAreaObjectGeneration()
    {
        objectParamsSet(new Planet("Uranus", "spr_planet_uranus"), new Vector3((float)-3.85, (float)0.12, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Ariel", "spr_satellite_ariel"), new Vector3((float)0.92, (float)1.9, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Miranda", "spr_satellite_miranda"), new Vector3((float)2.73, (float)-0.12, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Umbriel", "spr_satellite_umbriel"), new Vector3((float)4.24, (float)-1.82, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Station", "spr_station"), new Vector3((float)-1.9, (float)1.9, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Military_base", "spr_military_base"), new Vector3((float)5, (float)2.0, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Ship("Players_ship", "spr_players_ship"), new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        //objectParamsSet(new Button("Button_play", "spr_button_play"), new Vector3((float)-0.01, (float)-2, (float)1), new Vector3(1, 1, 1));
    }

    // Нептун (1 спутник)
    public static void NeptuneAreaObjectGeneration()
    {
        objectParamsSet(new Planet("Neptune", "spr_planet_neptune"), new Vector3((float)-3.4, (float)-0.5, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Triton", "spr_satellite_triton"), new Vector3((float)4.85, (float)1.82, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Station", "spr_station"), new Vector3((float)-1.45, (float)2.12, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Planet("Military_base", "spr_military_base"), new Vector3((float)4.2, (float)-1.5, (float)1), new Vector3(1, 1, 1));
        objectParamsSet(new Ship("Players_ship", "spr_players_ship"), new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        //objectParamsSet(new Button("Button_play", "spr_button_play"), new Vector3((float)-0.01, (float)-2, (float)1), new Vector3(1, 1, 1));
    }


    //todo объединить эти три в один:
    public static void InhabitedFriendlyPlanetScreenGeneration(Planet planet)
	{
		//Надо бы сделать здесь расчёт положения и масштаба кнопок в зависимости от размеров камеры, чтобы всё всегда умещалось в экран
		objectParamsSet(new OtherObects("Back_white", "spr_bkg_land_white"), new Vector3((float)0, (float)0, (float)0), new Vector3(2,2,1));
		objectParamsSet(new Button("Button_quests", "spr_button_quests"), new Vector3((float)-2.65, (float)1.59, (float)-1), new Vector3(1,1,1));
		objectParamsSet(new Button("Button_shop", "spr_button_shop"), new Vector3((float)-2.65, (float)0.52, (float)-1), new Vector3(1,1,1));
		objectParamsSet(new Button("Button_ship", "spr_button_ship"), new Vector3((float)-2.65, (float)-0.57, (float)-1), new Vector3(1,1,1));
		objectParamsSet(new Button("Button_menu_onPlanet", "spr_button_menu_onPlanet"), new Vector3((float)-2.65, (float)-1.64, (float)-1), new Vector3(1,1,1));
		objectParamsSet(new Button("Button_takeoff", "spr_button_takeoff"), new Vector3((float)2.37, (float)-2.15, (float)-1), new Vector3(1,1,1));

		string spr_planetpic = "spr_planetpic_" + planet.Name.ToLower(), 
            spr_planetname = "spr_planetname_" + planet.Name.ToLower();
		//switch (planet.Name) 
		//{
		//case "Earth":
		//	spr_planetpic = "spr_planetpic_earth";
		//	spr_planetname = "spr_planetname_earth";
		//	break;
		//}

        ///// Здесь надо поработать с масштабом, чтобы в дефолтном виде он был 1:1, тут костыльЮ так как картинка чуть больше чем надо. Вывод: надо уменьшить картинку.
        ///// Здесь надо поработать с масштабом, чтобы в дефолтном виде он был 1:1, тут костыльЮ так как картинка чуть больше чем надо. Вывод: надо уменьшить картинку.
        objectParamsSet(new Planet("Back_planetpic", spr_planetpic), new Vector3((float)2.37, (float)0.04, (float)-1), new Vector3((float)0.674, (float)0.673, 1));
        objectParamsSet(new Planet("Header_planetname", spr_planetname), new Vector3((float)2.34, (float)2.1, (float)-1), new Vector3((float)0.765, (float)0.703, 1));
    }

    public static void UninhabitedPlanetScreenGeneration(Planet planet)
    {
        //Надо бы сделать здесь расчёт положения и масштаба кнопок в зависимости от размеров камеры, чтобы всё всегда умещалось в экран
        objectParamsSet(new OtherObects("Back_white", "spr_bkg_land_white"), new Vector3((float)0, (float)0, (float)0), new Vector3(2, 2, 1));

        objectParamsSet(new Button("Button_explore", "spr_button_explore"), new Vector3((float)-2.4, (float)1.26, (float)-1), new Vector3(1, 1, 1));
        objectParamsSet(new Button("Button_ship", "spr_button_ship"), new Vector3((float)-2.4, (float)-0.55, (float)-1), new Vector3(1, 1, 1));
        objectParamsSet(new Button("Button_shop", "spr_button_shop"), new Vector3((float)-2.4, (float)-1.65, (float)-1), new Vector3(1, 1, 1));
        objectParamsSet(new Button("Button_takeoff", "spr_button_takeoff"), new Vector3((float)2.37, (float)-1.8, (float)-1), new Vector3(1, 1, 1));
    }

    public static void StationsScreenGeneration(string target)
    {
        // target - Station or Military_base
        //Надо бы сделать здесь расчёт положения и масштаба кнопок в зависимости от размеров камеры, чтобы всё всегда умещалось в экран
        objectParamsSet(new OtherObects("Back_white", "spr_bkg_land_white"), new Vector3((float)0, (float)0, (float)0), new Vector3(2, 2, 1));
        if (target == "Station")
        {
            objectParamsSet(new Button("Button_quests", "spr_button_quests"), new Vector3((float)-2.65, (float)1.59, (float)-1), new Vector3(1, 1, 1));
            objectParamsSet(new Button("Button_shop", "spr_button_shop"), new Vector3((float)-2.65, (float)0.52, (float)-1), new Vector3(1, 1, 1));
        }
        else
        {
            objectParamsSet(new Button("Button_combat_mission", "spr_button_combat_mission"), new Vector3((float)-2.65, (float)0.7, (float)-1), new Vector3(1, 1, 1));
        }

        objectParamsSet(new Button("Button_ship", "spr_button_ship"), new Vector3((float)-2.65, (float)-0.57, (float)-1), new Vector3(1, 1, 1));
        objectParamsSet(new Button("Button_menu_onPlanet", "spr_button_menu_onPlanet"), new Vector3((float)-2.65, (float)-1.64, (float)-1), new Vector3(1, 1, 1));
        objectParamsSet(new Button("Button_takeoff", "spr_button_takeoff"), new Vector3((float)2.37, (float)-2.15, (float)-1), new Vector3(1, 1, 1));

        string spr_planetpic = "spr_planetpic_" + target.ToLower(),
            spr_planetname = "spr_planetname_" + target.ToLower();
        objectParamsSet(new Planet("Back_planetpic", spr_planetpic), new Vector3((float)2.37, (float)0.04, (float)-1), new Vector3((float)0.674, (float)0.673, 1));
        objectParamsSet(new Planet("Header_planetname", spr_planetname), new Vector3((float)2.34, (float)2.1, (float)-1), new Vector3((float)0.765, (float)0.703, 1));
    }

    public static void OnPlanetButtonClick(Button button)
    {
        //Надо бы сделать здесь расчёт положения и масштаба кнопок в зависимости от размеров камеры, чтобы всё всегда умещалось в экран
        //objectParamsSet(new OtherObects("Back_white_onPlanet", "spr_bkg_land_white"), new Vector3((float)0, (float)0, (float)-2), new Vector3(1, 1, 1));
     
        objectParamsSet(new Planet("Header_onPlanet", button.SpriteName), new Vector3((float)0, (float)2.3, (float)-1), new Vector3(1, 1, 1));
        objectParamsSet(new Button("Button_back", "spr_button_back"), new Vector3((float)0, (float)-2.3, (float)-1), new Vector3(1, 1, 1));
    }

    public static void NumbersGameObjectsGeneration()
	{
		GameObject current_obj = new GameObject();
		current_obj.name = "numbersObj";
		current_obj.AddComponent<scr_numbers> ();
	}

    public static void BattleScreenGeneration()
    {
        GameObject current_obj = new GameObject();
        current_obj.name = "bullsAndCowsObj";
        current_obj.AddComponent<scr_bulls_and_cows>();
    }

	public static void AlienShipObjectGeneration()
	{
		// Здесь надо сделать генерацию по краю карты для пограничных систем; и в любой точке для систем, захваченных пришельцами.
        string area = "all";

        switch (Control.currentSystemStatus)
        {
            case "alien":
                area = "all";
                break;
            case "border":
                area = "right";
                break;
            default:
                return;
        }

        objectParamsSet(new Ship("Aliens_ship", "spr_aliens_ship"), GetGenerationPoint(area), new Vector3(1, 1, 1));
	}

    public static void PirateShipObjectGeneration()
    {
        // Здесь надо сделать генерацию по в любой точке карты для систем под контролем людей, и по левоу краю для пограничных
        string area = "all";

        switch (Control.currentSystemStatus)
        {
            case "human":
                area = "all";
                break;
            case "border":
                area = "left";
                break;
            default:
                return;
        }

        objectParamsSet(new Ship("Pirates_ship", "spr_pirates_ship"), GetGenerationPoint(area), new Vector3(1, 1, 1));
    }

    public static Vector3 GetGenerationPoint(string area) // Генерируем точку, в которой появится корабль. area - область, в которой генерятся корабли (left, right, all)
    {
        float x, y;
        float borderLeft = 0, borderRight = 0;
        RaycastHit2D rayHit;

        switch (area)
        {
            case "left":
                borderLeft = Control.borders.x;
                borderRight = 0;
                break;
            case "right":
                borderLeft = 0;
                borderRight = Control.borders.z;
                break;
            case "all":
                borderLeft = Control.borders.x;
                borderLeft = Control.borders.z;
                break;
        }

        x = Random.Range(borderLeft, borderRight);

        // Здесь проверка на то, чтобы корабль не заспавнился на другом объекте
        do
        {
            y = Random.Range(Control.borders.y, Control.borders.w);
            rayHit = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);
        } while (rayHit.transform != null);

        return new Vector3(x, y, 0);
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
            case "Button_quests":
            case "Button_shop":
            case "Button_ship":
            case "Button_menu_onPlanet":
            case "Button_takeoff":
            case "Button_explore":
            case "Button_combat_mission":
                current_obj.tag = "OnPlanetButton";
                break;
            case "Header_onPlanet":
            case "Button_back":
                current_obj.tag = "OnPlanetButton2";
                break;
            case "Back_white":
                current_obj.tag = "OnPlanetBackground";
                break;
            case "Back_planetpic":
            case "Header_planetname":
                current_obj.tag = "OnPlanetOther";
                break;
			case "Aliens_ship":
				current_obj.tag = "AliensShip";
				break;
            default:
                current_obj.tag = "CanLand";
                break;
        }

        var spriteComponent = current_obj.AddComponent<SpriteRenderer>();
		spriteComponent.sprite = Resources.Load<Sprite>("Sprites/" + logispaceObject.SpriteName);

        var rigidbodyComponent = current_obj.AddComponent<Rigidbody2D>();
        rigidbodyComponent.gravityScale = 0;

		if (logispaceObject.Name != "Players_ship" && logispaceObject.Name != "Back_white" 
            && logispaceObject.Name != "Back_planetpic" && logispaceObject.Name != "Header_planetname") // У этих объектов нет коллайдеров. Мб сделать их isTrigger 
		{
            if (current_obj.tag == "OnPlanetButton" || current_obj.tag == "OnPlanetButton2")
            {
                var boxCollider = current_obj.AddComponent<BoxCollider2D>();

                boxCollider.isTrigger = true;
            }
            else
            {
                var circleCollider = current_obj.AddComponent<CircleCollider2D>();
                //circleCollider.radius = (float)1.54; // Сюда вставить высоту спрайта
                circleCollider.radius = spriteComponent.sprite.rect.height / 200;

                //if (logispaceObject.objectType == "Button")
                circleCollider.isTrigger = true;
            }
		}
			
        current_obj.transform.position = objPosition;
        current_obj.transform.localScale = objScale; // Хз, не уверен насчёт localScale

		// Прихерачивание скриптов

		switch (logispaceObject.Name) 
		{
			case "Players_ship":
				var scr1 = current_obj.AddComponent<scr_players_ship> ();
				scr1.Speed = 2;
				break;
			case "Aliens_ship":
            case "Pirates_ship": //////////////////////////////////////////////// Пока что так
				var scr2 = current_obj.AddComponent<scr_alien_movement> ();
				scr2.speed = 2;
				break;
			default:
				break;
		}
		
    }
}
