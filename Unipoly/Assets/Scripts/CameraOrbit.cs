using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour
{
	public Transform target;
 
	public void Update()
	{
		transform.LookAt(target);
		transform.Translate(Vector3.right * Time.deltaTime);
	}
}