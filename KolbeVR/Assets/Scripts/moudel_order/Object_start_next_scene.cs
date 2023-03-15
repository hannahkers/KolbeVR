using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Object_start_next_scene : MonoBehaviour
{

    public GameObject[] list_of_puzzles;

    

    // make proper menu scene change
    void Start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
