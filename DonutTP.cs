using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutTP : MonoBehaviour {
	public GameObject target;
	public void OnTriggerEnter(Collider collider){
		GameObject other = collider.gameObject;
		Donut donut = other.GetComponent<Donut> ();
		if (donut != null) {
			other.transform.position = target.transform.position;
		}	
	}	
}