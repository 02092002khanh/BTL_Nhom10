using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LeverLoader : MonoBehaviour
{
    // private const string VALUE_FORMAT = "{0}%";
    [SerializeField] GameObject _loadingScreen;
    [SerializeField] Slider _slider;
    [SerializeField] TMP_Text _text;
    // private float _valueSlider = 0;
    public void LoadLever(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        _loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            _slider.value = progress;
            _text.text = progress * 100f + "%";
            yield return null ;
        }

    }

    // public void LoadingRun()
    // {
    //     _valueSlider += 0.5f;
    //     _slider.value = _valueSlider;
    //     _text.text =  string.Format(VALUE_FORMAT, (int)_valueSlider);
    // }


}
