using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    public static BonusScript bonus;
    static bool show = false;
    static float time;
    static float activeTime = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (show)
        {
            if ((Time.time - time) > activeTime)
            {
                ShutDown();
                show = false;
            }
        }
    }

    public void ShutDown()
    {
        bonus.GetComponent<SpriteRenderer>().enabled = false;
        if (bonus.name == "AddPaddle")
        {
            PlayerScript player = FindObjectOfType<PlayerScript>();
            player.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (bonus.name == "SubPaddle")
        {
            PlayerScript player = FindObjectOfType<PlayerScript>();
            player.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void ShutAll()
    {
        foreach (BonusScript bonus in FindObjectsOfType<BonusScript>())
        {
            bonus.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void Roulette()
    {
        if (!show)
        {
            int roll = Random.Range(0, 24);
            int chosen = roll % 4;
            bonus = FindObjectsOfType<BonusScript>()[chosen];
            bonus.GetComponent<SpriteRenderer>().enabled = true;
            if (bonus.name == "AddLife")
            {
                bonus.AddLife();
            }
            else if (bonus.name == "SubLife")
            {
                bonus.SubLife();
            }
            else if (bonus.name == "AddPaddle")
            {
                bonus.AddPaddle();
            }
            else if (bonus.name == "SubPaddle")
            {
                bonus.SubPaddle();
            }

            time = Time.time;
            show = true;
        }
    }

    public void AddLife()
    {
        if (Level.lifeCount < 3)
        {
            Level.lifeCount++;
            FindObjectOfType<PlayerScript>().LightUp(Level.lifeCount);
        }
    }

    public void SubLife()
    {
        Level.BallDied();
    }

    public void AddPaddle()
    {
        PlayerScript player = FindObjectOfType<PlayerScript>();
        player.transform.localScale = new Vector3(2F, 1, 1);
    }

    public void SubPaddle()
    {
        PlayerScript player = FindObjectOfType<PlayerScript>();
        player.transform.localScale = new Vector3(0.5F, 1, 1);
    }
}
