using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsPU : PowerUp
{
    public Inventory playerInventory;
    private AudioClip arrowPickUp;
    private SpriteRenderer arrowRenderer;

    // Start is called before the first frame update
    void Start()
    {
        powerUpSignal.Raise();
        arrowPickUp = Resources.Load<AudioClip>("coin Award 11");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = arrowPickUp;
        arrowRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            if(playerInventory.amountOfArrows >= 3)
            {
                playerInventory.amountOfArrows = 6;
            }
            else
            {
                playerInventory.amountOfArrows += 3;
            }
            powerUpSignal.Raise();
            //AudioSource audioSource = GetComponent<AudioSource>();
            //audioSource.PlayOneShot(arrowPickUp);
            GetComponent<AudioSource>().PlayOneShot(arrowPickUp);
            //this.gameObject.SetActive(false);
            arrowRenderer.enabled = false;
            StartCoroutine(WaitSoundCo());
        }    
    }

    private IEnumerator WaitSoundCo()
    {
        yield return new WaitForSeconds(1); 
        Destroy(this.gameObject);
    }
}
