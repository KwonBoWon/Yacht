using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Subject
{
    void addObj(IObserve obj); //옵저버 추가
    void removeObj(); //옵저버 삭제
    void Notify();//옵저버에게 데이터 전달
}
