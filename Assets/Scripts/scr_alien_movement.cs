using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_alien_movement : MonoBehaviour 
{

	private bool needToFly = false; // Когда она true - корабль готовится лететь
	private Vector2 vectorTarget; // Точка, в которую должен полететь корабль
	private string targetName; // Название объекта, к которому летит корабль
	private Rigidbody2D body;
	public float speed = 0.05f;
	private float distanceToPoint = 3f; // ?Подумать? Расстояние, на котором выбирается точка, в которую полетит корабль

	void Start () 
	{
		body = GetComponent<Rigidbody2D>();
	}

	void Update () 
	{
		if (needToFly && Control.buttonPlay) 
		{
			SpaceshipMovement();
		}
		else if (!needToFly)
		{
			// Выбор точки куда лететь.
			float a = body.transform.position.x + Random.Range (-distanceToPoint, distanceToPoint);
			float b = body.transform.position.y + Random.Range (-distanceToPoint, distanceToPoint);
            if (a > Control.borders.x && a < Control.borders.z && b > Control.borders.y && b < Control.borders.w)
            {
                vectorTarget = new Vector2(a, b);
                needToFly = true;
            }
		}
	}

	void SpaceshipMovement()
	{
		body.MovePosition(Vector2.MoveTowards(transform.position, vectorTarget, speed * Time.deltaTime));
		//Плавное перемещение до точки. Умножаем на Time.timeScale для того, чтоб было плавнее и картинка не дергалась
		//Теперь проверяем расстояние до цели
		if (Vector2.Distance(transform.position, vectorTarget) < 0.01)
		{ 
			needToFly = false; //Выключаем, если дошли
		}
	}
}
