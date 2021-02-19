using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifier
{
    private List<IObserver> _observerList;

    public Notifier()
    {
        _observerList = new List<IObserver>();
    }
    ~Notifier()
    {
        _observerList.Clear();
    }
    public void AddObserver(IObserver target)
    {
        _observerList.Add(target);
    }
    public void DeleteObserver(IObserver target)
    {
        _observerList.Remove(target);
    }
    public void Notify(int inputEvent)
    {
        _observerList[_observerList.Count - 1].OnNotify(inputEvent);
    }
}
