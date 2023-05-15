using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Mob))]
public class MobMovement : MonoBehaviour
{
    private Transform target;
    private LayerMask turretLayer;
    public float turretRadius = 2.5f;
    private int waypointIndex = 0;

    private List<Transform> openList = new List<Transform>(); // List of open nodes to evaluate
    private List<Transform> closedList = new List<Transform>(); // List of closed nodes that have already been evaluated

    private Mob mob;
    // Start is called before the first frame update
    void Start()
    {
        mob = GetComponent<Mob>();
        target = Waypoints.points[0];


    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * mob.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWaypoint();
        }

        mob.speed = mob.startSpeed;

    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    public void EndPath()
    {
        PlayerStats.lives--;
        WaveSpawner._mobAlive--;
        Destroy(gameObject);
    }
    /*
    void FindPath(Transform start, Transform target)
    {
        openList.Add(start); // Add the starting node to the open list

        while (openList.Count > 0)
        { // Keep searching until there are no more nodes to evaluate
            Transform currentNode = openList[0]; // Get the node with the lowest f-cost from the open list
            for (int i = 1; i < openList.Count; i++)
            {
                if (openList[i].GetComponent<Node>().fCost < currentNode.GetComponent<Node>().fCost)
                {
                    currentNode = openList[i];
                }
            }

            openList.Remove(currentNode); // Remove the current node from the open list
            closedList.Add(currentNode); // Add the current node to the closed list

            if (currentNode == target)
            { // If we have found the target node, stop searching and return the path
                return;
            }

            foreach (Transform neighbor in currentNode.GetComponent<Node>().neighbors)
            { // Loop through all the neighbors of the current node
                if (closedList.Contains(neighbor))
                { // If the neighbor is already in the closed list, skip it
                    continue;
                }

                if (IsNodeBlocked(neighbor))
                { // If the neighbor is blocked by a turret, skip it
                    continue;
                }

                float costToNeighbor = Vector3.Distance(currentNode.position, neighbor.position); // Calculate the cost to move from the current node to the neighbor
                float tentativeGCost = currentNode.GetComponent<Node>().gCost + costToNeighbor; // Calculate the tentative g-cost for the neighbor

                if (!openList.Contains(neighbor) || tentativeGCost < neighbor.GetComponent<Node>().gCost)
                { // If the neighbor is not in the open list or the tentative g-cost is less than the neighbor's g-cost
                    neighbor.GetComponent<Node>().gCost = tentativeGCost; // Update the neighbor's g-cost
                    neighbor.GetComponent<Node>().hCost = Vector3.Distance(neighbor.position, target.position); // Calculate the neighbor's h-cost
                    neighbor.GetComponent<Node>().parent = currentNode; // Set the neighbor's parent to the current node

                    if (!openList.Contains(neighbor))
                    { // If the neighbor is not in the open list, add it
                        openList.Add(neighbor);
                    }
                }
            }
        }
    }

    bool IsNodeBlocked(Transform node)
    {
        Collider[] colliders = Physics.OverlapSphere(node.position, turretRadius, turretLayer); // Check for colliders around the node within the turret radius
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Turret"))
            { // If the collider is a turret, the node is blocked
                return true;
            }
        }
        return false; // If no turrets are found, the node is not blocked
    }
    */
}
