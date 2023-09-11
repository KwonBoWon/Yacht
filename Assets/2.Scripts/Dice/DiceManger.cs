using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManger : MonoBehaviourPunCallbacks
{
    private static DiceManger instance;
    public static DiceManger Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<DiceManger>();
            return instance;
        }
    }
    public List<DiceController> diceControllerList;


    public void DiceRoll()
    {
        diceControllerList[PhotonNetwork.LocalPlayer.ActorNumber - 1].AllDiceRoll();
    }
    public void RPCDiceControllerInit()
    {
        photonView.RPC("DiceControllerInit", RpcTarget.All);
    }
    [PunRPC]
    public void DiceControllerInit()
    {
        diceControllerList[0].DiceInit(1); diceControllerList[1].DiceInit(2);
    }
}
