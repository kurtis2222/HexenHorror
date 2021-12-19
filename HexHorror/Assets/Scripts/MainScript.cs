using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
	
	public AudioClip death_snd;
	public AudioClip[] step_snd;
	AudioClip[] random_snd;
	Object[] temp;
	
	public GameObject flashlight;
	public Transform flash_normal;
	public Transform flash_run;
	
	bool issprinting = false;
	bool isdown = false;
	bool iskilled = false;
	
	Vector3 oldpos;
	int stepnumb = 0;
	float dist = 0.0f;
	
	GUIText gui_info;
	
	void Start()
	{
		gui_info = GameObject.Find("HudInfo").guiText;
		temp = Resources.LoadAll("RandomSound",typeof(AudioClip));
		random_snd = new AudioClip[temp.Length];
		for(int i = 0; i < temp.Length; i++)
			random_snd[i] = (AudioClip)temp[i];
		temp = null;
		ShowMessage("Get all the 3 parts of the sword");
		oldpos = gameObject.transform.position;
		StartCoroutine(StepTimer());
		StartCoroutine(RandomSound());
		Screen.showCursor = false;
		Screen.lockCursor = true;
	}
	
	void FixedUpdate()
	{
		if(!iskilled)
		{
			if(Input.GetButton("Run/Sprint"))
			{
				SetTransform(flashlight.transform, flash_run);
				issprinting = true;
			}
			else if(issprinting)
			{
				SetTransform(flashlight.transform, flash_normal);
				issprinting = false;
			}
			if(!isdown)
			{
				if(Input.GetButton("Fire2"))
				{
					flashlight.light.enabled = !flashlight.light.enabled;
					isdown = true;
				}
			}
		}
		if(!Input.GetButton("Fire2")) isdown = false;
		
		if(Input.GetKey(KeyCode.Escape))
			Application.LoadLevel(Application.loadedLevel);
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
			flashlight.light.enabled = false;
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
	
	IEnumerator RandomSound()
	{
		yield return new WaitForSeconds(Random.Range(8,16));
		audio.PlayOneShot(random_snd[Random.Range(0,random_snd.Length)]);
		StartCoroutine(RandomSound());
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