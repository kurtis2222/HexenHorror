using UnityEngine;
using System.Collections;

public class LBLevel : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if(col.name == "Player")
			Application.LoadLevel(1);
	}
}
