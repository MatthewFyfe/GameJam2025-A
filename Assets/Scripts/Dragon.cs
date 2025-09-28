using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public GameObject fireballprefab;
    public GameObject playerTarget;

    public float rotationSpeed = 0.001f;

    float spawnTime;

    public Transform fireball_spawn_1;
    public Transform fireball_spawn_2;
    public Transform fireball_spawn_3;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //lerp rotate to face player (or random facing?)
        if(playerTarget != null)
        {
            Vector3 direction = playerTarget.transform.position - transform.position;
            direction.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        //shoot fireballs
        if(Time.time - spawnTime >= 10f)
        {
            spawnTime = Time.time;
            shootFireballs(fireball_spawn_1);
            shootFireballs(fireball_spawn_2);
            shootFireballs(fireball_spawn_3);
        }
    }

    void shootFireballs(Transform spawnPos)
    {
        GameObject projectile = Instantiate(fireballprefab, spawnPos.position, spawnPos.rotation);
    }
}
