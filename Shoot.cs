using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bulletPrefab;
	public float bulletForce = 1000f;
	float timeElapsed = 1f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {




		timeElapsed += Time.deltaTime;

		if (timeElapsed >= 1f) {
		
			if (Input.GetButtonDown("Fire1")){//when the left mouse button is clicked
						
				FireBullet();//look for and use the fire bullet operation

			}
		}
	}
	
	
	public void FireBullet(){
		
		//Clone of the bullet
		GameObject Clone;
		
		//spawning the bullet at position
		Clone = (Instantiate(bulletPrefab, transform.position,transform.rotation)) as GameObject;

		//add force to the spawned objected
		Clone.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce);


		Destroy (Clone, 3);
		timeElapsed = 0f;
		
	}
}