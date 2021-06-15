using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnSound : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip clickFX;
    public bool soundFlag;
    void Start()
    {
        if (!PlayerPrefs.HasKey("soundFlag"))
        {
            PlayerPrefs.SetInt("soundFlag", 0);
            Load();
        }

        else
        {
            Load();
        }
    }
    public void ClickSound()
    {
        if(soundFlag)
            myFX.PlayOneShot(clickFX);
    }
    private void Load()
    {
        soundFlag = PlayerPrefs.GetInt("soundFlag") == 1;
    }
}
