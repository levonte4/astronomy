using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip aSource;
    public AudioSource audio;
    private bool flag;

    private void Start()
    {
        flag = false;
    }
    public void ClickSound()
    {
        if (flag)
        {
            audio.Stop();
            flag = false;
        }
        else
        {
            audio = GetComponent<AudioSource>();
            audio.PlayOneShot(aSource);
            flag = true;
        }
    }
}
