using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : LogispaceObject {
    public Button(string name, string spriteName) :base(name, spriteName){
        objectType = "Button";
    }
}
