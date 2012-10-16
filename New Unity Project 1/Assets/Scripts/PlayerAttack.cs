using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	
	public GameObject target;
	
	public float cooldown;
	public float attackTimer;

	// Use this for initialization
	void Start () {
		attackTimer = 0;
		cooldown = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (attackTimer > 0) {
			attackTimer -= Time.deltaTime;
		}
		if (attackTimer < 0) {
			attackTimer = 0;
		}
		if (Input.GetKeyUp(KeyCode.F)) {
			if (attackTimer == 0) {
				Attack();
				attackTimer = cooldown;
			}
		}
	}
	
	private void Attack() {
		float distance = Vector3.Distance(target.transform.position, transform.position);
		Vector3 dir = (target.transform.position - transform.position).normalized;
		float direction = Vector3.Dot(dir, transform.forward);
		if (distance < 2 && direction > 0) {
			EnemyHealth enemyHealth = (EnemyHealth)target.GetComponent("EnemyHealth");
			enemyHealth.AdjustCurHealth(-10);
		}
	}
}
