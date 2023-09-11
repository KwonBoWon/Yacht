
using Photon.Pun;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YatchManager : MonoBehaviourPunCallbacks // Pun이벤트 감지가능
{
    public static YatchManager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<YatchManager>();

            return instance;
        }
    }

    private static YatchManager instance;
    public static int turn = 1;
    public Text scoreText;
    public GameObject interativeUI;
    public GameObject informationUI;
    public TextMeshProUGUI turnTMP;
    public TextMeshProUGUI infoTMP;
    public GameObject startButton;
    public void StartGameButton()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            photonView.RPC("StartGame", RpcTarget.All);
            DiceManger.Instance.RPCDiceControllerInit();
        }
    }

    public override void OnJoinedRoom()
    {
        infoTMP.text = "Player: " + PhotonNetwork.CurrentRoom.PlayerCount;
    }
    private void AllPlayersJoined()
    {
        Debug.Log("All players have joined!");

    }

    public override void OnLeftRoom() // 플레이어(자신)가 나갈 때
    {
        SceneManager.LoadScene("YatchLobby");
    }


    public void PassTurnButton()
    {
        photonView.RPC("PassTurn", RpcTarget.All);
        photonView.RPC("TurnPlayerInterative", RpcTarget.All);
    }

    [PunRPC]
    private void TurnPlayerInterative()
    {
        if (turn == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            interativeUI.SetActive(true);
            return;
        }
        else
        {
            interativeUI.SetActive(false);
            return;
        }
    }
    [PunRPC]
    private void PassTurn()
    {
        _ = (turn == 2) ? turn = 1 : turn = 2;
        turnTMP.text = $"Player{turn} turn";
    }
    [PunRPC]
    public void StartGame()
    {

        turn = 1;
        turnTMP.text = $"Player{turn} turn";
        photonView.RPC("TurnPlayerInterative", RpcTarget.All);
        AllPlayersJoined();
        startButton.SetActive(false);

    }
}