using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameData : MonoBehaviour
{
    public static InGameData Instance;
    
    private bool _isShowAds;
    public bool IsShowAds
    {
        get => _isShowAds;
        set => _isShowAds = value;
    }
    private void Awake() {
        Instance = this;
        _isShowAds = Convert.ToBoolean(PlayerPrefs.GetInt("removeAds"));
        DontDestroyOnLoad(this.gameObject);
    }
}
