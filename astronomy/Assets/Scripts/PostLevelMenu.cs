using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostLevelMenu : MonoBehaviour
{
    Button tomenuButton;

    private void Start()
    {
        tomenuButton = GameObject.Find("Next").GetComponent<Button>();
        tomenuButton.onClick.AddListener(() =>
        {
            EndLevelMessage.ShowMessage();
        });
    }


}
