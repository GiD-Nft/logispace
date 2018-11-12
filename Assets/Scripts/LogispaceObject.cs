using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogispaceObject {
    public string objectType = "";
    private string name;
    private string spriteName;
    public LogispaceObject(string name, string spriteName)
    {
        this.name = name;
        this.spriteName = spriteName;
    }
    public string Name {
        get {
            return name;
        }
        set {
            name = value;
        }
    }
    public string SpriteName {
        get {
            return spriteName;
        }
        set {
            spriteName = value;
        }
    }
}
