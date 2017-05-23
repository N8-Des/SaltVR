using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cream : MonoBehaviour {
	public float damage;
	public float atkSpeed;
	public int range;
	private IEnumerator LifeTime;
	public bool alive = true;

	public IEnumerator Destroy(){
		yield return new WaitForSeconds (atkSpeed);
		alive = false;
		Destroy (this.gameObject);
	}

	public void OnTriggerStay(Collider collider){
		GameObject other = collider.gameObject;
		Donut donut = other.GetComponent<Donut> ();
		if (donut != null) {
			donut.TakeDamage (this.damage);
		}
	}
	public void Update(){
		if (alive) {
			LifeTime = Destroy ();
			StartCoroutine (LifeTime);
		}
	}
}