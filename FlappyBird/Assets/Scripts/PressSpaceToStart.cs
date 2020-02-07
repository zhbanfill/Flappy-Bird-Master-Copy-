using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceToStart : MonoBehaviour
{
    [Tooltip("The player objects rigidbody 2D component.")]
    public Rigidbody2D player;

    void Update ()
    {
        //If we press the space key, start the game.
		if(Input.GetKeyDown(KeyCode.Space))



        {
            BirdController.gameStarted = true;
            player.bodyType = RigidbodyType2D.Dynamic;
            Destroy(gameObject);
        }
	}
}
