using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHandler : MonoBehaviour
{
    public static SwitchList combinationInputList = new SwitchList();
    
    public static void DeactivateAllSwitches()
    {
        Switch2[] switches = FindObjectsOfType<Switch2>();
        combinationInputList.ClearList();
        foreach (Switch2 s in switches)
        {
            s.DeactivateSwitch();
        }
        
    }
}