using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour {
	public float damage;
	public float atkSpeed;
	public int range;
	public bool ableToFire = true;
	private IEnumerator fireCoRo;

	/* Hal Assisted Code*/
	public IEnumerator Fire(Donut donut) {
		if (donut != null) {
			donut.TakeDamage (this.damage); 
			ableToFire = false;
			Debug.Log ("BOOM");
			yield return new WaitForSeconds (atkSpeed);
			Debug.Log ("RELOAD");
			ableToFire = true;
		}
	}
	public void OnTriggerStay(Collider collider){
		if (ableToFire) {
			GameObject other = collider.gameObject;
			Donut donut = other.GetComponent<Donut> ();
			fireCoRo = Fire (donut);
			StartCoroutine(fireCoRo);
		}
	}
}