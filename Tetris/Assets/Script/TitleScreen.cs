using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GameObject canvas;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void Play()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }

}
