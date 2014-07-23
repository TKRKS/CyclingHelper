using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [AddComponentMenu("Low Traffic Trigger")]
    public class LowTrafficTrigger : MonoBehaviour
    {
        public GameObject audioSrcObj;
        public float insideVolume, outsideVolume;

        private AudioSource audioSrc;

        void Awake()
        {
            audioSrc = audioSrcObj.GetComponent<AudioSource>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name != "First Person Controller") return;

            audioSrc.volume = insideVolume;
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name != "First Person Controller") return;

            audioSrc.volume = outsideVolume;
        }
    }
}
