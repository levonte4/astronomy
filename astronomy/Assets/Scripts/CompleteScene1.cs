using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteScene1 : MonoBehaviour
{
    public bool Flag = false;
    public bool Completed = false;
    public CoreMech1 star;
    public CoreMech1 star1;
    public CoreMech1 star2;
    public CoreMech1 star3;
    public CoreMech1 star4;
    public CoreMech1 star5;
    public CoreMech1 star6;
    public CoreMech1 star7;
    public CoreMech1 star8;
    public CoreMech1 star9;
    public CoreMech1 star10;
    public CoreMech1 star11;

    void Update()
    {
        if (star.CorrectlyConnected & star1.CorrectlyConnected & star2.CorrectlyConnected & star3.CorrectlyConnected &
            star4.CorrectlyConnected & star5.CorrectlyConnected & star6.CorrectlyConnected & star7.CorrectlyConnected & 
            star8.CorrectlyConnected & star9.CorrectlyConnected & star10.CorrectlyConnected & star11.CorrectlyConnected & !Flag)
        {
            Flag = true;
            if (!PlayerPrefs.HasKey("SecondLvlCompleted"))
            {
                Completed = true;
                PlayerPrefs.SetInt("SecondLvlCompleted", 1);
                PlayerPrefs.Save();
            }
            else
                SceneManager.LoadScene(5);
        }
    }
}
