using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public static int score;

    public static bool simulating = false;

    public GameObject splashscreen;
    public Text message;
    public Text scoreShow;
    public LevelChanger nextLevel;

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

    public static void SimulateLevel(float forTime, int threshold) {
        if(simulating) {
            instance.StartCoroutine(instance.RunLevel(forTime, threshold));
        }
    }

    IEnumerator RunLevel(float timeLimit, int threshold) {

        //activate objects
        simulating = true;
        score = 0;

        yield return new WaitForSeconds(timeLimit);

        //deactivate objects
        simulating = false;
        SplashScreen(score, threshold);
    }

    void SplashScreen(int score, int threshold) {
        bool success = score >= threshold;
        message.text = success ? "You win!" : "Not Quite There!";
        scoreShow.text = score + " / " + threshold;
        splashscreen.SetActive(true);
        nextLevel.gameObject.SetActive(success);
    }
}
