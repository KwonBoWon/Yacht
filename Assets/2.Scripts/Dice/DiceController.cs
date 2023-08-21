using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DiceController : MonoBehaviour
{
    private List<GameObject> diceList;
    private List<TextMeshPro> diceTMPList;
    private int diceListCount;
    [ReadOnly]
    public int[] pairArray;
    public GameObject dicePrefab;
    private float dicePadding = 1.2f;


    // Start is called before the first frame update
    void Start()
    {
        diceListCount = 5;

        diceList = new List<GameObject>();
        diceTMPList = new List<TextMeshPro>();
        pairArray = new int[6] { 0, 0, 0, 0, 0, 0 };

        for (int i = 0; i < diceListCount; i++)
        {
            Vector3 tragetPos = this.transform.position + new Vector3(i * dicePadding, 0f, 0f);
            GameObject instantiateDice = Instantiate(dicePrefab, tragetPos, this.transform.rotation);
            instantiateDice.transform.SetParent(this.transform);
            instantiateDice.transform.name = $"Dice{i}";
            diceList.Add(instantiateDice);
            diceTMPList.Add(diceList[i].transform.Find("DiceTMP").GetComponent<TextMeshPro>());
        }

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
    private void AllDiceRoll()
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
