using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadControll : MonoBehaviour
{

    public int correctCombination;

    public bool accessGranted = false;

    public GameObject key;


    //Need code to substantiate a key or to open a door or box to next clue or puzzle


    // Start is called before the first frame update
    void Start()
    {
        key.SetActive(false);
        //doorOpen = false
        
    }

    // Update is called once per frame
    void Update()
    {
       if (accessGranted == true)
        {
            //action when correct code is entered
            //doorOpen = true;

            key.SetActive(true);
            accessGranted = false;


        }
    }

    public bool CheckIfCorrect(int combination)
    {
        if(combination == correctCombination)
        {
            accessGranted = true;
            return true;

        }
        return false;
    }


}
