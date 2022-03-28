using UnityEngine;
using System.Collections;

public class PlatformVerticalMovement : MonoBehaviour {
	
	private float useSpeed;
	public float directionSpeed = 9.0f;
	float origX;
	public float distance = 10.0f;
	public float timeScale = 1.0f;
	float timeElapsed = 0f;
	bool slowed = false;

	
	// Use this for initialization
	void Start () 
	{
		origX = transform.position.x;
		useSpeed = -directionSpeed;
		timeElapsed = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (origX - transform.position.x >= distance && useSpeed <= 0) {
			useSpeed = directionSpeed; //flip direction
		} else if (origX - transform.position.x <= -distance && useSpeed >= 0) {
			useSpeed = -directionSpeed; //flip direction
		}
		float curSpeed = useSpeed * Time.deltaTime;
		if (slowed) {
			curSpeed /= 2;
		}
		transform.Translate (curSpeed, 0, 0);
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


