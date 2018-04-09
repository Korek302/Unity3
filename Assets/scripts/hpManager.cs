using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class hpManager : MonoBehaviour
{
    public GameObject[] hearts;
    public Rigidbody2D characterBody;
    public Platformer2DUserControl playerController;

    private int hp;
    
	void Start ()
    {
        hp = hearts.Length;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            knockBack();
            hp--;
            hearts[hp].SetActive(false);
        }
        if(hp < 1)
        {
            SceneManager.LoadScene("GameLvl1");
        }
    }

    private void knockBack()
    {
        StartCoroutine("haltMovement");
        Vector2 vector = new Vector2(Random.Range(-5.0f, -1.0f), Random.Range(0.0f, 3.0f));
        characterBody.velocity = vector;
    }

    IEnumerator haltMovement()
    {
        playerController.movingEnabled = false;
        yield return new WaitForSeconds(1.0f);
        playerController.movingEnabled = true;
    }
}
