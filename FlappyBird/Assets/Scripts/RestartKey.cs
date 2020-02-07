﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartKey : MonoBehaviour
{
    public KeyCode restartKey = KeyCode.R;

    void Update()
    {
        if(Input.GetKeyDown(restartKey))
        {
      




            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
