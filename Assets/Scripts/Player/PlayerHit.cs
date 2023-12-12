using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Breakable"))
        {
            other.GetComponent<Pot>().Smash();
        }
        if(other.CompareTag("Cutable"))
        {
            other.GetComponent<Grass>().Cut();
        }
        if(other.CompareTag("Switchable"))
        {
            other.GetComponent<Switch2>().ActivateSwitch();
        }
        if(other.CompareTag("Switchable2"))
        {
            other.GetComponent<Switch2Collectable>().ActivateSwitch();
        }
    }
}
