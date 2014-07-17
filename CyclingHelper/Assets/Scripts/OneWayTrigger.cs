using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [AddComponentMenu("One-Way Trigger")]
    public class OneWayTrigger : MonoBehaviour
    {
        public Axis movementAxis;
        public bool negativeDirection;

        // Fired when the user goes through the trigger the correct direction
        public event Action Triggered;

        private Vector3 enterPos, exitPos;
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name != "First Person Controller") return;

            enterPos = other.gameObject.transform.position;
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name != "First Person Controller") return;

            exitPos = other.gameObject.transform.position;

            float initialValue = movementAxis == Axis.X ? enterPos.x : enterPos.z;
            float finalValue = movementAxis == Axis.X ? exitPos.x : exitPos.z;

            // We only want to trigger in a certain direction, not both
            if (negativeDirection == finalValue < initialValue && Triggered != null)
                Triggered();
        }
    }
}
