using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{

    public float side_of_player = 0.2f;

    public float distance_from_player = 2;

    private GameObject main_camera;

    public float close_distance = 2;

    private Vector3 go_to_position;

    public float speed = 4;

    public float speed_slow = 1;

    void Start()
    {
        main_camera = GameObject.FindGameObjectWithTag("MainCamera");
    }


    void Update()
    {
        get_position();
        if (close_distance < Vector3.Distance(main_camera.transform.position, this.transform.position))
        {
            Move_infront_of_player();
        }

        eye_level();
    }

    void Move_infront_of_player()
    {
        Vector3 director = go_to_position - transform.position;
        Quaternion rotator = Quaternion.LookRotation(director);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotator, speed * Time.deltaTime);
    }

    void eye_level()
    {
        if(this.transform.position.y <=  main_camera.transform.position.y)
        {
            this.transform.Translate(0, speed_slow * Time.deltaTime, 0);
        }
    }

    void get_position()
    {
        go_to_position = new Vector3((main_camera.transform.position.x + side_of_player), main_camera.transform.position.y, (main_camera.transform.position.z - distance_from_player));
    }
}
