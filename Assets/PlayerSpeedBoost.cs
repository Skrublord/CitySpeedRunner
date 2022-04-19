using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using Platformer.Mechanics;
using UnityEngine;

public class PlayerSpeedBoost : MonoBehaviour
{
    public float addedSpeed;
    public float addedJump;
    public float powerUpTimer;
    public float totalPowerUpTime;
    public new SpriteRenderer renderer;
    private float originalR;
    private float originalG;
    private float originalB;
    public float originalSpeed;
    public float originalJump;
    
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
            
            gameObject.GetComponent<PlayerController>().maxSpeed = addedSpeed + originalSpeed;
            gameObject.GetComponent<PlayerController>().jumpTakeOffSpeed = addedJump + originalJump;

            if (!gameObject.GetComponent<PlayerInvincibility>().enabled || !gameObject.GetComponent<DoubleTokenPoints>().enabled)
            {
                renderer.color = new Color(0f, 1f, 0f);
            }
        }
        else
        {
            renderer.color = new Color(originalR, originalG, originalB);
            gameObject.GetComponent<PlayerController>().maxSpeed = originalSpeed;
            gameObject.GetComponent<PlayerController>().jumpTakeOffSpeed = originalJump;
            gameObject.GetComponent<PlayerSpeedUp>().enabled = true;
            this.enabled = false;
        }
    }
}
