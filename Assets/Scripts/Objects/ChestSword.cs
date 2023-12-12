using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSword : Sign
{
    public Inventory playerInventory;

    public override void Update()
    {
        if(Input.GetButtonDown("Interact") && playerInRange && !isTextDisplayed)
        {
            dialogBox.SetActive(true);
            Debug.Log(textComponent.text);
            Debug.Log(lines[index]);
            if(textComponent.text == lines[index])
            {
                textComponent.text = string.Empty;
                NextLine();                
            }
            else
            {
                NextLine();
            }
            CheckAnswer();        
        }
    }

    void CheckAnswer()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Get the string input from the user
            string userInput = Input.inputString;

            // Check if the input is a single character and not the number "6"
            if (!string.IsNullOrEmpty(userInput) && userInput.Length == 1 && userInput == "6")
            {
                // Do something with the input, e.g., print it
                Debug.Log("User Input: " + userInput);
            }
        }
    }
    
}
