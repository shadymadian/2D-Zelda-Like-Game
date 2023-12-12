using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : Interactable
{
    
    public GameObject dialogBox;
    public TMP_Text textComponent;
    public string[] lines;
    public float textSpeed;
    public int index;
    public bool isTextDisplayed;
    
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
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
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }

    public IEnumerator TypeLine()
    {
        isTextDisplayed = true;
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTextDisplayed = false;
    }

    public virtual void NextLine()
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
        }
    }
}
