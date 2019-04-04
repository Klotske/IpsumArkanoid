using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    static int blockCount;
    public static int lifeCount = 3;

    public int lives = 3;
    public static int Score = 0;

    void Start()
    {
        blockCount = 0;
        print(lifeCount);
        foreach (Transform block in transform)
        {
            blockCount += 1;
            iTween.MoveFrom(block.gameObject, iTween.Hash("y", 7, "time", Random.Range(0.5f, 1f), "easeType", "EaseOutElastic"));
        }
    }

    private void Update()
    {
        
    }

    public static void BallDied()
    {
        print(lifeCount);
        lifeCount = lifeCount - 1;
        print(lifeCount);
        if (lifeCount <= 0)
        {
            //To LevelSelect
        }
        else
        {
            print(lifeCount);
            FindObjectOfType<PlayerScript>().LightUp(lifeCount);
        }
    }

    public static void BlockDied(int blockScore)
    {
        blockCount -= 1;
        Score += blockScore;
        if (blockCount <= 0)
        {
            // To Next Level
        }
    }
}
