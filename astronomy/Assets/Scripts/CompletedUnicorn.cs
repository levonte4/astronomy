using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompletedUnicorn : MonoBehaviour
{
    public Animator animator;
    public Canvas canvas;
    public bool Flag = false;
    public Button Volume;
    public Button Open;
    public Button Next;
    public Button Retry;

    void Update()
    {
        if (!Flag)
        {
            Flag = true;
            animator.SetBool("LevelCompleted", true);
            Retry.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(2);
            });
            Next.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(4);
            });
        }
    }
}
