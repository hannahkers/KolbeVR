using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectFollow : MonoBehaviour
{
    public GameObject follow_obj;
    public float speed = 1;
    public float range = .01f;
    public float disrange = .1f;
    private float dis = 0;
    public Rigidbody followrb;
    private Vector2 xandy_dis = new Vector2(0,0);
    public Vector2 xandy_disrange = new Vector2(.2f, .2f);

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
        caluate_xdis();
        caluate_ydis();
        if (dis < disrange && xandy_dis.x < xandy_disrange.x && xandy_dis.y < xandy_disrange.y)
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

    void caluate_xdis()
    {
        xandy_dis.x = this.transform.gameObject.transform.position.x - follow_obj.transform.position.x;
        if (xandy_dis.x < 0)
        {
            xandy_dis.x = xandy_dis.x * -1;
        }
    }

    void caluate_ydis()
    {
        xandy_dis.y = this.transform.gameObject.transform.position.y - follow_obj.transform.position.y;
        if (xandy_dis.y < 0)
        {
            xandy_dis.y = xandy_dis.y * -1;
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Better_end_point"))
        {
            this.transform.GetComponent<activate_next_puzzle>().next_puzzle();
        }

        if (other.CompareTag("lesser_end_point"))
        {
            this.transform.GetComponent<activate_next_puzzle>().next_puzzle_other();
        }
    }
}
