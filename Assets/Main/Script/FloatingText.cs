using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatingText : MonoBehaviour {

	public Animator animator;
	private string damageText;
	// Use this for initialization
	void Start () {
		AnimatorClipInfo[] clipinfo = animator.GetCurrentAnimatorClipInfo (0);
		Destroy (gameObject, clipinfo [0].clip.length);
		damageText = animator.gameObject.GetComponent<TextMeshProUGUI> ().text;
	}

	public void SetText(string text)
	{
		damageText = text;
	}
}
