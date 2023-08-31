using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
//ΩÃ±€≈Ê¿∏∑Œ ∆ƒΩÃ ≈¨∑°Ω∫ ¿€º∫
public class JSON_Parser
{
    private static string path;
    private static JSON_Parser parser;

    public static JSON_Parser instance
    {
        get
        {
            if(parser == null)
            {
                parser = new JSON_Parser();
            }
            return parser;
        }
    }

    public string readJSON(string filename) 
    {
        string json = File.ReadAllText(path + filename);
        return json;
    }
    private void Awake()
    {
        parser = this;
    }
    private void OnDestroy()
    {
        parser = null;
    }
}
