using System;
using UnityEngine;

namespace Assets.Scripts 
{
	public class BikeChainSound : MonoBehaviour 
    {
		CharacterController controller;

		void Start() 
        {
			controller = gameObject.GetComponent<CharacterController>();
		}

		void Update() 
        {
			gameObject.audio.volume = controller.velocity.magnitude.Remap(0, 3, 0, .05f);
		}
	}
}

