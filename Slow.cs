using UnityEngine;
using System.Collections;

public class Slow : MonoBehaviour {

	public float timeScale = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
				if (other.gameObject.tag == "Projectile") {
					//Debug.Log("hit");
					if (timeScale == 1.0f) {
						timeScale = 0.5f;
					}
					else
					{
						timeScale = 1.0f;
					}
					
					
				}
		}
}
