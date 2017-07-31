using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GridData
{
	public int x;
	public int y;

	public bool occupied;

	[System.Serializable]
	public struct Edges
	{
		public bool TOP;
		public bool BOTTOM;
		public bool LEFT;
		public bool RIGHT;

		public bool TOPLEFT;
		public bool BOTTOMLEFT;
		public bool TOPRIGHT;
		public bool BOTTOMRIGHT;
	}

	public Edges edgeData;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	void FindEdges()
	{
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
