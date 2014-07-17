using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [AddComponentMenu("Car")]
    public class Car : MonoBehaviour
    {
        public CarSpawner spawner { get; set; }

        // The spawner listens to this event so that it knows
        // when to stop keeping track of a car
        public event Action WasDestroyed;
        void OnDestroy()
        {
            if (WasDestroyed != null)
                WasDestroyed();
        }

        public void UpdateSpeedMultiplier(float newVal)
        {
            if (spawner != null)
                spawner.SpeedMultiplier = newVal;
            else
                gameObject.GetComponent<CarMoveSquare>().SpeedMultiplier = newVal;
        }
    }
}
