using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public Transform player;
    public int yOffset;

    void Update()
    {
        transform.position = new Vector2(player.position.x, yOffset); // Camera follows the player with specified offset position
    }
}