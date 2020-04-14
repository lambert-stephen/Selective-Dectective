using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Pathfinding : MonoBehaviour
{
  public Transform[] points;
  private NavMeshAgent nav;
  private int destPoint;
  float dist,dist2,seconds;
  void Start(){
      nav = GetComponent<NavMeshAgent>();
  }
  void FixedUpdate()
  {
     dist=nav.remainingDistance;
    seconds += Time.deltaTime;
    
      if (!nav.pathPending && nav.remainingDistance < 0.5f){
          GoToNextPoint();
      }
     if(seconds>2) 
      {
        dist2=dist-nav.remainingDistance;
        if(dist2 <1 && dist2>=0 )
        {
          Random.seed = System.DateTime.Now.Millisecond;
    destPoint=Random.Range(0,17);
  	nav.destination = points[destPoint].position;
        }

      }
  }
  void GoToNextPoint()
  {
  	if (points.Length == 0)
  	{
  		return;
  	}
    Random.seed = System.DateTime.Now.Millisecond;
    destPoint=Random.Range(0,17);
  	nav.destination = points[destPoint].position;
  }
}
