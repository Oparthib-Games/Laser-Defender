using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour {

    public void startGame(string name)
    {
        Application.LoadLevel(name);
    }
}
