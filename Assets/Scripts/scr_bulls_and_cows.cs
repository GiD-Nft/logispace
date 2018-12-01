using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bulls_and_cows : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(350, 170, 120, 80), "Выйти"))
        {
            Control.SpaceObjectsActivate(true);
            Destroy(GameObject.Find("bullsAndCowsObj"));
        }

        GUI.TextArea(new Rect(300, 25, 200, 100), "Бой");
    }
}
