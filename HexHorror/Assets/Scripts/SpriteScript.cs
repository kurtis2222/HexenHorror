using UnityEngine;
using System.Collections;

public class SpriteScript : MonoBehaviour {
	
	GameObject target;
	
	void Start()
	{
		target = GameObject.Find("Player");
	}
	
	void FixedUpdate ()
	{
		gameObject.transform.LookAt(target.transform.position);
	}
}
