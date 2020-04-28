using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reveal : MonoBehaviour 
{
    int r;
    int[] index = new int[4];
    public GameObject[] prefabs;
    public Transform[] points; 
    

    

 
    void Start()
    {
        int playerindex = PlayerPrefs.GetInt("index",0); 
        Random.seed = System.DateTime.Now.Millisecond;
        int n=Random.Range(0,3);

        while (true)
        {
            r=Random.Range(0,25);
            if(r!=playerindex)
            {
                index[0]=r;
                break;
            }
        }
        
        while (true)
        {
            r=Random.Range(0,25);
            if(r!=index[0] && r!=playerindex)
            {
                index[1]=r;
                break;
            }
        }
        while (true)
        {
            r=Random.Range(0,25);
            if(r!=index[0] && r!=index[1] && r!=playerindex)
            {
                index[2]=r;
                break;
            }
        }
        while (true)
        {
            r=Random.Range(0,25);
            if(r!=index[0] && r!=index[1] && r!=index[2] && r!=playerindex)
            {
                index[3]=r;
                break;
            }
        }
        index[n]=playerindex;
        
        if(n==0)
        {
        Instantiate(prefabs[index[0]], points[0].position, Quaternion.Euler(new Vector3(0, 180, 0)));
        GameObject clone=Instantiate(prefabs[index[1]], points[1].position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject; 
        clone.gameObject.tag = "NPC";
        GameObject clone2=Instantiate(prefabs[index[2]], points[2].position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
        clone2.gameObject.tag = "NPC";
        GameObject clone3=Instantiate(prefabs[index[3]], points[3].position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
        clone3.gameObject.tag = "NPC";
        }

        if(n==1)
        {
        GameObject clone=Instantiate(prefabs[index[0]], points[0].position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
        clone.gameObject.tag = "NPC";
        Instantiate(prefabs[index[1]], points[1].position, Quaternion.Euler(new Vector3(0, 180, 0)));
        GameObject clone2=Instantiate(prefabs[index[2]], points[2].position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
        clone2.gameObject.tag = "NPC";
        GameObject clone3=Instantiate(prefabs[index[3]], points[3].position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
        clone3.gameObject.tag = "NPC";
        }

        if(n==2)
        {
        GameObject clone=Instantiate(prefabs[index[0]], points[0].position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
        clone.gameObject.tag = "NPC";
        GameObject clone2=Instantiate(prefabs[index[1]], points[1].position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
        clone2.gameObject.tag = "NPC";
        Instantiate(prefabs[index[2]], points[2].position, Quaternion.Euler(new Vector3(0, 180, 0)));
        GameObject clone3=Instantiate(prefabs[index[3]], points[3].position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
        clone3.gameObject.tag = "NPC";
        }
        if(n==3)
        {
        GameObject clone=Instantiate(prefabs[index[0]], points[0].position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
        clone.gameObject.tag = "NPC";
        GameObject clone2=Instantiate(prefabs[index[1]], points[1].position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
        clone2.gameObject.tag = "NPC";
        GameObject clone3=Instantiate(prefabs[index[2]], points[2].position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
        clone3.gameObject.tag = "NPC";

        Instantiate(prefabs[index[3]], points[3].position, Quaternion.Euler(new Vector3(0, 180, 0)));
        }
    }


   


   
}