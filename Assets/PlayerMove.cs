using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public string horizontalAxis;
	public string verticalAxis;
	private Vector3 initialPos;
	
	void Start () {
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (Input.GetAxis (horizontalAxis), 0, Input.GetAxis (verticalAxis)) * .05f);
	}
}
