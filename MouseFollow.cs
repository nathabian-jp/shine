using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {

	public bool followX = true;
	public bool followY = true;
	public float speed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// Store the mouse position in screen coordinates
		Vector3 mousePos = Input.mousePosition;
		// Convert from screen coordinates to world coordinates
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
		// Ignore the z-position since we're working in 2D
		worldPos.z = transform.position.z;
		
		if (!followX) {
			worldPos.x = transform.position.x;
		}
		
		if (!followY) {
			worldPos.y = transform.position.y;
		}
		
		Vector3 target = worldPos;
		//What's our target location?
		Vector3 curLoc = transform.position;
		//What's our current location?
		Vector3 newPos = curLoc;
		//What's the new position?
		
		newPos.x += speed * (target.x - curLoc.x);
		newPos.y += speed * (target.y - curLoc.y);
		newPos.z += speed * (target.z - curLoc.z);
		
		var dir = newPos - transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
