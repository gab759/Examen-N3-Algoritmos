using System.Collections;
using UnityEngine;

public class GraphControl : MonoBehaviour
{
    public ListaSimple<GameObject> listAllNodes;
    public ListaSimple<Connections> listConnections;
    public ListaSimple<float> connectionWeights;
    public TextAsset textNodesPositions;
    public TextAsset textNodesConnections;
    public string[] arrayNodesPositions;
    public string[] currentNodePositions;
    public string[] arrayNodesConnections;
    public string[] currentNodesConnections;
    public GameObject objectNodePrefab;
    public EnemyController currentEnemy;

    void Start()
    {
        listAllNodes = new ListaSimple<GameObject>();
        listConnections = new ListaSimple<Connections>();
        connectionWeights = new ListaSimple<float>();
        InitializeConnectionWeights();
        DrawNodes();
        ConnectNodes();
        SetInitialNode();
        Debug.Log("Total de nodos añadidos: " + listAllNodes.Length);
    }

    void Update()
    {
        
    }
    private void InitializeConnectionWeights()
    {
        connectionWeights.InsertAtEnd(1f);
        connectionWeights.InsertAtEnd(2f); 
        connectionWeights.InsertAtEnd(3f);
        connectionWeights.InsertAtEnd(4f);
 
    }
    private void DrawNodes()
    {
        GameObject currentNode;
        arrayNodesPositions = textNodesPositions.text.Split('\n');
        for (int i = 0; i < arrayNodesPositions.Length; ++i)
        {
            currentNodePositions = arrayNodesPositions[i].Split(";");
            Vector2 positionToCreate = new Vector2(float.Parse(currentNodePositions[0]), float.Parse(currentNodePositions[1]));
            currentNode = Instantiate(objectNodePrefab, positionToCreate, transform.rotation);
            currentNode.name = "Node" + i.ToString();
            currentNode.transform.SetParent(this.transform);
            listAllNodes.InsertAtEnd(currentNode);
            Debug.Log("Nodo añadido: " + currentNode.name + " en la posición " + positionToCreate);
        }
    }
    private void ConnectNodes()
    {
        arrayNodesConnections = textNodesConnections.text.Split("\n");

        if (arrayNodesConnections.Length != connectionWeights.Length)
        {
            return;
        }

        for (int i = 0; i < arrayNodesConnections.Length; ++i)
        {
            currentNodesConnections = arrayNodesConnections[i].Split(";");

            NodeControl currentNode = listAllNodes.GetNodeAtPosition(i).GetComponent<NodeControl>();

            for (int j = 0; j < currentNodesConnections.Length; ++j)
            {
                int connectedNodeIndex = int.Parse(currentNodesConnections[j]);

                NodeControl connectedNode = listAllNodes.GetNodeAtPosition(connectedNodeIndex).GetComponent<NodeControl>();

                float weight = connectionWeights.GetNodeAtPosition(i);

                Connections newConnection = new Connections(currentNode, connectedNode, weight);
                listConnections.InsertAtEnd(newConnection);

                currentNode.AddAdjacentNode(connectedNode);
                connectedNode.AddAdjacentNode(currentNode);

                Debug.Log("Nodo: " + currentNode.name + " está conectado a " + connectedNode + " con peso " + weight);
            }
        }
    }
    private void SetInitialNode()
    {
        GameObject initialNode = listAllNodes.GetNodeAtPosition(0);

        currentEnemy.SetNewPosition(initialNode.transform.position,0f);
    }
}
