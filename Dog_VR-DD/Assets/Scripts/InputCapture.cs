using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputCapture : MonoBehaviour
{
    [Header("Select Action")]
    [SerializeField] InputActionReference rightControllerActionGrip;
    [SerializeField] InputActionReference leftControllerActionGrip;

    [Header("Activate Action")]
    [SerializeField] InputActionReference rightControllerActionTrigger;
    [SerializeField] InputActionReference leftControllerActionTrigger;

    //[Header("Primary Button Action")]
    //[SerializeField] InputActionReference rightPrimaryButtonAction;
    //[SerializeField] InputActionReference leftPrimaryButtonAction;

    //[Header("Secondary Button Action")]
    //[SerializeField] InputActionReference rightSecondaryButtonAction;
    //[SerializeField] InputActionReference leftSecondaryButtonAction;

    //[Header("Turn (JoyStick) Action")]
    //[SerializeField] InputActionReference rightTurnAction;
    //[SerializeField] InputActionReference leftTurnAction;

    //[Header("Primary 2D Axis Click Action (Joystick)")]
    //[SerializeField] InputActionReference right2DAxisButton;
    //[SerializeField] InputActionReference left2DAxisButton;

    //[Header("Primary 2D Axis Touch Action (Joystick)")]
    //[SerializeField] InputActionReference right2DAxisTouch;
    //[SerializeField] InputActionReference left2DAxisTouch;

    //[Header("My Actions")]
    //[SerializeField] XRLocomotionManager xRLocomotionManager;
    //[SerializeField] XRInteractionManager xRInteractionManager;


    [Header("Sound")]
    public bool barkReady;
    public bool sniffReady;
    public GameObject MouthPOS;
    public GameObject toyObjectOne;
    public GameObject toyObjectTwo;
    public GameObject toyObjectThree;
    public float pickUpCooldown = 1f;
    ObjectInteraction OI;
    public AudioClip Bork;
    public AudioClip Sniff;
    public AudioSource Source;


    private void Awake()
    {
        rightControllerActionGrip.action.performed += onRightGripPressed;
        leftControllerActionGrip.action.performed += onLeftGripPressed;

        rightControllerActionTrigger.action.performed += onRightTriggerPressed;
        leftControllerActionTrigger.action.performed += onLeftTriggerPressed;

        //rightPrimaryButtonAction.action.performed += onRightControllerPrimaryButtonPressed;
        //leftPrimaryButtonAction.action.performed += onLeftControllerPrimaryButtonPressed;

        //rightSecondaryButtonAction.action.performed += onRightControllerSecondaryButtonPressed;
        //leftSecondaryButtonAction.action.performed += onLeftControllerSecondaryButtonPressed;

        //rightTurnAction.action.performed += onRightJoystickTurn;
        //leftTurnAction.action.performed += onLeftJoystickTurn;

        //right2DAxisButton.action.performed += onRight2DAxisButtonPressed;
        //left2DAxisButton.action.performed += onLeft2DAxisButtonPressed;

        //right2DAxisTouch.action.performed += onRight2DAxisTouchPressed;
        //left2DAxisTouch.action.performed += onLeft2DAxisTouchPressed;
    }

    public void Start()
    {
        barkReady = true;
        sniffReady = true;
    }


    public void onRightTriggerPressed(InputAction.CallbackContext obj)
    {
        Debug.Log("Right Trigger Pressed.");
        
        {
            StartCoroutine(dropItem());
        }

        IEnumerator dropItem()
        {
            yield return null;
            MouthPOS.SetActive(false);
            toyObjectOne.GetComponent<SphereCollider>().enabled = true;
            toyObjectTwo.GetComponent<SphereCollider>().enabled = true;
            toyObjectThree.GetComponent<SphereCollider>().enabled = true;
            toyObjectOne.GetComponent<Rigidbody>().useGravity = true;
            toyObjectTwo.GetComponent<Rigidbody>().useGravity = true;
            toyObjectThree.GetComponent<Rigidbody>().useGravity = true;
            //GetComponent<Rigidbody>().AddForce(Vector3.down * 1f);
            toyObjectOne.transform.SetParent(null);
            toyObjectTwo.transform.SetParent(null);
            toyObjectThree.transform.SetParent(null);

            StartCoroutine(enablePickup());
        }

        IEnumerator enablePickup()
        {
            yield return new WaitForSeconds(pickUpCooldown);
            MouthPOS.SetActive(true);
        }


    }
    private void onLeftTriggerPressed(InputAction.CallbackContext obj)
    {
        Debug.Log("Left Trigger Pressed.");
    }

    private void onRightGripPressed(InputAction.CallbackContext obj)
    {
        Debug.Log("Right Grip Pressed.");

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

        yield return new WaitForSeconds(1);

        barkReady = true;
        //Debug.Log("ready to bark"); 
    }


    private void onLeftGripPressed(InputAction.CallbackContext obj)
    {
        Debug.Log("Left Grip Pressed.");

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

        yield return new WaitForSeconds(3);

        sniffReady = true;
        Debug.Log("ready to sniff");
    }


    //private void onRightControllerPrimaryButtonPressed(InputAction.CallbackContext obj)
    //{
    //    //Debug.Log("Right Primary Pressed (A).");
    //    xRLocomotionManager.AcivateContinousLocomotion();
    //}

    //private void onLeftControllerPrimaryButtonPressed(InputAction.CallbackContext obj)
    //{
    //    //Debug.Log("Left Primary Pressed (X).");
    //    xRLocomotionManager.AcivateWalkInPlaceLocomotion();
    //}

    //private void onRightControllerSecondaryButtonPressed(InputAction.CallbackContext obj)
    //{
    //    //Debug.Log("Right Secondary Pressed (B).");
    //    xRLocomotionManager.AcivateTeleportLocomotion();
    //}

    //private void onLeftControllerSecondaryButtonPressed(InputAction.CallbackContext obj)
    //{
    //    //Debug.Log("Left Secondary Pressed (Y).");
    //    if (xRInteractionManager.isRayInteractionIsActive == true)
    //    {
    //        xRInteractionManager.DisableRayCastInteraction();
    //    } else
    //    {
    //        xRInteractionManager.ActivateRayCastInteraction();
    //    }
    //}

    //private void onRightJoystickTurn(InputAction.CallbackContext obj)
    //{
    //    Debug.Log(obj.ReadValue<Vector2>());
    //}
    //private void onLeftJoystickTurn(InputAction.CallbackContext obj)
    //{
    //    Debug.Log(obj.ReadValue<Vector2>());
    //}

    //private void onRight2DAxisButtonPressed(InputAction.CallbackContext obj)
    //{
    //    Debug.Log("Right 2D Axis Pressed (Joystick).");
    //}

    //private void onLeft2DAxisButtonPressed(InputAction.CallbackContext obj)
    //{
    //    Debug.Log("Left 2D Axis Pressed (Joystick).");
    //}


    //private void onRight2DAxisTouchPressed(InputAction.CallbackContext obj)
    //{
    //    Debug.Log("Right 2D Axis Touched (Joystick).");
    //}

    //private void onLeft2DAxisTouchPressed(InputAction.CallbackContext obj)
    //{
    //    Debug.Log("Left 2D Axis Touched (Joystick).");
    //}

}
