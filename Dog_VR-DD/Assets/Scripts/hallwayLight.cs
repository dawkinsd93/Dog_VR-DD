using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallwayLight : MonoBehaviour
{
    public bool lightisFlickering = false;
    public float lighttimeDelay;

    // Update is called once per frame
    void Update()
    {
        if (lightisFlickering == false)
        {
            StartCoroutine(HallwayFlickeringLight());
        }
    }

    IEnumerator HallwayFlickeringLight()
    {
        lightisFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        lighttimeDelay = Random.Range(0.02f, 0.3f);
        yield return new WaitForSeconds(lighttimeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        lighttimeDelay = Random.Range(2f, 5f);
        yield return new WaitForSeconds(lighttimeDelay);
        lightisFlickering = false;

    }
}
