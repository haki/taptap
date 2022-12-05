using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int _score;
    private int _highScore;
    private Text _scoreText;

    public Text panelScore;
    public Text panelHighScore;
    public GameObject New;

    private void Start()
    {
        _score = 0;
        _scoreText = GetComponent<Text>();
        _scoreText.text = _score.ToString();
        panelScore.text = _score.ToString();
        _highScore = PlayerPrefs.GetInt("highscore");
        panelHighScore.text = _highScore.ToString();
    }

    public void Scored()
    {
        _score++;
        _scoreText.text = _score.ToString();
        panelScore.text = _score.ToString();

        if (_score > _highScore)
        {
            _highScore = _score;
            panelHighScore.text = _highScore.ToString();
            PlayerPrefs.SetInt("highscore", _highScore);
            New.SetActive(true);
        }
    }
    
    public int GetScore()
    {
        return _score;
    }
}
