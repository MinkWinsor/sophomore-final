﻿using UnityEngine;
using System.Collections;


public interface IPausable
{
    void OnPause();
    void OnUnPause();
}

public interface IFiring
{
    IEnumerator Fire(Vector3 target);
    float HitTarget(float damageDone);
}

public interface IMoving
{
    void moveHandler();
}



