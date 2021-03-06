using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(GameObject.FindWithTag("Trail"));
        }
    }
}
