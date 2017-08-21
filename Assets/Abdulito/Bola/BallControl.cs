using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    static Dictionary<string, GameObject> playersInstanciated = new Dictionary<string, GameObject>
        {
            { "Player 1", null },
            { "Player 2", null },
            { "Player 3", null },
            { "Player 4", null },
            { "Player 5", null },
            { "Player 6", null }
        };

    public GameObject cuentaAtras;
    public GameObject instrucciones;
    public enum PLAYER {
        ONE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX
    }

    public int score;

    public static Dictionary<string,int> scoreArray = new Dictionary <string,int>{
        {"Player 1", 0},
        {"Player 2", 0},
        {"Player 3", 0},
        {"Player 4", 2},
        {"Player 5", 0},
        {"Player 6", 0}
    };

    public PLAYER playerNumber;

	private bool isEnabled;

    private Vector3 currentDirection = new Vector3(1f,0,0);

    public float acceleration = 0.5f;
    public float rotation_force = 0.1f;

    public GameObject arrow;

    private GameObject pointingArrow;

    // boost attributes
    private float boost;
    private bool boostIsPressed;

    [HeaderAttribute("Atributos de boost")]
    public float max;
    public float velocidad;
    public float jumpFactor;

    void Start(){

		score = 0;
		isEnabled = true;
		boost = 0;
        pointingArrow =
      		(GameObject)Instantiate(arrow, transform.position, transform.rotation);
		Debug.Log("respawneao");
	}


    void Update(){
        scoreArray[transform.root.gameObject.tag] = score;
		handleControl();
        updateArrow();
    }

	void OnDestroy() {
		if (playersInstanciated[gameObject.tag] == gameObject.transform.root.gameObject) {
			playersInstanciated[gameObject.tag] = null;
		}
		Destroy(pointingArrow.transform.root.gameObject);
	}

    void updateArrow(){

      // position
      pointingArrow.GetComponent<Transform>().position = GetComponent<Transform>().position;

      pointingArrow.GetComponent<Transform>().LookAt(new Vector3(1f, 0, 0));
      pointingArrow.GetComponent<Transform>().localScale = GetComponent<Transform>().localScale*0.7f;

      // rotation
      pointingArrow.GetComponent<Transform>().LookAt( pointingArrow.GetComponent<Transform>().position -
        currentDirection);
    }

    // for the moment, just keyboard controls
    void handleControl()
    {
		if (!isEnabled)
			return;
		Rigidbody body = GetComponent<Rigidbody>();
        float angle = 0;

        float avance = 0;
        if (playerNumber == PLAYER.ONE){
          if (Input.GetKey("a")) {
            angle = rotation_force;
          }
          else if (Input.GetKey("d")) {
            angle = -rotation_force;
          }

         // avance go
          if (Input.GetKey("w")){
            avance = acceleration;
          }

          // boost
          handleBoost("space");

        }
        else if (playerNumber == PLAYER.TWO){
          if (Input.GetKey("left")) {
            angle = rotation_force;
          }
          else if (Input.GetKey("right")) {
            angle = -rotation_force;
          }

          // avance
          if (Input.GetKey("up")){
            avance = acceleration;
          }

          // boost
          handleBoost("+");

        }
        else if (playerNumber == PLAYER.THREE)
        {
            if (Input.GetAxis("Horizontal Joystick 1") < -0.5f)
            {
                angle = rotation_force;
            }
            else if (Input.GetAxis("Horizontal Joystick 1") > 0.5f)
            {
                angle = -rotation_force;
            }

            // avance
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                avance = acceleration;
            }

            // boost

            if (boostIsPressed)
            {
                if (!Input.GetKeyUp(KeyCode.Joystick1Button1))
                {
                    if (boost < max)
                        boost += velocidad;
                }
                else
                {
                    applyBoost();
                    boostIsPressed = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                boostIsPressed = true;
                boost = 0;
            }

        }


        else if (playerNumber == PLAYER.FOUR)
        {
            if (Input.GetAxis("Horizontal Joystick 2") < -0.5f)
            {
                angle = rotation_force;
            }
            else if (Input.GetAxis("Horizontal Joystick 2") > 0.5f)
            {
                angle = -rotation_force;
            }

            // avance
            if (Input.GetKey(KeyCode.Joystick2Button0))
            {
                avance = acceleration;
            }

            // boost
            if (boostIsPressed)
            {
                if (!Input.GetKeyUp(KeyCode.Joystick2Button1))
                {
                    if (boost < max)
                        boost += velocidad;
                }
                else
                {
                    applyBoost();
                    boostIsPressed = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Joystick2Button1))
            {
                boostIsPressed = true;
                boost = 0;
            }

        }

        else if (playerNumber == PLAYER.FIVE)
        {
            if (Input.GetAxis("Horizontal Joystick 3") < -0.5f)
            {
                angle = rotation_force;
            }
            else if (Input.GetAxis("Horizontal Joystick 3") > 0.5f)
            {
                angle = -rotation_force;
            }

            // avance
            if (Input.GetKey(KeyCode.Joystick3Button0))
            {
                avance = acceleration;
            }

            // boost
            if (boostIsPressed)
            {
                if (!Input.GetKeyUp(KeyCode.Joystick3Button1))
                {
                    if (boost < max)
                        boost += velocidad;
                }
                else
                {
                    applyBoost();
                    boostIsPressed = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Joystick3Button1))
            {
                boostIsPressed = true;
                boost = 0;
            }

        }

        else if (playerNumber == PLAYER.SIX)
        {
            if (Input.GetAxis("Horizontal Joystick 4") < -0.5f)
            {
                angle = rotation_force;
            }
            else if (Input.GetAxis("Horizontal Joystick 4") > 0.5f)
            {
                angle = -rotation_force;
            }

            // avance
            if (Input.GetKey(KeyCode.Joystick4Button0))
            {
                avance = acceleration;
            }

            // boost
            if (boostIsPressed)
            {
                if (!Input.GetKeyUp(KeyCode.Joystick4Button1))
                {
                    if (boost < max)
                        boost += velocidad;
                }
                else
                {
                    applyBoost();
                    boostIsPressed = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Joystick4Button1))
            {
                boostIsPressed = true;
                boost = 0;
            }

        }
        //control.Normalize();

        currentDirection = apply2DRotation(currentDirection, angle);
				body.velocity += currentDirection*avance;
    }

    // generar el boost desde un boton preciso
    void handleBoost(string button){
      if(boostIsPressed){
        if (!Input.GetKeyUp(button)){
          if(boost < max)
            boost += velocidad;
        } else {
          applyBoost();
          boostIsPressed = false;
        }
      } else if (Input.GetKeyDown(button)) {
        boostIsPressed = true;
        boost = 0;
      }
    }

    void applyBoost(){
			Rigidbody body = GetComponent<Rigidbody>();
      Vector3 boostvector = new Vector3(0, 1, 0)*jumpFactor;
      boostvector += currentDirection;
      boostvector.Normalize();
      body.velocity += boostvector*boost;
    }

		static public Vector3 apply2DRotation(Vector3 vector, float rotation) {
			return new Vector3(
          vector.x * Mathf.Cos(rotation) - vector.z * Mathf.Sin(rotation),
					0,
					vector.z * Mathf.Cos(rotation) + vector.x * Mathf.Sin(rotation)
			);
		}

	public void enable() {
		isEnabled = true;
	}
	public void disable() {
		isEnabled = false;
	}
    public void DesactivaCuentaAtras()
    {
        cuentaAtras.SetActive(false);
        instrucciones.SetActive(false);
    }
}
