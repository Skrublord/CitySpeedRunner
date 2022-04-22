using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using Platformer.Mechanics;
using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
    public float powerUpTimer;
    public float totalPowerUpTime;
    public float colorTimeRemaining;
    public float colorTimer;
    public new SpriteRenderer renderer;
    private int changeColor;
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
        colorTimeRemaining = colorTimer;
        renderer = gameObject.GetComponent<SpriteRenderer>();
        originalR = renderer.color.r;
        originalG = renderer.color.g;
        originalB = renderer.color.b;
        changeColor = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpTimer > 0)
        {
            gameObject.GetComponent<PlayerController>().isInvincible = true;

            powerUpTimer -= Time.deltaTime;

            if (colorTimeRemaining > 0)
            {
                colorTimeRemaining -= Time.deltaTime;
            }
            else
            {
                changeColor++;
                colorTimeRemaining = colorTimer;
            }

            if (changeColor == 1)
            {
                renderer.color = new Color(1f, 0f, 0f);
            }
            else if (changeColor == 2)
            {
                renderer.color = new Color(1f, 0.5f, 0f);
            }
            else if (changeColor == 3)
            {
                renderer.color = new Color(1f, 1f, 0f);
            }
            else if (changeColor == 4)
            {
                renderer.color = new Color(0f, 1f, 0f);
            }
            else if (changeColor == 5)
            {
                renderer.color = new Color(0f, 0f, 1f);
            }
            else if (changeColor == 6)
            {
                renderer.color = new Color(0.5f, 0f, 1f);
            }
            else
            {
                renderer.color = new Color(1f, 1f, 1f);
                changeColor = 0;
            }
        }
        else
        {
            renderer.color = new Color(originalR, originalG, originalB);
            gameObject.GetComponent<PlayerController>().isInvincible = false;
            this.enabled = false;
        }
    }
}
