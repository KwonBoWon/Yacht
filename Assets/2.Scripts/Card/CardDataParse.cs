using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class CardDataParse : MonoBehaviour
{
    [SerializeField] private Deck cardds;
    
    private void Start()
    {
        StartCoroutine(GetDeckData());
    }
    IEnumerator GetDeckData()
    {
        // Mock 서버 주소
        string url = "https://ad6df666-3620-45cb-b2a9-0eb8afa03edc.mock.pstmn.io"; 

        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string jsonString = request.downloadHandler.text;
            cardds = JsonUtility.FromJson<Deck>(jsonString);
            Debug.Log("Received JSON data: " + jsonString);
        }
        else
        {
            Debug.LogError("Failed to fetch JSON data: " + request.error);
        }
    }
    
}
