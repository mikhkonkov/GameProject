using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public Transform target;
	public float movementSpeed;
	public float rotationSpeed;
	public int minDistance;
	
	private Transform myTransform;
	
	void Awake() {
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
		minDistance = 2;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(target.position, myTransform.position, Color.yellow);
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, 
			Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		
		if (Vector3.Distance(target.position, myTransform.position) >= minDistance) {
			myTransform.position += myTransform.forward * movementSpeed * Time.deltaTime;
		}
	}
}
