using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public static int score;

    private void Start () {
        if (instance) {
            Destroy (this);
        } else {
            instance = this;
        }
    }

    private void Update () {

    }

    public static void AddToScore (int addition) {
        score += addition;
    }
}
