using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    public Sprite noMedal;
    public Sprite bronzeMedal;
    public Sprite silverMedal;
    public Sprite goldMedal;

    public Image medal;
    public Text highscoreText;

    public GameObject loseWindow;

    public AudioClip[] buttonclips;
    public RandomContainer randCont;

    void Update ()
    {
        loseWindow.SetActive(BirdController.gameOver);

        //Assign badges and show the highscore at the end of the game.
        if(loseWindow.activeSelf)
        {
            highscoreText.text = BirdController.highscoreDisplay;

            if (BirdController.score < 5)
                medal.sprite = noMedal;
            else if (BirdController.score < 10)
                medal.sprite = bronzeMedal;
            else if (BirdController.score <= 20)
                medal.sprite = silverMedal;
            else
                medal.sprite = goldMedal;
        }

        if(BirdController.score > BirdController.highestScore)
        {
            BirdController.highestScore = BirdController.score;
        }
	}

    public void ResetGame()
    {
        randCont.clips = buttonclips;

        randCont.PlaySound(false);

        //Reload the scene.
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}