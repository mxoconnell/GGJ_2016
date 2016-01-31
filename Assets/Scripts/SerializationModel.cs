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
        public string Value { get; set; }
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

}




//TODO deletme
    /*public class DeserializeObjectGraph
    {
        public void Main()
        {
            var input = new StringReader(Document);

            var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());

            var order = deserializer.Deserialize<Order>(input);

            Console.WriteLine("Order");
            Console.WriteLine("-----");
            Console.WriteLine();
            foreach (var item in order.Items)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", item.PartNo, item.Quantity, item.Price, item.Descrip);
            }
            Console.WriteLine();

            Console.WriteLine("Shipping");
            Console.WriteLine("--------");
            Console.WriteLine();
            Console.WriteLine(order.ShipTo.Street);
            Console.WriteLine(order.ShipTo.City);
            Console.WriteLine(order.ShipTo.State);
            Console.WriteLine();

            Console.WriteLine("Billing");
            Console.WriteLine("-------");
            Console.WriteLine();
            if (order.BillTo == order.ShipTo)
            {
                Console.WriteLine("*same as shipping address*");
            }
            else
            {
                Console.WriteLine(order.ShipTo.Street);
                Console.WriteLine(order.ShipTo.City);
                Console.WriteLine(order.ShipTo.State);
            }
            Console.WriteLine();

            Console.WriteLine("Delivery instructions");
            Console.WriteLine("---------------------");
            Console.WriteLine();
            Console.WriteLine(order.SpecialDelivery);
        }

        public class Order
        {
            public string Receipt { get; set; }
            public DateTime Date { get; set; }
            public Customer Customer { get; set; }
            public List<OrderItem> Items { get; set; }

            [YamlAlias("bill-to")]
            public Address BillTo { get; set; }

            [YamlAlias("ship-to")]
            public Address ShipTo { get; set; }

            public string SpecialDelivery { get; set; }
        }

        public class Customer
        {
            public string Given { get; set; }
            public string Family { get; set; }
        }

        public class OrderItem
        {
            [YamlAlias("part_no")]
            public string PartNo { get; set; }
            public string Descrip { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }

        public class Address
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
        }

        private const string Document = @"---
            receipt:    Oz-Ware Purchase Invoice
            date:        2007-08-06
            customer:
                given:   Dorothy
                family:  Gale

            items:
                - part_no:   A4786
                  descrip:   Water Bucket (Filled)
                  price:     1.47
                  quantity:  4

                - part_no:   E1628
                  descrip:   High Heeled ""Ruby"" Slippers
                  price:     100.27
                  quantity:  1

            bill-to:  &id001
                street: |-
                        123 Tornado Alley
                        Suite 16
                city:   East Westville
                state:  KS

            ship-to:  *id001

            specialDelivery: >
                Follow the Yellow Brick
                Road to the Emerald City.
                Pay no attention to the
                man behind the curtain.
...";
    }*/
