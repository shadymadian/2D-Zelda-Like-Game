using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    dungeonkey,
    enemy,
    button
}

public class Door : Interactable
{
    [Header("Door Variables")]
    public DoorType thisDoorType;
    public bool doorOpen = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    
    void Update()
    {
        if(Input.GetButtonDown("Interact"))
        {
            if(playerInRange && thisDoorType == DoorType.key)
            {
                if(playerInventory.keyInInventory == true)
                {
                    openDoor();
                    playerInventory.keyInInventory = false;
                }
            }
            if(playerInRange && thisDoorType == DoorType.dungeonkey)
            {
                if(playerInventory.dungeonKeyInInventory == true)
                {
                    openDoor();
                    playerInventory.dungeonKeyInInventory = false;
                }
            }
        }
    }
    
    public void openDoor()
    {
        doorSprite.enabled = false;
        doorOpen = true;
        physicsCollider.enabled = false;
    }

    public void closeDoor()
    {
        doorSprite.enabled = true;
        doorOpen = false;
        physicsCollider.enabled = true;
    }
}
