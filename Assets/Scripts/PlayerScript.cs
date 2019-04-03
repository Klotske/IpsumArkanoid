using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float limit;
    public float playerVelocity;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition.x += Input.GetAxis("Horizontal") * playerVelocity;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        if (playerPosition.x <= -limit)
        {
            transform.position = new Vector2(-limit + 0.01f, playerPosition.y);
            playerPosition.x = -limit + 0.01f;
        }
        else if (playerPosition.x >= limit)
        {
            transform.position = new Vector2(limit - 0.01f, playerPosition.y);
            playerPosition.x = limit - 0.01f;
        }
        else
        {
            transform.position = playerPosition;
        }   
    }

    public void Glow()
    {
        iTween.ColorFrom(gameObject, Color.white, 0.33f);
    }
}
