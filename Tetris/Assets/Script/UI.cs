using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UI : MonoBehaviour
{
    public int counterOfRowsDeleted = 0;
    public int timeLeft = 10;
    public int toWin = 2;
    public Text show;
    public Text points;
    public Text gameOver;
    public bool end = false;

    bool paused = false;
    public Text button;

    public GameObject canvas;
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoseTime");
        paused = true;
    }

    // Update is called once per frame
    void Update()
    {
        points.text = ("Points: " + counterOfRowsDeleted + "/" + toWin);
        show.text = ("Time Left: " + timeLeft);

        if(timeLeft <= 0)
        {
            timeLeft = 0;
            Time.timeScale = 0;
            Destroy(FindObjectOfType<Groups>());
            Destroy(FindObjectOfType<GroupO>());
            gameOver.text = ("GAME OVER");
        }

        if(end == true)
        {
            timeLeft = 0;
            Time.timeScale = 0;
            Destroy(FindObjectOfType<Groups>());
            Destroy(FindObjectOfType<GroupO>());
            gameOver.text = ("GAME OVER");
        }

        if (counterOfRowsDeleted >= toWin)
        {
            timeLeft = 0;
            Time.timeScale = 0;
            Destroy(FindObjectOfType<Groups>());
            Destroy(FindObjectOfType<GroupO>());
            gameOver.color = Color.green;
            gameOver.fontSize = 120;
            gameOver.text = ("Win");
        }

        if (paused)
        {
            Time.timeScale = 0;
            button.text = "Play";
        }
        else
        {
            Time.timeScale = 1;
            button.text = "Pause";
        }
    }

    public void TimeUp()
    {
        timeLeft = timeLeft + 15;
    }

    public void counterUp()
    {
        counterOfRowsDeleted++;
    }

    public void Finish()
    {
        end = true;
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

    public void Play()
    {
        camera.position = new Vector3(5, 8.37f, -11);
        canvas.SetActive(false);
        paused = false;
    }

    public void Pause()
    {
        paused = !paused;
    }

    public void Reload()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
