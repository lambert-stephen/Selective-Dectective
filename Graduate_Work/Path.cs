using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
   	public Transform citizen,target;
    public Transform[] points;
	public GridBuild grid;
	public Rigidbody rb;

    public int pathFound=0,isMoving=0;
    public List<Node> path = new List<Node>();

    void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update() 
    {
		if(isMoving==1)
		return;
        else
        {
        int destPoint=Random.Range(0,3);
		pathFound=FindPath(citizen.position, points[destPoint].position);
        if(pathFound==1)
            {
			
            isMoving=1;
            isMoving=move();

            }
	}
	}

    int move()  
    {
        int i=1;
		
        while(i<path.Count)
        {

            Node nextNode=path[i];
			Vector3 dir = (nextNode.worldPosition - citizen.position).normalized;
			Vector3 velocity = dir * 2;
			/*
			while(true)
            {
        
            rb.velocity =  velocity;
            if(Vector3.Distance(citizen.position,nextNode.worldPosition)<0.2f) 
			break;
			}
            i++; */
        }
		Debug.Log("HEre");
    path.Clear();
    return 0;


    }

	int FindPath(Vector3 startPos, Vector3 targetPos) 
	{
		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);
        
		List<Node> openSet = new List<Node>();
		HashSet<Node> closedSet = new HashSet<Node>();
		openSet.Add(startNode);

		while (openSet.Count > 0) {
			Node node = openSet[0];
			for (int i = 1; i < openSet.Count; i ++) {
				if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost) {
					if (openSet[i].hCost < node.hCost)
						node = openSet[i];
				}
			}

			openSet.Remove(node);
			closedSet.Add(node);

			if (node == targetNode) {
				RetracePath(startNode,targetNode);
				return 1;
			}

			foreach (Node neighbour in grid.GetNeighbours(node)) {
				if (!neighbour.walkable || closedSet.Contains(neighbour)) {
					continue;
				}

				int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
				if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetNode);
					neighbour.parent = node;

					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
				}
			}
		}
		return 0;
	}

	void RetracePath(Node startNode, Node endNode) {
		
		Node currentNode = endNode;

		while (currentNode != startNode) {
			this.path.Add(currentNode);
			currentNode = currentNode.parent;
		}
		this.path.Reverse();

		

	}

	int GetDistance(Node nodeA, Node nodeB) {
		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if (dstX > dstY)
			return 14*dstY + 10* (dstX-dstY);
		return 14*dstX + 10 * (dstY-dstX);
	}
}


