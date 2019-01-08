using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayScore : MonoBehaviour {
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start () {
        text = GetComponent<TextMeshProUGUI> ();
    }

    // Update is called once per frame
    void Update () {
        if (text) {
            text.SetText (GameManager.score.ToString ());
        }
    }
}
