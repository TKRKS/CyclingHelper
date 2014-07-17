using System;
using UnityEngine;

namespace Assets.Scripts
{
	public class CarMoveSquare : MonoBehaviour
    {
		public bool MoveX;
		public float NorthWestPosition;
		public float NorthEastPosition;
		public float SouthEastPosition;
		public float SouthWestPosition;
		public float Speed;

        public float SpeedMultiplier { get; set; }

        void Start()
        {
            SpeedMultiplier = 1;
        }
		
		void Update() 
        {
            float finalSpeed = SpeedMultiplier * Speed;

			Vector3 currentPosition = gameObject.transform.position;
			if (MoveX) {
                currentPosition.x = currentPosition.x + finalSpeed;
				if (Speed > 0) {
					if (currentPosition.x > SouthEastPosition) {
						gameObject.transform.Rotate(new Vector3(0,90,0));
						MoveX = false;
						Speed = Speed * -1;
					}
				} else {
					if (currentPosition.x < NorthWestPosition) {
						gameObject.transform.Rotate(new Vector3(0,90,0));
						MoveX = false;
						Speed = Speed * -1;
					}
				}
			} else {
                currentPosition.z = currentPosition.z + finalSpeed;
				if (Speed > 0) {
					if (currentPosition.z > NorthEastPosition) {
						gameObject.transform.Rotate(new Vector3(0,90,0));
						MoveX = true;
					}
				} else {
					if (currentPosition.z < SouthWestPosition) {
						gameObject.transform.Rotate(new Vector3(0,90,0));
						MoveX = true;
					}
				}
			}
			gameObject.transform.position = currentPosition;
		}
	}
}



