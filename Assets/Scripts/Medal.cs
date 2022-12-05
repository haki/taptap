using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Sprite metalMedal;
    public Sprite bronzeMedal;
    public Sprite silverMedal;
    public Sprite goldMedal;

    private Image _img;

    private void Start()
    {
        _img = GetComponent<Image>();
    }

    private void Update()
    {
        int gameScore = GameManager.GameScore;

        if (gameScore > 0 && gameScore <= 5)
        {
            _img.sprite = metalMedal;
        }
        else if (gameScore > 5 && gameScore <= 10)
        {
            _img.sprite = bronzeMedal;
        }
        else if (gameScore > 10 && gameScore <= 15)
        {
            _img.sprite = silverMedal;
        }
        else if (gameScore > 15)
        {
            _img.sprite = goldMedal;
        }
    }
}
