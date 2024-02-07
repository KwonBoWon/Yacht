using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DiceController : MonoBehaviourPunCallbacks, Subject
{
    [SerializeField] private List<Dice> diceList;
    private float dicePadding = 1.2f;

    [SerializeField] private IObserve o;
    public static int[] pairArray;
    public GameObject dicePrefab;
    [SerializeField] private TextMeshProUGUI pairTMPUI;

    private void Awake()
    {
        addObj(GameObject.Find("Canvas").GetComponent<IObserve>());
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
    /// <summary>
    /// 모든 주사위(잠겨있지 않은) 굴리기
    /// </summary>
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
            Notify();
        }
    }
    public string getList()
    {
        string list = "";
        for (int i = 0; i < diceList.Count; i++)
        {
            list += diceList[i].GetText();
        }
        return list;
    }
    public void addObj(IObserve obj)
    {
        o = obj;
        //throw new System.NotImplementedException();
    }

    public void removeObj()
    {
        o = null;
        //throw new System.NotImplementedException();
    }

    public void Notify()
    {
        o.OnNotify(this.gameObject);
        //throw new System.NotImplementedException();
    }

}
