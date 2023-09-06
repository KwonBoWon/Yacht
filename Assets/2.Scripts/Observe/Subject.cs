using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Subject 
{
    public void addObserver(IObserve o);
    public void removeObserver(IObserve o);
    public void inform();
}
