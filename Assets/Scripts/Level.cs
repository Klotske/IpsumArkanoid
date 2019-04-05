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
    public static int Score = 0;

    void Start()
    {
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
        Score += blockScore;
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "SCORE: " + Score.ToString();
        if (len <= 0)
        {
            lifeCount = 3;
            SceneManager.LoadScene("Menu");
        }
    }
}
