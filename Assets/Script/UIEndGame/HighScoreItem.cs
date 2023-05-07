using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class HighScoreItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _rank;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _name;

    public void Initialize(int rank, int score, string name)
    {
        _rank.text = rank.ToString();
        _score.text = score.ToString();
        _name.text = name;
    }
}
