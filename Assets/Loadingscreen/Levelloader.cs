using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelloader : MonoBehaviour
{

    public void loadscene(string name)
    {
        Application.LoadLevel(name);
    }
	public void exit_to_desktop() {
		Application.Quit();
	}
}
