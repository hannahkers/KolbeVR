using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectFollow : MonoBehaviour
{
    public GameObject follow_obj;
    public float speed = 1;
    public float range = .01f;
    public float disrange = .1f;
    public float dis = 0;
    public Rigidbody followrb;

    // Start is called before the first frame update
    void Start()
    {
        followrb = GetComponent<Rigidbody>();
        follow_obj = GameObject.FindGameObjectWithTag("follow_this");
    }

    // Update is called once per frame
    void Update()
    {
        caluate_dis();
        if (dis < disrange)
        {
            movement();
            followrb.useGravity = false;
        }
        else
        {
            followrb.useGravity = true;
        }
    }

    private float Xing;
    private float Ying;
    private Vector3 here;

    void caluate_dis()
    {
        dis = Vector3.Distance(this.transform.gameObject.transform.position, follow_obj.transform.position);
    }

    void movement()
    {
        update_this_object();
        Follow_x_axis();
        Follow_y_axis();
    }

    void Follow_x_axis()
    {

        Xing = follow_obj.transform.position.x;
        
        if(Xing >  (here.x + range))
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if(Xing < (here.x - range))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

    }

    void Follow_y_axis()
    {

        Ying = follow_obj.transform.position.y;

        if (Ying > (here.y + range))
        {
            this.transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else if (Ying < (here.y - range))
        {
            this.transform.Translate(0, -speed * Time.deltaTime, 0);
        }

    }

    void update_this_object()
    {
        here = this.gameObject.transform.position;
    }

}
