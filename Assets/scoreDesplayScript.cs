using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDesplayScript : MonoBehaviour {

	void Start () {
        Text scoreDesplayText = GetComponent<Text>();

        scoreDesplayText.text = scoreScript.score.ToString();

        scoreScript.Reset();
	}
}
