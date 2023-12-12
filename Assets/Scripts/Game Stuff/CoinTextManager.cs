using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTextManager : MonoBehaviour
{
    public Inventory playerInventory;
    public TMP_Text coinDisplay;
    
    public void UpdateCoinCount()
    {
        coinDisplay.text = "" + playerInventory.amountOfCoins;
    }
}
