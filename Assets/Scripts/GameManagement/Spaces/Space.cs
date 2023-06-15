using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space: MonoBehaviour
{
    public SpaceTemplate ThisSpaceType;

    public List<Neighbor> AdjacentTiles = new List<Neighbor>();

    public bool IsValid;

    public float OverlapRadius;

    private GameManager GM;

    private void Awake()
    {
        GM = GameObject.Find("GameManagerObject").GetComponent<GameManager>();
    }

    void Start()
    {
        this.GetComponent<MeshRenderer>().material = ThisSpaceType.SpaceMaterial;

        GetNeighbors();
    }

    void Update()
    {
        if (this.IsValid)
        {
            //this.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material.color = ThisSpaceType.SpaceMaterial.color;
        }
    }

    private void GetNeighbors()
    {
        int SpaceLayer = 1<<LayerMask.NameToLayer("Spaces");

        Collider[] HitSpace = Physics.OverlapSphere(this.transform.position, OverlapRadius, SpaceLayer);

        foreach (var collider in HitSpace)
        {
            if (collider.gameObject.GetInstanceID() == this.gameObject.GetInstanceID())
            {
                //Debug.Log(gameObject.name + " Error: " + collider.gameObject.name);
            }
            else
            {
                //Debug.Log(gameObject.name + "Space Hit: " + collider.gameObject.name);

                if (collider.gameObject.TryGetComponent(out Space TempSpace))
                {
                    Vector3 NewDirection = TempSpace.transform.position - transform.position;
                    NewDirection = NewDirection.normalized;

                    Neighbor newNeighbor = new Neighbor();
                    newNeighbor.space = TempSpace;
                    newNeighbor.Direction = NewDirection;
                    AdjacentTiles.Add(newNeighbor);
                }
            }
        }
    }

    public void ActivateSpace(PlayerClass AffectedPlayer)
    {
        ThisSpaceType.ActivateSpaceEffect(AffectedPlayer);
    }
}

[System.Serializable]
public class Neighbor
{
    public Space space;

    public Vector3 Direction;
}
