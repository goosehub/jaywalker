using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCars : MonoBehaviour
{
    public Rigidbody carInstance;
    public float spawnFrequency = 4.0f;
    public Vector3 startingPosition;
    public Quaternion startingRotation;

    // Use this for initialization
    void Start ()
    {
        startingPosition = new Vector3(carInstance.position.x, carInstance.position.y, carInstance.position.z);
        startingRotation = new Quaternion(carInstance.rotation.x, carInstance.rotation.y, carInstance.rotation.z, carInstance.rotation.w);
        if (!gameObject.name.Contains("Clone"))
        {
            InvokeRepeating("spawnCar", spawnFrequency, spawnFrequency);
        }
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
            if (gameObject.name.Contains("Clone"))
            {
                Destroy(gameObject);
            }
        }
    }

    void spawnCar ()
    {
        Rigidbody newCarInstance;
        newCarInstance = Instantiate(this.carInstance, startingPosition, startingRotation);
    }
}
