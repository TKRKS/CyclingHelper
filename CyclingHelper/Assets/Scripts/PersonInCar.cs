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
namespace Application
{
	public class PersonInCar : MonoBehaviour {
		public PersonInCar () {
		}

		void OnTriggerEnter(Collider collider) {
			if (collider.gameObject.name == "First Person Controller") {
				Debug.Log("Near a person car");
			}
		}
	}
}

