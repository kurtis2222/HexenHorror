using UnityEngine;
using System.Collections;

public class ElementPickup : MonoBehaviour {
	
	public int level;
	public GameObject monster;
	public string monster_tag;
	GameObject[] monster_spawn;
	public AudioClip pick_snd;
	public AudioClip[] boss_snd;
	public float waittime = 2.0f;
	public float waittime2 = 2.0f;
	
	GameObject target;
	bool block = false;
	
	void Start()
	{
		monster_spawn = GameObject.FindGameObjectsWithTag(monster_tag);	
		target = GameObject.Find("Player");
	}
	
	void FixedUpdate ()
	{
		if(!block)
		{
			if(Vector3.Distance(gameObject.transform.position,target.transform.position) < 1.0f)
			{
				renderer.enabled = false;
				light.enabled = false;
				GameObject.Find("GameControl").GetComponent<ControlScript>().OpenExit(level);
				target.audio.PlayOneShot(pick_snd);
				FreezePlayer(true);
				StartCoroutine(BossTalk(waittime));
				block = true;
			}
		}
	}
	
	void FreezePlayer(bool input)
	{
		target.GetComponent<FPSInputController>().enabled = !input;
		target.GetComponent<CharacterMotor>().enabled = !input;
	}
	
	IEnumerator BossTalk(float sec)
	{
		yield return new WaitForSeconds(sec);
		target.audio.PlayOneShot(boss_snd[0]);
		if(boss_snd.Length > 1)
			StartCoroutine(BossTalk2(waittime2));
		else
		{
			FreezePlayer(false);
			for(int i = 0; i < monster_spawn.Length; i++)
				GameObject.Instantiate(monster,monster_spawn[i].transform.position,monster_spawn[i].transform.rotation);
			Destroy(gameObject);
		}
	}
	
	IEnumerator BossTalk2(float sec)
	{
		yield return new WaitForSeconds(sec);
		FreezePlayer(false);
		target.audio.PlayOneShot(boss_snd[1]);
		for(int i = 0; i < monster_spawn.Length; i++)
			GameObject.Instantiate(monster,monster_spawn[i].transform.position,monster_spawn[i].transform.rotation);
		Destroy(gameObject);
	}
}
