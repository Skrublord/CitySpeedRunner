using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolSky : MonoBehaviour
{
    private float initialYPosition;
    private Rigidbody2D rb;

    public int walkSpeed;
    public int startPosition;
    public int endPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialYPosition = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<CapsuleCollider2D>().enabled)
        {
            this.enabled = false;
        }

        if ((transform.position.y <= initialYPosition - startPosition && walkSpeed < 0) || (transform.position.y >= initialYPosition + endPosition && walkSpeed > 0))
        {
            Flip();
        }
        else
        {
            rb.velocity = new Vector2(0, walkSpeed * Time.fixedDeltaTime);
        }
    }

    void Flip()
    {
        walkSpeed *= -1;
    }
}
