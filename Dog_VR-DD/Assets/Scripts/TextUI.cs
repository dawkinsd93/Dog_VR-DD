using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextUI : MonoBehaviour
{
    //this script is assigned to game manager object 


    //text objects: 
    public GameObject textRoot;
    public TextMeshProUGUI uiText;
    public string thought;



    public void Start()
    {
        //set the root active (inactive by default): 
        textRoot.SetActive(true);

        //call coroutine: 
        StartCoroutine(DisplayText());
    }


    IEnumerator DisplayText()
    {
        //BORED 
        write(" ");
        yield return new WaitForSeconds(6);
        write("bored...");
        yield return new WaitForSeconds(5);
        write ("find human to play with?");
        yield return new WaitForSeconds(12);
        write("find ball");
        yield return new WaitForSeconds(14);
        write(" ");
        yield return new WaitForSeconds(2); 
        write("got ball!");
        yield return new WaitForSeconds(4);
        write("play?????");
        yield return new WaitForSeconds(8);


        write(" ");
        yield return new WaitForSeconds(20); 



        write("why no play????");
        yield return new WaitForSeconds(2);


        //HUNGRY 
        write("hmm.... hungry");
        yield return new WaitForSeconds(5);
        write("hungry. food?????");
        yield return new WaitForSeconds(6);
        write("nice smell. find food.");
        yield return new WaitForSeconds(6);
        write("food smell close.");
        yield return new WaitForSeconds(8);
        write("food. find food.");
        yield return new WaitForSeconds(8);
        write("found food!!!");
        yield return new WaitForSeconds(2);



        //NEED A WEE 
        write("need wee");
        yield return new WaitForSeconds(5);
        write(" ");
        yield return new WaitForSeconds(6);
        write("really need wee........");
        yield return new WaitForSeconds(6);
        write("human open door???");
        yield return new WaitForSeconds(4);
        write("where human????");
        yield return new WaitForSeconds(8);
        write("need wee!!!!!");
        yield return new WaitForSeconds(2);



    }


    public void write(string message)
    {
        uiText.text = message;
    }


}
