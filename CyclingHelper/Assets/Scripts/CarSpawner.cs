using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [AddComponentMenu("Car Spawner")]
    public class CarSpawner : MonoBehaviour
    {
        public Axis axisToTravel;
        public GameObject carPrefab;
        public float carSpeed = 0.1f;
        public float spawnDelay = 5;
        public float initialDelay = 0;

        // Slows down cars if they catch up to the player
        // (not exposed to Unity editor but settable by other scripts)
        public float SpeedMultiplier { get; set; }

        private float elapsedTime;
        private bool hasSpawned;
        private HashSet<GameObject> spawnedCars;

        void Start()
        {
            hasSpawned = false;
            spawnedCars = new HashSet<GameObject>();
            SpeedMultiplier = 1;
        }

        void Update()
        {
            elapsedTime += Time.deltaTime;

            if (!hasSpawned && elapsedTime >= initialDelay || elapsedTime >= spawnDelay)
                SpawnCar();

            // Move all cars that this spawner is responsible for
            float finalSpeed = carSpeed * SpeedMultiplier;
            foreach (var car in spawnedCars)
            {
                car.gameObject.transform.Translate(
                    x: axisToTravel == Axis.X ? finalSpeed : 0,
                    y: axisToTravel == Axis.Y ? finalSpeed : 0,
                    z: axisToTravel == Axis.Z ? finalSpeed : 0,
                    relativeTo: Space.World);
            }
        }

        void SpawnCar()
        {
            Quaternion rotation = axisToTravel == Axis.Z 
                ? Quaternion.identity 
                : Quaternion.Euler(0, 90, 0);

            // Instantiate a new car
            var newCar = Instantiate(carPrefab, transform.position, rotation) as GameObject;
			            
            // Keep track of cars we're responsible for, and remove them when they are destroyed
            var carScript = newCar.GetComponent<Car>();
            spawnedCars.Add(newCar);
            carScript.WasDestroyed += () => spawnedCars.Remove(newCar);
            carScript.spawner = this;

            // Reset tracking variables
            elapsedTime = 0;
            hasSpawned = true;
        }
    }
}
