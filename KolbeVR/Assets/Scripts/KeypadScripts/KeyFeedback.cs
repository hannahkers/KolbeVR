using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFeedback : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip keySound;
    public bool keyHit = false;

    private Color originalColor;
    private Renderer renderer;

    //return color Timer
    private float colorReturnTime = .1f;
    private float returnColor;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1;
        audioSource.volume = .1f;
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(keyHit && returnColor < Time.time)
        {
            audioSource.PlayOneShot(keySound);
            returnColor = Time.time + colorReturnTime;
            renderer.material.color = Color.green;
            keyHit = false;
       
        }

        if (renderer.material.color != originalColor && returnColor < Time.time)
        {
            renderer.material.color = originalColor;
        }
        
    }
}
