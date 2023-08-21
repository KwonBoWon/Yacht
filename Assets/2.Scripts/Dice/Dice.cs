using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    // Start is called before the first frame update
    public enum state{
        normal,
        locked
    }
    [ReadOnly] private state nowState;
    [ReadOnly] private TextMeshPro diceTMP;
    private int nowNumber;

    public state GetNowState () { return nowState; }
    public void SetNowState(state _state) { nowState = _state; }



    void Start()
    {
        nowState = state.normal;
        diceTMP = gameObject.transform.Find("DiceTMP").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RollDice()
    {
        nowNumber = Random.Range(1, 7);
        diceTMP.text = nowNumber.ToString();
    }
    public void DiceLocker()
    {
        if(nowState == state.normal)
        {
            Lock();
        }
        else if(nowState == state.locked)
        {
            UnLock();
        }
    }
    private void Lock()
    {
        nowState = state.locked;
        diceTMP.color = Color.gray;
    }
    private void UnLock()
    {
        nowState = state.normal;
        diceTMP.color = Color.white;
    }
}
