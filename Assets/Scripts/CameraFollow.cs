using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, speed * Time.deltaTime);
    }
}
