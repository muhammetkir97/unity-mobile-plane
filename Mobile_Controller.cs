using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput; 
//You need Standard Assets/Cross Platform Input for this code. Add the Standard Assets/CrossPlatformInput/Prefabs/MobileSingleStickControl prefab to your scene
public class ControlPlane : MonoBehaviour {
	Rigidbody plane; //plane rigidbody. My settings for rigidbody mass is 0.1, drag = 1,angular drag = 0.05 and collision = Continuous.
	Vector3 forw,vel2 = Vector3.zero;
	float vel = 0f,rotX = 0f,rotY = 0f,speed = 1f; //vel veriable is not necessary, speed value sets the speed of plane

	void Start () {
		plane = GameObject.Find ("Player").GetComponent<Rigidbody>();  //Change the "Player" to name of your plane object.
  }
	void Update () {
	
	}

	void FixedUpdate () {
		forw = Vector3.SmoothDamp (forw,transform.forward,ref vel2,0.3f); //Smooth movement. If your plane move in the wrong direction change the "transform.forward" to transform.up or down etc.

		transform.Translate (forw * -speed,Space.World); //if the object on the opposite direction delete the "-" symbol.
		rotX = CrossPlatformInputManager.GetAxis ("Vertical");
		rotY = CrossPlatformInputManager.GetAxis ("Horizontal");

		/* not working
		rotX = Mathf.SmoothDamp (rotX, CrossPlatformInputManager.GetAxis ("Vertical"), ref vel, 0.3f);
		rotY = Mathf.SmoothDamp (rotY, CrossPlatformInputManager.GetAxis ("Horizontal"), ref vel, 0.3f);
		*/
	
		transform.Rotate (rotX *  transform.right,Space.World);
		transform.Rotate (rotY * transform.up,Space.World);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
	
	}
}
