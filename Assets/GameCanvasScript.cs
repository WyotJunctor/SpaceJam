using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasScript : MonoBehaviour
{
    public static GameCanvasScript instance;

    private void Start() {
        if (instance) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
