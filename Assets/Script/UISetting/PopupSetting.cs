using UnityEngine;
using UnityEngine.UI;

public class PopupSetting : MonoBehaviour
{
    
    [SerializeField] private Slider _sliderVolume;
    [SerializeField] private GameObject _popupSetting;
    
    [SerializeField] private float _timeDelayTurnOffObject = 0.5f;
    private void Awake() {
        _popupSetting.transform.localScale = new Vector3(0f, 0f, 0f);
        //_background.alpha = 0f;
    }
    private void OnEnable() {
        // Turn on animation
        // ChangeScale(_popupSetting, new Vector3(1f, 1f, 1f), _timeDelayTurnOffObject);
        // ChangeAlpha(_background, 1f, _timeDelayTurnOffObject);
    }

    private void OnDisable() {
        SoundManeger.Instance.SaveVolume();
    }
    private void Start() {
        //this._btnClose.onClick.AddListener(TurnOffObject);
        
        LoadVolume();
    }
    public void ChangeVolume() 
    { 
        SoundManeger.volume = _sliderVolume.value; 
        SoundManeger.Instance.SaveVolume();
    }  
    private void LoadVolume() { _sliderVolume.value = SoundManeger.volume; }

    private void TurnOffObject()
    {
        //SoundManeger.Instance.PlaySound(EActionSound.Button);
        //ChangeAlpha(_background, 0f, _timeDelayTurnOffObject);
        //ChangeScale(_popupSetting, new Vector3(0f, 0f, 0f), _timeDelayTurnOffObject);
        // this.ActionWaitTime(_timeDelayTurnOffObject, () =>
        // {
        //     ClosePopup(this.gameObject);
        // });
    }
}
