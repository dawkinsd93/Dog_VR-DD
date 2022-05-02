using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseQuest : MonoBehaviour
{
    //note: this script sits on GameManager object 

    //make it accessible in other scripts: 
    //public static VaseQuest instance; 

    //ref the canvases (both inactive by default) 
    public GameObject VaseStartCanvas;
    public GameObject VaseEndCanvas; 

    //counting vases smashed: 
    public int smashedTotal = 0;
    public bool SmashedThemAll;


    private void Start()
    {
        //start by setting it false 
        SmashedThemAll = false; 
    }

    public void Update()
    {
        //after player has smashed the first vase (when smashedTotal == 1), activate the start quest screen 
        if (smashedTotal == 1)
        {
            VaseStartCanvas.SetActive(true);

            //start coroutine to turn off after a few seconds:
            StartCoroutine(StartCanvasTime()); 
        }
        

        //when reach 5 smashed vases, change boolean SmashedThemAll to true 
        if (smashedTotal == 5)
        {
            SmashedThemAll = true; 
        }


        //if SmashedThemAll is true, turn off quest screen (if not already) and load the success screen 
        if (SmashedThemAll)
        {
            VaseStartCanvas.SetActive(false); 
            VaseEndCanvas.SetActive(true);

            //start coroutine to turn off after a few seconds:
            StartCoroutine(EndCanvasTime());
        }


    }

    //whenever a vase is smashed, add 1 (function sends number)
    public void vaseSmashed(int vase)
    {
        //this function is called from within ObjectInteraction whenever vase is smashed, sends in '1'  

        //add the number (1) to 'smahedTotal' 
        smashedTotal += vase; 
        Debug.Log(smashedTotal); 

    }

    IEnumerator StartCanvasTime()
    {
        yield return new WaitForSeconds(5);
        VaseStartCanvas.SetActive(false);
    }

    IEnumerator EndCanvasTime()
    {
        yield return new WaitForSeconds(5);
        VaseEndCanvas.SetActive(false);
    }
}
