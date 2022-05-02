using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCheck : MonoBehaviour
{
    public GameObject noKeyText;
    public GameObject keyPath;
    public GameObject keyObj;
    public GameObject upstairsTrig;
    public Collider doorTrig;
    public AudioSource doorOpeningSFX;
    public AudioSource doorLockedSFX;

    // Update is called once per frame
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Key")
        {
            //Debug.Log("Door Opened!");
            //doorAni.wrapMode = WrapMode.Once;
            //doorAni.Play();
            //doorOpeningSFX.Play();

        }
        else
        {
            Debug.Log("No Key Found");
            noKeyText.SetActive(true);
            keyPath.SetActive(true);
            keyObj.SetActive(true);
            upstairsTrig.SetActive(true);
            doorLockedSFX.Play();


            StartCoroutine(keyTextReset());
        }
    }

    public IEnumerator keyTextReset()
    {
        yield return new WaitForSeconds(10f);
        noKeyText.SetActive(false);

    }
}
