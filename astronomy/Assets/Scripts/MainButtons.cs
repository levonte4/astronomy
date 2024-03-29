using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainButtons : MonoBehaviour
{
    public GameObject ScriptHolder;
    public CompleteScene Script;
    public bool Completed;
    public int Flag = 0;
    public Sprite FinalUnicorn;
    public Sprite Dragon;
    public Sprite FinalDragon;

    void Start()
    {
        var canvas = GameObject.Find("Canvas");
        Button dragonButton = GameObject.Find("DragonButton").GetComponent<Button>();
        dragonButton.interactable = false;
        Button lastButton = GameObject.Find("LastButton").GetComponent<Button>();
        lastButton.interactable = false;
    }

    void Update()
    {
        if (Flag == 0 & PlayerPrefs.HasKey("FirstLvlCompleted"))
        {
            Flag = 1;
            var canvas = GameObject.Find("Canvas");
            Button unicornButton = GameObject.Find("UnicornButton").GetComponent<Button>();
            unicornButton.image.sprite = FinalUnicorn;
            unicornButton.onClick.RemoveAllListeners();
            unicornButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(3);
            });
            Button dragonButton = GameObject.Find("DragonButton").GetComponent<Button>();
            dragonButton.interactable = true;
            dragonButton.image.sprite = Dragon;
            Destroy(ScriptHolder);
        }
        if (Flag == 1 & PlayerPrefs.HasKey("SecondLvlCompleted"))
        {
            Flag = 2;
            var canvas = GameObject.Find("Canvas");
            Button dragonButton = GameObject.Find("DragonButton").GetComponent<Button>();
            dragonButton.image.sprite = FinalDragon;
            dragonButton.onClick.RemoveAllListeners();
            dragonButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(5);
            });
            Destroy(ScriptHolder);
        }
    }
}
