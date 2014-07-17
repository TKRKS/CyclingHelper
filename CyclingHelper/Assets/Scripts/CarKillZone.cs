using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [AddComponentMenu("Car Kil Zone")]
    public class CarKillZone : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Car>() != null)
                Destroy(other.gameObject);
        }
    }
}
