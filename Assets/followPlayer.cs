using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
    public float cameraDistance = 5.0f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }
    void LateUpdate()
    {
        transform.position = player.transform.position - player.transform.forward * cameraDistance;
        transform.LookAt(player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
    }
}
