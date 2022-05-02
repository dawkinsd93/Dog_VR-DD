using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInteraction : MonoBehaviour
{
    //(this script is attached to test ball, rope, and vase objects that dog can interact with) 

    //ref the mouth's position 
    public Transform MouthPOS;

    //ref the VaseQuest script so we can call a function from it to send a variable 
    public VaseQuest vaseQuest;

    //ref the MetreLevels script so can call NaughtyDog function when smashed a vase 
    public MetreLevels metreLevels;

    //boolean to check if vase has smashed - so only plays once 
    public bool hasSmashed;

    //reference vase objects: 
    public GameObject intactVase;
    public GameObject brokenVase; 

    [Header("Sound")]
    public AudioClip PickUpNoise;
    public AudioClip DropNoise;
    public AudioClip ShatterNoise; 
    public AudioSource Source;
    public GameObject MouthPOStransform;

    public float objectCarryTime = 1f;
    public float pickUpCooldown = 1f;


    public void Start()
    {
        //set boolean to false at start 
        hasSmashed = false; 
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Mouth" + "Key")
        {
            //if object is a vase, just play the shatter noise and break it: 
            if (gameObject.tag == "Vase")
            {
                if (hasSmashed == false)
                {
                    //start coroutine (so can destroy after sound ends) 
                    StartCoroutine(VaseDestroy());

                    //play smashing noise 
                    Source.PlayOneShot(ShatterNoise, 1f);

                    //replace the vase mesh with shattered glass pieces
                    intactVase.SetActive(false);
                    brokenVase.SetActive(true);

                    //send '1' to the function in VaseQuest script:
                    FindObjectOfType<VaseQuest>().vaseSmashed(1);
                    //could alternatively do: 
                    //vaseQuest.GetComponent<VaseQuest>().vaseSmashed(1); 

                    //also send '1' to the function in MetreLevels script: 
                    FindObjectOfType<MetreLevels>().NaughtyDog(1);
                    //could alternatively do: 
                    //metreLevels.GetComponent<MetreLevels>().NaughtyDog(1); 

                    //then set boolean to true so won't happen again 
                    hasSmashed = true;
                }
            }
            //for all other objects, pick up in mouth: 
            else
            {
                GetComponent<SphereCollider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.transform.position = MouthPOS.position;
                this.transform.parent = GameObject.Find("MouthPOS").transform;

                Source.PlayOneShot(PickUpNoise, 1f);

            }
        }


        //if press button, object drops 

    }


    public void OnTriggerExit(Collider collider)
    {
        this.gameObject.transform.SetParent(null);
    }

    // Coroutine below drops the ball and then reactivates the ability to pick-up after a 2 second cooldown period
    public IEnumerator dropItem()
    {
        yield return null;
        MouthPOStransform.SetActive(false);
        GetComponent<SphereCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().AddForce(Vector3.down * 1f);
        this.gameObject.transform.SetParent(null);
        StartCoroutine(enablePickup());

    }

    public IEnumerator enablePickup()
    {
        yield return new WaitForSeconds(pickUpCooldown);
        MouthPOStransform.SetActive(true);
    }

    public IEnumerator VaseDestroy()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false); 
    }


}
