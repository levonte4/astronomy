using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnSound : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip clickFX;
    public void ClickSound()
    {
        myFX.PlayOneShot(clickFX);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
