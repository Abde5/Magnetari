using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPositioner : MonoBehaviour {

	public GameObject characterPrefab;
	public Vector3 offset = new Vector3(0, 0f, 0);
	public float turnSpeed;

	public GameObject campoFuerza;

	private GameObject character;
	private float scale = 1;
	private Vector3 currentLookat;

	void Start() {
		currentLookat = new Vector3(1, 0, 0);
		character =
			(GameObject)Instantiate(characterPrefab, transform.position, transform.rotation);
	}

	private void OnDestroy() {
		Destroy(character);
	}


	// actualizar direccion del personaje
	void Update () {

		// put character on ball
		Transform character_trans = character.GetComponent<Transform>();
		Transform player_trans = GetComponent<Transform>();

		character_trans.position = player_trans.position+ (scale*new Vector3(0,1,0)) + offset;

		Rigidbody player_rigid = GetComponent<Rigidbody>();
		Vector3 direction = player_rigid.velocity;
		direction.y = 0;

		// lookat slowly
		direction.Normalize();
		currentLookat += direction * turnSpeed;
		currentLookat.Normalize();

		character.GetComponent<Transform>().LookAt(character.GetComponent<Transform>().position + currentLookat);

		character.GetComponent<Transform>().position = GetComponent<Transform>().position;

		relocate();

        // update animation
        updateAnimation();
	}

    void updateAnimation()
    {
        Animator anim = character.GetComponent<Animator>();
        // if velocity up - moving true
        if(GetComponent<Rigidbody>().velocity.magnitude > 0.1f) {
            anim.SetBool("Moving", true);
        } else {
            anim.SetBool("Moving", false);
        }

    }

	void relocate() {
		RaycastHit hit;

		int mask = (1 << LayerMask.NameToLayer("Gameplay"));
		Vector3 beforeCampo = new Vector3(0, 1, 0);
		beforeCampo *= campoFuerza.GetComponent<SphereCollider>().radius*0.01f;

		Ray ray = new Ray(GetComponent<Transform>().position+beforeCampo,new Vector3(0,-1,0));
		if (Physics.Raycast(ray, out hit, mask)){
			Vector3 newPosition = hit.point + new Vector3(0, 0.2f, 0);
			
			// TOFIX: magnet to move fluidly
			//character.GetComponent<Transform>().position += (newPosition - character.GetComponent<Transform>().position)*1f;
			character.GetComponent<Transform>().position = newPosition;
			Rigidbody player_rigid = GetComponent<Rigidbody>();
			
		}

	}

	public float getScale() {
        return scale;
	}

}
