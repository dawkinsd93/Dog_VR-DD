using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bathroomDoorTrig : MonoBehaviour
{
    public GameObject doorClosed;
    public GameObject doorOpen;
    public GameObject bathTrig;
    public GameObject lostScentCanvas;
    public GameObject turnOffScent;
    public AudioSource doorCreakSFX;
    public AudioSource dogGrowlSFX;
    public AudioSource creakyFloorsSFX;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            //
        }
        else
        {

            doorClosed.SetActive(false);
            doorOpen.SetActive(true);
            lostScentCanvas.SetActive(true);
            turnOffScent.SetActive(false);
            doorCreakSFX.Play();
            creakyFloorsSFX.Stop();



            StartCoroutine(DogGrowl());

        }
    }

    public IEnumerator DogGrowl()
    {
        yield return new WaitForSeconds(5f);
        dogGrowlSFX.Play();
        lostScentCanvas.SetActive(false);

        yield return new WaitForSeconds(2f);
        bathTrig.SetActive(false);

    }

}
