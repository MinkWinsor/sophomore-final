using UnityEngine;
using System.Collections;

public class EnemyCollider : MonoBehaviour {
    
    public float ColissionDamage = 50;
    private Unit parentUnit;

    void Start()
    {
        parentUnit = GetComponentInParent<Unit>();
    }

	void OnTriggerEnter(Collider other) {
        UnitPlayer unitToDamage = other.GetComponent<UnitPlayer>();
        unitToDamage.TakeDamage(ColissionDamage);
        parentUnit.Kill();
	}
}
