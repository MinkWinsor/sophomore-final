using UnityEngine;
using System.Collections;

public class TakeDamagePowerUp : PowerUp {

    public float DamageAmount = 50;


    protected override void OnTriggerEnter(Collider _other)
    {
        UnitPlayer unitToDamage = _other.GetComponent<UnitPlayer>();
        unitToDamage.TakeDamage(DamageAmount);
        gameObject.SetActive(false);
    }
}
