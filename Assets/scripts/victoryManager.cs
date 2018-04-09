using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class victoryManager : MonoBehaviour
{
    public int LvlNo;
    public GameObject PlayAgainButton;
    public Button PlayAgainButton2;
    public GameObject LvlFinishPanel;
    public Platformer2DUserControl PlayerController;
    public Animator Animator;
    private const int finalLvl = 2;

    private void Start()
    {
        PlayAgainButton.SetActive(false);
        LvlFinishPanel.SetActive(false);
        PlayAgainButton2.onClick.AddListener
        (
            () => { RestartGame(); }
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerController.movingEnabled = false;
            Animator.speed = 0;

            if(LvlNo == finalLvl)
            {
                PlayAgainButton.SetActive(true);
            }
            else
            {
                LvlFinishPanel.SetActive(true);
                StartCoroutine("jumpToNewLayer");
            }
        }
    }

    public void RestartGame()
    {
        LvlNo = 1;
        SceneManager.LoadScene("GameLvl" + LvlNo);
    }

    IEnumerator jumpToNewLayer()
    {
        yield return new WaitForSeconds(2.0f);
        LvlNo++;
        SceneManager.LoadScene("GameLvl" + LvlNo);
    }
}
