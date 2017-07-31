using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class GameManager : MonoBehaviour
{
	public int GRID_WIDTH;
	public int GRID_HEIGHT;
	public GridData[,] data;
	public GameObject gridSelector;

	public int blocksAvailable;
	// Use this for initialization
	void Start()
	{
		CreateGridData();
	}

	void CreateGridData()
	{
		data = new GridData[GRID_WIDTH, GRID_HEIGHT];
		for(int i = 0; i < GRID_WIDTH-1; i++)
		{
			for (int j = 0; j < GRID_HEIGHT-1; j++)
			{
				data[i, j] = new GridData()
				{
					x = i,
					y = j,
					occupied = false
				};
			}
		}
		//SaveGridData();
	}

	void LoadGridData()
	{

	}

	void SaveGridData()
	{
		XmlWriterSettings settings = new XmlWriterSettings()
		{
			Indent = true,
			IndentChars = ("\t"),
			OmitXmlDeclaration = true
		};
		using (XmlWriter writer = XmlWriter.Create("data.xml"))
		{
			writer.WriteStartDocument();
			writer.WriteStartElement("map");
			for (int i = 0; i < GRID_WIDTH - 1; i++)
			{
				for (int j = 0; j < GRID_HEIGHT - 1; j++)
				{
					if(data[i, j].occupied)
					{
						writer.WriteStartElement("g");
						writer.WriteAttributeString("x", i.ToString());
						writer.WriteAttributeString("y", j.ToString());
						writer.WriteEndElement();
					}
				}
			}
			writer.WriteEndElement();
			writer.WriteEndDocument();
		}
	}
	public bool CheckGrid(int x, int y)
	{
		return data[x, y].occupied;
	}

	public void OccupyGrid(int x,int y)
	{
		data[x, y].occupied = true;
		SaveGridData();
	}

	// Update is called once per frame
	void Update()
	{
	#if UNITY_ANDROID
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			// Get movement of the finger since last frame
			Vector2 touchPosition = Input.GetTouch(0).position;
			print(touchPosition);
			// Move object across XY plane
			//transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
		}
	#else
		Vector2 inPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		inPosition = new Vector2(Mathf.Round(inPosition.x), Mathf.Round(inPosition.y));
		gridSelector.transform.position = inPosition;
		if(Input.GetMouseButtonDown(0))
		{
			if(!CheckGrid((int)inPosition.x, (int)inPosition.y))
			{
				OccupyGrid((int)inPosition.x, (int)inPosition.y);
			}
		}
	#endif
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;

		Vector3 offset = new Vector3(2.5f, 2.5f, 1f);

		Gizmos.DrawLine(Vector3.zero + offset, new Vector3(GRID_WIDTH, 0, 0) + offset);
		Gizmos.DrawLine(new Vector3(GRID_WIDTH, 0, 0) + offset, new Vector3(GRID_WIDTH, GRID_HEIGHT, 0) + offset);
		Gizmos.DrawLine(new Vector3(GRID_WIDTH, GRID_HEIGHT, 0) + offset, new Vector3(0, GRID_HEIGHT, 0) + offset);
		Gizmos.DrawLine(new Vector3(0, GRID_HEIGHT, 0) + offset, Vector3.zero + offset);

		for (int i = 0; i <= GRID_WIDTH; i++)
		{
			Gizmos.DrawLine(new Vector3(i, 0, -1f) + offset, new Vector3(i, GRID_HEIGHT, -1f) + offset);
		}

		for (int j = 0; j <= GRID_HEIGHT; j++)
		{
			Gizmos.DrawLine(new Vector3(0, j, -1f) + offset, new Vector3(GRID_WIDTH, j, -1f) + offset);
		}
	}
}
