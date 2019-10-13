using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CreateAssetMenu(fileName = "spell", menuName = "Create a spell")]
[Serializable]
public class Spell : ScriptableObject
{
	public string String_name;
	public Sprite icon;
	public GameObject upgradeObject;
	Upgrades upgrade;
	private void OnEnable()
	{
		upgrade = upgradeObject.GetComponent<Upgrades>();
	}



}

