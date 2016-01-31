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

    public class NpcSprite
    {
		// The name of the sprite (e.g. 'horse' corresponds to the sprite 'horse.jpg')
		public string SpriteName { get; set; }
		// The list of variations on the sprite
		public List<NpcSpriteVariant> Variants { get; set; }
    }

    public class NpcSpriteVariant
    {
		// The identifying color of the variant
        public string Colour { get; set; }
		// The age of this creature variant
        public int Age { get; set; }
		// Personality type of this variant
        public string PType { get; set; }
		// List of possible names a creature of this variant can have
        public List<string> NpcNames { get; set; }
    }

}