using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyPickUp : MonoBehaviour
{
    public GameObject staticKey;
    public GameObject lockedDoor;
    public GameObject openDoor;
    public GameObject keyPath;
    public GameObject foundKey;
    public GameObject doorTriggerOff;
    public AudioSource keyPickUpSFX;


    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Key")
        {
            staticKey.SetActive(false);
            keyPath.SetActive(false);
            Debug.Log("Key found!");
            doorTriggerOff.SetActive(false);

            lockedDoor.SetActive(false);
            openDoor.SetActive(true);

            keyPickUpSFX.Play();
            foundKey.SetActive(true);
            StartCoroutine(foundKeyCanvas());


        }

    }

    public IEnumerator foundKeyCanvas()
    {
        yield return new WaitForSeconds(10f);
        foundKey.SetActive(false);

    }

}
