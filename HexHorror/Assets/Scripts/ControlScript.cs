using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {
	
	GameObject[] monsters;
	public GameObject[] exit1;
	public GameObject exit_trigger1;
	public GameObject[] exit2;
	public GameObject exit_trigger2;
	public GameObject exit3;
	
	public void OpenExit(int level)
	{
		if(level == 1)
		{
			for(int i = 0; i < exit1.Length; i++)
				exit1[i].SetActiveRecursively(true);
			exit_trigger1.collider.enabled = true;
		}
		else if(level == 2)
		{
			for(int i = 0; i < exit2.Length; i++)
				exit2[i].SetActiveRecursively(true);
			exit_trigger2.collider.enabled = true;
		}
		else if(level == 3)
		{
			exit3.SetActiveRecursively(true);
		}
	}
	
	public void ClearMonsters()
	{
		monsters = GameObject.FindGameObjectsWithTag("Enemy");
		for(int i = 0; i < monsters.Length; i++)
			GameObject.Destroy(monsters[i]);
		monsters = null;
	}
}
