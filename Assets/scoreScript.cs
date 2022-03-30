using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {

    int point = 100;
    public static int score = 0;
    Text scoreAsText;

    void Start()
    {
        scoreAsText = GetComponent<Text>();
        Reset();
    }

    public void ScoreAPoint()
    {
        score += point;
        scoreAsText.text = score.ToString();
    }
    public static void Reset()
    {
        score = 0;
    }

}
