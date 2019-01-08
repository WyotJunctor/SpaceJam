﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ComponentTriangle : MonoBehaviour {
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start () {
        print ("Shoop");
        rb = GetComponent<Rigidbody2D> ();
        rb.velocity += (Vector2)transform.localPosition.normalized * 10f;
    }
}
