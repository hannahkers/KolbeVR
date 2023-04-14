using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{

    public GameObject CubetobeMoved;
    public float speed;
    public Transform Target;
    public ButtonVR buttonVr;
    public GameObject Endzone;

    public bool endZoneReached;

    // Start is called before the first frame update
    void Start()
    {
        buttonVr.isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCube();

    }

    public void MoveCube()
    {
        if (buttonVr.isPressed == true)
        {
            float step = speed * Time.deltaTime;
            CubetobeMoved.transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
        }
    }

    private void GameOver()
    {
        if (CubetobeMoved.transform.position == Endzone.transform.position)
        {
            // Give reward/key Congratulations
            this.gameObject.GetComponent<Single_has_been_completed>().activate_has_been_done();
            Debug.Log("congratulations");
        }


    }


}

