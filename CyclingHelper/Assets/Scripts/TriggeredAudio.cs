using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(OneWayTrigger))]
    [AddComponentMenu("Triggered Audio")]
    public class TriggeredAudio : MonoBehaviour
    {
        public AudioSource audioSrc;

        private OneWayTrigger trigger;

        void Start()
        {
            trigger = GetComponent<OneWayTrigger>();
            trigger.Triggered += () =>
            {
                audioSrc.Play();
            };
        }
    }
}
