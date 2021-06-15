using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnabledIconMusic : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    public bool musicFlag = true;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicFlag"))
        {
            PlayerPrefs.SetInt("musicFlag", 0);
            Load();
        }

        else
        {
            Load();
        }
        UpdateButtonIcon();
    }

    public void OnButtonPress()
    {
        musicFlag = !musicFlag;

        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().enabled = musicFlag;

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (musicFlag == true)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }

        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    private void Load()
    {
        musicFlag = PlayerPrefs.GetInt("musicFlag") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("musicFlag", musicFlag ? 1 : 0);
    }
}
