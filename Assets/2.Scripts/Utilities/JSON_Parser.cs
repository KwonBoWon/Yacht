using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
//싱글톤으로 파싱 클래스 작성
[Serializable]
public class JSON_Parser
{
    private TextAsset json_Data;
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

    public Card_data readJSON(string filename) 
    {
        Debug.Log(filename);
        try
        {
            json_Data = Resources.Load<TextAsset>(filename);
        }
        catch
        {
            Debug.Log("파일이 존재하지 않습니다.");
        }
        Card_data tmp = JsonUtility.FromJson<Card_data>(json_Data.text);
        return tmp;
    }
    private void OnDestroy()
    {
        parser = null;
    }
}
[Serializable]
public class Card_data
{
    public int point;
    public string name, description;
}