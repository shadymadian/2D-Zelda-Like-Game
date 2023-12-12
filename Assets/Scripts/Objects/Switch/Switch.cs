using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool active;
    public BoolValue storedValue;
    public Sprite activeSprite;
    private SpriteRenderer mySprite;
    public Door thisDoor;
    public static int i = 0;

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

    public void ActivateSwitch()
    {
        active = true;
        storedValue.RuntimeValue = active;
        if (i<3)
        {
            i++;
            mySprite.sprite = activeSprite;
        }
        else
        {
            thisDoor.openDoor();
            mySprite.sprite = activeSprite;
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ActivateSwitch();
        }
    }
}
