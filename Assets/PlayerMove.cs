using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public string horizontalAxis;
	public string verticalAxis;
	private Rigidbody rb;
	public Material mat;
	public Arm leftArm;
	public KeyCode leftArmKey;
	public Arm rightArm;
	public KeyCode rightArmKey;
	public float health = 50f;
	public HeadScript head;
	private bool gameOver; // the player has lost if this is true
	private bool gameEnded; // game ending stuff has occurred
	public string enemyColor;
	
	void Start () {
		leftArm.punchKey = leftArmKey;
		rightArm.punchKey = rightArmKey;
		rb = GetComponent<Rigidbody> ();
		MeshRenderer[] mr = GetComponentsInChildren<MeshRenderer> ();
		MeshRenderer thisMesh = GetComponent<MeshRenderer> ();
		for (int i = 0; i < mr.Length; i++)
			if (mr[i] != thisMesh)
				mr[i].material = mat;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			rb.velocity = new Vector3 (Input.GetAxis (horizontalAxis), 0, Input.GetAxis (verticalAxis)) * 5f;
			leftArm.UpdateCall ();
			rightArm.UpdateCall ();
		} else if (gameOver && !gameEnded) {
			head.PopHead ();
			rb.isKinematic = true;
			GUI.singleton.SetWinText (enemyColor);
			gameEnded = true;
		} else if (gameOver) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				Application.LoadLevel (0);
			}
		}
		
		if (health <= 0f) {
			gameOver = true;
		}
	}
	
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.name == "Wall") {
			rb.velocity = Vector3.zero;
		}
	}
	
	public void Damage (float dmg) {
		health -= dmg;
	}
}
