using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public static int score;

    public static bool simulating = false;

    public List<Collider2D> tools = new List<Collider2D>();

    private void Start () {
        if (instance) {
            Destroy (gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update () {
        if (Input.GetKeyDown(KeyCode.P) && simulating) {
            SplashScreen.instance.Pause();
        }
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

        foreach (Collider2D collider in tools) {
            collider.enabled = true;
        }
        simulating = true;
        score = 0;

        yield return new WaitForSeconds(timeLimit);

        simulating = false;

        //Fetch old high score
        int highscore = 0;
        if(PlayerPrefs.HasKey("level")) {
            int level = PlayerPrefs.GetInt("level");
            if(PlayerPrefs.HasKey("score" + level)) {
                highscore = PlayerPrefs.GetInt("score" + level);
            }
            if(score > highscore) {
                PlayerPrefs.SetInt("score" + level, score);
            }
        } else {
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.SetInt("score1", score);
        }

        PlayerPrefs.Save();

        Time.timeScale = 0f;
        SplashScreen.instance.Splash(score, threshold, highscore);
    }
}
