﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class victoryManager : MonoBehaviour
{
    public GameObject PlayAgainButton;
    public GameObject LvlFinishPanel;
    public GameObject VictoryPanel;
    public GameObject Player;
    public Animator Animator;
    private const int finalLvl = 2;

    private void Start()
    {
        LvlFinishPanel.SetActive(false);
        VictoryPanel.SetActive(false);
        PlayAgainButton.GetComponent<Button>().onClick.AddListener
        (
            () => { RestartGame(); }
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player.GetComponent<Platformer2DUserControl>().movingEnabled = false;
            Animator.speed = 0;

            if (ValueContainer.Container.CurrLvl == finalLvl)
            {
                VictoryPanel.SetActive(true);
            }
            else
            {
                LvlFinishPanel.SetActive(true);
                StartCoroutine("jumpToNewLayer");
            }
            ValueContainer.Container.CurrLvl = 1;
        }
    }

    public void RestartGame()
    {
        ValueContainer.Container.CurrLvl = 1;
        SceneManager.LoadScene("GameLvl" + ValueContainer.Container.CurrLvl);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator jumpToNewLayer()
    {
        yield return new WaitForSeconds(2.0f);
        ValueContainer.Container.CurrLvl++;
        ValueContainer.Container.Hearts = Player.GetComponent<hpManager>().GetHearts();
        SceneManager.LoadScene("GameLvl" + ValueContainer.Container.CurrLvl);
    }
}
