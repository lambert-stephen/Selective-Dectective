using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ignoreCollison : MonoBehaviour
{
// declare a field in your class
Collider collider;

    void Start()
    {
        // in your Start method
        collider = GetComponent<Collider>(); 
    }


    //Collide with object
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ignoreNPC")
        {
            Physics.IgnoreCollision(collision.collider, collider);
        }
    }
}
