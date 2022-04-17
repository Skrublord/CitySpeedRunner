using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class PlayerSpeedUp : MonoBehaviour
{
    public float countDown;
    public float timeRemaining;
    public float speedLimit;
    public float jumpLimit;
    public float increase;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        countDown = timeRemaining;
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        else
        {
            bool underSpeedLimit = player.maxSpeed < speedLimit;
            bool underJumpLimit = player.jumpTakeOffSpeed < jumpLimit;

            if (underSpeedLimit || underJumpLimit)
            {
                if (underSpeedLimit)
                {
                    player.maxSpeed += increase;
                }
                if (underJumpLimit)
                {
                    player.jumpTakeOffSpeed += increase;
                }
            }
            else
            {
                this.enabled = false;
            }

            countDown = timeRemaining;
        }
    }
}
