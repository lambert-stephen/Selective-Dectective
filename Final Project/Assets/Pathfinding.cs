using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Pathfinding : MonoBehaviour
{
  public Transform[] points;
  private NavMeshAgent nav;
  private int destPoint;
  float dist,dist2;
  float countSeconds = 0;
  float randTimeToChangePath;
  void Start(){
      nav = GetComponent<NavMeshAgent>();
      randTimeToChangePath = Random.Range(5,15);
  }
  void FixedUpdate()
  {
    dist=nav.remainingDistance;
    countSeconds += Time.deltaTime;
    //Debug.Log(countSeconds + " Count"); //Print to dev log seconds
      if (!nav.pathPending && nav.remainingDistance < 1.0f){
          GoToNextPoint();
      }
     if(countSeconds>randTimeToChangePath) //After x rand seconds, NPC changes their mind.
      {
        dist2=dist-nav.remainingDistance;
        if(dist2 <1 && dist2>=0 )
        {
          Random.seed = System.DateTime.Now.Millisecond;
          destPoint=Random.Range(0,11);
  	      nav.destination = points[destPoint].position;
        }
        countSeconds = 0;
        randTimeToChangePath = Random.Range(5,15);
      }
  }
  void GoToNextPoint()
  {
  	if (points.Length == 0)
  	{
  		return;
  	}
    Random.seed = System.DateTime.Now.Millisecond;
    destPoint=Random.Range(0,11);
  	nav.destination = points[destPoint].position;
  }

}
