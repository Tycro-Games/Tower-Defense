using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar : MonoBehaviour
{
	public DisplaySpell[] Displays;
	Spell Selected = null;
	Transform cam;
	public float Range = 10f;
	public LayerMask layerMask;
	private void Start()
	{
		cam = Camera.main.transform;






	}
	public void OutOfSelectMenu()
	{
		foreach (DisplaySpell spell in Displays)
		{
			if (spell.spell != null)
				spell.Remove.SetActive(false);

		}

	}
	public void InOfSelectMenu()
	{
		foreach (DisplaySpell spell in Displays)
		{
			if (spell.spell != null)
				spell.Remove.SetActive(true);

		}

	}
	private void Update()
	{
		#region Input
		if (!Interactable.InLibrary)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1) && Displays.Length > 0 && Displays[0].spell != null)
			{


				if (Selected == null)
				{
					Displays[0].activate = true;
					Selected = Displays[0].spell;
				}
				else
				{
					Deactivate();
				}
			}



		}

		#endregion

		if (Selected != null && Input.GetMouseButtonDown(1))
		{
			if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, Range, layerMask, QueryTriggerInteraction.Ignore))
			{
				Upgrades[] upgrades = hit.collider.GetComponents<Upgrades>();
				if (upgrades != null)
				{

					foreach (Upgrades upgrade in upgrades)
					{

						if (upgrade.Sring_name == Selected.String_name)
						{

							upgrade.enabled = true;
							break;
						}
					}
				}
			}

		}
	}
	void Deactivate()
	{
		foreach (DisplaySpell spell in Displays)
		{
			if (spell.activate == true)
			{
				spell.activate = false;
			}
		}
		Selected = null;
	}

	public void AddSpell(Spell MySpell,Animator anim)
	{

		bool Placed = false;
		while (!Placed)
		{
			foreach (DisplaySpell display in Displays)
			{
				if (display.spell == null)
				{
					display.animator = anim;
					display.spell = MySpell;
					//remove button is active now
					display.Remove.SetActive(true);
					Placed = true;
					break;
				}
			}

			break;
		}
		if (!Placed)
		{
			Debug.Log("No space for other spells");
		}
	}
}
