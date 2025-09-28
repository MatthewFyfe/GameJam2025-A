using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zomball : MonoBehaviour
{
    public GameObject playerTarget;

    public GameObject parentTombstone;

    public float speed = 10f;

    public Rigidbody rb;

    public Material mod_material;

    float spawnFrame;

    // Start is called before the first frame update
    void Start()
    {
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
        //Debug.Log(parentTombstone.transform.rotation.x);
        if(parentTombstone.transform.rotation.x > 0.3 || parentTombstone.transform.rotation.x < -0.3)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }

        // //flicker cool materials animation
        // if(Time.frameCount % 30 == 0)
        // {
        //     mod_material.color = Color.yellow;
        // }

        // if(Time.frameCount % 60 == 0)
        // {
        //     mod_material.color = Color.red;
        // }
    }

    void fireAtPlayer()
    {
        Vector3 direction = (playerTarget.transform.position - this.transform.position).normalized;
        //remoev some hight to the shot
        direction.y -= 0.1f;
        rb.velocity = direction * speed;
    }
}
