using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spell_Slot : MonoBehaviour
{
	public Spell spell;
	Image ig;
	Animator button;
	public bool yellow;
	private void Awake()
	{		
		ig = GetComponent<Image>();
		ig.sprite = spell.icon;
		button = GetComponentInParent<Animator>();
	}
	private void OnEnable()
	{
		button.SetBool("Yellow", yellow);
	}
	public void ButtonAddSpell()
	{
		FindObjectOfType<ToolBar>().AddSpell(spell,button);
		yellow = true;
		button.SetBool("Yellow", yellow);
		
	}
}
