using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : LogispaceObject 
{
    public Planet(string name, string spriteName) :base(name, spriteName)
	{
        objectType = "planet";
    }
   
}
