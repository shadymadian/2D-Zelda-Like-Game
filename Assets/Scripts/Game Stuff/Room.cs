using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Enemy[] enemies;
    public Pot[] pots;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            for(int i = 0; i < enemies.Length; i++)
            {
                ChangeActivaton(enemies[i], true);
            }
            for(int i = 0; i < pots.Length; i++)
            {
                ChangeActivaton(pots[i], true);
            }
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivaton(enemies[i], false);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivaton(pots[i], false);
            }
        }
    }

    public void ChangeActivaton(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }
}
