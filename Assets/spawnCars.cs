using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCars : MonoBehaviour
{
    public Rigidbody carPrefab;
    public Transform barrelEnd;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("spawnCar", 3.0f, 5f);
    }
	
	// Update is called once per frame
	void spawnCar ()
    {
        Rigidbody carInstance;
        carInstance = Instantiate(carPrefab, new Vector3(80, 1, -420), Quaternion.Euler(0, 0, 0));
    }
}
