using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class UIHandler : MonoBehaviour, IObserve
{
    Regex condition;
    int point;
    string diceNum;
    public void OnNotify(GameObject s)
    {
        if (s.TryGetComponent(out DiceController d))
        {
            diceNum = d.getList();
            if (condition != null)
            {
                checkCondition(condition, diceNum, point);
                Debug.Log(diceNum);
            }
        }
        if (s.TryGetComponent(out Card c))
        {
            this.condition =new Regex(@c.getCondition());
            this.point = c.getPoint();
        }
        //throw new System.NotImplementedException()
        
    }
    private bool checkCondition(Regex r, string s,int p)
    {
        Debug.Log(this.condition);
        if (r.IsMatch(s))
        {
            Debug.Log(p);
            return true;
        }
        return false;
    }
}
public class InformationUI
{

}
public class InteractableUI
{

}
