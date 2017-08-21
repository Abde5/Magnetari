using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	static public int maxPlayers = 6;

	public GameObject number;

    static public int chosenNumber;
	public Sprite[] numbersSprite;

	public void Start() {
		chosenNumber = 1;
	}

	public void incrementNumber() {
		if (chosenNumber < 6)
			chosenNumber += 1;
		updateNumber();
	}

	public void decrementNumber() {
		if (chosenNumber > 1)
			chosenNumber -= 1;
		updateNumber();
	}

	public void updateNumber() {
		number.transform.GetComponent<UnityEngine.UI.Image>().sprite = numbersSprite[chosenNumber - 1];
	}

}
