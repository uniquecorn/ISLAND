using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
	public int x;
	public int y;

	public SpriteRenderer sr;
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

	public int spriteIndex;

	// Use this for initialization
	void Start ()
	{
		
	}

	public void SwitchTile()
	{

		if (!edgeData.TOP && !edgeData.LEFT && !edgeData.RIGHT && !edgeData.BOTTOM && !edgeData.TOPLEFT && !edgeData.BOTTOMLEFT && !edgeData.TOPRIGHT && !edgeData.BOTTOMRIGHT)
		{
			sr.sprite = Tools.RandomObject(AssetHandler.instance.fill,out spriteIndex);
		}
		else if(edgeData.TOP && edgeData.LEFT && edgeData.RIGHT && edgeData.BOTTOM)
		{
			sr.sprite = Tools.RandomObject(AssetHandler.instance.island, out spriteIndex);
		}
		else if(edgeData.TOP)
		{
			if(edgeData.LEFT)
			{
				if(edgeData.RIGHT)
				{
					sr.sprite = Tools.RandomObject(AssetHandler.instance.edgeLTR, out spriteIndex);
				}
				else if(edgeData.BOTTOM)
				{
					sr.sprite = Tools.RandomObject(AssetHandler.instance.edgeLTB, out spriteIndex);
				}
				else
				{
					sr.sprite = Tools.RandomObject(AssetHandler.instance.cornerLT, out spriteIndex);
				}
			}
			else if (edgeData.RIGHT)
			{
				if (edgeData.BOTTOM)
				{
					sr.sprite = Tools.RandomObject(AssetHandler.instance.edgeRTB, out spriteIndex);
				}
				else
				{
					sr.sprite = Tools.RandomObject(AssetHandler.instance.cornerRT, out spriteIndex);
				}
			}
			else if (edgeData.BOTTOM)
			{
				sr.sprite = Tools.RandomObject(AssetHandler.instance.corrTB, out spriteIndex);
			}
			else
			{
				sr.sprite = Tools.RandomObject(AssetHandler.instance.edgeT, out spriteIndex);
			}
		}
		else if (edgeData.BOTTOM)
		{
			if (edgeData.LEFT)
			{
				if (edgeData.RIGHT)
				{
					sr.sprite = Tools.RandomObject(AssetHandler.instance.edgeRLB, out spriteIndex);
				}
				else
				{
					sr.sprite = Tools.RandomObject(AssetHandler.instance.cornerLB, out spriteIndex);
				}
			}
			else if (edgeData.RIGHT)
			{
				sr.sprite = Tools.RandomObject(AssetHandler.instance.cornerRB, out spriteIndex);
			}
			else
			{
				sr.sprite = Tools.RandomObject(AssetHandler.instance.edgeB, out spriteIndex);
			}
		}
		else if (edgeData.RIGHT)
		{
			if (edgeData.LEFT)
			{
				sr.sprite = Tools.RandomObject(AssetHandler.instance.corrLR, out spriteIndex);
			}
			else
			{
				sr.sprite = Tools.RandomObject(AssetHandler.instance.edgeR, out spriteIndex);
			}
		}
		else if (edgeData.LEFT)
		{
			sr.sprite = Tools.RandomObject(AssetHandler.instance.edgeL, out spriteIndex);
		}
		//if
	}

	// Update is called once per frame
	void Update ()
	{
		SwitchTile();
	}
}
