using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : View
{
    public string PlayScene;
    public View Settings;

    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(PlayScene);
    }

    public void ShowSettings()
    {
        Hide();
        Settings.Show();
    }
}
