using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinPlayer : MonoBehaviour
{
    public CharacterDatabase _characterDB;
    public SpriteRenderer _artWorkSprite;
    private int _selectOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        _artWorkSprite = gameObject.GetComponent<SpriteRenderer>();
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

    private void UpgradeCharacter(int selectOption)
    {
        Character character = _characterDB.GetCharacter(selectOption);
        _artWorkSprite.sprite = character._characterSprite;
    }

    public void Load()
    {
        _selectOption = PlayerPrefs.GetInt("selectOption");
    }

}
