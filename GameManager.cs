using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioManager AM;

    private bool state = false;

    [SerializeField]
    public GameObject PanelPause;

    [SerializeField]
    public GameObject Cam;

    [SerializeField]
    public GameObject RestartPanel;

    [SerializeField]
    public GameObject QuitPanel;

    [SerializeField]
    public GameObject NewBest;

    public void PauseControl()
    {
        if(Time.timeScale == 1)
        {
            Cam.SetActive(false);
            AM.Stop();
            PanelPause.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            //Cam.SetActive(true);
            AM.Start();
            Time.timeScale = 1;
            PanelPause.SetActive(false);
        }
    }

    public void RestartControl()
    {
        if (state == false)
        {
            RestartPanel.SetActive(true);
            state = true;
        }
        else
        {
            state = false;
            RestartPanel.SetActive(false);
        }
    }

    public void QuitControl()
    {
        if (state == false)
        {
            QuitPanel.SetActive(true);
            state = true;
        }
        else
        {
            state = false;
            QuitPanel.SetActive(false);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        NewBest.SetActive(false);
        
    }

    public void MenuUtama()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        NewBest.SetActive(false);
        
    }

}
