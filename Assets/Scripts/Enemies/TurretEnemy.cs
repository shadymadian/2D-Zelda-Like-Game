using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Log
{
    public GameObject profectile;
    public float fireDelay;
    private float fireDelaySeconds;
    public bool canfire = true;

    private void Update()
    {
        fireDelaySeconds -= Time.deltaTime;
        if(fireDelaySeconds <= 0)
        {
            canfire = true;
            fireDelaySeconds = fireDelay;
        }
    }
    // Start is called before the first frame update
    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                if(canfire == true)
                { 
                Vector3 tmpVector = target.transform.position - transform.position;
                GameObject current = Instantiate(profectile, transform.position, Quaternion.identity);
                current.GetComponent<Projectile>().Launch(tmpVector);
                canfire = false;
                ChangeState(EnemyState.walk);
                animator.SetBool("wakeUp", true);
            }
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            animator.SetBool("wakeUp", false);
        }
    }
}
