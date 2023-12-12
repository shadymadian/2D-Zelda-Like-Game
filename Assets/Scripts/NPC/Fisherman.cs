using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisherman : StationaryNPC
{
    public SignalSender deactivation;
    public override void NextLine()
    {
        if(index < lines.Length - 1)
        {
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            if(index != lines.Length - 1)
            {   
                index++;
            }
        }
        else
        {
            dialogBox.SetActive(false);
            index = 0;
            deactivation.Raise();
            //this.gameObject.SetActive(false);
        }
    }
}
