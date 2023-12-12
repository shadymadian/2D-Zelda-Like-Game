using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float speed;
    public Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidBody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    public void OnTriggerEnter2D(Collider2D other)
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
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
