using UnityEngine;
using System.Collections;

public class MoveOnNavMesh : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }

    public void setNewTarget (Transform newTarget)
    {
        agent.destination = newTarget.position;
    }
}
