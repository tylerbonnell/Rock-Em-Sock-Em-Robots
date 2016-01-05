using UnityEngine;
using System.Collections;

public class BodyPart : MonoBehaviour {
	
	public PlayerMove player;
	public float healthValue; // the value that the player loses when hit here
	public AudioClip[] hitSounds;

	void OnCollisionEnter (Collision collision) {
		Arm a = collision.gameObject.GetComponent<Arm> ();
		if (a != null && a.isPunching) {
			player.Damage (healthValue);
			if (hitSounds.Length > 0)
				AudioSource.PlayClipAtPoint (hitSounds[Random.Range(0, hitSounds.Length)], transform.position);
		}
	}
}
