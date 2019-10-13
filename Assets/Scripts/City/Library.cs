using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Library : MonoBehaviour
{
	public GameObject SelectMenu;
	ToolBar toolBar;
	public Animator anim;
	private void Start()
	{
		if (SelectMenu.activeInHierarchy)
		{
			SelectMenu.SetActive(false);
		}
		toolBar = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ToolBar>();
	}
	public void ActivateMenu()
	{
		
		toolBar.InOfSelectMenu();
		SelectMenu.SetActive(true);
		Interactable.CursorLock();
		Interactable.NoShoot();
	}
	public void DeactivateMenu()
	{
		toolBar.OutOfSelectMenu();
		SelectMenu.SetActive(false);
		Interactable.CursorOpen();
		Interactable.Shoot();
	}
	




}
