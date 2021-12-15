using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//control GUI, used for buttons
public class Gui_Scripts : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        
    }
    public void Restart()
    {
        SpawnManager.waveNum = 1;
        SceneManager.LoadScene(1);
        
    }

    public void StartGame()
    {
        SpawnManager.waveNum = 1;
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SpawnManager.waveNum = 1;
        SceneManager.LoadScene(0);
    }
    public void EndGame()
    {
        SceneManager.LoadScene(2);
    }
}
