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

    // Use this for initialization
    void Start()
    {
        Reader = new StringReader(Resources.Load<TextAsset>("npc_data").text);

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
}
