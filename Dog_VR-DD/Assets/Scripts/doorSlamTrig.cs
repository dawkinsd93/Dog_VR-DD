using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSlamTrig : MonoBehaviour
{
    public GameObject doorOpen;
    public GameObject doorSlam;
    public GameObject hingeDoor;
    public GameObject BlackScreen;
    public GameObject TorchOBJ;
    public AudioSource mainMusic;
    public AudioSource doorSlamSFX;
    public AudioSource dramaticSFX;
    public float timeDelay = 1f;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            //
        }
        else
        {

            hingeDoor.SetActive(false);
            doorOpen.SetActive(true);

            StartCoroutine(EndScene());

        }
    }

    public IEnumerator EndScene()
    {
        yield return new WaitForSeconds(50f * Time.deltaTime);

        doorOpen.SetActive(false);
        doorSlam.SetActive(true);
        doorSlamSFX.Play();
        dramaticSFX.Play();

        yield return new WaitForSeconds(timeDelay * Time.deltaTime);

        mainMusic.Stop();
        BlackScreen.SetActive(true);
        TorchOBJ.SetActive(false);

    }
}
