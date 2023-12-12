using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Switch2Collectable : MonoBehaviour 
{
    public bool active;
    public BoolValue storedValue;
    public Sprite activeSprite;
    public Sprite deactiveSprite;
    private SpriteRenderer mySprite;
    public GameObject thisChest;
    
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
            active = true;
            storedValue.RuntimeValue = active;
            mySprite.sprite = activeSprite;
            thisChest.SetActive(true);
        }   
    }
}
