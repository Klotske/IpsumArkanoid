using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public int hitsToKill;
    public int points;
    private int numberOfHits;
    Vector3 startingPosition;

    void Start()
    {
        numberOfHits = 0;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            numberOfHits++;

            if (numberOfHits == hitsToKill)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Shake();
            }
        }
    }

    public void Shake()
    {
        iTween.Stop(gameObject);
        transform.position = startingPosition;
        iTween.ShakePosition(gameObject, Vector3.one * Random.Range(-0.2f, 0.2f), 0.2f);
    }

    public static void ShakeAll()
    {
        foreach (BlockScript block in FindObjectsOfType<BlockScript>())
        {
            block.Shake();
        }
    }
}
