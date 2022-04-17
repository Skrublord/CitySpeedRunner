using Platformer.Core;
using Platformer.Model;
using Platformer.Mechanics;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// This event is fired when user input should be enabled.
    /// </summary>
    public class EnablePlayerInput : Simulation.Event<EnablePlayerInput>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        public BoundaryFollow boundary;
        public PlayerSpeedUp speedUp;
        public PlayerController playerController;
        public override void Execute()
        {
            var player = model.player;
            player.controlEnabled = true;

            boundary = GameObject.Find("BoundaryZone").GetComponent<BoundaryFollow>();
            boundary.farthestDistance = player.transform.position.x;
            speedUp = GameObject.Find("Player").GetComponent<PlayerSpeedUp>();
            speedUp.enabled = true;
            speedUp.countDown = 10f;
            player.maxSpeed = 3f;
            player.jumpTakeOffSpeed = 7f; 
            Score.scoreValue = 0;
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            playerController.points = 0;
        }
    }
}