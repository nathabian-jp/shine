using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float horizontalSpeed = 20F;
	public float verticalSpeed = 20F;
	public float jumpHeight = 10f;
	private Rigidbody2D myRigidBody2D;

	void Start() {
		myRigidBody2D = GetComponent<Rigidbody2D> ();
	}


	void Update() {
		float h = horizontalSpeed * Input.GetAxis("Horizontal");
		myRigidBody2D.AddForce (Vector2.right * h);
	}


	void OnCollisionStay2D(Collision2D coll) {

				if (coll.gameObject.tag == "Terrain" || coll.gameObject.tag == "Platform") {
						float v = verticalSpeed * Input.GetAxis ("Vertical");
						//print ("collide");
						if (v >= 0.1f) {
							v = jumpHeight;
							myRigidBody2D.AddForce (Vector2.up * jumpHeight);
							//print ("jump damnit");
						}	
				}
		}
}