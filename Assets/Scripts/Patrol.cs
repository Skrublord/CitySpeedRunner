using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private float initialXPosition;
    private Rigidbody2D rb;

    public int walkSpeed;
    public int startPosition;
    public int endPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialXPosition = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x <= initialXPosition - startPosition && walkSpeed < 0) || (transform.position.x >= initialXPosition + endPosition && walkSpeed > 0))
        {
            Flip();
        }
        else
        {
            rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }
    }

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
    }
}
