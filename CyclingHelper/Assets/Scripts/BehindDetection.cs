using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets;

namespace Assets.Scripts 
{
	public class BehindDetection : MonoBehaviour 
    {
        public GameObject audioSrcObj;
		public AudioSource ambientSound;
		private AudioSource alertSound;
        private HashSet<GameObject> cars;
        private GameObject player;

		void Start()
        {
            cars = new HashSet<GameObject>();
            player = GameObject.Find("First Person Controller");
            alertSound = audioSrcObj.GetComponent<AudioSource>();
		}

        // a) Slow cars down that are about to run player over
        // b) Adjust pitch of warning sound based on how close nearest car is
		void Update()
        {
            if (cars.Count > 0)
            {
                GameObject closestCar = cars.MinBy(car => DistToPlayer(car));
                var c = closestCar.GetComponent<Car>();
                float closestCarDistance = DistToPlayer(closestCar);

                c.UpdateSpeedMultiplier(closestCarDistance < 15 ? closestCarDistance.Remap(0, 15, 0, 1) : 1);
                alertSound.pitch = closestCarDistance >= 15 ? .1f : 1.4f - closestCarDistance.Remap(0, 15, 0.5f, 1.3f);
				ambientSound.pitch = cars.Count > 4 ? 1.5f : ((float) cars.Count).Remap(0f, 4f, .5f, 1.5f);
			}
            else
            {
                alertSound.pitch = .1f;
				ambientSound.pitch = .5f;
			}
		}

        float DistToPlayer(GameObject car)
        {
            return Vector3.Distance(car.transform.position, player.transform.position);
        }

		void OnTriggerEnter(Collider collider)
        {
            var gameObj = collider.gameObject;

			if (gameObj.GetComponent<Car>() != null)
            {
                cars.Add(gameObj);
            }
		}

		void OnTriggerExit(Collider collider)
        {
            var gameObj = collider.gameObject;
            Car car;

            if ((car = gameObj.GetComponent<Car>()) != null)
            {
                cars.Remove(gameObj);
                car.UpdateSpeedMultiplier(1);
            }
		}
	}
}

