using UnityEngine;
using System.Collections;

public class SpawnElement : MonoBehaviour {
	
	GameObject[] boxes1;
	public GameObject element1;
	GameObject[] boxes2;
	public GameObject element2;
	GameObject[] boxes3;
	public GameObject element3;
	
	void Start ()
	{
		boxes1 = GameObject.FindGameObjectsWithTag("Element1");
		int rnd = Random.Range(0,boxes1.Length);
		GameObject.Instantiate(element1,
			boxes1[rnd].transform.position + new Vector3(0,1,0),
			boxes1[rnd].transform.rotation);
		boxes2 = GameObject.FindGameObjectsWithTag("Element2");
		rnd = Random.Range(0,boxes2.Length);
		GameObject.Instantiate(element2,
			boxes2[rnd].transform.position + new Vector3(0,1,0),
			boxes2[rnd].transform.rotation);
		boxes3 = GameObject.FindGameObjectsWithTag("Element3");
		rnd = Random.Range(0,boxes3.Length);
		GameObject.Instantiate(element3,
			boxes3[rnd].transform.position + new Vector3(0,1,0),
			boxes3[rnd].transform.rotation);
	}
}
