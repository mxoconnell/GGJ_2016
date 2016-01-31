using UnityEngine;
using System.Collections;
using SerializationModel;
using UnityEngine.UI;

//prefab, view class for NPCS
public class NPC : MonoBehaviour
{
	public int Age;
    public string NPCName;

    public Image ColorLayer;

    public Image Highlight;
    public Image CharacterSprite;

	void Awake()
    {
        //load in one from a random set of sprites

        //apply defined color

    }
}
