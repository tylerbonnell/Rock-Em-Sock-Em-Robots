using UnityEngine;
using System.Collections;

public class Arm : MonoBehaviour {

	public HingeJoint upperArm;
	public HingeJoint forearm;
	private JointSpring upperArmSpring;
	private JointSpring forearmSpring;
	public KeyCode punchKey;
	private float initialUpperPos;
	private float initialLowerPos;
	
	void Start () {
		initialUpperPos = upperArm.spring.targetPosition;
		upperArmSpring = upperArm.spring;
		initialLowerPos = forearm.spring.targetPosition;
		forearmSpring = forearm.spring;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (punchKey)) {
			//forearm.AddForce (Vector3.right * 30 * direction + Vector3.up * 15, ForceMode.Impulse);
			setTargetPositions (-20f, 0f);
		} else if (Input.GetKeyUp (punchKey)) {
			setTargetPositions (initialUpperPos, initialLowerPos);
		}
	}
	
	private void setTargetPositions (float upperArmTarget, float forearmTarget) {
		upperArmSpring.targetPosition = upperArmTarget;
		forearmSpring.targetPosition = forearmTarget;
		upperArm.spring = upperArmSpring;
		forearm.spring = forearmSpring;
	}
}
