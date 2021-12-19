using UnityEngine;
using System.Collections;

public class CreditsRoll : MonoBehaviour {

	void Start () {
		GetComponent<TextMesh>().text =
			"HeXen Horror Game\n" +
			"Game made by Kurtis\n\n\n\n" +
			"Testers\n" +
			"Sleepy93HUN\n" +
			"TomI1997\n\n\n\n" +
			"Made with Unity\n" +
			"Sprites and Sounds are from Hexen\n" +
			"Footstep sounds are from counter-strike";
		StartCoroutine(EndGame());
	}

	void Update () {
		gameObject.transform.position += new Vector3(0,0.03f,0);
	}
	
	IEnumerator EndGame()
	{
		yield return new WaitForSeconds(30.0f);
		Application.Quit();
	}
}
