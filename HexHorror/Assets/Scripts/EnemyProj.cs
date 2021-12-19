using UnityEngine;
using System.Collections;

public class EnemyProj : MonoBehaviour {

	void Start()
	{
		rigidbody.velocity = transform.TransformDirection(new Vector3 (0, 0, 50));
		ShootBullet();
		StartCoroutine(DestroyAuto());
	}
	
	void FixedUpdate()
	{
		ShootBullet();
	}
	
	public AudioClip impact_sound;
	Ray ray;
	RaycastHit hit = new RaycastHit();
	bool hit_before = false;
	
	void ShootBullet()
	{
		if(!hit_before)
		{
			ray = new Ray(transform.position,transform.forward);
			Physics.SphereCast(ray,0.5f,out hit,2.0f);
			if(hit.collider)
			{
				if(hit.collider.gameObject.name == "Player")
				{
					hit.collider.gameObject.GetComponent<MainScript2>().KillPlayer();
					InitDestroy();
				}
				else if(hit.collider.gameObject.name != "ms_kor")
					InitDestroy();
			}
		}
	}
	
	void InitDestroy()
	{
		audio.PlayOneShot(impact_sound);
		hit_before = true;
		GetComponentInChildren<Renderer>().enabled = false;
		StartCoroutine(DestroyBullet());	
	}
	
	IEnumerator DestroyBullet()
	{
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
	
	IEnumerator DestroyAuto()
	{
		yield return new WaitForSeconds(5.0f);
		Destroy(gameObject);
	}
}
