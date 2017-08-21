using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour {

  public float attractionFactor = 1;
  public float fuerza = 1;
  private float radio;
  private List<GameObject> inRadius = new List<GameObject>();


	// Update is called once per frame
	void Update () {
    radio =
			GetComponent<Transform>().parent.GetComponent<CharacterPositioner>().getScale() * attractionFactor;
		GetComponent<SphereCollider>().radius = radio;
		updateSpeed();
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "item") {
      inRadius.Add(other.gameObject);
      Physics.IgnoreCollision(other,
			    GetComponent<Transform>().parent.GetComponent<SphereCollider>());

		}
	}

	void OnTriggerExit(Collider other){
    if (other.tag == "item") {
			deleteCollider(other.gameObject);
		}
  }

	public void deleteCollider(GameObject other) {
			inRadius.Remove(other);
	}

	private Vector3 calculateAttraction(GameObject item) {
		Vector3 direction = GetComponent<Transform>().position -
			item.GetComponent<Transform>().position;

		float distance = direction.magnitude;
    float force = (radio - distance)
				* GetComponent<Transform>().parent.GetComponent<CharacterPositioner>().getScale();

    return direction*force;
	}

  public void updateSpeed() {
    // cleanup
		int i = 0;
    while(i < inRadius.Count) {
      if (inRadius[i].gameObject.tag == "absorbed"){
        deleteCollider(inRadius[i]);
				i++;
			}
			i++;
		}

		foreach (GameObject collider in inRadius) {
      if (collider.gameObject.tag == "absorbed")
				deleteCollider(collider);
		}

    foreach (GameObject collider in inRadius){
      Vector3 attraction = calculateAttraction(collider.gameObject);
    	collider.GetComponent<Rigidbody>().velocity += attraction;
    }
	}

	void OnCollisionEnter(){
		//Debug.Log("colision!!!11!1!");
    }

}
