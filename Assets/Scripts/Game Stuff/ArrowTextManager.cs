using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrowTextManager : MonoBehaviour
{
    public Inventory playerInventory;
    public TMP_Text arrowDisplay;
    
    public void UpdateArrowCount()
    {
        arrowDisplay.text = "" + playerInventory.amountOfArrows;
    }
}
