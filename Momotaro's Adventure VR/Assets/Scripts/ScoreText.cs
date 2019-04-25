using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    
    private GameManagerNew _gameManagerNew;
    public Text _scoreText;
    public Text _levelText;

    void Start()
    {
        _gameManagerNew = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerNew>();

        DoScoreUpdate();
        _gameManagerNew.ScoreUpdated += DoScoreUpdate;

        DoLevelUpdate();
        _gameManagerNew.LevelUpdated += DoLevelUpdate;
    }

    public void DoScoreUpdate()
    {
        _scoreText.text = "Score: " + _gameManagerNew.Score;
    }

    public void DoLevelUpdate()
    {
        _levelText.text = "Level: " + _gameManagerNew.Level;
    }
}
