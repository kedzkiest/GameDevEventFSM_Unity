using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SingletonMessage : MonoBehaviour
{
    public static SingletonMessage instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

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
        if (message_vector.Count > 0)
        {
            return message_vector.ElementAt(0);
        }

        return "null";
    }

    public void DelFirstVal()
    {
        if(message_vector.Count > 0)
        {
            message_vector.RemoveAt(0);
        }

        return;
    }

    public bool CheckEmpty()
    {
        return message_vector.Count == 0;
    }
}
