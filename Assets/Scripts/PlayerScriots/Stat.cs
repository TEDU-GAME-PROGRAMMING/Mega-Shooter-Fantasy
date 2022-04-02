using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat 
{
    [SerializeField]
    private int StartingValue;
    
    public int getValue()
    {
        return StartingValue;
    }
    public void setValue()
    {
        StartingValue++;
    }
}
