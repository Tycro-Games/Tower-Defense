using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Interactable : MonoBehaviour
{
	bool NotAlreadyIn;
	static FirstPersonController firstPersonController;
	static Shoot shot;
	public ToolBar toolBar;
	public static bool InLibrary;
	private void Start()
	{
		firstPersonController = GetComponent<FirstPersonController>();
		shot = GetComponentInChildren<Shoot>();
		InteractionWithGround.Add(transform);
		
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Building_Interactable" && Input.GetKey(KeyCode.E) && !NotAlreadyIn)
		{
			if (other.name == "Library")
			{

				other.GetComponent<Library>().ActivateMenu();
				
				NotAlreadyIn = true;
			}
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Building_Interactable")
		{
			if (other.name == "Library")
			{
				other.GetComponent<Library>().DeactivateMenu();
				NotAlreadyIn = false;
			}
		}
	}
	private void Update()
	{
		//enter some Inventory
		if (Input.GetKeyDown(KeyCode.Tab) && firstPersonController.m_CharacterController.isGrounded)
		{
			if (firstPersonController.CamMoving)
			{

				CursorLock();
			}
			else
			{

				CursorOpen();
			}
		}
		if (firstPersonController.canMove)
		{
			firstPersonController.m_PreviouslyGrounded = firstPersonController.m_CharacterController.isGrounded;
		}

	}
	public static void CursorLock()
	{
		InLibrary = true;
		firstPersonController.CamMoving = false;
		firstPersonController.canMove = false;
		firstPersonController.m_PreviouslyGrounded = false;
		shot.enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	public static void CursorOpen()
	{
		InLibrary = false;
		firstPersonController.CamMoving = true;
		firstPersonController.canMove = true;
		shot.enabled = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	public static void NoShoot()
	{
		
		shot.enabled = false;
	}
	public static void  Shoot()
	{
		shot.enabled = true;
	}
}
