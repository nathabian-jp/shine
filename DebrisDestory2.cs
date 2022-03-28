using UnityEngine;
using System.Collections;

public class DebrisDestroy2 : MonoBehaviour {
	
	// Destroy whatever hit this
	void OnTriggerEnter2D(Collider2D other) {
		// If it's the player, debug that the game is over
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Game over");
			Destroy(other.gameObject);
			Application.LoadLevel ("Level4");
		}
	}
}
