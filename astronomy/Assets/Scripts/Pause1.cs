using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause1 : MonoBehaviour
{
    public GameObject Template;
    public Button PauseButton;
    public bool Flag = false;
    public CompleteScene1 Script;

    void Start()
    {
        PauseButton.onClick.AddListener(() =>
        {
            ShowPauseMenu();
        });
    }

    void Update()
    {
        if (Script.Completed & !Flag)
        {
            Flag = true;
            Destroy(PauseButton.transform.gameObject);
        }
    }

    public void ShowPauseMenu()
    {
        GameObject pauseMenu = Instantiate(Template);
        Transform image = pauseMenu.transform.Find("Image");
        Button resume = image.Find("Resume").GetComponent<Button>();
        Button retry = image.Find("Retry").GetComponent<Button>();
        Button menu = image.Find("Menu").GetComponent<Button>();
        resume.onClick.AddListener(() =>
        {
            Destroy(pauseMenu);
        });
        retry.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
        menu.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }
}
