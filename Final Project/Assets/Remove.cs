using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    int index;
    
    // Start is called before the first frame update
    void Start()
    {
       index = PlayerPrefs.GetInt("index", 99); 
       Transform child = this.transform.GetChild(index);
       child.parent = null;
    Destroy(child.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
