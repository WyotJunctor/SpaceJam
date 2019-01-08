﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Text))]
public class RunButton : MonoBehaviour, IPointerClickHandler
{

    public float time;
    public int score;

    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
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