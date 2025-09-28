using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves : MonoBehaviour
{
    public AudioSource leafAudio;
    public AudioClip burnClip;

    void OnCollisionEnter(Collision collision)
    {
        var pm = collision.collider.material;

        if (pm.name.Contains("Fireball"))
        {
            leafAudio.clip = burnClip;
            leafAudio.Play();
            Invoke("DestroyLeaves", 1f);
        }
    }

    void DestroyLeaves()
    {
        Destroy(gameObject);
    }
}
