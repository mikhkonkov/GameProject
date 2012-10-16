using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public int maxHealth = 100;
	
	private int _curhealth;
	private float healthBarLength;

	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width/2;
		if (_curhealth < 1) _curhealth = 1;
		_curhealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() {
		GUI.Box(new Rect(10,40,healthBarLength,20),"");
		GUI.Box(new Rect(10,40,Screen.width/2,20), _curhealth + "/" + maxHealth);
	}
	
	public void AdjustCurHealth(int adjust) {
		_curhealth += adjust;
		if (_curhealth < 0) _curhealth = 0;
		if (_curhealth > maxHealth) _curhealth = maxHealth;
		healthBarLength = (Screen.width/2) * (_curhealth/(float)maxHealth);
	}
}
