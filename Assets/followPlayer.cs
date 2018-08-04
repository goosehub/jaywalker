using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
    public float cameraDistance = 5.0f;
	
    void Update()
    {
        transform.position = player.transform.position - player.transform.forward * cameraDistance;
        transform.LookAt(player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
    }
}
