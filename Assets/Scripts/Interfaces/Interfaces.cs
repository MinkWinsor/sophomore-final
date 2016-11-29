/*
Interfaces for functionality across the game.
 */

//Required Libraries
using UnityEngine;
using System.Collections;

//Pausable objects need functions for pausing and unpausing
public interface IPausable
{
    void OnPause();
    void OnUnPause();
}

//Function for firing. Should always be a coroutine so that firing is only available at a certain speed.
public interface IFiring
{
    IEnumerator Fire(Transform target);
}

//Units that allow changing health need these functions.
public interface IHealth
{
    float TakeDamage(float _damage);
    float AddHealth(float _addedHealth);
}