
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


namespace Bleakwater {
    public class TileGraph : MonoBehaviour, ITileGraph
    {
        [SerializeField]
        private float _neighborRange = 1;
        private Dictionary<ITile, Node> TileToNodeMap = new Dictionary<ITile, Node>();

        private void Awake()
        {
            Init();
        }

        private void Init()
        {

            ITile[] tiles = GetComponentsInChildren<ITile>();
            foreach (ITile tile in tiles)
            { 
                TileToNodeMap.Add(tile, new Node(tile));
                tile.Transform.gameObject.layer = LayerMask.NameToLayer("Tile");//there is never a reason for a Tile not to be on the tile layer. It will break the tile graph.
            }
            foreach (ITile tile in tiles)
            {
                TileToNodeMap[tile].Neighbors.AddRange(CheckCollisionForNeighbors(tile));
            }

        }

        private List<Node> CheckCollisionForNeighbors(ITile tile)
        {
            Vector3 position = tile.Transform.position;
            int tileLayer = 1 << LayerMask.NameToLayer("Tile");
            Collider [] neighborCollider = Physics.OverlapSphere(position, _neighborRange, tileLayer);
            List<Node> neighbors = new List<Node>();    
            foreach (Collider col in neighborCollider)
            {
                ITile neighborTile = col.GetComponent<ITile>();
                if(neighborTile != tile) 
                {
                    neighbors.Add(TileToNodeMap[neighborTile]);
                }
            }
            
            return neighbors;
        }


        public bool AddTile(ITile tile)
        {
            if (TileToNodeMap.ContainsKey(tile))
            {
                TileToNodeMap.Add(tile, new Node(tile));
                Node nodeToAdd = TileToNodeMap[tile];
                nodeToAdd.Neighbors.AddRange(CheckCollisionForNeighbors(tile));
                foreach (Node neighbors in nodeToAdd.Neighbors)
                {
                    neighbors.Neighbors.Add(nodeToAdd);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveTile(ITile tile)
        {
            if (TileToNodeMap.ContainsKey(tile))
            {
                Node nodeToRemove = TileToNodeMap[tile];
                foreach (Node neighbor in TileToNodeMap[tile].Neighbors)
                {
                    neighbor.Neighbors.Remove(nodeToRemove);
                }
                TileToNodeMap.Remove(tile);
                return true;
            }
            else 
            { 
                return false; 
            }
            
        }

        public IEnumerable<ITile> GetAllTiles()
        {
            return TileToNodeMap.Keys;
        }





        public IEnumerable<ITile> GetTilesInRange(ITile location, int range)
        {
            HashSet<ITile> tilesInRange = new HashSet<ITile>();
            List<Node> nodesAtEdge = new List<Node>
            {
                TileToNodeMap[location]
            };

            tilesInRange.Add(location);

            for (int i = 0; i < range; i++)
            {
                nodesAtEdge = GetTilesSurroundingSet(tilesInRange, nodesAtEdge);
            }
            return tilesInRange;
        }

        private List<Node> GetTilesSurroundingSet(HashSet<ITile> tilesInRange, List<Node> nodesAtEdge)
        {
            List<Node> nextNodesAtEdge = new List<Node>();
            foreach (Node node in nodesAtEdge)
            {
                foreach (Node neighbor in node.Neighbors)
                {
                    if (tilesInRange.Add(neighbor.Tile))
                    {
                        nextNodesAtEdge.Add(neighbor);
                    }
                }
            }
            nodesAtEdge = nextNodesAtEdge;

            return nodesAtEdge;
        }

        public IEnumerable<ITile> GetTilesInRangeLOS(ITile location, int range)
        {
            throw new System.NotImplementedException();
        }

        public ITile GetClosestTileOfType<TTile>(Vector3 pos) where TTile : ITile
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITile> GetTilesInRadiusOfType<TTile>(Vector3 pos, int radius) where TTile : ITile
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITile> GetTilesOfType<TTile>() where TTile : ITile
        {
            throw new System.NotImplementedException();
        }




        #region A*
        private float Heuristic(Node goal, Node current)
        {
            //nodes can be at any angle, so we are starting with a distance heuristic
            float distance = Vector3.Distance(goal.Tile.Transform.position, current.Tile.Transform.position);
            return distance;
        }
        private float Distance(Node tile1, Node tile2)
        {
            return Vector3.Distance(tile1.Tile.Transform.position,tile2.Tile.Transform.position);
        }
        private List<ITile> ReconstructPath(Node current)
        {
            List<ITile> totalPath = new List<ITile>();
            while(current.CameFrom != null)
            {
                totalPath.Add(current.Tile);
                current = current.CameFrom;
            }
            totalPath.Reverse();
            return totalPath;
        }
        public List<ITile> GetPathToTile(ITile startTile, ITile goalTile)
        {
            Node start = TileToNodeMap[startTile];
            Node goal = TileToNodeMap[goalTile];

            MinHeap open = new MinHeap();
            HashSet<Node> closed = new HashSet<Node>();

            start.g = 0f;
            start.f = Heuristic(start, goal);
            start.CameFrom = null;
            open.Add(start);


            while (open.Count>0)
            {
                Node currentNode = open.RemoveMin();
                closed.Add(currentNode);
                if(currentNode == goal)
                {
                    
                    return ReconstructPath(currentNode);
                }
                foreach(Node neighbor in currentNode.Neighbors)
                {
                    if (!closed.Contains(neighbor))
                    {
                        if (!open.Contains(neighbor))
                        {
                            neighbor.g = float.PositiveInfinity;
                            open.Add(neighbor);
                        }
                        float gTentative = currentNode.g + Distance(neighbor, currentNode);
                        if (gTentative < neighbor.g)
                        {
                            neighbor.CameFrom = currentNode;
                            neighbor.g = gTentative;
                            neighbor.f = neighbor.g + Heuristic(neighbor, goal);
                            
                            open.Update(neighbor);
                        }
                    }
                }
            }
            return null;
        }

        
        private class Node
        {
            public Node(ITile Tile)
            {
                this.Tile = Tile;
            }
            public ITile Tile;
            public List<Node> Neighbors = new();
            public Node CameFrom;
            public int HeapIndex;
            public float f  = float.PositiveInfinity;
            public float g = float.PositiveInfinity;
            public float h = float.PositiveInfinity;

  
        }
        private class MinHeap
        {
            private List<Node> nodes;
            private HashSet<Node> nodeSet;  // used to quickly check if a node is in the heap
            public int Count => nodes.Count;

            
            public MinHeap()
            {
                nodes = new List<Node>();
                nodeSet = new HashSet<Node>();
            }

            public void Add(Node node)
            {
                node.HeapIndex = nodes.Count;
                nodes.Add(node);
                nodeSet.Add(node);
                SortUp(node);
            }

            public Node RemoveMin()
            {
                Node minNode = nodes[0];
                nodeSet.Remove(minNode);
                nodes[0] = nodes[nodes.Count - 1];
                nodes[0].HeapIndex = 0;
                nodes.RemoveAt(nodes.Count - 1);
                if (nodes.Count > 0)
                {
                    SortDown(nodes[0]);
                }
                return minNode;
            }

            public void Update(Node node)
            {
                SortUp(node);
            }

            public bool Contains(Node node)
            {
                return nodeSet.Contains(node);
            }
            private void SortUp(Node node)
            {
                int parentIndex = (node.HeapIndex - 1) / 2;

                while (true)
                {
                    Node parent = nodes[parentIndex];
                    if (node.f < parent.f)
                    {
                        Swap(node, parent);
                    }
                    else
                    {
                        break;
                    }

                    parentIndex = (node.HeapIndex - 1) / 2;
                }
            }

            private void SortDown(Node node)
            {
                while (true)
                {
                    int childIndexLeft = node.HeapIndex * 2 + 1;
                    int childIndexRight = node.HeapIndex * 2 + 2;
                    int swapIndex = 0;

                    if (childIndexLeft < nodes.Count)
                    {
                        swapIndex = childIndexLeft;

                        if (childIndexRight < nodes.Count)
                        {
                            if (nodes[childIndexLeft].f > nodes[childIndexRight].f)
                            {
                                swapIndex = childIndexRight;
                            }
                        }

                        if (node.f > nodes[swapIndex].f)
                        {
                            Swap(node, nodes[swapIndex]);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }

            private void Swap(Node node1, Node node2)
            {
                int node1Index = node1.HeapIndex;
                int node2Index = node2.HeapIndex;
                
                nodes[node1Index] = node2;
                nodes[node2Index] = node1;
                
                node1.HeapIndex = node2Index;
                node2.HeapIndex = node1Index;
            }
            public static void TestMinHeap()
            {
                // create a new min heap
                MinHeap minHeap = new MinHeap();

                // create some nodes
                Node node1 = new Node(null) { f = 5 };
                Node node2 = new Node(null) { f = 10 };
                Node node3 = new Node(null) { f = 3 };
                Node node4 = new Node(null) { f = 20 };

                // add the nodes to the heap
                minHeap.Add(node1);
                minHeap.Add(node2);
                minHeap.Add(node3);
                minHeap.Add(node4);

                // remove the minimum node and check that it's node3
                Node minNode = minHeap.RemoveMin();
                if (minNode != node3)
                {
                    Debug.LogError("Test failed: Removed node should be node3 but was {0}" + minNode.f);
                    return;
                }

                // update node1's fScore to be the smallest and check that it's now the minimum node
                node1.f = 1;
                minHeap.Update(node1);
                minNode = minHeap.RemoveMin();
                if (minNode != node1)
                {
                    Debug.LogError("Test failed: Removed node should be node1 but was {0}" + minNode.f);
                    return;
                }

                Debug.Log("Test passed");
            }
        }
        #endregion
    }

}