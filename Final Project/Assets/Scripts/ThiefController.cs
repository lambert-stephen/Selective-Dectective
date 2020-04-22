  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThiefController : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 90;

    int selector = 0;
    int moving=0;
    Rigidbody rb;
    Transform t;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        t = this.GetComponent<Transform>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))//  && (rb.velocity.magnitude < maxFwdSpeed))
            {
            rb.velocity = this.transform.forward * 80f * Time.deltaTime;
            animator.enabled=true;
            }
           /* 
        else if (Input.GetKey(KeyCode.DownArrow) )// && (rb.velocity.magnitude < maxBckSpeed))
            {
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;
            }
            */
        else 
        {
            animator.enabled=false;
        }    

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
            FindObjectOfType<AudioManager>().Play("Stolen");
            selector += 1;
            DestroyObject(theCollision.gameObject);
        } 
    }



}