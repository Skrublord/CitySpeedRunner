using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using Platformer.Mechanics;
using UnityEngine;

public class DoubleTokenPoints : MonoBehaviour
{
    public int multiplier;
    public float powerUpTimer;
    public float totalPowerUpTime;
    public new SpriteRenderer renderer;
    private float originalR;
    private float originalG;
    private float originalB;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        powerUpTimer = totalPowerUpTime;
        renderer = gameObject.GetComponent<SpriteRenderer>();
        originalR = renderer.color.r;
        originalG = renderer.color.g;
        originalB = renderer.color.b;
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpTimer > 0)
        {
            powerUpTimer -= Time.deltaTime;
            gameObject.GetComponent<PlayerController>().multiplier = multiplier;

            if (!gameObject.GetComponent<PlayerInvincibility>().enabled)
            {
                renderer.color = new Color(1f, 0.66f, 0f);
            }
        }
        else
        {
            renderer.color = new Color(originalR, originalG, originalB);
            gameObject.GetComponent<PlayerController>().multiplier = 1;
            this.enabled = false;
        }
    }
}
