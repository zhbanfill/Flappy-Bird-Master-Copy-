using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [Tooltip("`Text` is the text object we will be displaying score to.")]
    public Text text;

	void Update ()
    {
        //Updates the text objects text field with the score we currently have.
        text.text = BirdController.scoreDisplay;
	}
}