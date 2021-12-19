using UnityEngine;
using System.Collections;

public class SpawnGizmo : MonoBehaviour {
	
	public Vector3 gizmo_size;
	public int line_length = 2;
	
	void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position,transform.position + transform.forward*line_length);
		Gizmos.color = Color.red;
		Gizmos.DrawCube(transform.position,gizmo_size);
	}
}
