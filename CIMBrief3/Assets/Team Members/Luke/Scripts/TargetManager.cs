using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
	public TargetNode[,] nodes;
	public int levelWidth;
	public int levelLength;
	public Vector2 bottomLeftCorner;
	public LayerMask layerMask;
	private void Awake()
	{
		FillGrid();
	}

	private void FillGrid()
	{
		nodes = new TargetNode[levelWidth, levelLength];
		for (int x = 0; x < levelWidth; x++)
		{
			for (int y = 0; y < levelLength; y++)
			{
				Vector3 position = new Vector3(bottomLeftCorner.x + x+0.5f,1, bottomLeftCorner.y + y+0.5f);
				nodes[x, y] = new()
				{
					worldPosition = position
				};
				if (Physics.OverlapBox(new Vector3(position.x, 0.6f, position.y), Vector3.one*0.4f, 
					    Quaternion.identity, layerMask).Length > 0)
				{
					nodes[x, y].isBlocked = true;
				}
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (!Application.isPlaying)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(new Vector3(bottomLeftCorner.x, 0, bottomLeftCorner.y), new Vector3(bottomLeftCorner.x, 5, bottomLeftCorner.y));
			Gizmos.color = new Color(0f, 1f, 0f, 0.5f);
			Gizmos.DrawCube(new Vector3(bottomLeftCorner.x + levelWidth / 2f, 0, bottomLeftCorner.y + levelLength / 2f),
				new Vector3(levelWidth, 0.1f, levelLength));
		}
		else
		{
			foreach (TargetNode node in nodes)
			{
				if (node.isBlocked)
				{
					Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
				}
				else
				{
					Gizmos.color = new Color(0f, 1f, 0f, 0.5f);
				}
				Gizmos.DrawCube(node.worldPosition, Vector3.one);
			}
		}
	}
}
