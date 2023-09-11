using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Dice : MonoBehaviourPunCallbacks, IPunObservable
{
    // Start is called before the first frame update
    public enum state{
        normal,
        locked
    }
    [SerializeField] private state nowState;
    [SerializeField] private TextMeshPro diceTMP;
    private int nowNumber;

    public state GetNowState () { return nowState; }
    public void SetNowState(state _state) { nowState = _state; }



    void Awake()
    {
        nowState = state.normal;
        diceTMP = gameObject.transform.Find("DiceTMP").GetComponent<TextMeshPro>();
    }

    public void RollDice()
    {
        nowNumber = Random.Range(1, 7);
        photonView.RPC("DiceText", RpcTarget.All, nowNumber.ToString());

    }
    [PunRPC]
    public void DiceText(string text)
    {
        diceTMP.text = text;
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
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(nowNumber);
        }
        else
        {
            this.nowNumber = (int)stream.ReceiveNext();
        }
    }
    public void OwnerShiptRequest(int id)
    {
        photonView.TransferOwnership(id);
    }
    public string GetText()
    {
        return diceTMP.text;
    }

}
