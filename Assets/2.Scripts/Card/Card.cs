using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

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
    protected Regex condition_pattern;
    abstract public void checkCondition();
    abstract public void effect();
}
