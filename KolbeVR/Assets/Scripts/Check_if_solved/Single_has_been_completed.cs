using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single_has_been_completed : MonoBehaviour
{

    private GameObject check_op;

    public string compare_string_value;

    // Start is called before the first frame update
    void Start()
    {

        if (compare_string_value == null)
        {
            compare_string_value = "";
        }

        check_op = GameObject.FindGameObjectWithTag("check_op_array");


        if(check_op != null)
        {

            check_op.GetComponent<Check_if_operational>().set_up_goal();
        }
        else
        {
            Debug.Log("you need the check_if_oeratinal in scene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate_has_been_done()
    {
        if (check_op != null)
        {

            check_op.GetComponent<Check_if_operational>().has_been_completed(compare_string_value);
        }
    }
}
