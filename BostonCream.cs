using UnityEngine;
using System.Collections;

public class BostonCream : Donut
{
	
	public Vector3 offset = new Vector3 (0.0f, -0.75f, 0.0f);												//Returns true if damage killed this object -- Hal
	public override bool  TakeDamage (float damage)
	{
		health = health - damage;
		if (health <= 0) {
			if (dead == false) {
				GameObject Cream = GameObject.Instantiate ((GameObject)Resources.Load ("Cream"));
				Debug.Log ("What");
				Cream.AddComponent<Rigidbody> ();
				Cream.transform.position = this.transform.position + offset;
				Destroy (this.gameObject);
				dead = true;
				return true;
				} else {
					return false;
				}
			} else {
				return false; 
		}
}
}