using UnityEngine;
using System.Collections;

public class MainScript2 : MonoBehaviour {
	
	public AudioClip sword_snd;
	
	public AudioClip death_snd;
	public AudioClip[] step_snd;
	
	public GameObject sword;
	public GameObject sword_cent;
	public GameObject proj;
	Transform sword_norm;
	Transform sword_clear;
	public Transform sword_atk;
	public Transform proj_point;
	public Transform proj_point2;
	public Transform proj_point3;
	
	bool isblock = false;
	bool iskilled = false;
	
	Vector3 oldpos;
	int stepnumb = 0;
	float dist = 0.0f;
	
	GUIText gui_info;
	
	void Start()
	{
		sword_norm = sword_cent.transform;
		gui_info = GameObject.Find("HudInfo").guiText;
		oldpos = gameObject.transform.position;
		StartCoroutine(StepTimer());
		Screen.showCursor = false;
		Screen.lockCursor = true;
	}
	
	void FixedUpdate()
	{
		if(!iskilled)
		{
			if(Input.GetButton("Fire1") && !isblock)
			{
				isblock = true;
				audio.PlayOneShot(sword_snd);
				GameObject.Instantiate(proj,proj_point.position,proj_point.rotation);
				GameObject.Instantiate(proj,proj_point2.position,proj_point2.rotation);
				GameObject.Instantiate(proj,proj_point3.position ,proj_point3.rotation);
				sword_cent.transform.rotation = sword_atk.rotation;
				sword.animation.Play("attack");
				StartCoroutine(ResetSword());
			}
		}
		if(Input.GetKey(KeyCode.Escape))
			Application.LoadLevel(Application.loadedLevel);
	}
	
	IEnumerator ResetSword()
	{
		yield return new WaitForSeconds(2.0f);
		sword_cent.transform.rotation = sword_norm.rotation;
		isblock = false;
	}
	
	void SetTransform(Transform main, Transform target)
	{
		main.position = target.position;
		main.rotation = target.rotation;
	}
	
	void MakeStep()
	{
		audio.PlayOneShot(step_snd[stepnumb]);
		stepnumb+=1;
		if(stepnumb == step_snd.Length) stepnumb = 0;
	}
	
	public void KillPlayer()
	{
		if(!iskilled)
		{
			iskilled = true;
			audio.PlayOneShot(death_snd);
			GetComponent<DeathGUI>().enabled = true;
			GetComponent<FPSInputController>().enabled = false;
			GetComponent<CharacterMotor>().enabled = false;
			GetComponent<MouseLook>().enabled = false;
		}
	}
	
	IEnumerator StepTimer()
	{
		yield return new WaitForSeconds(0.5f);
		dist = Vector3.Distance(gameObject.transform.position,oldpos);
		if(dist > 4)
		{
			MakeStep();
			yield return new WaitForSeconds(0.25f);
			MakeStep();
		}
		else if(dist > 0.5)
			MakeStep();
		
		oldpos = gameObject.transform.position;
		StartCoroutine(StepTimer());
	}
	
	public void ShowMessage(string message)	
	{
		gui_info.text = message;
		gui_info.enabled = true;
		StartCoroutine(HideMessage());
	}
	
	IEnumerator HideMessage()
	{
		yield return new WaitForSeconds(2.0f);
		gui_info.enabled = false;
	}
}