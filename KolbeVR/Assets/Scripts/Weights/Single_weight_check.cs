using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single_weight_check : MonoBehaviour
{
    public int acceptable_weight = 1;

    private int track_wight = 0;

    public bool weight_good = false;

    public List<GameObject> lastone;

    private bool complete = false;

    private float dis;


    void Update()
    {
        if (weight_good == true && lastone != null)
        {
            

            if (acceptable_weight == track_wight && complete == false)
            {
                complete = true;
                this.gameObject.GetComponent<Single_has_been_completed>().activate_has_been_done();
            }
            else
            {
                get_track_wight();
                Check_if_ontop();
            }
        }

    }

    void Check_if_ontop()
    {
        foreach(GameObject q in lastone)
        {
            dis = Vector3.Distance(this.transform.position, q.transform.position);

            if (dis > 1 || q.transform.position.y > this.transform.position.y + 1)
            {
                q.GetComponent<ObjectWeightValue>().toucheding = false;
                lastone.Remove(q);
            }
        }
        
    }

    void get_track_wight()
    {
        track_wight = 0;
        for(int w = 0; w < lastone.Count; w++)
        {
            int here =  lastone[w].GetComponent<ObjectWeightValue>().weight;
            track_wight = track_wight + here;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("weights"))
        {
            weight_good = true;
            if (other.gameObject.GetComponent<ObjectWeightValue>().toucheding == false)
            {
                other.gameObject.GetComponent<ObjectWeightValue>().toucheding = true;
                lastone.Add(other.gameObject);
            }
            

        }
    }
}
