using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject nowCard; 
    [SerializeField] private Cardd nowCardd;
    [SerializeField] private string nowDiceData;

    public GameObject NowCard
    {
        get => nowCard;
        set => nowCard = value;
    }

    public Cardd NowCardd
    {
        get => nowCardd;
        set => nowCardd = value;
    }

    public string NowDiceData
    {
        get => nowDiceData;
        set => nowDiceData = value;
    }


    public void RexCheck(){
      if(RegexManager.Instance.IsValidCard(nowCardd.condition, nowDiceData)){
         Debug.Log("Valid");
      }
      else{
         Debug.Log("Invalid");
      }
   }

   void Update()
   {
       if (Input.GetKeyDown(KeyCode.C))
       {
           RexCheck();
       }
   }
}