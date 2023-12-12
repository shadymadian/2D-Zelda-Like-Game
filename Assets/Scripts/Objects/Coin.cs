using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PowerUp
{
    public Inventory playerInventory;
    private AudioClip coinPickUp;
    private SpriteRenderer coinRenderer;

    // Start is called before the first frame update
    void Start()
    {
        powerUpSignal.Raise();
        coinPickUp = Resources.Load<AudioClip>("Coin Award 11");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = coinPickUp;
        coinRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerInventory.amountOfCoins += 1;
            powerUpSignal.Raise();
            //AudioSource audioSource = GetComponent<AudioSource>();
            //audioSource.PlayOneShot(coinPickUp);
            GetComponent<AudioSource>().PlayOneShot(coinPickUp);
            //this.gameObject.SetActive(false);
            coinRenderer.enabled = false;
            StartCoroutine(WaitSoundCo());
        }    
    }

    private IEnumerator WaitSoundCo()
    {
        yield return new WaitForSeconds(1); 
        Destroy(this.gameObject);
    }
}
