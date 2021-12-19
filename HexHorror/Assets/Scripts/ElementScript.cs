using UnityEngine;
using System.Collections;

public class ElementScript : MonoBehaviour {
	
	float count;
	bool isup = false;

	void FixedUpdate () {
		if(count > 0.1f) isup = false;
		else if(count < -0.1f) isup = true;
		count += (isup ? 0.01f : -0.01f);
		gameObject.transform.position = new Vector3(
			gameObject.transform.position.x,
			gameObject.transform.position.y + (isup ? 0.005f : -0.005f),
			gameObject.transform.position.z);
	}
}
