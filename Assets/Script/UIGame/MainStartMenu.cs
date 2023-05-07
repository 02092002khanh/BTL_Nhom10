using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStartMenu : MonoBehaviour
{
    [SerializeField] GameObject settingMenu, highScoreMenu, skinMenu;
    public void ChooseSkin()
    {
        skinMenu.SetActive(true);
    }

    public void HighScore()
    {
        highScoreMenu.SetActive(true);
    }

    public void Setting()
    {
        settingMenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
