using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowHint : MonoBehaviour
{
    public GameObject UnicornHint;
    public GameObject DragonHint;
    public Button Open;

    void Start()
    {
        Open.onClick.AddListener(() =>
        {
            Show();
        });
    }

    public void Show()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 | SceneManager.GetActiveScene().buildIndex == 3)
        {
            GameObject unicornHint = Instantiate(UnicornHint);
            Transform image = unicornHint.transform.Find("Image");
            Button next = image.Find("Next").GetComponent<Button>();
            next.onClick.AddListener(() =>
            {
                Destroy(unicornHint);
            });
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4 | SceneManager.GetActiveScene().buildIndex == 5)
        {
            GameObject dragonHint = Instantiate(DragonHint);
            Transform image = dragonHint.transform.Find("Image");
            Button next = image.Find("Next").GetComponent<Button>();
            next.onClick.AddListener(() =>
            {
                Destroy(dragonHint);
            });
        }
    }
}
