using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OLDInputCapture : MonoBehaviour
{
    [Header("Select Action")]
    [SerializeField] InputActionReference rightControllerGrip, leftControllerGrip;

    [Header("Sound")]
    public bool barkReady;
    public bool sniffReady;
    public AudioClip Bork;
    public AudioClip Sniff;
    public AudioSource Source;

    // Start is called before the first frame update
    private void Awake()
    {
        rightControllerGrip.action.performed += onRightGripPressed;
        leftControllerGrip.action.performed += onLeftGripPressed;
    }

    public void Start()
    {
        barkReady = true;
        sniffReady = true;
    }

    void onRightGripPressed(InputAction.CallbackContext obj)
    {
        //Debug.Log("Right grip pressed"); 

        if (barkReady)
        {
            Source.PlayOneShot(Bork, 1f);
            StartCoroutine(barkCoolDown());
        }

    }

    IEnumerator barkCoolDown()
    {
        barkReady = false;
        //Debug.Log("can't bark"); 

        yield return new WaitForSeconds(2);

        barkReady = true;
        //Debug.Log("ready to bark"); 
    }


    void onLeftGripPressed(InputAction.CallbackContext obj)
    {
        //Debug.Log("Left grip pressed"); 

        if (sniffReady)
        {
            Source.PlayOneShot(Sniff, 1f);
            StartCoroutine(sniffCoolDown());
        }

    }

    IEnumerator sniffCoolDown()
    {
        sniffReady = false;
        Debug.Log("can't sniff");

        yield return new WaitForSeconds(5);

        sniffReady = true;
        Debug.Log("ready to sniff");
    }
}

