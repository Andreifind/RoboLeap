using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public float frequency;
    public float intensity;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.position = Vector2.up * Mathf.Cos(Time.time * frequency ) * intensity;
    }
}
