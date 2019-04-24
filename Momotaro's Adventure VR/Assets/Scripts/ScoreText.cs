using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    
    private GameManagerNew _gameManagerNew;
    public Text _scoreText;
    void Start()
    {
        _gameManagerNew = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerNew>();
        DoScoreUpdate();
        _gameManagerNew.ScoreUpdated += DoScoreUpdate;
    }

    public void DoScoreUpdate()
    {
        _scoreText.text = "Score: " + _gameManagerNew.Score;
    }
}
