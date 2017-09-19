using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenuController : MonoBehaviour {

	public GameObject Pausemenu;
	public GameObject FPS;
	bool active=false;
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) &&!active)
		{
			Pausemenu.SetActive (true);
			FPS.gameObject.GetComponent<FirstPersonController> ().CanMove = false;
			Cursor.visible = true;
			Cursor.lockState= CursorLockMode.None;
			active = true;
			Time.timeScale = 0;
		}
		else if(Input.GetKeyDown(KeyCode.Escape)&&active)
		{
			resume ();
		}
	}
	public void resume()
	{
		FPS.gameObject.GetComponent<FirstPersonController> ().CanMove = true;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Pausemenu.SetActive (false);
		active = false;
		Time.timeScale = 1;
	}
}
