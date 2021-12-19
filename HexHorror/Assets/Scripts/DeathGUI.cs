using UnityEngine;
using System.Collections;

public class DeathGUI : MonoBehaviour {

	public Texture death_texture;
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),death_texture);
	}
}
