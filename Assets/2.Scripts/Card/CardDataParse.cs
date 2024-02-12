using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CardDataParse : MonoBehaviour
{
    public TextAsset loadedJson;
    [SerializeField] private Deck cardds;
    
    private void Start()
    {
        
        
        
        loadedJson = Resources.Load<TextAsset>("CardData");
        Debug.Log(loadedJson.ToString());
        cardds = JsonUtility.FromJson<Deck>(loadedJson.ToString());
        Debug.Log(cardds.ToString());
        
        foreach (Cardd card in cardds.deck)
        {
            Debug.Log("Card Name: " + card.cardName);
            Debug.Log("Description: " + card.description);
            Debug.Log("Point: " + card.point);
            Debug.Log("Condition: " + card.condition);
        }

        
        //carddList = JsonUtility.FromJson<CarddList>(loadedJson.ToString());

        //Debug.Log($"{carddList.CarddList1[0].CardName}");
    }
}
