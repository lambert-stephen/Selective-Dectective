using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefSpawn : MonoBehaviour
{
     public GameObject[] prefabs;
     int index;
     Transform t;

    // Start is called before the first frame update
    void Start()
    {
      t = this.GetComponent<Transform>();
      index = PlayerPrefs.GetInt("index",0); 
      GameObject go = Instantiate(prefabs[index], t.position, Quaternion.identity) as GameObject; 
      go.transform.parent = t;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
