using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Shape : MonoBehaviour {

    public bool isOnPath;
    public bool affected;

    public float speed;

    public Vector3[] path;
    public int currentIndex;
    public int lastIndex;

    public Vector3 target;

    private Vector3 dampVel;

    Rigidbody2D rb;

    public void SetPath (Vector3[] _path) {
        //print ("Path length: " + _path.Length);
        path = _path;
        lastIndex = path.Length - 1;
    }

    // Start is called before the first frame update
    void Start () {
        currentIndex = 1;
        affected = true;
        isOnPath = true;
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update () {
        if (isOnPath && path.Length > 0) {
            if (currentIndex < lastIndex) {
                target = path[currentIndex];
                transform.up = Vector3.SmoothDamp (transform.up, (target - transform.position).normalized, ref dampVel, 0.3f);

                rb.velocity = (target - path[currentIndex - 1]).normalized * speed;

                if ((transform.position - target).sqrMagnitude < 0.01f) {
                    currentIndex++;
                    //print ("Next index!");
                }
            } else {
                Destroy (gameObject);
            }
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.collider.CompareTag ("Shape")) {
            isOnPath = false;
            if (affected) {
                print ("Gimme money");
                collision.collider.GetComponent<Shape> ().affected = true;
                GameManager.score += Mathf.RoundToInt (collision.relativeVelocity.sqrMagnitude / 10f);
            }
        }
    }
}
