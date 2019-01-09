using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Autoloader : MonoBehaviour
{

    public bool LoadOnStart;
    // Start is called before the first frame update
    void Start()
    {
        if(LoadOnStart) {
            LoadLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Submit") > 0) {
            LoadLevel();
        }
        else if (Input.GetKeyDown(KeyCode.R)) {
            {
                PlayerPrefs.SetInt("level", 1);
                PlayerPrefs.Save();
            }
        }
    }

    public void LoadLevel() {
        int level = 1;
        if(PlayerPrefs.HasKey("level")) {
            level = PlayerPrefs.GetInt("level");
        } else {
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene("Level" + level);
    }
}
