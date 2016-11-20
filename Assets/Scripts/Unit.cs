using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour {

    public float health = 1000;
    protected float healthMax;

    void Start()
    {
        healthMax = health;
    }

	public virtual float TakeDamage (float _damage)
    {
        health -= _damage;
        if (health <= 0)
            Kill();
        return health;
	}

    public virtual float AddHealth (float _addedHealth)
    {
        health += _addedHealth;
        if (health > healthMax)
            health = healthMax;
        return health;
    }
    
    public void Kill()
    {
        Destroy(gameObject);
    }
}
