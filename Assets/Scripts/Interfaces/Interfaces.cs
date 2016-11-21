using UnityEngine;
using System.Collections;


public interface IPausable
{
    void OnPause();
    void OnUnPause();
}

public interface IFiring
{
    void Fire();
    float HitTarget(float damageDone);
}

public interface IMoving
{
    void moveHandler();
}



