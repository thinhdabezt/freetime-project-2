using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    //starting position for the parallax game object
    Vector2 startingPosition;

    //starting z value of the parallax game object
    float startingZ;

    //distance that the camera has move from the start position of the parallax object
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;


    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    //if the object new is in front of target, use nearClipPlane, if it behind the target, use farClipPlane
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    //the further the object from the player, the faster the ParallaxEffect object will move, drag its z value closer to make it move slower
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;

        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
