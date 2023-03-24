using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPressurePlates : MonoBehaviour
{

    private GameObject[] pressure_plates;

    private int number_activated_pressure_plates = 0;

    public bool all_plates_activated = false;

    // Start is called before the first frame update
    void Start()
    {
        pressure_plates = GameObject.FindGameObjectsWithTag("pressure_plate");
    }

    // Update is called once per frame
    void Update()
    {
        Check_bool_values();

        Check_if_all_pressure_plates_active();
    }

    void Check_bool_values()
    {
        number_activated_pressure_plates = 0;

        foreach (GameObject p in pressure_plates)
        {
            if (p.GetComponent<TestObjectWeight>().weight_good == true)
            {
                number_activated_pressure_plates = number_activated_pressure_plates + 1;
            }
        }
    }



    void Check_if_all_pressure_plates_active()
    {
        if (number_activated_pressure_plates >= pressure_plates.Length)
        {
            all_plates_activated = true;
            this.gameObject.GetComponent<Single_has_been_completed>().activate_has_been_done();
        }
        else
        {
            all_plates_activated = false;
        }
    }
}
