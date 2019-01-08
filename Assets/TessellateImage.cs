using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessellateImage : MonoBehaviour {
    Material mat;
    public Vector2 offset;
    private Vector2 currentOffset;

    public float translateSpeed = 1f;

    // Start is called before the first frame update
    void Start () {
        mat = GetComponent<Renderer> ().sharedMaterial;
        currentOffset = Vector2.zero;
    }

    // Update is called once per frame
    void Update () {
        print (mat.mainTextureOffset);
        mat.SetTextureOffset ("_MainTex", currentOffset);
        currentOffset += offset.normalized * translateSpeed * Time.deltaTime;
    }
}
