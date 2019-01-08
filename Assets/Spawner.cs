using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Spawner : MonoBehaviour {

    public GameObject[] shapes;
    public float speed = 1f;

    public Transform start;
    public Transform mid;
    public Transform end;

    public Vector3[] path;

    public int spawnNumber = 0;

    // Start is called before the first frame update
    void Start () {
        //if (!Application.isEditor) {
        spawnNumber = 0;
            UpdatePath ();
            InvokeRepeating ("Spawn", 0f, 1f);
        //}
    }

    private void Update () {
        //if (Application.isEditor) {
            UpdatePath ();
        //}
    }

    public void UpdatePath () {
        if (start && mid && end) {
            path = GetPath (start.position, mid.position, end.position, 40);
        }
    }

    void Spawn () {
        if (!Application.isPlaying)
            return;

        GameObject inst = Instantiate (shapes[spawnNumber++ % shapes.Length], start.position, Quaternion.identity);

        Shape shape = inst.GetComponent<Shape> ();
        if (shape) {
            shape.SetPath (path);
            shape.speed = speed;
        }
    }

    Vector3 GetPoint (Vector3 p0, Vector3 p1, Vector3 p2, float t) {
        return Vector3.Lerp (Vector3.Lerp (p0, p1, t), Vector3.Lerp (p1, p2, t), t);
    }

    Vector3[] GetPath (Vector3 p0, Vector3 p1, Vector3 p2, int resolution = 20) {
        Vector3[] path = new Vector3[resolution];
        for (int i = 0; i < resolution; i++) {
            path[i] = GetPoint (p0, p1, p2, (float)i / (resolution-1));
        }
        return path;
    }

    private void OnDrawGizmos () {
        if (start) {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere (start.position, 1f);
        }

        if (mid) {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere (mid.position, 1f);
        }

        if (end) {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere (end.position, 1f);
        }

        if (path.Length > 1) {
            Gizmos.color = Color.cyan;
            for (int i = 0; i < path.Length - 1; i++) {
                Gizmos.DrawLine (path[i], path[i + 1]);
            }
        }
    }
}
