using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DiceController : MonoBehaviourPunCallbacks
{
    [SerializeField] private List<Dice> diceList;
    private float dicePadding = 1.2f;
    
    public static int[] pairArray;
    public GameObject dicePrefab;
    [SerializeField] private TextMeshProUGUI pairTMPUI;

    void Start()
    {

    }
    public void DiceInit(int id)
    {
        photonView.TransferOwnership(id);
        pairArray = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
        for (int i = 0; i < diceList.Count; i++)
        {
            Debug.Log("**" + i + "-" + id);
            diceList[i].OwnerShiptRequest(id);
        }
    }
    public void AllDiceRoll()
    {
        if (YatchManager.turn == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            for (int i = 0; i < diceList.Count; i++)
            {
                if (diceList[i].GetNowState() == Dice.state.normal)
                {
                    diceList[i].RollDice();
                }
            }
            PairDetect();
        }
    }
    private void PairDetect()
    {
        if(pairTMPUI == null)
        {
           pairTMPUI = GameObject.Find("PairTMP").GetComponent<TextMeshProUGUI>();
        }
        pairArray = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
        string text = "";
        for (int i = 0;i < diceList.Count; i++)
        {
            pairArray[int.Parse(diceList[i].GetText()) -1 ]++;
        }
        for (int i = 0; i < pairArray.Length; i++)
        {
            if (pairArray[i] > 1) 
            {
                text += $"{i + 1} is {pairArray[i]}pair" + "\n";
            }
        }
        pairTMPUI.text = text;
    }
}
