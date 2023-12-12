using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    private Animator animator;
    public LootTable thisLoot;
    public SignalSender achieve;
    private static int numberCollectable;
    private static int numberStory;
    public bool isCollecatable;
    public bool isStory;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cut() 
    {
        if(isCollecatable)
        {
            numberCollectable++;
            if(numberCollectable == 5)
            {
                achieve.Raise();
            }
        }
        if(isStory)
        {
            numberStory++;
            if(numberStory == 20)
            {
                achieve.Raise();
            }
        }
        animator.SetBool("Cut", true);
        StartCoroutine(breakCo());
        MakeLoot();
    }

    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }

    private void MakeLoot()
    {
        if(thisLoot != null)
        {
            PowerUp current = thisLoot.LootPowerUp();
            if(current != null)
            {
                Instantiate(current.gameObject,transform.position, Quaternion.identity);
            }
        }
    }
}
