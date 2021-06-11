using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevelMessage : MonoBehaviour
{
    private static EndLevelMessage instance;
    public GameObject Template;

    void Awake()
    {
        instance = this;
    }

    public static void ShowMessage()
    {
        GameObject messageBox = Instantiate(instance.Template);
        Transform image = messageBox.transform.Find("Image");
        Button retry = image.Find("Retry").GetComponent<Button>();
        Button menu = image.Find("Menu").GetComponent<Button>();
        Button next = image.Find("Next").GetComponent<Button>();
        retry.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
        menu.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
        if ((SceneManager.GetActiveScene().buildIndex == 4))
            next.interactable = false;
        next.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(3);
        });
    }
}
