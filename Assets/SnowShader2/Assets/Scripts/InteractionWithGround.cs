using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithGround : MonoBehaviour
{
	public Shader drawShader;
	private Material drawMaterial;
	private Material myMaterial;
	public GameObject _terrain;
	static List<Transform> _objects = new List<Transform>();
	RaycastHit _groundHit;
	int _layerMask;
	private RenderTexture splatmap;
	[Range(0, 50)]
	public float _brushSize;
	[Range(0, 1)]
	public float _brushStrength;
	public static void Sort(Transform tr)
	{
		_objects.Remove(tr);
	}
	public static void Add(Transform tr)
	{
		_objects.Add(tr);
	}
	
	void Start()
	{
		_layerMask = LayerMask.GetMask("Ground");
		drawMaterial = new Material(drawShader);
		_terrain = GameObject.FindGameObjectWithTag("Ground");
		myMaterial = _terrain.GetComponent<MeshRenderer>().material;
		myMaterial.SetTexture("_Splat", splatmap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat));

	}

	// Update is called once per frame
	void LateUpdate()
	{

		foreach (Transform tr in _objects)
		{
			if (Physics.Raycast(tr.position, -Vector3.up, out _groundHit, 1f, _layerMask))
			{
				drawMaterial.SetVector("_Coordinate", new Vector4(_groundHit.textureCoord.x, _groundHit.textureCoord.y, 0, 0));
				
			}
			drawMaterial.SetFloat("_Strength", _brushStrength);
			drawMaterial.SetFloat("_Size", _brushSize);
			RenderTexture temp = RenderTexture.GetTemporary(splatmap.width, splatmap.height, 0, RenderTextureFormat.ARGBFloat);
			Graphics.Blit(splatmap, temp);
			Graphics.Blit(temp, splatmap, drawMaterial);
			RenderTexture.ReleaseTemporary(temp);
		}
		
	}
}