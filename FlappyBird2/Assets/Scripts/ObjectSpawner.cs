using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Tooltip("The pipe prefab we will be spawning.")]
    public GameObject pipe;

    [Tooltip("The floor prefab we will be spawning.")]
    public GameObject floor;

    [Tooltip("The background prefab we will be spawning.")]
    public GameObject background;

    [Tooltip("The offset in world space that we will spawn a pipe prefab at.")]
    public Vector3 pipeOffset = new Vector3(15.2f, 0, 0);

    [Tooltip("The offset in world space that we will spawn a floor prefab at.")]
    public Vector3 floorOffset = new Vector3(15.2f, -5, 0);

    [Tooltip("The offset in world space that we will spawn a background prefab at.")]
    public Vector3 BackgroundOffset = new Vector3(14.3f, 0, 0);

    [Tooltip("The interval[In Seconds] between pipe prefab spawning. This will need to be modified depending on size of art assets.")]
    public float pipeSpawnTime = 1.4f;

    [Tooltip("The interval[In Seconds] between floor prefab spawning. This will need to be modified depending on size of art assets.")]
    public float floorSpawnTime = 4f;

    [Tooltip("The interval[In Seconds] between background prefab spawning. This will need to be modified depending on size of art assets.")]
    public float backgroundSpawnTime = 6f;

    [Tooltip("The max upwards Y position a pipe prefab can spawn.")]
    public float maxPipeHeight = 2.9f;

    [Tooltip("The min downwards Y position a pipe prefab can spawn.")]
    public float minPipeHeight = -1.8f;

    //The local time that has passed since the last spawn of a pipe prefab.
    private float pipeLocalTime;
    //The local time that has passed since the last spawn of a floor prefab.
    private float floorLocalTime;
    //The local time that has passed since the last spawn of a background prefab.
    private float backgroundLocalTime;

    private void Start()
    {
        //Set both the floor and background local times to their max values so that a new floor and background spawn.
        floorLocalTime = floorSpawnTime;
        backgroundLocalTime = backgroundSpawnTime;
    }

    void Update ()
    {
        //If the game is over or the game is not started, don't do anything.
        if (BirdController.gameOver || !BirdController.gameStarted) return;

        //Add the local intervals to track time in seconds passed.
        pipeLocalTime += Time.deltaTime;
        floorLocalTime += Time.deltaTime;
        backgroundLocalTime += Time.deltaTime;
        
        if (pipeLocalTime >= pipeSpawnTime)
        {
            //Set the local time to zero.
            pipeLocalTime = 0;
            //Instantiate a pipe prefab.
            Instantiate(pipe, pipeOffset + new Vector3(0, Random.Range(minPipeHeight, maxPipeHeight), 0), Quaternion.identity);
        }
        
        if (floorLocalTime >= floorSpawnTime)
        {
            //Set the local time to zero.
            floorLocalTime = 0;
            //Instantiate a floor prefab.
            Instantiate(floor, floorOffset, Quaternion.identity);
        }
        
        if (backgroundLocalTime >= backgroundSpawnTime && background != null)
        {
            //Set the local time to zero.
            backgroundLocalTime = 0;
            //Instantiate a background prefab.
            Instantiate(background, BackgroundOffset, Quaternion.identity);
        }
	}
}