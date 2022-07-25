using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
{    
    public PauseMenu paumen;

    void Start()
    {
        paumen = FindObjectOfType<PauseMenu>();
    }
    
    public void changemenuscene(string scenename)
    {
        SceneManager.LoadScene(scenename);
        paumen.Resume();
        Time.timeScale = 1f;
    }

    public void doexitgame()
    {
        Application.Quit();
    }
}
