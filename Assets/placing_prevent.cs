using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placing_prevent : MonoBehaviour {

	public void UiEnter(){
		print ("eiei");
		globalvariable.IsOverUi = true;
	}
	public void UiExit(){
		globalvariable.IsOverUi = false;
	}
}
