using UnityEngine;
using System.Collections;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using SerializationModel;

public class Model : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        var input = new StringReader(Resources.Load<TextAsset>("datYamal").text);

        var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());

        ConversationOption ConvoOption = deserializer.Deserialize<ConversationOption>(input);
    }


    // Update is called once per frame
    void Update () {
	
	}
}
