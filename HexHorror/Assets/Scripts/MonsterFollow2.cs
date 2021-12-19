using UnityEngine;
using System.Collections;

public class MonsterFollow2 : MonoBehaviour {
	
	public AudioClip monster_snd;
	public Transform proj_point;
	public GameObject enemy_proj;
	public GameObject enemy_die;
	GameObject target;
	public int hp = 15;
	
	void Start()
	{
		target = GameObject.Find("Player");
		StartCoroutine(Shoot());
		StartCoroutine(MakeSound());
	}
	
	void FixedUpdate ()
	{
		if(Vector3.Distance(transform.position,target.transform.position) < 3.0f)
		{
			target.GetComponent<MainScript2>().KillPlayer();
			enabled = false;
		}
		gameObject.GetComponent<NavMeshAgent>().destination = target.transform.position;
	}
	
	public void Damage()
	{
		hp-=1;
		if(hp == 0)
		{
			GameObject.Instantiate(enemy_die,gameObject.transform.position,gameObject.transform.rotation);
			Destroy(gameObject);
		}
	}
	
	IEnumerator Shoot()
	{
		yield return new WaitForSeconds(2.0f);
		proj_point.LookAt(target.transform.position);
		GameObject.Instantiate(enemy_proj,proj_point.position,proj_point.rotation);
		StartCoroutine(Shoot());
	}
	
	IEnumerator MakeSound()
	{
		yield return new WaitForSeconds(Random.Range(4,8));
		audio.PlayOneShot(monster_snd);
		StartCoroutine(MakeSound());
	}
}
