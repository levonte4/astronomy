using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public bool IsFirstLaunch = true;

    public void Start()
    {
        if (PlayerPrefs.HasKey("IsFirstLaunch"))
            IsFirstLaunch = false;
    }

    public void NextScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
