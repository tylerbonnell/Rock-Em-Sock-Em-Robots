using UnityEngine;
using System.Collections;

public class HeadScript : MonoBehaviour {

	public void PopHead () {
		HingeJoint joint = GetComponent<HingeJoint> ();
		joint.autoConfigureConnectedAnchor = false;
		joint.connectedAnchor = joint.connectedAnchor + Vector3.up * 4;
	}
}
