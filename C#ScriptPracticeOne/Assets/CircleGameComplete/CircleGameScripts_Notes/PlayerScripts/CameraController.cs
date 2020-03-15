using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject objectToFollow;

    public float speed = 2.0f;

    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);

        this.transform.position = position;
    }
}
/* public GameObject player;        //Public variable to store a reference to the player game object


 private Vector3 offset;            //Private variable to store the offset distance between the player and camera

 // Use this for initialization
 void Start()
 {
     //Calculate and store the offset value by getting the distance between the player's position and camera's position.
     offset = transform.position - player.transform.position;
 }

 // LateUpdate is called after Update each frame
 void LateUpdate()
 {
     // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
     transform.position = player.transform.position + offset;
 }
}*/
