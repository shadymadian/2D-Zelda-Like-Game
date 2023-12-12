using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchList
{
    private List<int> combinationInput = new List<int>();

    public void AddToList(int orderNumber)
    {
        combinationInput.Add(orderNumber);
        /*foreach(int x in combinationInput) {
            Debug.Log(x.ToString());
        }*/
    }

    public void ClearList()
    {
        combinationInput.Clear();
    }

    public List<int> GetList()
    {
        return combinationInput;
    }

    public int CountList()
    {
        return combinationInput.Count;
    }
}