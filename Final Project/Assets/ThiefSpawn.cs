using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefSpawn : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] points;
    
    int index,spawnPoint;
    Transform t;
    GameObject tvCam;

    // Start is called before the first frame update
    void Start()
    {
      t = this.GetComponent<Transform>();
      tvCam = this.transform.Find("TV Camera").gameObject;

      Random.seed = System.DateTime.Now.Millisecond;
      spawnPoint=Random.Range(0,4);
      t.position=points[spawnPoint].position;
      index = PlayerPrefs.GetInt("index",0); 
      GameObject go = Instantiate(prefabs[index], t.position, Quaternion.identity) as GameObject; 
      go.transform.parent = t;
      tvCam.transform.parent = go.transform; //THIS WILL GIVE ERRORS IF DON'T SELECT THIEF
      tvCam.transform.position = tvCam.transform.position + new Vector3(0.0f, 1.5f, -3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
