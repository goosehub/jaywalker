using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCar : MonoBehaviour
{
    public float frequencyMin;
    public float frequencyMax;
    public float speed;
    public Vector3 startingPosition;
    public Quaternion startingRotation;
    public string carName;
    public bool bigCarsOnly;

    // Use this for initialization
    void Start ()
    {
        startingPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        startingRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);

        StartCoroutine(startSpawn());
    }

    // Update is called once per frame
    IEnumerator startSpawn()
    {
        while (true)
        {
            float respawnDelay = Random.Range(frequencyMin, frequencyMax);
            yield return new WaitForSeconds(respawnDelay);
            Spawn();
        }
    }

    void Spawn()
    {
        string carToUse = randomCar();
        if (bigCarsOnly)
        {
            carToUse = randomBigCar();
        }
        if (carName != null && carName != "")
        {
            carToUse = carName;
        }
        Rigidbody currentCarInstance = GameObject.Find(carToUse).GetComponent<Rigidbody>();
        Rigidbody newCarInstance = Instantiate(currentCarInstance, startingPosition, startingRotation);
        StartCoroutine(driveCar(newCarInstance));
    }

    // Update is called once per frame
    IEnumerator driveCar(Rigidbody newCarInstance)
    {
        while (true)
        {
            float driveFrequency = 0.1f;
            yield return new WaitForSeconds(driveFrequency);
            newCarInstance.velocity = transform.forward * (speed);
            destroyCarWhenOutOfScene(newCarInstance);
        }
    }

    void destroyCarWhenOutOfScene(Rigidbody newCarInstance)
    {
        if (
            newCarInstance.position.z > 1200
            || newCarInstance.position.z < -1200
            || newCarInstance.position.x > 1200
            || newCarInstance.position.x < -1200
            )
        {
            if (newCarInstance.name.Contains("Clone"))
            {
                Destroy(newCarInstance.gameObject);
            }
        }
    }

    string randomCar()
    {
        List<string> carList = new List<string>();
        carList.Add("cityBus");
        carList.Add("cityBus");
        carList.Add("cityBus");
        carList.Add("cityBus");
        carList.Add("cityBus");
        carList.Add("cityBus");
        carList.Add("cityBus");
        carList.Add("cityBus");
        carList.Add("cityBus");
        carList.Add("cityBus");
        carList.Add("redTruck");
        carList.Add("redTruck");
        carList.Add("redTruck");
        carList.Add("redTruck");
        carList.Add("redTruck");
        carList.Add("redTruck");
        carList.Add("yellowTruck");
        carList.Add("yellowTruck");
        carList.Add("yellowTruck");
        carList.Add("yellowTruck");
        carList.Add("yellowTruck");
        carList.Add("yellowTruck");
        carList.Add("sportsCar");
        carList.Add("sportsCar");
        carList.Add("sportsCar");
        carList.Add("sportsCar");
        carList.Add("sportsCar");
        carList.Add("sportsCar");
        carList.Add("schoolBus");
        carList.Add("schoolBus");
        carList.Add("schoolBus");
        carList.Add("cop");
        carList.Add("cop");
        carList.Add("cop");
        carList.Add("taxi");
        carList.Add("taxi");
        carList.Add("taxi");
        carList.Add("garbageTruck");
        carList.Add("garbageTruck");
        carList.Add("garbageTruck");
        carList.Add("ambulance");
        carList.Add("ambulance");
        carList.Add("ambulance");
        carList.Add("fireTruck");
        carList.Add("iceCreamTruck");
        System.Random rnd = new System.Random();
        string randomCar = carList[rnd.Next(carList.Count)];
        return randomCar;
    }

    string randomBigCar()
    {
        List<string> carList = new List<string>();
        carList.Add("fireTruck");
        carList.Add("schoolBus");
        carList.Add("schoolBus");
        carList.Add("garbageTruck");
        carList.Add("garbageTruck");
        carList.Add("garbageTruck");
        carList.Add("garbageTruck");
        carList.Add("yellowTruck");
        carList.Add("yellowTruck");
        carList.Add("yellowTruck");
        carList.Add("yellowTruck");
        carList.Add("yellowTruck");
        carList.Add("yellowTruck");
        carList.Add("redTruck");
        carList.Add("redTruck");
        carList.Add("redTruck");
        carList.Add("redTruck");
        carList.Add("redTruck");
        carList.Add("redTruck");
        carList.Add("redTruck");
        carList.Add("redTruck");
        carList.Add("redTruck");
        carList.Add("redTruck");
        System.Random rnd = new System.Random();
        string randomCar = carList[rnd.Next(carList.Count)];
        return randomCar;
    }
}
