using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchPickUp : MonoBehaviour
{
    public GameObject staticTorch;
    public GameObject mouthTorchObj;
    public GameObject hallwayLight;
    public GameObject lightsOutCanvas;
    public AudioSource powerDownSFX;
    public AudioSource ballStairsSFX;
    public float ballDelay = 1f;
    public GameObject ballDownStairObj;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Key")
        {
            staticTorch.SetActive(false);

            StartCoroutine(mouthTorch());
        }
    }

    public IEnumerator mouthTorch()
    {
        yield return new WaitForSeconds(0);
        lightsOutCanvas.SetActive(true);
        mouthTorchObj.SetActive(true);
        hallwayLight.SetActive(false);
        powerDownSFX.Play();
        StartCoroutine(ballStairs());
    }

    public IEnumerator ballStairs()
    {
        yield return new WaitForSeconds(ballDelay);
        ballDownStairObj.SetActive(true);
        ballStairsSFX.Play();

        yield return new WaitForSeconds(90f * Time.deltaTime);
        lightsOutCanvas.SetActive(false);


    }

}
