using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Dice : MonoBehaviourPunCallbacks, IPunObservable
{
    /// <summary>
    /// 주사위의 상태
    /// </summary>
    public enum state{
        normal,
        locked
    }
    /// 현 주사위의 상태
    [SerializeField] private state nowState;
    // 주사위의 숫자값
    [SerializeField] private TextMeshPro diceTMP;
    // 주사위의 현 숫자
    private int nowNumber;

    public state GetNowState () { return nowState; }
    public void SetNowState(state _state) { nowState = _state; }



    void Awake()
    {
        nowState = state.normal;
        diceTMP = gameObject.transform.Find("DiceTMP").GetComponent<TextMeshPro>();
    }
    /// <summary>
    /// 주사위를 굴리고 nowNumber, Text 변경
    /// </summary>
    public void RollDice()
    {
        nowNumber = Random.Range(1, 7);
        photonView.RPC("DiceText", RpcTarget.All, nowNumber.ToString());

    }
    /// <summary>
    /// 주사위 텍스트를 text값으로 변경
    /// </summary>
    /// <param name="text"></param>
    [PunRPC]
    public void DiceText(string text)
    {
        diceTMP.text = text;
    }
    /// <summary>
    /// 주사위가 노말이면 잠기게 잠겨있으면 노말로 변경
    /// </summary>
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
    /// <summary>
    /// 주사위의 색깔을 회색으로 변경
    /// </summary>
    private void Lock()
    {
        nowState = state.locked;
        diceTMP.color = Color.gray;
    }
    /// <summary>
    /// 주사위의 색깔을 흰색(원래색)으로 변경
    /// </summary>
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
