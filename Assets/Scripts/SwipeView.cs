using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using SerializationModel;

//Buttons have OnClick methods tied via the editor to public methods

public class SwipeView : MonoBehaviour, IView
{
    public GameObject topCard;
    public GameObject bottomCard;

    [SerializeField]
    Image PortraitA, PortraitB;
    [SerializeField]
    Text NPCNameA, NPCNameB;
    [SerializeField]
    Text NPCAgeA, NPCAgeB;

    Vector3 topCardOriginalPosition;
    bool canSwipe = true; //false when we are swiping
    float dx = 3;
    float dy = 2;
    int hLim = 100;//Determines when the card is far enough away to reshuffle, also limits drag distance
    int vLim = 100;

	IList<NpcSprite> SpriteData;

    void Start()
    {
        topCardOriginalPosition = topCard.transform.position;
		SpriteData = GameController.GetNpcSprites();
    }
    public void ChangeView(IView nextView)
    {
        throw new NotImplementedException();
    }

    public RectTransform GetRoot()
    {
        return Root;
    }

    float LastSliderValue = 0.0f;

	[SerializeField]
	Controller GameController;

    [SerializeField]
    RectTransform Root;

    [SerializeField]
    RectTransform[] SwipeScreens;

    [SerializeField]
    Animator[] Animators;

    int Selector = 0;

    [SerializeField]
    float SliderThreshold;


    public static System.Action<float> DidSwipe;

    // Update is called once per frame
    void Update()
    {
        //Get the position of the card's viewport's content
        Vector3 contentPosition = topCard.transform.GetChild(0).transform.GetChild(0).position;

        //swipe distance enough to initiate
        if (Vector3.Distance(topCardOriginalPosition, contentPosition) > hLim / 7)//TODO remove magic 5
        {
            //determine if swipe was right/left
            if (topCardOriginalPosition.x > contentPosition.x)
            {
                swipeInitiated(true);
            }
            else
            {
                swipeInitiated(false);
            }

        }

        //If the user cannot swipe, move it off of the screen
        if (!canSwipe)
        {
            var cardPosition = topCard.transform.position;
            cardPosition.x += dx;
            cardPosition.y += dy;
            topCard.transform.position = cardPosition;
            //fade out also

            //Card has left view. Allow user to swipe again. Move the bottom card to where the top was and bring it to the front. 
            if (cardPosition.x > hLim || cardPosition.x < -hLim)//TODO remove magic and compare to "topCardOriginalPosition"
            {
                canSwipe = true;
                dx = Math.Abs(dx);

                topCard.transform.position = bottomCard.transform.position;
                bottomCard.transform.position = topCardOriginalPosition;
                bottomCard.transform.SetAsLastSibling();

                //Now the top card and bottom card switch roles.
                var placeholder = topCard;
                topCard = bottomCard;
                bottomCard = placeholder;
                FillNextPortrait();
            }
        }
    }

    public void swipeInitiated(bool isRight)
    {
        if (canSwipe)
        {
            if (isRight)
                dx *= -1;

            //Debug.Log("Swiped!");

            dy = UnityEngine.Random.Range(-dy, dy);
            canSwipe = false;


        }
    }

    //Load in NPC Data

    public void FillNextPortrait()
    {
		NPC npc = bottomCard.GetComponentInChildren<Image>().gameObject.AddComponent<NPC>();
       // bottomCard.GetComponentInChildren<NPC>().InitializeNewNPC();
		NpcSprite sprite = SpriteData[UnityEngine.Random.Range(0, SpriteData.Count)];
		NpcSpriteVariant variant = sprite.Variants[UnityEngine.Random.Range(0, sprite.Variants.Count)];
		string name = variant.NpcNames[UnityEngine.Random.Range(0, variant.NpcNames.Count)];
		int age = variant.Age;

		npc.NPCName = name;
		npc.Age = age;

		// TODO Set the sprite images
		// TODO update the logo image based on the sprite
    }
}
