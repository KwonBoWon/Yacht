using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class Roll : MonoBehaviour
{
    private TextMeshPro numberTMP;
    private int nowNumber;
    // Start is called before the first frame update
    void Start()
    {
        numberTMP = transform.Find("TMP").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RollDice()
    {
        nowNumber = Random.Range(1, 7);
        numberTMP.text = nowNumber.ToString();
    }
}
