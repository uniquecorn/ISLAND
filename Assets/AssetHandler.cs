using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetHandler : MonoBehaviour
{
	public Sprite[] fill;
	public Sprite[] island;

	public Sprite[] edgeT;
	public Sprite[] edgeB;
	public Sprite[] edgeL;
	public Sprite[] edgeR;

	public Sprite[] corrLR;
	public Sprite[] corrTB;


	public Sprite[] cornerLT;
	public Sprite[] cornerRT;
	public Sprite[] cornerLB;
	public Sprite[] cornerRB;

	public Sprite[] edgeLTR;
	public Sprite[] edgeLTB;
	public Sprite[] edgeRTB;
	public Sprite[] edgeRLB;

	public GameObject grid;

	public static AssetHandler instance;

	// Use this for initialization
	void Start ()
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
