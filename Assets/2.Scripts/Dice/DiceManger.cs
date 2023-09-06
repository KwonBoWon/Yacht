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
    public Transform[] spawnPositions;
    public GameObject diceControllerPrefab;
    public List<GameObject> diceController;
    private void Start()
    {
        SpawnPlayer();
    }
    private void SpawnPlayer()
    {
        int localPlayerIndex = PhotonNetwork.LocalPlayer.ActorNumber - 1; 
        Transform spawnPostition = spawnPositions[localPlayerIndex % spawnPositions.Length];

        GameObject tmp =  PhotonNetwork.Instantiate(diceControllerPrefab.name, spawnPostition.position, spawnPostition.rotation);
        tmp.name = $"P{PhotonNetwork.LocalPlayer.ActorNumber}DiceController";
        tmp.transform.SetParent(transform);
        diceController.Add(tmp);
    }

}
