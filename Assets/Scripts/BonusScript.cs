using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    public static BonusScript bonus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Glow()
    {
        iTween.ColorFrom(gameObject, Color.white, 10f);
    }

    public void Roulette()
    {
        //FindObjectsOfType<BonusScript>()[2].name = "111";
        int roll = Random.Range(8, 24);
        int spins = roll / 4;
        int chosen = roll % 4;

        bonus = FindObjectsOfType<BonusScript>()[chosen];
        bonus.Glow();
    }
}
