using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RevealTimer : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft = 20;
    public int secondsLeftTillCredits = 5;
    public bool takingAway = false;

    // Start is called before the first frame update
    void Start()
    {
        textDisplay.GetComponent<TextMesh>().text = "Say who did it! Thief will be revealed in:" + secondsLeft;// "00:" + secondsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if(takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
        if(secondsLeft==0)
        {
            textDisplay.GetComponent<TextMesh>().text = "The Thief Was" ;
            destroyNPC();
            StartCoroutine(Wait());
        }
     

    }
    
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if(secondsLeft < 10)
        {
            textDisplay.GetComponent<TextMesh>().text = "Say who did it! Thief will be revealed in: " + secondsLeft;// "00:0" + secondsLeft;
        }
        else
        {
            textDisplay.GetComponent<TextMesh>().text = "Say who did it! Thief will be revealed in: " + secondsLeft;//text = "00:" + secondsLeft;
        }
        takingAway = false;
    }

             void destroyNPC()
            {
                GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
                for(int i=0; i< npcs.Length; i++)
                {
                    Destroy(npcs[i]);
                }
            }
    IEnumerator Wait()
    {
       
    yield return new WaitForSeconds(5);
    secondsLeftTillCredits -= 1;

    if(secondsLeftTillCredits < 0)
    {
        SceneManager.LoadScene("Credits");
    }
        
       
    }
}
