using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_if_operational : MonoBehaviour
{
    public int check_has_been_complete = 0;

    private int num_hold_array = 0;

    private int num_tracker = 0;

    public GameObject[] object_to_mark_off_on_the_list;

    public string[] string_value_of_object;

    public void Check_if_done()
    {
        if(check_has_been_complete >= num_tracker)
        {
            Debug.Log("You are victorious");
        }
    }

    void Start()
    {
        //Invoke("set_up_goal", 2.0f);
    }

    public void set_up_goal()
    {
        num_tracker = num_tracker + 1;
    }

    
    public void has_been_completed(string obj_name)
    {
        check_has_been_complete = check_has_been_complete + 1;
        Check_if_done();
        string_valuse(obj_name);
    }

    private void string_valuse(string obj_name)
    {
        for (int i = 0; i < string_value_of_object.Length; i++)
        {
            if (string_value_of_object[i] == obj_name)
            {
                object_to_mark_off_on_the_list[i].SetActive(true);
            }
        }
    }





}
