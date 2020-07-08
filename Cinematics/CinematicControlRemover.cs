using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;



    public class CinematicControlRemover : MonoBehaviour
    {
        GameObject player;
        private void Start()
        {
            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().stopped += EnabaleControl;
            player= GameObject.FindWithTag("Player");


        }
        void DisableControl(PlayableDirector pd)
        {
            player.GetComponent<PlayerMovement>().enabled = false;

        }
        void EnabaleControl(PlayableDirector pd)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }


