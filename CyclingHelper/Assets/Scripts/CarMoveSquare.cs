// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;

namespace Application {
	public class CarMoveSquare : MonoBehaviour {
		
		public bool MoveX;
		public float NorthWestPosition;
		public float NorthEastPosition;
		public float SouthEastPosition;
		public float SouthWestPosition;
		public float Speed;
		
		public CarMoveSquare () {
		}
		
		void Update() {
			Vector3 currentPosition = gameObject.transform.position;
			if (MoveX) {
				currentPosition.x = currentPosition.x + Speed;
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
				currentPosition.z = currentPosition.z + Speed;
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



