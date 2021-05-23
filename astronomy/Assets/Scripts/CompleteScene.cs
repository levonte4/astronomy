using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteScene : MonoBehaviour
{
    public bool Completed = false;
    public CoreMech star;
    public CoreMech star1;
    public CoreMech star2;
    public CoreMech star3;
    public CoreMech star4;
    public CoreMech star5;
    public CoreMech star6;
    public CoreMech star7;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (star.CorrectlyConnected & star1.CorrectlyConnected & star2.CorrectlyConnected & star3.CorrectlyConnected &
            star4.CorrectlyConnected & star5.CorrectlyConnected & star6.CorrectlyConnected & star7.CorrectlyConnected)
            Completed = true;
    }
}
