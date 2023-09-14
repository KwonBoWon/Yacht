using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Card : MonoBehaviour
{
    [SerializeField]
    protected string cardName;
    protected JSON_Parser jparse;
    [SerializeField]
    protected int point;
    [SerializeField]
    protected string description;
    [SerializeField]
    protected string name;
    protected string condition;
    abstract public string getCondition();
    abstract public int getPoint();
}
