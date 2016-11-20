using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitPlayer : Unit {

    public Image healthBar;

    public override float TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);
        healthBar.transform.localScale = new Vector3((health / healthMax), 1, 1);
        print(health);
        return health;
    }

    public override float AddHealth(float _addedHealth)
    {
        return 0;
    }


}
