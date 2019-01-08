using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public static Portal lastPortal;

    public Portal pair;

    public float teleportCD = 0f;
    public float maxTeleportCD = 0.01f;

    // Start is called before the first frame update
    void Start () {
        if (lastPortal != null) {
            transform.up = -transform.up;
            pair = lastPortal;
            lastPortal.pair = this;
            lastPortal = null;
        } else {
            lastPortal = this;
        }
    }

    private void Update () {
        if (teleportCD > 0f) {
            teleportCD -= Time.deltaTime;
        } else {
            teleportCD = 0f;
        }
    }

    void TeleportToPair (Transform t) {
        if (!pair || teleportCD > 0f)
            return;

        t.position = pair.transform.position;
        teleportCD = maxTeleportCD;
        pair.teleportCD = pair.maxTeleportCD;
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag ("Shape") && collision.GetComponent<Rigidbody2D>()) {
            TeleportToPair (collision.transform);
        }
    }
}
