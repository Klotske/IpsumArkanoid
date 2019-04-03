using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject playerObject;
    private Rigidbody2D rig;
    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        ballInitialForce = new Vector2(100.0f, 300.0f);

        ballIsActive = false;

        ballPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") == true)
        {
            if (!ballIsActive)
            {
                rig.isKinematic = false;

                rig.AddForce(ballInitialForce);

                ballIsActive = !ballIsActive;
            }
        }

        if (!ballIsActive && playerObject != null)
        {

            ballPosition.x = playerObject.transform.position.x;

            transform.position = ballPosition;
        }

        if (ballIsActive && transform.position.y < -6)
        {
            ballIsActive = !ballIsActive;
            ballPosition.x = playerObject.transform.position.x;
            ballPosition.y = -3.93f;
            transform.position = ballPosition;

            rig.isKinematic = true;
        }
    }
}
