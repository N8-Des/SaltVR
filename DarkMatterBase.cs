using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMatterBase : MonoBehaviour {
	public float damage;
	public float atkSpeed;
	public int range;
	public bool ableToFire = true;
	public ParticleSystem lightn;
	public List<Donut> donuts = new List<Donut> ();
	private IEnumerator fireCoRo;

	public IEnumerator Fire() {
		List<Donut> toRemove = new List<Donut>();
		foreach (Donut donut in donuts) {
			bool dead = donut.TakeDamage (this.damage) || donut.dead;
			if (dead) {
				toRemove.Add(donut);
			}
		}


		foreach (Donut donut in toRemove) {
			donuts.Remove (donut);
			toRemove.Remove (donut);
		}
		lightn.Play ();
		ableToFire = false;
		yield return new WaitForSeconds (atkSpeed);
		ableToFire = true;
	}


	public void OnTriggerEnter(Collider collider) {
		GameObject other = collider.gameObject;
		Donut donut = other.GetComponent<Donut> ();
		if (donut != null) {
			donuts.Add (donut);
		}

	}

	public void OnTriggerExit(Collider collider) {
		GameObject other = collider.gameObject;
		Donut donut = other.GetComponent<Donut> ();
		if (donut != null) {
			donuts.Remove (donut);
		}
	}


	public void Update(){
		if (ableToFire) {
			if (donuts.Count > 0) {
				fireCoRo = Fire ();
				StartCoroutine (fireCoRo);
			}
		}
	}
//	public void OnTriggerStay(Collider collider){
//	}
}