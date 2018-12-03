using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_landing : MonoBehaviour 
{
    public Transform bkg_land_white; // Background
    public List<Transform> buttons; // Кнопки
    Planet planet;
    
    // Use this for initialization
    void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void Landing()
    {

        //Control.SpaceObjectsActivate(false); // Деактивируем объекты космоса
        if (Control.playerTargetName == "button_left")
        {
            Control.SpaceObjectsActivate(false);
            Control.currentPlanetIndex -= 1;
            scr_object_generating.PlanetAreaObjectGeneration();
        }
        else if (Control.playerTargetName == "button_right")
        {
            Control.SpaceObjectsActivate(false);
            Control.currentPlanetIndex += 1;
            scr_object_generating.PlanetAreaObjectGeneration();

        }
        else if (Control.playerTargetName == "Earth")
        {
            Control.setLandCameraSize(true);
            Control.SpaceObjectsActivate(false); // УБРАТЬ ПОТОМ!!!


            //			Debug.Log ("Подгружаем объекты экрана планеты");
            //			Debug.Log ("Загрузка фона");
            //			Instantiate (bkg_land_white, new Vector3 (0, 0, 0), Quaternion.identity);
            //			Debug.Log ("      Готово");
            //
            //			Debug.Log ("Загрузка кнопок");
            //			foreach (Transform t in buttons) {
            //				Instantiate (t, new Vector3 (t.position.x, t.position.y, t.position.z), Quaternion.identity);
            //				Debug.Log ("      Готово");
            //			}
            planet = new Planet(Control.playerTargetName, "");
            scr_object_generating.InhabitedFriendlyPlanetScreenGeneration(planet);
        }

        else if (Control.playerTargetName == "Aliens_ship" || Control.playerTargetName == "Pirates_ship")
        {
            Control.setLandCameraSize(true);
            Control.SpaceObjectsActivate(false);
            scr_object_generating.BattleScreenGeneration();
        }

        else if (Control.playerTargetName == "Station" || Control.playerTargetName == "Military_base")
        {
            Control.setLandCameraSize(true);
            Control.SpaceObjectsActivate(false);
            scr_object_generating.StationsScreenGeneration(Control.playerTargetName);
        }

        else //if (Control.playerTargetName == "Moon")
        {
            Control.setLandCameraSize(true);
            Control.SpaceObjectsActivate(false); // УБРАТЬ ПОТОМ!!!

            //			Debug.Log ("Подгружаем объекты экрана планеты");
            //			Debug.Log ("Загрузка фона");
            //			Instantiate (bkg_land_white, new Vector3 (0, 0, 0), Quaternion.identity);
            //			Debug.Log ("      Готово");
            //
            //			///// Щас будут костыли. Это уберётся, когда сделаем создание объектов из скрипта
            //
            //			Debug.Log ("Загрузка кнопок");
            //			foreach (Transform t in buttons) {
            //				if (t.name == "btn_ship" || t.name == "btn_menu" || t.name == "btn_explore" || t.name == "btn_takeoff") 
            //				{
            //					Instantiate (t, new Vector3 (t.position.x, t.position.y, t.position.z), Quaternion.identity);
            //					Debug.Log ("      Готово");
            //				}	
            //			}
            planet = new Planet(Control.playerTargetName, "");
            scr_object_generating.UninhabitedPlanetScreenGeneration(planet);
        }
    }
}
