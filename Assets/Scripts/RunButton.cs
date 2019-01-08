using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class RunButton : MonoBehaviour, IPointerClickHandler
{

    public float time;
    public int score;

    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        time = 15;
        score = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.simulating) {
            text.text = "Running....";
        } else {
            text.text = "Run!";
        }
    }

    public void OnPointerClick(PointerEventData pedata) {
        if(pedata.button == PointerEventData.InputButton.Left) {
            GameManager.SimulateLevel(time, score);
        }
    }
}
