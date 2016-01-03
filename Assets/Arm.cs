using UnityEngine;
using System.Collections;

public class Arm : MonoBehaviour {

	public Rigidbody forearm;
	public KeyCode punchKey;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (punchKey)) {
			Debug.Log ("punch!");
			forearm.AddForce (Vector3.right * 3000 + Vector3.up * 2000, ForceMode.Acceleration);
		}
	}
}
