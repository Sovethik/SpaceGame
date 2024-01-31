using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOb : MonoBehaviour {

    public float speed = 1;
    private int[] rotation = { -45, 45 };
    private int rot;

    private void Start()
    {
        rot = rotation[Random.Range(0, rotation.Length)];
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, rot) * speed * Time.deltaTime);
    }
}
