﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomies : MonoBehaviour {
    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag ("Shape")) {
            if (collision.GetComponent<Rigidbody2D> ()) {
                collision.GetComponent<Rigidbody2D> ().velocity *= 1.5f;
            }
        }
    }
}
