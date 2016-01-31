using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;


namespace SerializationModel {

    public class ConversationOption
    {
        public string name { get; set; }
        public string playerText { get; set; }
   
        public Response response { get; set; }   
    }

    public class Response
    {
        public string npcText { get; set; }
        public float value { get; set; }
        public string next { get; set; }
    }

    public class ConversationNode
    {
        public ConversationOption[] consequentOptions { get; set; }
        public string tag { get; set; } //reference to next node in tree
    }

    public class ConversationTree
    {
        public ConversationNode[] consequentOptions { get; set; }
    }

    public class readInData
    {
       /* StringReader input = new StringReader(Document);
        Deserializer deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
         order = deserializer.Deserialize<Order>(input);*/
    }
}
