using UnityEngine;
using System.Collections;

public class HeadScript : MonoBehaviour {

	public AudioClip popSound;

	public void PopHead () {
		HingeJoint joint = GetComponent<HingeJoint> ();
		joint.autoConfigureConnectedAnchor = false;
		joint.connectedAnchor = joint.connectedAnchor + Vector3.up * 2f;
		joint.anchor = joint.anchor - Vector3.up * 3f;
		AudioSource.PlayClipAtPoint (popSound, transform.position, 2f);
	}
}