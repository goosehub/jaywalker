using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour {

    public player_movement movement;

    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log(collision.collider.tag);
            // movement.enabled = false;
        }
    }
}
