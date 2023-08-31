using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class onepairCard : Card
{
    private string filename = "onepairCard.json";
    public void Awake()
    {
        jparse = JSON_Parser.instance;
        string tmp = this.jparse.readJSON(filename);
        Debug.Log(tmp);
    }
    
    
    public override void checkCondition()
    {
        throw new System.NotImplementedException();
    }
    public override void effect()
    {
        throw new System.NotImplementedException();
    }
}
