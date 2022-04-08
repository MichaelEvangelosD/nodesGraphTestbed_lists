﻿using System;
using System.Collections.Generic;

namespace Graphs
{
    public class Graph
    {
        private struct Connection
        {
            public int from_index;
            public int to_index;

            public override string ToString()
            {
                return $"{from_index} conects to {to_index}";
            }
        }

        private List<string> nodes = new List<string>();

        private List<Connection> connections = new List<Connection>();

        public Graph(string node)
        {
            //We have to initialize the graph with at least ONE node.
            AddNode(node);
        }

        /// <summary>
        /// Call to add a new node in the list ONLY if it not already in the list.
        /// </summary>
        /// <param name="node">The new node's name.</param>
        public void AddNode(string node)
        {
            if (!IsNode(node))
            {
                nodes.Add(node);

                Console.WriteLine($"Node {node} created in the nodes list.");
            }
            else
            {
                Console.WriteLine($"Node {node} already exists in the nodes list.");
            }
        }

        public void RemoveNode(string node)
        {
            if (IsNode(node))
            {
                int index = nodes.IndexOf(node);

                _TryNodeDeletion(index);
            }
            else
            {
                Console.WriteLine($"{node} does not exist in the nodes list.");
            }
        }

        void _TryNodeDeletion(int nodeIndex)
        {
            try
            {
                nodes.RemoveAt(nodeIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Given index {nodeIndex} is out of range.");
                throw;
            }

            Console.WriteLine($"Node \"{nodes[nodeIndex]}\" deleted.");
        }

        public void AddConnection(string from, string to)
        {
            // TODO: check if the connection already exists...

            int from_index = nodes.IndexOf(from);

            if (from_index == -1)
            {
                // TODO: throw error, exit...
                return;
            }

            int to_index = nodes.IndexOf(to);

            if (to_index == -1)
            {
                // TODO: throw error, exit...
                return;
            }

            Connection newConnection = new Connection();

            newConnection.from_index = from_index;
            newConnection.to_index = to_index;

            connections.Add(newConnection);
        }

        //TODO
        public void RemoveConnection(string from, string to)
        {
            int fromNode = nodes.IndexOf(from);
            int toNode = nodes.IndexOf(to);

            if (true)
            {

            }
        }

        /// <returns>True if the node exists inside the nodes list, false if not.</returns>
        public bool IsNode(string node)
        {
            return nodes.Contains(node);
        }

        //TODO
        /// <returns>True if the connection exists inside the connections list, false if not.</returns>
        public bool IsConnected(string from, string to)
        {


            for (int i = 0; i < ConnectionCount(); i++)
            {
                if (connections[i])
                {

                }
            }
        }

        /// <returns>The nodes List element count.</returns>
        public int NodeCount()
        {
            return nodes.Count;
        }

        /// <returns>The connections List element count.</returns>
        public int ConnectionCount()
        {
            return connections.Count;
        }

        /// <summary>
        /// Call to write all the nodes and node connections info to the console.
        /// </summary>
        public void Dump()
        {
            _PrintNodes();
            _PrintNodeConnections();
        }

        /// <summary>
        /// Prints the nodes list elements to the console.
        /// </summary>
        void _PrintNodes()
        {
            int nodeCount = NodeCount();

            Console.WriteLine($"Total nodes in the list: {nodeCount}");

            for (int i = 0; i < nodeCount; i++)
            {
                Console.WriteLine(nodes[i]);
            }
        }

        /// <summary>
        /// Prints the connections list elements to the console.
        /// </summary>
        void _PrintNodeConnections()
        {
            int nodeConnectionsCount = ConnectionCount();

            Console.WriteLine($"Total nodes in the list: {nodeConnectionsCount}");

            for (int i = 0; i < nodeConnectionsCount; i++)
            {
                Console.WriteLine(connections[i].ToString());
            }
        }
    }
}
