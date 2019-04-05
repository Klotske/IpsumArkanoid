using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    static int blocks = 25;
    static int blockCount = 25;
    public static int lifeCount = 3;

    public int lives = 3;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "SCORE: " + LevelManager.Score.ToString();
    }

    private void Update()
    {
        
    }

    public static void BallDied()
    {
        lifeCount = lifeCount - 1;
        if (lifeCount <= 0)
        {
            FindObjectOfType<PlayerScript>().LightUp(0);
            //To LevelSelect
            lifeCount = 3;
            LevelManager.Score = 0;
            SceneManager.LoadScene("Menu");
        }
        else
        {
            FindObjectOfType<PlayerScript>().LightUp(lifeCount);
        }
    }

    public static void BlockDied(int blockScore)
    {
        int len = GameObject.FindGameObjectsWithTag("Block").Length;
        LevelManager.Score += blockScore;
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "SCORE: " + LevelManager.Score.ToString();
        if (len <= 0)
        {
            lifeCount = 3;
            SceneManager.LoadScene("Menu");
        }
    }
}
