using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [Tooltip("The moving speed of this object.")]
    public float scrollSpeed = 0.07f;

    void Update ()
    {
        //Don't move if the games over, or the game has not started.
        if (BirdController.gameOver || !BirdController.gameStarted) return;

        //Add to the leftward position, multiplied by the scroll speed to allow for speed manipulation.
        transform.position += Vector3.left * scrollSpeed;
	}
}