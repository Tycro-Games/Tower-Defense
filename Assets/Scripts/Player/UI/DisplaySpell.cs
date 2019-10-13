using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DisplaySpell : MonoBehaviour
{

	public Spell spell;
	Image icon;
	TextMeshProUGUI text;
	public GameObject Remove;
	public Animator animator;
	public bool activate;
	private void Start()
	{
		text = GetComponentInChildren<TextMeshProUGUI>();
		icon = GetComponent<Image>();
		if (Remove != null)
		{
			if (Remove.activeSelf)
			{
				Remove.SetActive(false);
			}
		}
	}

	void Update()
	{

		if (icon.sprite == null)
		{
			icon.enabled = false;

		}
		else
		{
			icon.enabled = true;
		}
		if (spell != null)
		{

			if (icon.sprite == null)
			{
				icon.sprite = spell.icon;
			}

			if (activate && spell != null)
			{
				icon.color = Color.red;

				Debug.Log("selected" + name);

			}
			else
			{
				icon.color = Color.white;

			}
		}


	}

	public void Dest()
	{
		animator.SetBool("Yellow", false);
		spell = null;
		icon.sprite = null;

	}

}
