using UnityEngine;
using System.Collections;

public class MonsterFollow : MonoBehaviour {
	
	public AudioClip monster_snd;
	GameObject target;
	
	void Start()
	{
		target = GameObject.Find("Player");
		StartCoroutine(MakeSound());
	}
	
	void FixedUpdate ()
	{
		if(Vector3.Distance(transform.position,target.transform.position) < 3.0f)
		{
			target.GetComponent<MainScript>().KillPlayer();
			enabled = false;
		}
		gameObject.GetComponent<NavMeshAgent>().destination = target.transform.position;
	}
	
	IEnumerator MakeSound()
	{
		yield return new WaitForSeconds(Random.Range(4,12));
		audio.PlayOneShot(monster_snd);
		StartCoroutine(MakeSound());
	}
}
