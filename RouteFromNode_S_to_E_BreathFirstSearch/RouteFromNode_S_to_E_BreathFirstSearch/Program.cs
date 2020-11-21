using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RouteFromNode_S_to_E_BreathFirstSearch.Program;

namespace RouteFromNode_S_to_E_BreathFirstSearch
{
    public class Program
    {
        public enum State { Unvisited, Visited, Visiting };
        static void Main(string[] args)
        {
        }

        public bool Search(Graph g, DirectedGraphNode start, DirectedGraphNode end)
        {
            if (start == end)
            {
                return true;
            }

            /* Operates as a queue */
            LinkedList<DirectedGraphNode> q = new LinkedList<DirectedGraphNode>();

            foreach (DirectedGraphNode n in g.nodes)
            {
                n.state = State.Unvisited;
            }

            start.state = State.Visiting;
            q.AddLast(start);

            DirectedGraphNode tempNode;

            while (q != null)
            {
                tempNode = q.First(); q.RemoveFirst(); // i.e., dequeue
                if (tempNode != null)
                {
                    foreach (DirectedGraphNode node in tempNode.getAdjacent())
                    {
                        if (node.state == State.Unvisited)
                        {
                            if (node == end)
                            {
                                return true;
                            }
                            else
                            {
                                node.state = State.Visiting;
                                q.AddLast(node);
                            }
                        }
                    }
                    tempNode.state = State.Visited;
                }

            }
            return false;
        }
    }

    public class DirectedGraphNode
    {
        public string name;
        public DirectedGraphNode[] childrens;
        public State state;

        public DirectedGraphNode(string name)
        {
            this.name = name;
        }

        internal IEnumerable<DirectedGraphNode> getAdjacent()
        {
            return childrens;
        }
    }

    public class Graph
    {
        public DirectedGraphNode[] nodes;
    }
}
