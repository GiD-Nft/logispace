using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_landing : MonoBehaviour 
{
    public Transform bkg_land_white; // Background
    public List<Transform> buttons; // Кнопки
    
    // Надо подумать, может это как-то можно сделать автоматически, без занесения объектов вручную через интерфейс.

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
		if (Control.playerTargetName == "Earth") {
			Control.SpaceObjectsActivate (false); // УБРАТЬ ПОТОМ!!!


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
			scr_object_generating.InhabitedFriendlyPlanetScreenGeneration(Control.playerTargetName);
		} 
		else if (Control.playerTargetName == "Moon") 
		{
			Control.SpaceObjectsActivate (false); // УБРАТЬ ПОТОМ!!!

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

			scr_object_generating.UninhabitedPlanetScreenGeneration(Control.playerTargetName);
		}
    }
}
