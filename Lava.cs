using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {
	public float damage;
	public float atkSpeed;
	public int range;

	public void OnTriggerStay(Collider collider){
		GameObject other = collider.gameObject;
		Donut donut = other.GetComponent<Donut> ();
			if (donut != null) {
				donut.TakeDamage (this.damage);
	}
	}
}