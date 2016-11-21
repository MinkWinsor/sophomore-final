using UnityEngine;
using System.Collections;

public class MoveOnNavMesh : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        OnlyUpdateScript.PhysicsUpdates += setNewTarget;
    }

    public void setNewTarget (Transform newTarget)
    {
        agent.destination = newTarget.position;
    }

    public void setNewTarget()
    {
        
        agent.destination = target.position;
    }

    protected virtual void OnDestroy()
    {
        OnlyUpdateScript.PhysicsUpdates -= setNewTarget;
    }
}
