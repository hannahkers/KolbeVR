using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single_has_been_completed : MonoBehaviour
{

    private GameObject check_op;



    // Start is called before the first frame update
    void Start()
    {
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

            check_op.GetComponent<Check_if_operational>().has_been_completed();
        }
    }
}
