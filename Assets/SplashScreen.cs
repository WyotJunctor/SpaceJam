using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    public static bool isPaused = false;

    public GameObject splashScreen;
    public GameObject pauseScreen;
    public TextMeshProUGUI message;
    public TextMeshProUGUI scoreShow;
    public TextMeshProUGUI highScoreText;
    public LevelChanger nextLevel;

    public static SplashScreen instance;

    private void Start() {
        if (instance) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }

    public void Pause() {
        if (isPaused) {
            Resume();
        }
        else {
            Stop();
        }
    }

    public void Resume() {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Stop() {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Splash(int score, int threshold, int oldHighScore) {
        bool success = score >= threshold;
        message.text = success ? "You win!" : "Not Quite There!";
        scoreShow.text = score + " / " + threshold;
        highScoreText.text = "Old High Score : " + oldHighScore;
        splashScreen.SetActive(true);
        nextLevel.gameObject.SetActive(success);
    }

    public void Retry() {
        Time.timeScale = 1f;
        GameManager.instance.Restart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() {
        Time.timeScale = 1f;
        Application.Quit();
    }

}
