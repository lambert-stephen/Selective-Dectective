using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject[] prefabs;
    public Transform[] points; 
    int[] index = new int[5];
    public Button c1;
    public Button c2;
    public Button c3;
    public Button c4;
    
    int r;
    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        c1.onClick.AddListener(char1);
        c2.onClick.AddListener(char2);
        c3.onClick.AddListener(char3);
        c4.onClick.AddListener(char4);
        Random.seed = System.DateTime.Now.Millisecond;
        index[0]=Random.Range(0,19);
        while (true)
        {
            r=Random.Range(0,19);
            if(r!=index[0])
            {
                index[1]=r;
                break;
            }
        }
        while (true)
        {
            r=Random.Range(0,19);
            if(r!=index[0] && r!=index[1])
            {
                index[2]=r;
                break;
            }
        }
        while (true)
        {
            r=Random.Range(0,19);
            if(r!=index[0] && r!=index[1] && r!=index[2])
            {
                index[3]=r;
                break;
            }
        }
        Instantiate(prefabs[index[0]], points[0].position, Quaternion.Euler(new Vector3(0, 180, 0)));
        Instantiate(prefabs[index[1]], points[1].position, Quaternion.Euler(new Vector3(0, 180, 0)));
        Instantiate(prefabs[index[2]], points[2].position, Quaternion.Euler(new Vector3(0, 180, 0)));
        Instantiate(prefabs[index[3]], points[3].position, Quaternion.Euler(new Vector3(0, 180, 0)));
        
    }

    public void char1()

    {
   PlayerPrefs.SetInt("index", index[0]);
   Debug.Log("Selected");
     SceneManager.LoadScene("SampleScene");
    }
     public void char2()

    {
    PlayerPrefs.SetInt("index", index[1]);
    Debug.Log("Selected");
      SceneManager.LoadScene("SampleScene");
    }

 public void char3()

    {
    PlayerPrefs.SetInt("index", index[2]);
    Debug.Log("Selected");
      SceneManager.LoadScene("SampleScene");
    }

 public void char4()

    {
    PlayerPrefs.SetInt("index", index[3]);
    Debug.Log("Selected");
      SceneManager.LoadScene("SampleScene");
    }


   
}