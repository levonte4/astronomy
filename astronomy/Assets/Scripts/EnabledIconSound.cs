using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnabledIconSound : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    public bool soundFlag = true;

    // Start is called before the first frame update
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
        UpdateButtonIcon();
    }

    public void OnButtonPress()
    {
        soundFlag = !soundFlag;
        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (soundFlag == false)
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
        soundFlag = PlayerPrefs.GetInt("soundFlag") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("soundFlag", soundFlag ? 1 : 0);
    }
}
