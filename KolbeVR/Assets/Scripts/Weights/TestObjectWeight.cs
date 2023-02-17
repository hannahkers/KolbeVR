using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjectWeight : MonoBehaviour
{
    public int acceptable_weight = 1;

    public bool weight_good = false;

    private GameObject lastone;

    private float dis;


    void Update()
    {
        if(weight_good == true && lastone != null)
        {
            Check_if_ontop();
        }
    }

    void Check_if_ontop()
    {
        dis = Vector3.Distance(this.transform.position, lastone.transform.position);

        if(dis > 1 || lastone.transform.position.y > this.transform.position.y + 1)
        {
            weight_good = false;
        }
    }

    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("weights"))
        {
            if (other.gameObject.GetComponent<ObjectWeightValue>().weight == acceptable_weight)
            {
                weight_good = true;
                lastone = other.gameObject;
            }

        }
    }

    
}