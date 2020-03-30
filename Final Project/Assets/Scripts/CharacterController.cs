﻿  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterController : MonoBehaviour
{
    public float speed = 25.0f;
    public float rotationSpeed = 90;
	
	private float maxFwdSpeed = 10f;
    private float maxBckSpeed = 5f;

    Rigidbody rb;
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T) && (rb.velocity.magnitude < maxFwdSpeed))
            rb.velocity += this.transform.forward * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.G) && (rb.velocity.magnitude < maxBckSpeed))
        {
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.H))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.F))
            t.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);
    }
}