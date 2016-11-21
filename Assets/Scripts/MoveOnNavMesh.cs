using UnityEngine;
using System.Collections;
using System;

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

    public void StopMoving()
    {
        agent.updatePosition = false;
        agent.updateRotation = false;
        OnlyUpdateScript.PhysicsUpdates -= setNewTarget;
    }
    public void StartMoving()
    {
        agent.updatePosition = true;
        agent.updateRotation = true;
        OnlyUpdateScript.PhysicsUpdates += setNewTarget;
    }

    protected virtual void OnDestroy()
    {
        OnlyUpdateScript.PhysicsUpdates -= setNewTarget;
    }
    
}
