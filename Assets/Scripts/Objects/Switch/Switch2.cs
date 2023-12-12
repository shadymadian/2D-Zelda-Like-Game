using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Switch2 : MonoBehaviour 
{
    public bool active;
    public int orderNumber;
    public Combination combinationRiddle1;
    public BoolValue storedValue;
    public Sprite activeSprite;
    public Sprite deactiveSprite;
    private SpriteRenderer mySprite;
    public Door thisDoor;
    
    // Start is called before the first frame update
    void Start()
    {
        active = storedValue.RuntimeValue;
        mySprite = GetComponent<SpriteRenderer>();
        if(active)
        {
            ActivateSwitch();
        }
    }

    void Update()
    {

    }

    public void ActivateSwitch()
    {
        if(!active)
        {
            SwitchHandler.combinationInputList.AddToList(orderNumber);
            active = true;
            storedValue.RuntimeValue = active;
            mySprite.sprite = activeSprite;
            /*if(active)
            {
                context.Raise();
            }*/
        }
        CheckCombination();    
    }
    
    public void DeactivateSwitch()
    {
        mySprite.sprite = deactiveSprite;
        active = false;
    }

    public void CheckCombination()
    {
        /*foreach(int x in combinationRiddle1.combinationOrder) {
            Debug.Log(x.ToString());
        }*/
        if(Enumerable.SequenceEqual(SwitchHandler.combinationInputList.GetList(), combinationRiddle1.combinationOrder)) 
        {
            thisDoor.openDoor();
        }
        else if (SwitchHandler.combinationInputList.CountList() == combinationRiddle1.combinationOrder.Count())
        {
            SwitchHandler.DeactivateAllSwitches();
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger) 
        {
            //if(active) 
            //{
                context.Raise();
            //}
            playerInRange = true;
        }
    }*/

    /*private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //if(!active) 
            //{
                context.Raise();
            //}
            playerInRange = false;
        }
    }*/
}
