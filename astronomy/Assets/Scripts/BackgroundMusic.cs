using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;
    public bool musicFlag;

    private void Awake()
    {
        if (backgroundMusic == null && musicFlag)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}