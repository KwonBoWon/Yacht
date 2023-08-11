using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    private List<GameObject> diceList;
    private List<TextMeshPro> diceTMPList;
    private int diceListCount;
    [ReadOnly]
    public int[] pairArray;


    // Start is called before the first frame update
    void Start()
    {
        diceListCount = 5;

        diceList = new List<GameObject>();
        diceTMPList = new List<TextMeshPro>();
        pairArray = new int[6] { 0, 0, 0, 0, 0, 0 };

        for (int i = 0; i < diceListCount; i++)
        {
            diceList.Add(transform.Find($"Cube ({i})").gameObject);
            diceTMPList.Add(diceList[i].transform.Find("TMP").GetComponent<TextMeshPro>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0;i < diceListCount;i++)
            {
                diceList[i].GetComponent<Roll>().RollDice();
            }
            PairDetect();
        }
        if (Input.GetMouseButtonDown(1))
        {
            PairDetect();
        }
    }

    private void PairDetect()
    {
        pairArray = new int[6] { 0, 0, 0, 0, 0, 0 };
        for (int i = 0;i < diceListCount; i++)
        {
            pairArray[int.Parse(diceTMPList[i].text) -1 ]++;
        }
        for (int i = 0; i < pairArray.Length; i++)
        {
            if (pairArray[i] > 1) 
            {
                Debug.Log($"{i + 1}는 {pairArray[i]}개 있습니다.");
            }
        }
    }
}
