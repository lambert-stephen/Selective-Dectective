  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ThiefController : MonoBehaviour
{
    public float speed = 2f;
    public float rotationSpeed = 90;
	
	private float maxFwdSpeed = 2f;
    private float maxBckSpeed = 1f;

    Rigidbody rb;
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        t = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("[5]") )//&& (rb.velocity.magnitude < maxFwdSpeed))
            rb.velocity += this.transform.forward * speed * Time.deltaTime;
        else if (Input.GetKey("[2]") )// && (rb.velocity.magnitude < maxBckSpeed))
        {
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey("[3]"))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey("[1]"))
            t.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);

    }

    //Collide with object
    void OnCollisionEnter(Collision theCollision)
    {
        if(theCollision.gameObject.tag == "Steal_This")
        {
            FindObjectOfType<AudioManager>().Play("Stolen");
            DestroyObject(theCollision.gameObject);
        } 
    }



}