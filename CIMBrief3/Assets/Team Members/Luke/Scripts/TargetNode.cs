using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TargetNode
{
	public bool isBlocked;
	public Vector3 worldPosition;
	public TargetNode neighbourNorth;
	public TargetNode neighbourEast;
	public TargetNode neighbourSouth;
	public TargetNode neighbourWest;
}
