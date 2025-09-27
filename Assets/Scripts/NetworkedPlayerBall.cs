using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;

public class NetworkedPlayerBall : NetworkBehaviour
{
    //Attach to our local CameraFollow
    void Start()
    {
        //CameraFollow.target = transform.Find("CameraTarget").gameObject.transform;
        CameraFollow.target = GameObject.Find("CameraTarget").transform;
    }

    void Update()
    { 
        
    }
}