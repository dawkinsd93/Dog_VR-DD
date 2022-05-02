using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniffScript : MonoBehaviour
{
    public AudioClip Sniff;
    public AudioSource Source; 

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Source.PlayOneShot(Sniff, 1f);
        }
    }
}