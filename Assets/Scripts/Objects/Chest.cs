using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chest : Interactable
{
    [Header("Contents")]
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue storedOpen;

    [Header("Signals and Dialog")]
    public SignalSender raiseItem;
    public GameObject dialogBox;
    public TMP_Text dialogText;

    [Header("Animation")]
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isOpen = storedOpen.RuntimeValue;
        if(isOpen)
        {
            animator.SetBool("opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && playerInRange)
        {
            if(!isOpen)
            {
                openChest();
            }
            else
            {
                leaveChest();
            }
        }
    }

    public void openChest()
    {
        dialogBox.SetActive(true);
        dialogText.text = contents.itemDescription;
        playerInventory.AddItem(contents);
        storeCollectable();
        playerInventory.currentItem = contents;
        raiseItem.Raise();
        context.Raise();
        isOpen = true;
        animator.SetBool("opened", true);
        storedOpen.RuntimeValue = isOpen;
    }

    public void storeCollectable()
    {
        if(contents.itemName == "emerald")
        {
            playerInventory.foundEmerald = true;
        }
    }

    public void leaveChest()
    {
        dialogBox.SetActive(false);
        raiseItem.Raise();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger && !isOpen) 
        {
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
