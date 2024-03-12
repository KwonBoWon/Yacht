using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cardd
{
    public string cardName;
    public string description;
    public int point;
    public string condition;
    
}

[System.Serializable]
public class Deck
{
    // ** 이 이름이 json 배열의 이름과 같아야함
    public List<Cardd> deck;

}
