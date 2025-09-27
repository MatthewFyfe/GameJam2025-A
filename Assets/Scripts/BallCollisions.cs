using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    public ControlPointSP cp_ref;

    void OnCollisionEnter(Collision collision)
    {
        cp_ref.HandleCollision(collision);
    }
}
