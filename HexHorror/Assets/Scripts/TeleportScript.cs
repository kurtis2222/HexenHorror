using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {
	
	public AudioClip tele_snd;
	public Transform warp_point;
	public string message;
	
	void OnTriggerEnter (Collider col) {
    	if(col.name == "Player")
		{
			col.gameObject.audio.PlayOneShot(tele_snd);
			col.gameObject.GetComponent<MainScript>().ShowMessage(message);
			col.transform.position = warp_point.position;
			col.transform.rotation = warp_point.rotation;
			GameObject.Find("GameControl").GetComponent<ControlScript>().ClearMonsters();
		}
	}
}
