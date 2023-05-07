using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HiScorePopUp : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] EndMenu endMenu;
    [SerializeField] HighScoreTable highScoreTable;
   
    public void Enter()
    {
        if(inputField.text.Replace(" ", "") != "")
        {
            if(inputField.text.Length > 12)
            {
                inputField.text = inputField.text.Substring(0,12);
            }
            highScoreTable.AddHiScoreEntry(endMenu.score, inputField.text);
            gameObject.SetActive(false);
        }
        
    }
}
