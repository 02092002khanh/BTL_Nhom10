using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject _pauseUI;
    public void PauseGame()
    {
        Time.timeScale = 0;
        _pauseUI.SetActive(true);
    }

}
