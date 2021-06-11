using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteScene : MonoBehaviour
{
    public bool Flag = false;
    public bool Completed = false;
    public CoreMech star;
    public CoreMech star1;
    public CoreMech star2;
    public CoreMech star3;
    public CoreMech star4;
    public CoreMech star5;
    public CoreMech star6;
    public CoreMech star7;

    void Update()
    {
        if (star.CorrectlyConnected & star1.CorrectlyConnected & star2.CorrectlyConnected & star3.CorrectlyConnected &
            star4.CorrectlyConnected & star5.CorrectlyConnected & star6.CorrectlyConnected & star7.CorrectlyConnected & !Flag)
        {
            Flag = true;
            if (!PlayerPrefs.HasKey("FirstLvlCompleted"))
            {
                Completed = true;
                PlayerPrefs.SetInt("FirstLvlCompleted", 1);
                PlayerPrefs.Save();
            }
            else
                SceneManager.LoadScene(3);
        }
    }
}
