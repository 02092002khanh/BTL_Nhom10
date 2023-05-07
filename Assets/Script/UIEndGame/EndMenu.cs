using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    GameController controller;
    public int score;    
    int minScore;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject nameInputWindow;

    private void Start() 
    {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<GameController>();
        score = controller.score;        
        scoreText.text = "Your Score: " + score.ToString();
        //load saved data
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScore loaded = JsonUtility.FromJson<HighScore>(jsonString);
        //get lowest value
        
        if(loaded.hiScoreEntryList != null)
        {
            if(loaded.hiScoreEntryList.Count <= 0)
            {
                minScore = -1;
            }
            else
            {
                minScore = loaded.hiScoreEntryList.Min(s => s.score);
            }
        }
        if((score > minScore) || (loaded.hiScoreEntryList.Count <= 10) )
        {
            nameInputWindow.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    private class HighScore
    {
        public List<SavedData> hiScoreEntryList;
    }

    [System.Serializable]

    public class SavedData
    {
        public int score;
        public string name;
    }
    
}
