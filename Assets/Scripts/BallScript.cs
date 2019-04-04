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
    public AudioClip hit;
    public AudioClip pop;
    public AudioClip lose;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        ballInitialForce = new Vector2(100f, 300f);

        ballIsActive = false;

        ballPosition = transform.position;

        //GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") == true)
        {
            if (!ballIsActive)
            {
                rig.isKinematic = false;
                ballPosition.y = -3.8f;
                rig.AddForce(ballInitialForce);
                ballIsActive = !ballIsActive;
                GetComponent<TrailRenderer>().enabled = true;
            }
        }

        if ((rig.velocity.y <= 0.2f) && (rig.velocity.y >= -0.2f))
        {
            Vector2 force = new Vector2(rig.velocity.y, 1f);
            rig.AddForce(force);
        }

        if (!ballIsActive && playerObject != null)
        {

            ballPosition.x = playerObject.transform.position.x;

            transform.position = ballPosition;
        }

        if (ballIsActive && transform.position.y < -6)
        {
            Level.BallDied();
            GetComponent<AudioSource>().PlayOneShot(lose);
            GetComponent<TrailRenderer>().enabled = false;
            ballIsActive = !ballIsActive;
            ballPosition.x = playerObject.transform.position.x;
            ballPosition.y = -3.9f;
            rig.velocity = new Vector2(0f, 0f);
            transform.position = ballPosition;
            rig.isKinematic = true;

        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle")
        {
            collision.gameObject.GetComponent<PlayerScript>().Glow();
        }
        else if (collision.gameObject.tag == "Block")
        {
            GetComponent<AudioSource>().PlayOneShot(hit);
        }
        else
        {
            BlockScript.ShakeAll();
            GetComponent<AudioSource>().PlayOneShot(pop);
        }
    }
}
