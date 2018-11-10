using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_players_ship : MonoBehaviour 
{

    Rigidbody2D body;
	// Use this for initialization
	void Start () 
    {
        body = GetComponent<Rigidbody2D>();
	}

    public float Speed = 0.05f;

    // Update is called once per frame
    void Update() {

        //если значение выставлено и движение разрешено, то наш объект должен двигаться в нужную сторону
        if (Control.playerNeedToFly && Control.buttonPlay)
            SpaceshipMovement();
	}

    void SpaceshipMovement()
    {
        body.MovePosition(Vector2.MoveTowards(transform.position, Control.playerVectorTarget, Speed * Time.deltaTime));
        //Плавное перемещение до точки. Умножаем на Time.timeScale для того, чтоб было плавнее и картинка не дергалась
        //Теперь проверяем расстояние до цели
        if (Vector2.Distance(transform.position, Control.playerVectorTarget) < 0.01)
        {
            Control.playerNeedToFly = false;//Выключаем, если дошли
            Control.buttonPlay = false; // Снова всё останавливается
            Debug.Log("Горит красный свет. Все стоят (Нажмите Play)");

            // Приземление на планету.
            GameObject.Find("Main Camera").GetComponent<scr_landing>().Landing();
        }
    }
}
