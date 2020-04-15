using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinObject : MonoBehaviour
{
    Transform t;
    float speed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        gameObject.GetComponent<Renderer>().material.color = new Color( 0.0f, 0.0f, Random.Range(.1f,.5f)); 
    }

    // Update is called once per frame
    void Update()
    {
        t.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
