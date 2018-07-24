using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCars : MonoBehaviour
{
    public Rigidbody carInstance;
    public float spawnFrequency = 4.0f;
    public Vector3 startingPosition;
    public Quaternion startingRotation;
    // public Vector3 startingPositionOriginal;
    // public Vector3 startingRotationOriginal;

    // Use this for initialization
    void Start ()
    {
        startingPosition = new Vector3(carInstance.position.x, carInstance.position.y, carInstance.position.z);
        startingRotation = new Quaternion(carInstance.rotation.x, carInstance.rotation.y, carInstance.rotation.z, carInstance.rotation.w);
        if (!gameObject.name.Contains("Clone"))
        {
            InvokeRepeating("spawnCar", spawnFrequency, spawnFrequency);
        }
        // invokeSpawnCars(startingPosition, startingRotation);
    }

    private void Update()
    {
        if (
            carInstance.position.z > 1000
            || carInstance.position.z < -1000
            || carInstance.position.x > 1000
            || carInstance.position.x < -1000
            )
        {
            Destroy(gameObject);
        }
    }

    void invokeSpawnCars(Vector3 startingPositionOriginal, Quaternion startingRotationOriginal)
    {
        // Rigidbody newCarInstance;
        // CarInstance = Instantiate(this.carInstance, startingPosition, startingRotation);
    }

    void spawnCar ()
    {
        Rigidbody newCarInstance;
        newCarInstance = Instantiate(this.carInstance, startingPosition, startingRotation);
    }
}
