using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;

    [SerializeField] GameObject leftPaw, rightPaw;

    Vector3 previousPOSLeft, previousPOSRight, direction;

    Vector3 gravity = new Vector3(0, -9.8f, 0);

    [SerializeField] float doggoSpeed = 4;

    public bool isWalking;

    //sound object: 
    [Header("Sound")]
    public AudioSource carpetWalkClip;


    // Start is called before the first frame update
    void Start()
    {
        //make sure walking sound is paused (because set to PlayOnAwake) 
        carpetWalkClip.Pause();

        SetPreviousPOS();
    }

    void SetPreviousPOS()
    {
        previousPOSLeft = leftPaw.transform.position;
        previousPOSRight = rightPaw.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //calculate velocity of player hand movement
        Vector3 leftPawVelocity = leftPaw.transform.position - previousPOSLeft;
        Vector3 rightPawVelocity = rightPaw.transform.position - previousPOSRight;
        float totalVelocity = +leftPawVelocity.magnitude * 0.8f + rightPawVelocity.magnitude * 0.8f;

        if (totalVelocity >= 0.05f) //If true player has swung their hand
        {
            // Get the direction the player is facing
            direction = Camera.main.transform.forward;
            // move player using character controller
            characterController.Move(doggoSpeed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up));

            //set boolean to true 
            isWalking = true;
            
        }

        else
        {
            isWalking = false; 
        }

        //whilst player is walking, play clip; whilst player is stationary, pause clip 
        if (isWalking)
        {
            //Debug.Log("Doggo is walking"); 
            //carpetWalkClip.UnPause();

            //Spams the sound
            //carpetWalkClip.loop = true;
            //carpetWalkClip.Play();
        } 
        
        else 
        {
            //Debug.Log("Doggo is standing still"); 
            //carpetWalkClip.Pause();
        }



        //Applying gravity
        characterController.Move(gravity * Time.deltaTime);
        SetPreviousPOS();
    }

}
