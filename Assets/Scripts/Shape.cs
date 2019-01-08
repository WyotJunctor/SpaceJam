using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShapeType { square, rectangle, circle, triangle, hexagon, }

[RequireComponent(typeof(Rigidbody2D))]
public class Shape : MonoBehaviour {

    public ShapeType type;

    public bool isOnPath;
    public bool affected;

    public float speed;

    public Vector3[] path;
    public int currentIndex;
    public int lastIndex;

    public Vector3 target;

    private Vector3 dampVel;

    public Transform subcomponent;

    public float health = 30f;

    Rigidbody2D rb;

    public void SetPath (Vector3[] _path) {
        //print ("Path length: " + _path.Length);
        path = _path;
        transform.up = (path[1] - path[0]).normalized;
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
    void FixedUpdate () {
        if (isOnPath && path.Length > 0) {
            float t = 0f;
            if (currentIndex < lastIndex) {
                target = path[currentIndex];
                transform.up = Vector3.SmoothDamp (transform.up, (target - transform.position).normalized, ref dampVel, 0.3f);

                rb.velocity = (target - path[currentIndex - 1]).normalized * speed;

                if ((transform.position - target).magnitude < 2 * speed * Time.fixedDeltaTime) {
                    rb.position = target;
                    currentIndex++;
                }
            } else {
                Destroy (gameObject);
            }
        }

        if (transform.position.magnitude > 20 || health < 0f) {
            Destroy (gameObject);
        }
    }

    IEnumerator IncreaseAngularVelocity () {
        if (!affected) {
            float direction = Mathf.Sign (rb.angularVelocity);
            while (true) {
                rb.angularVelocity += direction * 30f * Time.deltaTime;
                yield return new WaitForEndOfFrame ();
            }
        }
    }

    IEnumerator IncreaseScale () {
        if (!affected) {
            while (transform.localScale.x < 3f) {
                transform.localScale += Vector3.one * 0.5f * Time.deltaTime;
                yield return new WaitForEndOfFrame ();
            }
        }
    }

    IEnumerator IncreaseVelocity () {
        if (!affected) {
            Vector2 direction = rb.velocity.normalized;
            while (true) {
                rb.velocity += direction * Time.deltaTime;
                yield return new WaitForEndOfFrame ();
            }
        }
    }

    void BreakIntoSubcomponents () {
        //if (affected)
            //return;

        if (transform.childCount == 0)
            return;

        subcomponent.SetParent (null);
        subcomponent.gameObject.SetActive (true);

        Destroy (gameObject);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.collider.CompareTag ("Shape")) {
            isOnPath = false;
            if (affected) {
                collision.collider.GetComponent<Shape> ().affected = true;
                GameManager.score += Mathf.RoundToInt (collision.relativeVelocity.magnitude / 4f);
                health -= collision.relativeVelocity.magnitude;

                switch (type) {
                    case ShapeType.square:
                        float x = rb.velocity.x;
                        float y = rb.velocity.y;

                        Vector2 targetVel;
                        if (Mathf.Abs (x) > Mathf.Abs (y)) {
                            targetVel = new Vector2 (x, 0f).normalized * 5f;
                        } else {
                            targetVel = new Vector2 (0f, y).normalized * 5f;
                        }

                        rb.velocity = targetVel; 
                        break;

                    case ShapeType.rectangle:
                        StartCoroutine (IncreaseAngularVelocity ());
                        break;
                    case ShapeType.circle:
                        StartCoroutine (IncreaseScale ());
                        break;
                    case ShapeType.triangle:
                        StartCoroutine (IncreaseVelocity ());
                        break;
                    case ShapeType.hexagon:
                        BreakIntoSubcomponents ();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        isOnPath = false;
    }
}
