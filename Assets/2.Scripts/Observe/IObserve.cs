using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserve
{
    void OnNotify(GameObject s);//객체의 변화를 감지하면 수행할 일
}
