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
	public class HUD : MonoBehaviour {

		public HUD () {
		}

		void OnStart() {
		}

		void OnGUI() {
			Vector3 pos = gameObject.transform.position;
			GUI.Box(new Rect(10,10,200,90), "Gui Test");
			GUI.Box(new Rect(20,40,180,20), + truncate(pos.x, 3) + "#" + truncate(pos.y, 3) + "#" + truncate(pos.z, 3)); 
		}

		public float truncate(float value, int digits) {
			double mult = Math.Pow(10.0, digits);
			double result = Math.Truncate( mult * value ) / mult;
			return (float) result;
		}
	}
}
