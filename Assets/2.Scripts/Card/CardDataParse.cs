using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;


public class CardDataParse : MonoBehaviour
{
    [SerializeField] private Deck cardds;
    
    private void Start()
    {
        StartCoroutine(GetDeckData());
    }
    /// <summary>
    /// 서버로부터 덱을 Get요청
    /// </summary>
    /// <returns></returns>
    IEnumerator GetDeckData()
    {
        // Mock 서버 주소
        string url = "https://ad6df666-3620-45cb-b2a9-0eb8afa03edc.mock.pstmn.io"; 

        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();
        
        // TODO 요청에 실패하면 다시 보내도록
        if (request.result == UnityWebRequest.Result.Success)
        {
            string jsonString = request.downloadHandler.text;
            Debug.Log("Received JSON data: " + jsonString);
            cardds = JsonUtility.FromJson<Deck>(jsonString);
            Shuffle(cardds.deck);
        }
        else
        {
            Debug.LogError("Failed to fetch JSON data: " + request.error);
        }
    }
    /// <summary>
    /// 리스트 요소 섞기 (Fisher-Yates)
    /// </summary>
    /// <param name="list"></param>
    /// <typeparam name="T"></typeparam>
    void Shuffle<T>(List<T> list)
    {
        int count = list.Count;
        for (int i = 0; i < count - 1; i++)
        {
            int randomIndex = Random.Range(i, count);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
    
}
