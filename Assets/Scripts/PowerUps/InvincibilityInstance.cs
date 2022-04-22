using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;


namespace Platformer.Mechanics
{
    /// <summary>
    /// This class contains the data required for implementing token collection mechanics.
    /// It does not perform animation of the token, this is handled in a batch by the 
    /// TokenController in the scene.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class InvincibilityInstance : MonoBehaviour
    {
        public float colorTimeRemaining;
        public float colorTimer;
        public int changeColor;

        public AudioClip tokenCollectAudio;
        [Tooltip("If true, animation will start at a random position in the sequence.")]
        public bool randomAnimationStartTime = false;
        [Tooltip("List of frames that make up the animation.")]
        public Sprite[] idleAnimation, collectedAnimation;

        internal Sprite[] sprites = new Sprite[0];

        internal SpriteRenderer _renderer;

        //unique index which is assigned by the TokenController in a scene.
        internal int tokenIndex = -1;
        internal TokenController controller;
        //active frame in animation, updated by the controller.
        internal int frame = 0;
        internal bool collected = false;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            if (randomAnimationStartTime)
                frame = Random.Range(0, sprites.Length);
            sprites = idleAnimation;
        }

        void Update()
        {
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
                _renderer.color = new Color(1f, 0f, 0f);
            }
            else if (changeColor == 2)
            {
                _renderer.color = new Color(1f, 0.5f, 0f);
            }
            else if (changeColor == 3)
            {
                _renderer.color = new Color(1f, 1f, 0f);
            }
            else if (changeColor == 4)
            {
                _renderer.color = new Color(0f, 1f, 0f);
            }
            else if (changeColor == 5)
            {
                _renderer.color = new Color(0f, 0f, 1f);
            }
            else if (changeColor == 6)
            {
                _renderer.color = new Color(0.5f, 0f, 1f);
            }
            else
            {
                _renderer.color = new Color(1f, 1f, 1f);
                changeColor = 0;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            //only execute OnPlayerEnter if the player collides with this token.
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player != null) OnPlayerEnter(player);
        }

        void OnPlayerEnter(PlayerController player)
        {
            if (collected) return;
            //disable the gameObject and remove it from the controller update list.
            frame = 0;
            sprites = collectedAnimation;
            if (controller != null)
                collected = true;
            AudioSource.PlayClipAtPoint(this.tokenCollectAudio, this.transform.position);
            player.GetComponent<PlayerInvincibility>().powerUpTimer = 10f;
            player.GetComponent<PlayerInvincibility>().enabled = true;
            Destroy(this.gameObject);
        }
    }
}