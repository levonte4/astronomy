using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOFF : MonoBehaviour
{
    private btnSound mySound;
    // Start is called before the first frame update
    void Start()
    {
        mySound = GetComponent<btnSound>();
    }

    public void ClickSound()
    {
        mySound.enabled = !mySound.enabled;
    }
}
