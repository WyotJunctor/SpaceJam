using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public void OnSelect(PointerEventData pedata) {
        if (pedata.button == PointerEventData.InputButton.Left) {
            if(!PlayerPrefs.HasKey("level")) {
                PlayerPrefs.SetInt("level", 1);
            }

            int currentLevel = PlayerPrefs.GetInt("level");
            int nextLevel = currentLevel + 1;
            PlayerPrefs.SetInt("level", nextLevel);
            PlayerPrefs.Save();
            Time.timeScale = 1f;
            SceneManager.LoadScene("Level" + nextLevel);
        }
    }
}
