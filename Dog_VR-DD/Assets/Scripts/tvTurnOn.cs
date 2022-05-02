using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tvTurnOn : MonoBehaviour
{
    public GameObject TVTrigger;
    public Collider TVBoxTrig;
    public Collider playerTrig;
    public void OnTriggerEnter(Collider TVBoxTrig)
    {
        if (playerTrig.gameObject.tag == "Mouth")
        {
            TVTrigger.SetActive(true);
        }
    }

}
