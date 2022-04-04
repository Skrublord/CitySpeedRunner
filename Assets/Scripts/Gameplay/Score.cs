using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Model;
using Platformer.Core;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{
    public class Score : MonoBehaviour
    {
        public static int scoreValue;
        Text score;


        // Start is called before the first frame update
        void Start()
        {
            scoreValue = 0;
            score = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            PlayerPrefs.SetInt("score", scoreValue);
            score.text = "Score: " + scoreValue;
        }
    }
}