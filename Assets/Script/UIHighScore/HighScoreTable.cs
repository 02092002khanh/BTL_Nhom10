using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreTable : MonoBehaviour
{
    
    [SerializeField] private Transform container;
    [SerializeField] private HighScoreItem hiScoreEntryTemplate;
    List<HiScoreEntry> hiScoreEntrieList;
    List<HighScoreItem> hiScoreEntryTransformList;
    void Awake()
    {
        hiScoreEntryTransformList = new List<HighScoreItem>();
        
        if(!(PlayerPrefs.HasKey("highScoreTable")))
        {
            hiScoreEntrieList = new List<HiScoreEntry>();
            HighScore highScore = new HighScore { hiScoreEntryList = hiScoreEntrieList};
            string json = JsonUtility.ToJson(highScore);
            PlayerPrefs.SetString("highScoreTable", json);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetString("highScoreTable"));
        }
        else
        {
            //load data from playerpref
        }
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScore loaded = JsonUtility.FromJson<HighScore>(jsonString);
        
        //sorting
        for(int i= 0; i< loaded.hiScoreEntryList.Count; i++)
        {
            for(int j = i + 1; j<loaded.hiScoreEntryList.Count; j++)
            {
                if(loaded.hiScoreEntryList[j].score > loaded.hiScoreEntryList[i].score)
                {
                    HiScoreEntry temp = loaded.hiScoreEntryList[j];
                    loaded.hiScoreEntryList[j] = loaded.hiScoreEntryList[i];
                    loaded.hiScoreEntryList[i] = temp;
                }
            }
        }
        //limited to 10 entry
        if (loaded.hiScoreEntryList.Count > 10)
        {
            for (int h = loaded.hiScoreEntryList.Count; h>10; h--)
            {
                loaded.hiScoreEntryList.RemoveAt(10);
            }
        }
        
        hiScoreEntryTransformList.Clear();
        container.DestroyAllChilren();

        for (int i = 0; i < loaded.hiScoreEntryList.Count; i++)
        {
            CreateHSEntryTransform(i, loaded.hiScoreEntryList[i]);
        }
    }


    //create highscore entry transform
    void CreateHSEntryTransform(int index, HiScoreEntry hiScoreEntry)
    {
        HighScoreItem newHiScoreEntry = Instantiate<HighScoreItem>(hiScoreEntryTemplate, container);
        newHiScoreEntry.Initialize(index + 1, hiScoreEntry.score, hiScoreEntry.name);
        hiScoreEntryTransformList.Add(newHiScoreEntry);
    }
    public void AddHiScoreEntry(int score, string name )
    {
        //create new entry
        HiScoreEntry hiScoreEntry = new HiScoreEntry{score = score, name = name};
        //load data
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScore loaded = JsonUtility.FromJson<HighScore>(jsonString);
        //add new data
        loaded.hiScoreEntryList.Add(hiScoreEntry);   
        loaded.hiScoreEntryList = loaded.hiScoreEntryList.OrderByDescending(s => s.score).ToList();
        //limited to 10 entry
        if (loaded.hiScoreEntryList.Count > 10)
        {
            for (int h = loaded.hiScoreEntryList.Count; h>10; h--)
            {
                loaded.hiScoreEntryList.RemoveAt(10);
            }
        }
        //save new loaded data
        string json = JsonUtility.ToJson(loaded);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(score + name);
        
        hiScoreEntryTransformList.Clear();
        container.DestroyAllChilren();

        for (int i = 0; i < loaded.hiScoreEntryList.Count; i++)
        {
            CreateHSEntryTransform(i, loaded.hiScoreEntryList[i]);
        }
    }

    public class HighScore
    {
        public List<HiScoreEntry> hiScoreEntryList;
    }

    [System.Serializable]
    public class HiScoreEntry
    {
        public int score;
        public string name;
    }
}