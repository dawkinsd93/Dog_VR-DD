using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhineAtDoor : MonoBehaviour
{
    public AudioClip Cry;
    //public AudioClip Bark; 
    public GameObject WhineCanvas; 
    public AudioSource Source;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            WhineCanvas.SetActive(true); 
            Source.PlayOneShot(Cry, 1f); 
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            WhineCanvas.SetActive(false);
        }
    }
}
