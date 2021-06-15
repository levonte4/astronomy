using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionMessages : MonoBehaviour
{
    public bool Flag = false;
    public SceneLoad sceneLoad;
    public GameObject Instruction1;
    public GameObject Instruction2;
    public GameObject Instruction3;
    public bool soundFlag;
    public AudioSource myFX;
    public AudioClip clickFX;

    void Update()
    {
        soundFlag = PlayerPrefs.GetInt("soundFlag") == 1;
        if (!Flag & sceneLoad.IsFirstLaunch)
        {
            Flag = true;
            ShowInstructions();
        }
    }
    public void SoundBtn()
    {
        if (soundFlag)
            myFX.PlayOneShot(clickFX);
    }

    public void ShowInstructions()
    {
        GameObject instruction1 = Instantiate(Instruction1);
        Transform image1 = instruction1.transform.Find("Image");
        Button next1 = image1.Find("Next").GetComponent<Button>();
        next1.onClick.AddListener(() =>
        {
            SoundBtn();
            GameObject instruction2 = Instantiate(Instruction2);
            Destroy(instruction1);
            Transform image2 = instruction2.transform.Find("Image");
            Button next2 = image2.Find("Next").GetComponent<Button>();
            next2.onClick.AddListener(() =>
            {
                SoundBtn();
                GameObject instruction3 = Instantiate(Instruction3);
                Destroy(instruction2);
                Transform image3 = instruction3.transform.Find("Image");
                Button next3 = image3.Find("Next").GetComponent<Button>();
                next3.onClick.AddListener(() =>
                {
                    SoundBtn();
                    Destroy(instruction3);
                });
            });
        });
    }
}
