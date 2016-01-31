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
        public string Name { get; set; }
        public List<string> PlayerText { get; set; }
        public Response Response { get; set; }   
    }

    public class Response
    {
        public List<string> NpcText { get; set; }
        public string npcHP { get; set; }
        public string Next { get; set; }
    }

    public class ConversationNode
    {
        public List<ConversationOption> Options { get; set; }
        public string Tag { get; set; } //reference to next node in tree
    }

    public class NpcData
    {
        public string NpcName { get; set; }
		public List<ConversationNode> ConversationTree { get; set; }
    }


    public class NPCSprite
    {
        public string SpriteName;
        public List<npcSpriteVariant> variants;
    }

    public class npcSpriteVariant
    {
        public string color { get; set; }
        public int age { get; set; }
        public string pType { get; set; }
        public List<string> npcNames { get; set; }
    }

}