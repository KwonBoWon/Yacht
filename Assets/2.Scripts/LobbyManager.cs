using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks // Pun스크립트 
{
    private readonly string gameVersion = "1"; // 게임 버젼 관리 

    public Text connectionInfoText;
    public Button joinButton;
    
    private void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        joinButton.interactable = false;
        connectionInfoText.text = "Connecting To Master Server...";
    }
    
    public override void OnConnectedToMaster() // 마스터 서버 접속시
    {
        joinButton.interactable = true;
        connectionInfoText.text = "Online : Connected to Master Server";
    }
    
    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = $"Offline : Connection Disalbed {cause.ToString()} - Try reconnecting...";

        PhotonNetwork.ConnectUsingSettings();
    }
    
    public void Connect()
    {
        joinButton.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "Conneting to Random Room...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            connectionInfoText.text = $"Offline : Connection Disalbed - Try reconnecting...";

            PhotonNetwork.ConnectUsingSettings();
        }
    }
    
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "There is no empty room, Creating new Room";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2});
    }
    
    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "Coneected with Room.";
        PhotonNetwork.LoadLevel("Main");
    }
}