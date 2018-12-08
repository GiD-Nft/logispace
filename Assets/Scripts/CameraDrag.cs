using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour 
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    Camera cam;// = Camera.main;

	// Use this for initialization
	void Start () 
    {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Control.isCameraDraggable)
            MoveCamera();
	}

    void MoveCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

        //if (Mathf.Abs(move.x) < Control.borders.z && Mathf.Abs(move.y) < Control.borders.w)
        //if (CheckBorders())
        transform.Translate(move, Space.World);

    }

    bool CheckBorders()
    {
        if (Mathf.Abs(transform.position.x) + Camera.main.pixelWidth / 2 < Control.borders.z &&
            Mathf.Abs(transform.position.y) + Camera.main.pixelHeight / 2 < Control.borders.w)
            return true;
        return false;
    }
}
