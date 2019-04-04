using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject levelManager;
    

    void Start()
    {
        if (LevelManager.Instance == null)
        {
            Instantiate(levelManager);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
