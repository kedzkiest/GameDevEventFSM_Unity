using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SingletonMessage
{
    public static SingletonMessage instance;

    private List<string> message_vector = new List<string>();

    private SingletonMessage() { }

    public static SingletonMessage Instance()
    {
        return instance;
    }

    public void AddVal(string val)
    {
        message_vector.Add(val);
    }

    public string GetVal()
    {
        return message_vector.ElementAt(0);
    }

    public void DelFirstVal()
    {
        message_vector.RemoveAt(0);
    }

    public bool CheckEmpty()
    {
        return message_vector.Count == 0;
    }
}
