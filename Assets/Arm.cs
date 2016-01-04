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
	public bool isPunching;
	
	void Start () {
		initialUpperPos = upperArm.spring.targetPosition;
		upperArmSpring = upperArm.spring;
		initialLowerPos = forearm.spring.targetPosition;
		forearmSpring = forearm.spring;
	}
	
	// must be called by the player object
	public void UpdateCall () {
		if (Input.GetKeyDown (punchKey)) {
			CancelInvoke ("resetPunch");
			isPunching = true;
			Invoke ("resetPunch", .2f);
			setTargetPositions (-20f, 0f);
		} else if (Input.GetKeyUp (punchKey)) {
			setTargetPositions (initialUpperPos, initialLowerPos);
		}
	}
	
	private void resetPunch () {
		isPunching = false;
	}
	
	private void setTargetPositions (float upperArmTarget, float forearmTarget) {
		upperArmSpring.targetPosition = upperArmTarget;
		forearmSpring.targetPosition = forearmTarget;
		upperArm.spring = upperArmSpring;
		forearm.spring = forearmSpring;
	}
}
