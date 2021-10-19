using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyValueReader : MonoBehaviour
{
    public string _key, _value;

    public void Read(string key, string value)
    {
        _key = key;
        _value = value;
    }
}
