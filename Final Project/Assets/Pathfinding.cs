using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Pathfinding : MonoBehaviour
{
  public Transform[] points;
  private NavMeshAgent nav;
  private int destPoint;
  void Start(){
      nav = GetComponent<NavMeshAgent>();
  }
  void FixedUpdate(){
      if (!nav.pathPending && nav.remainingDistance < 0.5f){
          GoToNextPoint();
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
    Debug.Log("Destination: "+destPoint);
  	nav.destination = points[destPoint].position;
  	destPoint = (destPoint + 1) % points.Length;
  }
}
