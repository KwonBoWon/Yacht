using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using System.IO;
using System;
using System.Text.RegularExpressions;
using TMPro;

[Serializable]
public class onepairCard : Card
{
    private static string F_NAME = "onepairCard";
    [SerializeField]
    private TextMeshPro name_text;
    [SerializeField]
    private TextMeshPro description_text;
    [SerializeField]
    private TextMeshPro point_text;
    void Awake()
    {
        jparse = JSON_Parser.instance;;
        Card_data data = jparse.readJSON(F_NAME);
        this.point = data.point;
        this.description = data.description;
        this.name = data.name;
        this.condition_pattern = data.pattern;
        name_text.text = this.name;
        description_text.text = this.description;
        point_text.text = this.point.ToString();
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
