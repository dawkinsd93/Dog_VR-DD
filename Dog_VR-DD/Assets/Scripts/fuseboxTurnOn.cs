using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuseboxTurnOn : MonoBehaviour
{
    public GameObject fuseboxON;
    public GameObject fuseboxOFF;
    public GameObject lightsON;
    public GameObject doorSlamTrig;
    public AudioSource powerONsfx;

    // Update is called once per frame
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Key")
        {
            //Debug.Log("Fusebox trigger entered");

        }
        else
        {
            Debug.Log("Fusebox turned on!");
            fuseboxOFF.SetActive(false);
            fuseboxON.SetActive(true);
            lightsON.SetActive(true);
            doorSlamTrig.SetActive(true);
            powerONsfx.Play();

        }
    }

}
