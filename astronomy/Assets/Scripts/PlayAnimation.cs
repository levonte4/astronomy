using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAnimation : MonoBehaviour
{
    public Animator animator;
    public CompleteScene completeScene;
    public Canvas canvas;
    public bool Flag = false;
    public Button Volume;
    public Button Open;
    public Button Next;
    public Image Text;
    public AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (completeScene.Completed & !Flag)
        {
            Flag = true;
            animator.SetBool("LevelCompleted", true);
            Volume.transform.localPosition = new Vector3(-950, -400, 1);
            Open.transform.localPosition = new Vector3(950, 400, 1);
            Next.transform.localPosition = new Vector3(950, -400, 1);
            Text.transform.localPosition = new Vector3(589.83f, 386.71f, 1);
            sound.Play();
        }
    }
}
