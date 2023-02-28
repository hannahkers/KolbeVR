using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//help form Dmitry Bychenko https://stackoverflow.com/questions/42527594/c-sharp-float-declaration

public class Track_HoldCount : MonoBehaviour
{

    public GameObject[] optional_hold_objects;

    //This is for future when turning public o.h.o. into private
    //public string tracked_held = "";

    private int[] times_touched;

    private float[][] time_held;


    private bool timer_active = false;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //This is for future when turning public o.h.o. into private
        //optional_hold_objects = GameObject.FindGameObjectsWithTag(tracked_held);

        create_arrays();
    }

    void Update()
    {
        if (timer_active == true)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
    }

    void create_arrays()
    {


        times_touched = new int[optional_hold_objects.Length];
        time_held = new float[optional_hold_objects.Length][];
        
    }
    
    public void object_picked_up(GameObject picked)
    {
        timer_active = true;
    }

    public void object_put_down(GameObject droped)
    {
        float get_time = timer;
        timer_active = false;

        for(int q = 0; q < optional_hold_objects.Length; q++)
        {
            if (optional_hold_objects[q] == droped)
            {
                //adds how long it was held
                time_held[q][times_touched[q]] = get_time;
                //adds how many times touched
                times_touched[q] = times_touched[q] + 1;
                //create new float to hold the value for the next time it is held
                time_held[q] = new float[times_touched[q]];


                q =  q + optional_hold_objects.Length;
            }
            
        }
    }

    void print_statz()
    {
        //prints statz out to an excel sheet
    }


}
