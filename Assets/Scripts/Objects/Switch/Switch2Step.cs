using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Switch2Step : MonoBehaviour 
{
    public bool active;
    public BoolValue storedValue;
    public Sprite activeSprite;
    public Sprite deactiveSprite;
    private SpriteRenderer mySprite;
    public GameObject thisBlockade;
    
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
            thisBlockade.SetActive(false);
        }   
    }

    public void DeactivateSwitch()
    {
        mySprite.sprite = deactiveSprite;
        active = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger) 
        {
            ActivateSwitch();
            thisBlockade.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            DeactivateSwitch();
            thisBlockade.SetActive(true);
        }
    }
}
