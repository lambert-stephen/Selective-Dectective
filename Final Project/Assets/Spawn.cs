using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject[] prefabs;
    public Transform[] points; 
    int[] index = new int[5];
    public Button[] buttons;
    int selected=0;
    
    int r;
    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        var colors1 = buttons[0].colors;
        var colors2 = buttons[0].colors;
        colors2.normalColor = Color.green;
        buttons[0].colors= colors2; 
        buttons[0].onClick.AddListener(char1);
        buttons[1].onClick.AddListener(char2);
        buttons[2].onClick.AddListener(char3);
        buttons[3].onClick.AddListener(char4);
        Random.seed = System.DateTime.Now.Millisecond;
        index[0]=Random.Range(0,25);
        while (true)
        {
            r=Random.Range(0,25);
            if(r!=index[0])
            {
                index[1]=r;
                break;
            }
        }
        while (true)
        {
            r=Random.Range(0,25);
            if(r!=index[0] && r!=index[1])
            {
                index[2]=r;
                break;
            }
        }
        while (true)
        {
            r=Random.Range(0,25);
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


    void Update() 
     {
      
      var colors1 = buttons[1].colors;
      var colors2 = buttons[1].colors;
      colors2.normalColor = Color.green;
      
      if(selected==1) 
      { 
        colors1 = buttons[0].colors;
      }

         
         if (Input.GetKeyDown(KeyCode.LeftArrow))
         {
            buttons[selected].colors=colors1;
             if(selected==0)
                {

                    selected=3;
                }
            else
                {
                    selected--;
                }
            buttons[selected].colors=colors2;

         }

          if (Input.GetKeyDown(KeyCode.RightArrow))
         {
           buttons[selected].colors=colors1;
             if(selected==3)
                {
                    selected=0;
                }
            else
                {
                    selected++;
                }
            buttons[selected].colors=colors2;  
         }
           if (Input.GetKeyDown(KeyCode.UpArrow))
         {
            buttons[selected].onClick.Invoke();
         }
           
 
     }

    public void char1()
    {
   PlayerPrefs.SetInt("index", index[0]);
   Debug.Log("Selected index: "+index[0]);
     SceneManager.LoadScene("Game");
    }
     public void char2()

    {
    PlayerPrefs.SetInt("index", index[1]);
    Debug.Log("Selected index: "+index[1]);
      SceneManager.LoadScene("Game");
    }

 public void char3()

    {
    PlayerPrefs.SetInt("index", index[2]);
    Debug.Log("Selected index: "+index[2]);
      SceneManager.LoadScene("Game");
    }

 public void char4()

    {
    PlayerPrefs.SetInt("index", index[3]);
    Debug.Log("Selected index: "+index[3]);
      SceneManager.LoadScene("Game");
    }


   
}