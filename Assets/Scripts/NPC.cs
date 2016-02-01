using UnityEngine;
using System.Collections;
using SerializationModel;
using UnityEngine.UI;

//prefab, view class for NPCS
public struct NPC
{
	public string Name { get; set; }
	public int Age { get; set; }
	public Sprite Sprite { get; set; }
	public string Colour { get; set; }
}
