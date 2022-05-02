using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetreLevels : MonoBehaviour
{
    public int maxGoodness = 5;
    public int currentGoodness;

    public GoodnessMetre goodnessMetre; //script 
    public GameObject goodnessMetreCanvas; //canvas 

    //reference the object interaction script to see when smashed vase: 
    //public ObjectInteraction objectInteraction;

    //boolean to see if vase has been smashed (so Naughty point only happens once) 
    public bool smashedVase = false;

    //bool to see if metre has been hidden (otherwise get error) 
    public bool hiddenYet; 


    void Start()
    {
        //set as max goodness level at start 
        currentGoodness = maxGoodness;

        goodnessMetre.SetMaxGoodness(maxGoodness);

        hiddenYet = false; 
    }

    //following Update function is being superceded by NaughtyDog() function being called from within ObjectInteraction  
    //private void Update()
    //{
    //    //if break vase 
    //    if (objectInteraction.GetComponent<ObjectInteraction>().hasSmashed == true && smashedVase == false)
    //    {
    //        //call NaughtyDog function with 1 naughtiness point 
    //        NaughtyDog(1);

    //        //so only happens once, turn it off: 
    //        smashedVase = true; 
    //    }

    //}

    //Update function to check if naughtiness is empty, and if so, hide the metre 
    public void Update()
    {
        //if current goodness is 0 AND canvas hasn't been hidden yet 
        if (currentGoodness == 0 && hiddenYet == false)
        {
            //start coroutine which waits 5 seconds and then turns it off 
            StartCoroutine(HideMetre()); 
        }
    }

    IEnumerator HideMetre()
    {
        yield return new WaitForSeconds(5); 
        goodnessMetreCanvas.SetActive(false);
        hiddenYet = true;
    }


    public void NaughtyDog(int naughtiness)
    {
        //minus 1 from goodness level 
        currentGoodness -= naughtiness;

        //update the goodness metre with this new level 
        goodnessMetre.SetGoodness(currentGoodness);
    }
}
