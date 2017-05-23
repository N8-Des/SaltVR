using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : MonoBehaviour {


	public List<Transform> nodes = new List<Transform>();
	public Transform nextNode;
	public float moveSpeed = 1.0f;
	public float closeEnough = 0.1f;
	public Rigidbody phys;
	public int nodeIndex = 0;
	public HealthDisplay healthDisplay;

	// Use this for initialization

	public void Start () {
		nextNode = nodes [0];
		phys = GetComponent<Rigidbody> ();
	}


	// Update is called once per frame
	public void Update () {
		MoveTowardsNextNode ();
	}

	public void MoveTowardsNextNode(){
		Vector3 delta = nextNode.transform.position - transform.position;
		phys.velocity = delta.normalized * moveSpeed;

		Debug.Log (delta);
		if (delta.magnitude < closeEnough) {
			Debug.Log ("CLOSE ENUF");
			nodeIndex++;
			if (nodeIndex >= nodes.Count) {
				healthDisplay.TakeDamage (1);
				Destroy (this.gameObject);
			} else {
				nextNode = nodes [nodeIndex];
			}
		}
	}


}
