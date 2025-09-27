using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;

public class ControlPoint : NetworkBehaviour
{
    float xRot, yRot = 0f;

    public Rigidbody playerBall;

    public float rotationSpeed = 5f;

    public float shootPower = 30f;

    public float angularDrag_default = 2f;

    public LineRenderer line;

    public GameObject playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
            return;

        if (IsOwner && CameraFollow.target == null)
        {
            //CameraFollow.target = transform.Find("CameraTarget").gameObject.transform;
            CameraFollow.target = GameObject.Find("CameraTarget").transform;
        }

        playerController.transform.position = playerBall.position;

        if(Input.GetMouseButton(0))
        {
            xRot += Input.GetAxis("Mouse X") * rotationSpeed;
            yRot += Input.GetAxis("Mouse Y") * rotationSpeed;
            if(yRot < -35f)
            {
                yRot = -35f;
            }
            playerController.transform.rotation = Quaternion.Euler(yRot, xRot, 0f);
            line.gameObject.SetActive(true);
            line.SetPosition(0, playerController.transform.position);
            line.SetPosition(1, playerController.transform.position + playerController.transform.forward * 4f);
        }

        if(Input.GetMouseButtonUp(0))
        {
            playerBall.velocity = playerController.transform.forward * shootPower;
            line.gameObject.SetActive(false);
        }
    }

    //Play SFX if needed, update drag to stop rolling on slopes
    public void HandleCollision(Collision collision)
    {
        //Debug.Log(collision.collider.material);
        var pm = collision.collider.material;

        if (pm.name.Contains("Grass"))
        {
            playerBall.angularDrag = angularDrag_default * 2;
        }
        else if (pm.name.Contains("Stone"))
        {
            playerBall.angularDrag = angularDrag_default;
        }
        else if (pm.name.Contains("Rough"))
        {
            playerBall.angularDrag = angularDrag_default * 200;
        }
    }
}
