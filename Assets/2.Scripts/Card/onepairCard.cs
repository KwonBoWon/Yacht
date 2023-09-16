using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using System.IO;
using System;
using TMPro;

[Serializable]
public class onepairCard : Card, Subject
{
    private static string F_NAME = "onepairCard";
    [SerializeField]
    private TextMeshPro name_text;
    [SerializeField]
    private TextMeshPro description_text;
    [SerializeField]
    private TextMeshPro point_text;
    [SerializeField]
    private IObserve o;

    public void addObj(IObserve obj)
    {
        o = obj;
        //throw new NotImplementedException();
    }

    public void Awake()
    {
        jparse = JSON_Parser.instance;;
        Card_data data = jparse.readJSON(F_NAME);
        this.point = data.point;
        this.description = data.description;
        this.name = data.name;
        this.condition = data.condition;
        name_text.text = this.name;
        description_text.text = this.description;
        point_text.text = this.point.ToString();
        addObj(GameObject.Find("Canvas").GetComponent<IObserve>());
        Notify();
    }
    public override int getPoint()
    {
        return this.point;
        //throw new System.NotImplementedException();
    }
    public override string getCondition()
    {
        return this.condition;
    }
    public void Notify()
    {
        o.OnNotify(this.gameObject);
        //throw new NotImplementedException();
    }

    public void removeObj()
    {
        o = null;
        //throw new NotImplementedException();
    }
}
