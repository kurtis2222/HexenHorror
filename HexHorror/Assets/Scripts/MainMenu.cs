using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	GUIStyle labelstyle = new GUIStyle();
	GUIStyle labelstyle2 = new GUIStyle();
	public GameObject playerobj;
	public GameObject[] monsters;
	string code = "000";
	
	public Transform start2;
	public Transform start3;
	
	void Start()
	{
		Screen.showCursor = true;
		Screen.lockCursor = false;
		labelstyle.fontSize = 32;
		labelstyle.normal.textColor = Color.red;
		labelstyle2.fontSize = 32;
		labelstyle2.normal.textColor = Color.white;
		labelstyle2.alignment = TextAnchor.MiddleCenter;
	}
	
	void FixedUpdate()
	{
		if(Input.GetKey(KeyCode.Escape))
			Application.Quit();
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(0,0,384,64),"HeXen Horror Game",labelstyle);
		GUI.Label(new Rect(0,Screen.height - 32,256,64),"Version: 1.0",labelstyle);
		GUI.Label(new Rect(Screen.width / 2 -128, Screen.height / 2 -128, 256, 64), "Select a difficulty", labelstyle2);
		if(GUI.Button(new Rect(Screen.width / 2 -64,  Screen.height / 2 -64, 128, 32), "Easy"))
			StartDifficulty(5);
		else if(GUI.Button(new Rect(Screen.width / 2 -64,  Screen.height / 2 -32, 128, 32), "Medium"))
			StartDifficulty(6);
		else if(GUI.Button(new Rect(Screen.width / 2 -64,  Screen.height / 2, 128, 32), "Hard"))
			StartDifficulty(7);
		GUI.Label(new Rect(Screen.width / 2 -128, Screen.height / 2 +128, 256, 64), "Level Code", labelstyle2);
		code = GUI.TextField(new Rect(Screen.width / 2 -16, Screen.height / 2 +192, 32, 24), code, 3);
		
		if(code == "386") SetTransform(playerobj.transform, start2);
		else if(code == "768") SetTransform(playerobj.transform, start3);
	}
	
	void StartDifficulty(int ms_speed)
	{
		for(int i = 0; i < monsters.Length; i++)
			monsters[i].GetComponent<NavMeshAgent>().speed = ms_speed;
		
		camera.enabled = false;
		playerobj.SetActiveRecursively(true);
		gameObject.GetComponent<SpawnElement>().enabled = true;
		enabled = false;
	}
	
	void SetTransform(Transform main, Transform target)
	{
		main.position = target.position;
		main.rotation = target.rotation;
	}
}
