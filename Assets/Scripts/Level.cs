using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    static int blocks = 25;
    static int blockCount = 25;
    static int levelCount = 1;
    static int levels = 5;
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
            Application.Quit();
            //LevelManager.Instance.Select("level2");
        }
        else
        {
            FindObjectOfType<PlayerScript>().LightUp(lifeCount);
        }
    }

    public static void BlockDied(int blockScore)
    {
        blockCount -= 1;
        Score += blockScore;
        if (blockCount <= 0 && levelCount < 5)
        {
            //LevelManager.Instance.Select(levelName);
        }
    }
}
