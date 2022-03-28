using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

	private float useSpeed;
	public float directionSpeed = 9.0f;
	float origY;
	public float distance = 10.0f;
	public float timeScale = 1.0f;
	float timeElapsed = 0f;
	bool slowed = false;

	// Use this for initialization
	void Start () 
	{
		origY = transform.position.y;
		useSpeed = -directionSpeed;
		timeElapsed = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
				if ((origY - transform.position.y > distance) && useSpeed <= 0){
						useSpeed = directionSpeed; //flip direction
				} else if ((origY - transform.position.y < -distance) && useSpeed > 0) {
						useSpeed = -directionSpeed; //flip direction
				}
				//transform.Translate (0, useSpeed * Time.deltaTime, 0);

		float curSpeed = useSpeed * Time.deltaTime;
		if (slowed) {
			curSpeed /= 2;
		}
		transform.Translate (0, curSpeed, 0);
		if (timeElapsed >= 3) {
			if (slowed) {
				slowed = false;
			}
		} else {
			//should count up time
			timeElapsed += Time.deltaTime;
		}
	}
	
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Projectile") {
			Debug.Log ("hit");
			//slows the platform
			timeElapsed = 0f;
			slowed = true;
		}
	}
}





