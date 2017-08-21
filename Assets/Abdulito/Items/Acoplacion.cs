using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// acoplar item en bola
public class Acoplacion : MonoBehaviour {

	static string[] tags = new string[] { "Player 1",
										  "Player 2",
										  "Player 3",
										  "Player 4",
										  "Player 5",
										  "Player 6" };

	void OnTriggerEnter(Collider other) {
		if (other.tag == "item") {
			transform.root.gameObject.GetComponent<BallControl>().score += 1;

			transform.parent.GetComponent<Absortion>().absorbed.Add(other.gameObject);
			other.gameObject.tag = "absorbed";
			other.gameObject.GetComponent<Transform>().parent =
					GetComponent<Transform>();

			// create new object and associate collider there
			GameObject new_collider_object = new GameObject();
			new_collider_object.GetComponent<Transform>().position =
				other.GetComponent<Transform>().position;
			new_collider_object.GetComponent<Transform>().rotation =
				other.GetComponent<Transform>().rotation;
			new_collider_object.GetComponent<Transform>().parent =
				GetComponent<Transform>().parent;

			new_collider_object.tag = gameObject.tag;

			Utils.CopyComponent<Collider>(other, new_collider_object);

			new_collider_object.GetComponent<CapsuleCollider>().height =
					other.gameObject.GetComponent<CapsuleCollider>().height;

			new_collider_object.GetComponent<CapsuleCollider>().direction =
					other.gameObject.GetComponent<CapsuleCollider>().direction;

			new_collider_object.GetComponent<CapsuleCollider>().radius =
					other.gameObject.GetComponent<CapsuleCollider>().radius;
			Debug.Log("acoplacion!!");

			new_collider_object.transform.localScale = other.transform.localScale;

			// kinematic -> false
			other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			other.gameObject.GetComponent<Collider>().isTrigger = true;

			
			

		} else if (Array.Exists(tags, x => x == other.tag) && other.tag != transform.root.tag) {
			// add speed
			Debug.Log("hello collision acoplao " + other.tag + " vs " + transform.root.tag);
			//Debug.Log(transform.parent.transform.parent.GetComponent<Rigidbody>().velocity);
			Rigidbody rb = other.transform.root.GetComponent<Rigidbody>();
			rb.velocity += transform.root.GetComponent<Rigidbody>().velocity * Utils.CollisionForce;

		}
	}
}
