using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics {
    public class BoundaryFollow : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        public Transform player;
        public int xOffset;
        public PlayerController playerObject;
        public float farthestDistance; 

        private void Awake()
        {
            farthestDistance = GameObject.Find("Player").transform.position.x;
        }

        void Update()
        {
            playerObject = GameObject.Find("Player").GetComponent<PlayerController>();

            if (playerObject.velocity.x > 0 && player.position.x > farthestDistance)
            {                
                farthestDistance = player.position.x;
                transform.position = new Vector2(player.position.x + xOffset, player.position.y); // Boundary Zone follows the player with specified offset position
            }
            else
            {
                transform.position = new Vector2(farthestDistance + xOffset, player.position.y);
            }
        }
    }
}