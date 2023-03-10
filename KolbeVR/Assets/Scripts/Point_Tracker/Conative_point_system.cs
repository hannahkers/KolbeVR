using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conative_point_system : MonoBehaviour
{

    public int fact_finder = 0;
    public int follow_thru = 0;
    public int quick_start = 0;
    public int implementor = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void add_point_fact_finder()
    {
        fact_finder = fact_finder + 1;
    }

    public void add_point_follow_thru()
    {
        follow_thru = follow_thru + 1;
    }

    public void add_point_quick_start()
    {
        quick_start = quick_start + 1;
    }

    public void add_point_implementor()
    {
        implementor = implementor + 1;
    }
}
