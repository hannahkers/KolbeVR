using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_next_puzzle : MonoBehaviour
{
    //any other object offilated with it 
    public GameObject[] self_obj;
    //if you want this puxxle to disabpar make it true
    public bool self_set_inactive = true;

    //next object to be activate
    public GameObject[] activate_next;
    
    public GameObject[] activate_next_other;

    public void next_puzzle()
    {
        foreach(GameObject q in activate_next)
        {
            q.SetActive(true);
        }

        if (self_set_inactive == true)
        {
            foreach (GameObject w in self_obj)
            {
                w.SetActive(false);
            }

            this.gameObject.SetActive(false);
        }
    }

    public void next_puzzle_other()
    {
        foreach (GameObject q in activate_next_other)
        {
            q.SetActive(true);
        }

        if (self_set_inactive == true)
        {
            foreach (GameObject w in self_obj)
            {
                w.SetActive(false);
            }

            this.gameObject.SetActive(false);
        }
    }
}
