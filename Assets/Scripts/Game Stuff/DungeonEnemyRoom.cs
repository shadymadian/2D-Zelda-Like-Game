using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom
{

    public Door[] Doors;

    private void Start()
    {
        
    }

    public void Checkenemies()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject.activeInHierarchy && i < enemies.Length -1)
            {
                return;
            }
        }
        openDoors();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivaton(enemies[i], true);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivaton(pots[i], true);
            }
            closeDoors();
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
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

    public void closeDoors()
    {
        for(int i = 0; i < Doors.Length; i++)
        {
            Doors[i].closeDoor();
        }
    }

    public void openDoors()
    {
        for (int i = 0; i < Doors.Length; i++)
        {
            Doors[i].openDoor();
        }
    }
}
