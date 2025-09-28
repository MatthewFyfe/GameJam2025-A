using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject playerTarget;

    public float speed = 30f;

    public Rigidbody rb;

    public Material mod_material;

    float spawnTime;


    // Start is called before the first frame update
    void Start()
    {
        //fire itself forwards
        rb.velocity = transform.forward * speed;
        
        spawnTime = Time.time;

        if(playerTarget == null)
        {
            playerTarget = GameObject.FindWithTag("Player");
        }

        InvokeRepeating("fireAtPlayer", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //see if it is time to fire again
        // if(Time.frameCount % 3000 == 0)
        // {
        //     fireAtPlayer();
        // }
        

        //see if it is time to expire (like 15 seconds?)
        if(Time.time - spawnTime > 15f)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }

        //flicker cool materials animation
        if(Time.frameCount % 30 == 0)
        {
            mod_material.color = Color.yellow;
        }

        if(Time.frameCount % 60 == 0)
        {
            mod_material.color = Color.red;
        }
    }

    void fireAtPlayer()
    {
        Vector3 direction = (playerTarget.transform.position - this.transform.position).normalized;
        //add some hight to the shot
        direction.y += 0.1f;
        rb.velocity = direction * speed;
    }
}
