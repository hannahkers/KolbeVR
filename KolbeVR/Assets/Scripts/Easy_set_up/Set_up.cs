using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_up : MonoBehaviour
{
    public Vector3 object_rows = new Vector3(0, 0, 0);
    public Vector3 gameobject_spaceing = new Vector3(0, 0, 0);

    public GameObject copy;
    // Start is called before the first frame update
    void Start()
    {
        if(copy == null)
        {
            copy = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Set_up_method()
    {
        for (int x = 0; x < object_rows.x; x++)
        {
            if(object_rows.z != null && object_rows.z > 0)
            {
                for(int z = 0; z < object_rows.z; z++)
                {
                    if(object_rows.y != null && object_rows.y > 0)
                    {
                        for(int y = 0; y < object_rows.y; y++)
                        {
                            Instantiate(copy, this.transform.TransformPoint(gameobject_spaceing.x * x, gameobject_spaceing.y * y, gameobject_spaceing.z * z), gameObject.transform.rotation);
                        }
                    }
                    else
                    {
                        Instantiate(copy, this.transform.TransformPoint(gameobject_spaceing.x * x, 0, gameobject_spaceing.z * z), gameObject.transform.rotation);
                    }
                }
            }
            else
            {
                Instantiate(copy, this.transform.TransformPoint(gameobject_spaceing.x * x, 0, 0), gameObject.transform.rotation);
            }
        }
    }
}
