using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DiceController : MonoBehaviourPunCallbacks
{
    private List<GameObject> diceList;
    private List<TextMeshPro> diceTMPList;
    private int diceListCount;
    private float dicePadding = 1.2f;

    [ReadOnly]
    public static int[] pairArray;
    public GameObject dicePrefab;
    public TextMeshProUGUI pairTMPUI;
    public Transform[] spawnPositions;
    // Start is called before the first frame update

    private void Awake()
    {
        diceListCount = 5;

        diceList = new List<GameObject>();
        diceTMPList = new List<TextMeshPro>();
        pairArray = new int[6] { 0, 0, 0, 0, 0, 0 };

        for (int i = 0; i < diceListCount; i++)
        {
            int localPlayerIndex = PhotonNetwork.LocalPlayer.ActorNumber - 1; // 배열은 0부터라서 첫번째 플레이어를 1로하기위해서
            Transform spawnPostition = spawnPositions[localPlayerIndex % spawnPositions.Length];


            Vector3 tragetPos = spawnPostition.position + new Vector3(i * dicePadding, 0f, 0f);
            //GameObject instantiateDice = Instantiate(dicePrefab, tragetPos, this.transform.rotation);
            GameObject instantiateDice = PhotonNetwork.Instantiate(dicePrefab.name, tragetPos, spawnPostition.rotation);
            instantiateDice.transform.SetParent(spawnPostition);
            instantiateDice.transform.name = $"Dice{i}";
            diceList.Add(instantiateDice);
            diceTMPList.Add(diceList[i].transform.Find("DiceTMP").GetComponent<TextMeshPro>());
        }
    }
    void Start()
    {
        AllDiceRoll();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            AllDiceRoll();
        }
        if (Input.GetKeyDown("s"))
        {
            PairDetect();
        }
    }
    public void AllDiceRoll()
    {
        for (int i = 0; i < diceListCount; i++)
        {

            Dice nowDice = diceList[i].GetComponent<Dice>();
            if(nowDice.GetNowState() == Dice.state.normal)
            {
                nowDice.RollDice();
            }
        }
        PairDetect();
    }
    private void PairDetect()
    {
        pairArray = new int[6] { 0, 0, 0, 0, 0, 0 };
        string text = "";
        for (int i = 0;i < diceListCount; i++)
        {
            pairArray[int.Parse(diceTMPList[i].text) -1 ]++;
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
