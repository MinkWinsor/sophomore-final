/*
 This script controls NavMeshAgents. It's mainly used on enemies to help them move towards the player.
 Allows stopping and starting, and giving new targets.
 */

 //Required Libraries
using UnityEngine;
using System.Collections;
using System;

public class MoveOnNavMesh : MonoBehaviour {

    //-Public Variables-//
    public Transform target;

    //-Private Variables-//
    private NavMeshAgent agent;

    //FUNCTION: Sets up nav agent and starts moving it towards the target, if given.
    //CALLED BY: Unity game engine
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(target != null)
        {
            setNewTarget();
        }
        UpdateScript.PhysicsUpdates += setNewTarget;
    }

    //FUNCTION: Sets a new target for the navigation. If called without parameters, sets it to the public transform.
    //CALLED BY: Any function, usually controller of the character or recycler.
    //INPUTS: Transform of the new target.
    public void setNewTarget (Transform newTarget)
    {
        agent.destination = newTarget.position;
    }

    //FUNCTION: Sets target of the agent.  Overloaded version that uses the public target variable.
    //CALLED BY: Any function, usually controller of the character or recycler.
    public void setNewTarget()
    {
        agent.destination = target.position;
    }

    //FUNCTION: Causes the agent to stop moving.
    //CALLED BY: Anything that stops the agent, almost always a recycler or pause function.
    public void StopMoving()
    {
        if(gameObject.activeSelf)
            agent.Stop();
        UpdateScript.PhysicsUpdates -= setNewTarget;
    }

    //FUNCTION: Causes the agent to start moving.
    //CALLED BY: Anything that starts the agent, almost always a recycler or pause function.
    public void StartMoving()
    {
        if (gameObject.activeSelf)
            agent.Resume();
        UpdateScript.PhysicsUpdates += setNewTarget;
    }

    //FUNCTION: Called when object is destroyed. (I.E. if scene is reloaded)
    //CALLED BY: Unity game engine
    protected virtual void OnDestroy()
    {
        UpdateScript.PhysicsUpdates -= setNewTarget; //Unsubscribes from actions.
    }
    
}
