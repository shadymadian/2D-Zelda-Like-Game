using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    [Header("State Machine")]
    public EnemyState currentState;

    [Header("Enemy Stats")]
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public Vector2 home;

    [Header("Death Effects")]
    public GameObject deathEffect;
    public LootTable thisLoot;

    [Header("Death Signal")]
    public SignalSender roomSignal;

    [Header("Audio")]
    public AudioClip hit;
    public new AudioSource audio;
    

    void Awake()
    {
        health = maxHealth.initialValue;
        audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        transform.position = home;
        health = maxHealth.initialValue;
        currentState = EnemyState.idle;
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(WaitSoundCo());
        if(health <= 0)
        {
            DeathEffect();
            MakeLoot();
            if(roomSignal != null)
            {
                roomSignal.Raise();
            }
            this.gameObject.SetActive(false);
        }
    }

    void DeathEffect()
    {
        if(deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.333f);
        }
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

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    public void PlaySound()
    {
        audio.clip = hit;
        audio.Play();
    }
    
    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if(myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    private IEnumerator WaitSoundCo()
    {
        yield return new WaitForSeconds(0.1333f); 
        PlaySound();
    }

    
}
