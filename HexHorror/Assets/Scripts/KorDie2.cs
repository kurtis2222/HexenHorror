using UnityEngine;
using System.Collections;

public class KorDie2 : MonoBehaviour {

	public AudioClip death_snd;
	public AudioClip spirit_snd;
	GameObject[] trash;
	
	void Start () {
		audio.PlayOneShot(death_snd);
		StartCoroutine(SprTimer(1.5f));
		StartCoroutine(SprTimer(1.8f));
		StartCoroutine(SprTimer(2.0f));
		StartCoroutine(SprTimer(2.5f));
		StartCoroutine(Credits());
	}
	
	IEnumerator SprTimer(float input)
	{
		yield return new WaitForSeconds(input);
		audio.PlayOneShot(spirit_snd);
	}
	
	IEnumerator Credits()
	{
		yield return new WaitForSeconds(4.0f);
		trash = GameObject.FindGameObjectsWithTag("Enemy");
		for(int i = 0; i < trash.Length; i++)
			GameObject.Destroy(trash[i]);
		GetComponent<SpriteScript>().enabled = false;
		GameObject.Find("end_cam").camera.enabled = true;
		GameObject.Destroy(GameObject.Find("Player"));
		GameObject.Find("credits_text").renderer.enabled = true;
		GameObject.Find("credits_text").GetComponent<CreditsRoll>().enabled = true;
		GameObject.Destroy(gameObject);
	}
}
