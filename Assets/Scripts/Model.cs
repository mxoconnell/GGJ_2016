using UnityEngine;
using System.Collections;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using SerializationModel;
using System.Collections.Generic;

public class Model : MonoBehaviour {

    StringReader Reader;
    Deserializer CamelCaseDeserializer;
    List<NpcData> NPCs;

    int CurrentNPC = 0;
    int CurrentConversationNodeIndex = 0;

    const string WinTag = "WIN";
    const string LoseTag = "LOSE";

    public static System.Action<string> OnBattleFinish;

    // Use this for initialization
    void Start()
    {
        // Reader = new StringReader(Resources.Load<TextAsset>("npc_data").text);

        Reader = new StringReader(Resources.Load<TextAsset>("creatures").text);

        CamelCaseDeserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
        NPCs = new List<NpcData>();
    }


    // Update is called once per frame
    public List<ConversationOption> GetPlayerOptions () {

        NPCs = CamelCaseDeserializer.Deserialize<List<NpcData>>(Reader);
        return NPCs[CurrentNPC].ConversationTree[0].Options;
    }

    public string GetRandomPlayerText(int ConversationOptionIndex)
    {
        List<string> PlayerTextList = NPCs[CurrentNPC].ConversationTree[0].Options[ConversationOptionIndex].PlayerText;

        return PlayerTextList[Random.Range(0, PlayerTextList.Count)];
    }

    public string GetNPCResponse(int ConversationOptionIndex)
    {
        Response r = NPCs[CurrentNPC].ConversationTree[0].Options[ConversationOptionIndex].Response;

        //set the next node!

        CurrentConversationNodeIndex = GetConversationTreeIndexforTag(r.Next);

        return r.NpcText[Random.Range(0, r.NpcText.Count)];
    }

    int GetConversationTreeIndexforTag(string targetTag)
    {
        for(int i = 0; i<NPCs[CurrentNPC].ConversationTree.Count;++i)// (ConversationNode Node in NPCs[CurrentNPC].ConversationTree)
        {
            if(NPCs[CurrentNPC].ConversationTree[i].Tag==WinTag || NPCs[CurrentNPC].ConversationTree[i].Tag == LoseTag)
            {
                EndBattle(NPCs[CurrentNPC].ConversationTree[i].Tag == WinTag);
                return i;
            }
           if(NPCs[CurrentNPC].ConversationTree[i].Tag  == targetTag)
            {
                return i;
            }
        }

        Debug.LogError("No response. Starting over!");
        return 0;
    }

    void EndBattle(bool didWin)
    {
        string finishText = "Grats! You won! Click to go to the calendar and schedule your date.";

        if (didWin == false)
        {
            finishText = "Too bad. Better luck next time!";
        }

        OnBattleFinish(finishText);
    }
}
