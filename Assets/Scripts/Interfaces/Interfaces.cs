using UnityEngine;
using System.Collections;


public interface IPausable
{
    void OnPause();
    void OnUnPause();
}

public interface IFiring
{
    IEnumerator Fire(Transform target);
    float HitTarget(float damageDone);
}

public interface IMoving
{
    void moveHandler();
}

public interface IHealth
{
    float TakeDamage(float _damage);
    float AddHealth(float _addedHealth);
}