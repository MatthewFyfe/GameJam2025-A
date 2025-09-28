using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using FishNet.Object;
using TMPro;

public class ControlPointSP : MonoBehaviour
{
    public static int playerHP = 10;
    public static int dragonHP = 3;

    float xRot, yRot = 0f;

    public Rigidbody playerBall;

    public float rotationSpeed = 5f;

    public float shootPower = 30f;

    public float angularDrag_default = 2f;

    public LineRenderer line;

    public GameObject playerController;
    public GameObject respawnPoint;
    public GameObject diedCanvas;

    public AudioSource mainCameraAudio;
    public AudioClip fadingAudio;
    public AudioClip diedClip;
    public AudioClip golfClip;
    public AudioClip oobClip;
    public AudioClip zombieClip;
    public AudioClip burnClip;
    public AudioClip damageDragonClip;
    public AudioClip dragonDieClip;
    public AudioClip dragonBattleClip;
    public AudioClip leavesClip;
    public AudioClip stoneClip;

    bool aliveFlag = true;

    bool canShoot = true;
    bool grounded = true;

    public bool groundedMode = false;
    public float groundedThreshold = 1.0f;
    public LayerMask groundLayer;

    public bool velocityMode = false;
    public float velocityThreshold = 1.5f;

    public TMP_Text groundedTXT;
    public TMP_Text velocityTXT;
    public TMP_Text victoryTXT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //are we dead?
        if(playerHP <= 0 && aliveFlag)
        {
            aliveFlag = false;
            //Debug.Log("YOU DIED");
            mainCameraAudio.clip = diedClip;
            mainCameraAudio.Play();

            diedCanvas.SetActive(true);

        }

        //are we out of bounds?
        if(playerBall.transform.position.y < -50)
        {
            mainCameraAudio.clip = oobClip;
            mainCameraAudio.Play();

            playerBall.transform.position = respawnPoint.transform.position;
            playerBall.velocity = Vector3.zero;
            playerHP -= 1;
        }

        //are we grounded (if we care)
        if(groundedMode)
        {
            if(IsGrounded())
            {
                //Debug.Log("grounded");
                grounded = true;
                groundedTXT.text = "OnGround: yes";
                groundedTXT.color = Color.white;
            }
            else
            {
                grounded = false;
                groundedTXT.text = "OnGround: no";
                groundedTXT.color = Color.red;
            }
        }
        else
        {

        }

        //are we fast (if we care)
        if(velocityMode)
        {
            if(IsVelocitySlow())
            {
                canShoot = true;
                velocityTXT.text = "Velocity: just right";
                velocityTXT.color = Color.white;
            }
            else
            {
                canShoot = false;
                velocityTXT.text = "Velocity: too fast";
                velocityTXT.color = Color.red;
            }
        }
        else
        {

        }

        // if (!IsOwner)
        //     return;

        // if (IsOwner && CameraFollow.target == null)
        // {
        if(CameraFollow.target == null)
        {
            CameraFollow.target = GameObject.Find("CameraTarget").transform;
        }
        // }

        playerController.transform.position = playerBall.position;

        //if(Input.GetMouseButton(0) && canShoot && grounded)
        if(true)
        {
            xRot += Input.GetAxis("Mouse X") * rotationSpeed;
            yRot += Input.GetAxis("Mouse Y") * rotationSpeed;
            if(yRot < -45f)
            {
                yRot = -45f;
            }
            if(yRot > 45f)
            {
                yRot = 45f;
            }
            playerController.transform.rotation = Quaternion.Euler(yRot, xRot, 0f);
            line.gameObject.SetActive(true);
            line.SetPosition(0, playerController.transform.position);
            line.SetPosition(1, playerController.transform.position + playerController.transform.forward * 4f);
        }

        if(Input.GetMouseButtonUp(0) && canShoot && grounded)
        {
            playerBall.velocity = playerController.transform.forward * shootPower;
            line.gameObject.SetActive(false);

            //golf sfx
            mainCameraAudio.clip = golfClip;
            mainCameraAudio.Play();

            canShoot = false;

        }
    }

    //Play SFX if needed, update drag to stop rolling on slopes
    public void HandleCollision(Collision collision)
    {
        canShoot = true;

        Debug.Log(collision.collider.material);
        var pm = collision.collider.material;

        if (pm.name.Contains("Grass"))
        {
            playerBall.angularDrag = angularDrag_default * 2;
        }
        else if (pm.name.Contains("Stone"))
        {
            playerBall.angularDrag = angularDrag_default;
            mainCameraAudio.clip = stoneClip;
            mainCameraAudio.Play();
        }
        else if (pm.name.Contains("Rough"))
        {
            playerBall.angularDrag = angularDrag_default * 200;
        }
        else if (pm.name.Contains("Zomball"))
        {
            //take damage from fireball/zomball
            playerHP -= 1;
            mainCameraAudio.clip = zombieClip;
            mainCameraAudio.Play();
        }
        else if (pm.name.Contains("Fireball"))
        {
            //take damage from fireball/zomball
            playerHP -= 1;
            mainCameraAudio.clip = burnClip;
            mainCameraAudio.Play();
        }
        else if (pm.name.Contains("Weakpoint"))
        {
            //damage dragon
            Destroy(collision.collider.gameObject);
            dragonHP -= 1;
            mainCameraAudio.clip = damageDragonClip;
            mainCameraAudio.Play();
        }
        else if (pm.name.Contains("Leaves"))
        {
            mainCameraAudio.clip = leavesClip;
            mainCameraAudio.Play();
        }
        else if (pm.name.Contains("Wood"))
        {
            mainCameraAudio.clip = stoneClip;
            mainCameraAudio.Play();
        }

        //*****

         //did we win?
        if(dragonHP <= 0 && aliveFlag)
        {
            victoryTXT.text = "VICTORY ACHIEVED";

            aliveFlag = false;
            //Debug.Log("YOU WIN");
            mainCameraAudio.clip = dragonDieClip;
            mainCameraAudio.Play();

            diedCanvas.SetActive(true);
        }
    }

    public bool IsGrounded()
    {
        //Debug.DrawRay(transform.position, Vector3.down * 10, Color.red);
        return Physics.Raycast(playerBall.transform.position, Vector3.down, groundedThreshold, groundLayer);
    }

    public bool IsVelocitySlow()
    {
        //Debug.Log($"slow: {playerBall.velocity} : {playerBall.velocity.magnitude}");
        return playerBall.velocity.magnitude < velocityThreshold;
    }

    
}
