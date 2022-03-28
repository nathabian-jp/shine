using UnityEngine;
using System.Collections;

public class PCPlatform : MonoBehaviour {

	Vector3 oldPos;
	public float dist = 1f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		LayerMask mask = 1<<LayerMask.NameToLayer("Platform");
		//Debug.Log (LayerMask.NameToLayer ("Platform"));
		RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.up, dist,mask);

		if (hit.collider != null) {
			Debug.Log (hit.collider.gameObject);
			//if (hit.collider.gameObject.tag == "Platform") {
				if (oldPos == Vector3.zero) {
					oldPos = hit.collider.transform.position;
				}
				hit.point = hit.point + (new Vector2 (hit.collider.transform.position.x - oldPos.x, 0));
				gameObject.transform.position = hit.point;
				Debug.Log (hit.point);
				oldPos = hit.collider.transform.position;
			//}else{
				//oldPos = Vector3.zero;
			//}

		}else{
			oldPos = Vector3.zero;
		}
	}
}

