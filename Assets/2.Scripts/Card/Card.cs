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
    abstract public void checkCondition();
    abstract public void effect();
}
