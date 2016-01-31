using UnityEngine;
using System.Collections;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using SerializationModel;
using System.Collections.Generic;

public class Model : MonoBehaviour {

    StringReader Reader;
    StringReader NPCReader;

    Deserializer CamelCaseDeserializer;

    //Dialog info
    List<NpcData> DialogNPCs;

    int CurrentNPC = 0;
    int CurrentConversationNodeIndex = 0;

    const string WinTag = "WIN";
    const string LoseTag = "LOSE";

    public static System.Action<string> OnBattleFinish;

    // Use this for initialization
    void Awake()
    { 
        //Read in archetype file
        Reader = new StringReader(Resources.Load<TextAsset>("creatures").text);
		NPCReader = new StringReader(Resources.Load<TextAsset>("npcDefinitions").text);
        CamelCaseDeserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
        DialogNPCs = new List<NpcData>();
    }

    #region SwipeView

    #endregion

    #region BattleScreen

    public List<ConversationOption> GetPlayerOptions () { 
        //TODO Move this line up to Awake?  
        if(DialogNPCs.Count==0) DialogNPCs = CamelCaseDeserializer.Deserialize<List<NpcData>>(Reader);

        return DialogNPCs[CurrentNPC].ConversationTree[CurrentConversationNodeIndex].Options;
    }

	public List<NpcSprite> GetNpcSprites()
	{
		return CamelCaseDeserializer.Deserialize<List<NpcSprite>>(NPCReader);
	}

    public string GetRandomPlayerText(int ConversationOptionIndex)
    {
        List<string> PlayerTextList = DialogNPCs[CurrentNPC].ConversationTree[CurrentConversationNodeIndex].Options[ConversationOptionIndex].PlayerText;

        return PlayerTextList[Random.Range(0, PlayerTextList.Count)];
    }

    public string GetNPCResponse(int ConversationOptionIndex)
    {
        Response r = DialogNPCs[CurrentNPC].ConversationTree[CurrentConversationNodeIndex].Options[ConversationOptionIndex].Response;

        //set the next node!

        CurrentConversationNodeIndex = GetConversationTreeIndexforTag(r.Next);

        return r.NpcText[Random.Range(0, r.NpcText.Count)];
    }

    int GetConversationTreeIndexforTag(string targetTag)
    {
        if (targetTag == WinTag) { EndBattle(true); return 0; }
        if (targetTag == LoseTag) { EndBattle(false); return 0; }

        for (int i = 0; i<DialogNPCs[CurrentNPC].ConversationTree.Count;++i)// (ConversationNode Node in DialogNPCs[CurrentNPC].ConversationTree)
        {
           Debug.Log("Target tag: "+targetTag+" Available tag: "+DialogNPCs[CurrentNPC].ConversationTree[i].Tag);

            if (DialogNPCs[CurrentNPC].ConversationTree[i].Tag  == targetTag)
            {
                return i;
            }
        }

        //Maybe downgrade to a warning if this is actually a possibility.
        Debug.LogError("No matching response. Starting over!");
        return 0;
    }

    void EndBattle(bool didWin)
    {
        string finishText = "Grats! You won! Click to go to the calendar and schedule your date.";

        if (didWin == false)
        {
            finishText = "Too bad. Better luck next time!";
            //change button text
        }

        OnBattleFinish(finishText);
    }

    #endregion
}
