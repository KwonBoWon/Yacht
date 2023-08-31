
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
    public Transform[] spawnPositions;
    public GameObject playerPrefab;
    public GameObject ballPrefab;

    public GameObject interativeUI;
    public GameObject informationUI;
    public TextMeshProUGUI turnTMP;
    private int[] playerScores;
    

    private void Start()
    {
        playerScores = new[] { 0, 0 };
        SpawnPlayer();

        if (PhotonNetwork.IsMasterClient)
        {
            SpawnBall();
        }
        turn = 1;
        turnTMP.text = $"Player{turn} turn";
        photonView.RPC("TurnPlayerInterative", RpcTarget.All);
    }

    private void SpawnPlayer()
    {
        var localPlayerIndex = PhotonNetwork.LocalPlayer.ActorNumber - 1; // 배열은 0부터라서 첫번째 플레이어를 1로하기위해서
        var spawnPostition = spawnPositions[localPlayerIndex % spawnPositions.Length];


        PhotonNetwork.Instantiate(playerPrefab.name, spawnPostition.position, spawnPostition.rotation); // 입력으로 들어온 프리펩을 현재 내 세상에서 만들고 접속된 다른 플레이어에서 리모트로 생성

    }

    private void SpawnBall()
    {
        PhotonNetwork.Instantiate(ballPrefab.name, Vector2.zero, Quaternion.identity);
    }

    public override void OnLeftRoom() // 플레이어(자신)가 나갈 때
    {
        SceneManager.LoadScene("YatchLobby");
    }

    public void AddScore(int playerNumber, int score)
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        playerScores[playerNumber - 1] += score;

        photonView.RPC("RPCUpdateScoreText", RpcTarget.All,
            playerScores[0].ToString(), playerScores[1].ToString());

    }
    public void PassTurnButton()
    {
        photonView.RPC("PassTurn", RpcTarget.All);
    }

    [PunRPC]
    private void RPCUpdateScoreText(string player1ScoreText, string player2ScoreText)
    {
        scoreText.text = $"{player1ScoreText} : {player2ScoreText}";
    }
    [PunRPC]
    private void TurnPlayerInterative()
    {
        if(turn == PhotonNetwork.LocalPlayer.ActorNumber)
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
}