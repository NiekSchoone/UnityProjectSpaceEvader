using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;
	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play ();
		}
	}

	void FixedUpdate ()
	{
		if (Input.GetKey ("left") || Input.GetKeyUp ("a"))
			rigidbody.AddForce (-speed, 0.0f, 0.0f);
		
		if (Input.GetKey ("right") || Input.GetKeyUp ("d"))
			rigidbody.AddForce (speed, 0.0f, 0.0f);
		
		if (Input.GetKey ("up") || Input.GetKeyUp ("w"))
			rigidbody.AddForce (0.0f, 0.0f, speed);
		
		if (Input.GetKey ("down") || Input.GetKeyUp ("s"))
			rigidbody.AddForce (0.0f, 0.0f, -speed);
		
		rigidbody.position = new Vector3
		(
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
			0.0f,
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
		);
		
		//rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
