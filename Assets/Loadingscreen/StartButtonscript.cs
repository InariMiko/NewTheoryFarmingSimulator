using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonscript : MonoBehaviour {

	public void loadscene(string name)
    {
        Application.LoadLevel(name);
    }
}
