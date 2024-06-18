using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class ItemInfo : ScriptableObject
{
	public List<ExcelItemInfo> Sheet1; // Replace 'EntityType' to an actual type that is serializable.
}