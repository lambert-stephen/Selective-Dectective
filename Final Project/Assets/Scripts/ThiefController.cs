  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThiefController : MonoBehaviour
{
    public float speed = 25f;
    public float rotationSpeed = 90;

    int selector = 0;
    int moving=0;
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

        if (Input.GetKey(KeyCode.UpArrow))//  && (rb.velocity.magnitude < maxFwdSpeed))
            {
            rb.velocity = this.transform.forward * 80f * Time.deltaTime;
            }
           /* 
        else if (Input.GetKey(KeyCode.DownArrow) )// && (rb.velocity.magnitude < maxBckSpeed))
            {
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;
            }
            */

        if (Input.GetKey(KeyCode.RightArrow))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.LeftArrow))
            t.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);

        if (selector >= 3)
        {
            SceneManager.LoadScene("Reveal");
        }

    }

    //Collide with object
    void OnCollisionEnter(Collision theCollision)
    {
        if(theCollision.gameObject.tag == "Steal_This")
        {
            CounterScript.scoreValue += 1;
            FindObjectOfType<AudioManager>().Play("Stolen");
            selector += 1;
            DestroyObject(theCollision.gameObject);
        } 
    }



}