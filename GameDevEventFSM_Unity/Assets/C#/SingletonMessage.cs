using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SingletonMessage
{
    public static SingletonMessage instance;

    private string message_vector;

    private SingletonMessage() { }

    public void AddVal(string val)
    {

    }

    public string GetVal()
    {
        return "";
    }

    public void DelFirstVal()
    {

    }

    public bool CheckEmpty()
    {
        return true;
    }

    public static SingletonMessage Instance()
    {
        return instance;
    }
}
