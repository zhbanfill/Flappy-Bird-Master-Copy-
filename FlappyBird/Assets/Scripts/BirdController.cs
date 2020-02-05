using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    //Indicates if the game has started.
    public static bool gameStarted = false;

    //Indicates if the game is over.
    public static bool gameOver = false;

    //Our score for this play session.
    public static int score = 0;

    //Our highest score obtained.
    public static int highestScore = 0;

    //Returns the score as a string.
    public static string scoreDisplay
    {
        get
        {
            return score.ToString();
        }
    }

    //Returns the high score as a string.
    public static string highscoreDisplay
    {
        get
        {
            return highestScore.ToString();
        }
    }

    [Tooltip("`Jump Height` is how high our bird will go up when the `Jump Key` is pressed")]
    public float jumpHeight = 350.0f;

    [Tooltip("`Gravity Scale` is how much we will modify the gravity for this object against the current gravity in the physics settings.")]
    public float gravityScale = 1.0f;

    [Tooltip("`Animator` is the animator we want to link our trigger animations to. If you leave this field empty you will recieve an error.")]
    public Animator animator;

    [Tooltip("`Rigidbody 2D` is the Rigidbody we want to link our physics to. If you leave this field empty you will recieve an error.")]
    public new Rigidbody2D rigidbody2D;

    [Tooltip("`Jump Key` is the key that will make us do a `jump` when pressed.")]
    public KeyCode jumpKey = KeyCode.Space;

    [Tooltip("`Death Layer` is the layer our bird will be set to when it dies, this allows us to change physics against certain objects when we die.")]
    public int deathLayer = 10;

    private void Start()
    {
        //Indicate we have not started and the game is not over yet.
        gameStarted = false;
        gameOver = false;

        //Sets the static score to 0 so that score does not carry over on reload of this scene.
        score = 0;
    }

    void Update ()
    {
        Application.targetFrameRate = 60;

        //If the game is over or the game has not started, don't apply physics.
        if (gameOver || !gameStarted) return;

        if (Input.GetKeyDown(jumpKey))
        {
            //Sets the rotation of our object to 20 degrees, the slerp at the bottom of this function will be what tilts us back down.
            transform.rotation = Quaternion.Euler(0, 0, 20f);

            //Sets the Rigidbody to a zero velocity.
            rigidbody2D.velocity = Vector2.zero;

            //Adds an upwards force.
            rigidbody2D.AddForce(Vector2.up * jumpHeight);

            //Attemps to do a jump animation on our set animator.
            if (animator)
            {
                try
                {
                    //Sets the jump trigger on the animator.
                    animator.SetTrigger("Jump");
                }
                catch (System.Exception ex) //Catches if the triggers are not set correctly.
                {
                    Debug.LogError("You have not configured your animator trigger event correctly. Please make sure you have a `jump` trigger or modify this code.");
                }
            }
            else Debug.LogError("You have no attached an animator to your BirdController or have not set the property. Please make sure you have one or you will not have working animations.");
        }

        //Apply downwards gravity.
        rigidbody2D.AddForce(Physics2D.gravity * gravityScale);
        //Modify the rotation of our player to be a -32 degrees on the Z-axis
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -32f), 0.05f);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Indicate the game is over.
        gameOver = true;
        //Change our game objects layer to the death layer.
        gameObject.layer = deathLayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When we enter a trigger region, add a point.
        ++score;
        //Destroy the score object so we don't rescore some how.
        Destroy(collision.gameObject);
    }
}