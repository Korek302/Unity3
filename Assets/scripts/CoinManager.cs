﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text ScoreText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ValueContainer.Container.Score += 10;
        ScoreText.text = "Score: " + ValueContainer.Container.Score;
        this.gameObject.SetActive(false);
    }
}
