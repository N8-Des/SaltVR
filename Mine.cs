using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {
	public float damage;
	public void explode(){		
		var exp = GetComponent<ParticleSystem>();
		exp.Play();
		Destroy(gameObject, exp.duration);
	}
	public void OnTriggerEnter(Collider collider){
		GameObject other = collider.gameObject;
		Donut donut = other.GetComponent<Donut> ();
		if (donut != null) {
			donut.TakeDamage (this.damage); 
			explode();
		}
	}
}