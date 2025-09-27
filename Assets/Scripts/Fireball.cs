using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject playerTarget;

    public float speed = 30f;

    public Rigidbody rb;

    public Material mod_material;

    float spawnFrame;


    // Start is called before the first frame update
    void Start()
    {
        //fire itself towards player
        fireAtPlayer();
        spawnFrame = Time.frameCount;
    }

    // Update is called once per frame
    void Update()
    {
        //see if it is time to fire again
        if(Time.frameCount % 3000 == 0)
        {
            fireAtPlayer();
        }
        

        //see if it is time to expire
        if(Time.frameCount - spawnFrame > 10000)
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
