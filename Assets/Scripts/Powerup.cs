using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation
    public Color lowEmission;
    public Color highEmission;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);

        //material.SetColor("_EmissionColor", finalColor);
    }
}
