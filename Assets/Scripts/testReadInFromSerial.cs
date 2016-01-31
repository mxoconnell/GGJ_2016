using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using SerializationModel;//For conversation tree



public class testReadInFromSerial : MonoBehaviour {


public ConversationTree convo_tree;

        public void readItIn()
        {
            var input = new StringReader(Resources.Load<TextAsset>("datYamal").text);
            var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
            convo_tree = deserializer.Deserialize<ConversationTree>(input);
        }

    // Use this for initialization
    void Start () {

      /*  readItIn();
       // var nextOptions = convo_tree.consequentOptions;
        foreach (ConversationNode conNode in convo_tree.conversationNodes)
        {
            foreach (ConversationOption conOpp in conNode.conversationOptions)
            {
                Debug.Log(conOpp.playerText);
                Debug.Log(conOpp.response);
            }
        }*/

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
