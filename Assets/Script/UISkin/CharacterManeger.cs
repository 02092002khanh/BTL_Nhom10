using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManeger : MonoBehaviour
{
    public CharacterDatabase _characterDB;
    public Image _artWorkSprite;
    private int _selectOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("selectOption"))
        {
            _selectOption = 0;
        }
        else
        {
            Load();
        }
        UpgradeCharacter(_selectOption);
    }

    public void NextOption()
    {
        _selectOption++;
        if(_selectOption >= _characterDB._characterCount)
        {
            _selectOption = 0;
        }

        UpgradeCharacter(_selectOption);
        Save();
    }
    
    public void BackOption()
    {
        _selectOption--;
        if(_selectOption < 0)
        {
            _selectOption = _characterDB._characterCount - 1;
        }
        UpgradeCharacter(_selectOption);
        Save();
    }

    private void UpgradeCharacter(int selectOption)
    {
        Character character = _characterDB.GetCharacter(selectOption);
        _artWorkSprite.sprite = character._characterSprite;
    }

    public void Load()
    {
        _selectOption = PlayerPrefs.GetInt("selectOption");
    }

    public void Save()
    {
        PlayerPrefs.SetInt("selectOption", _selectOption);
    }

    public void ChangeSence()
    {
        SceneManager.LoadScene(1);
    }

}

