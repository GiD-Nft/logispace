using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : LogispaceObject {
    public Ship(string name, string spriteName) :base(name, spriteName){
        objectType = "ship";
    }
}
