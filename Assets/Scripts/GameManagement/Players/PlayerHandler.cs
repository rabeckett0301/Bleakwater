using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    //public
    public enum PlayerState
    {
        Idle,
        Ready,
        Roll,
        Move,
        TakeCard,
        Battle,
        Shop
    }

    public PlayerState CurrentPlayerState;

    public float MoveSpeed;

    public int SpacesToMove;

    public bool Selecting;

    public List<Space> Checked = new List<Space>();

    public Dictionary<Space, List<Space>> ListPairs = new Dictionary<Space, List<Space>>();

    //public Space TileToCheck;

    //private
    private PlayerClass Class;
    private GameManager GM;

    //serialized
    [SerializeField]
    private Space TargetSpace;

    [SerializeField]
    private Space CurrentSpace;

    private void Awake()
    {
        GM = GameObject.Find("/GameManagerObject").GetComponent<GameManager>();
        Class = this.GetComponent<PlayerClass>();
    }

    void Start()
    {

    }

    void Update()
    {
        //Selecting Space
        if (Selecting && Input.GetMouseButtonDown(0))
        {
            Ray SelectRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitObj;

            if(Physics.Raycast(SelectRay, out HitObj))
            {
                if (HitObj.collider.tag == "Space")
                {
                    Debug.Log("Space hit!");
                    TargetSpace = HitObj.collider.gameObject.GetComponent<Space>();
                    List <Space> NewSpaces = GetNewPath(TargetSpace);

                    if(NewSpaces != null)
                    {
                        StartCoroutine(MoveToSpace(NewSpaces));
                    }

                }
                else
                {
                    Debug.Log("Object hit was not a space");
                }
            }
        }

        this.transform.position = new Vector3(this.CurrentSpace.gameObject.transform.position.x, this.CurrentSpace.gameObject.transform.position.y + 1f, this.CurrentSpace.gameObject.transform.position.z);
    }

    public void ChangeState(PlayerState NextState)
    {
        if (NextState == CurrentPlayerState) return;

        switch (NextState)
        {
            case PlayerState.Ready:
                break;

            case PlayerState.Roll:
                Class.GetAP();
                this.GetAvailableSpaces();
                Selecting = true;
                break;

            case PlayerState.Move:
                break;

            case PlayerState.Battle:
                break;
        }

        CurrentPlayerState = NextState;

        //Debug.Log("State Change Over");
    }

    public void StartTurn()
    {
        Debug.Log("Starting turn");

        ChangeState(PlayerState.Roll);
    }

    public void GetAvailableSpaces()
    {
        int MoveRange = Class.ActionPoints;

        foreach (KeyValuePair<Space, List<Space>> entry in ListPairs)
        {
            entry.Key.IsValid = false;
        }

        Checked = new List<Space>();

        Checked.Add(this.CurrentSpace);

        ListPairs.Clear();

        Checked = CheckNeighborsInrange(Checked, MoveRange, CurrentSpace);

        foreach (KeyValuePair<Space, List<Space>> entry in ListPairs)
        {
            entry.Key.IsValid = true;
        }
    }

    private List<Space> GetNewPath(Space Tile)
    {
        if (ListPairs.TryGetValue(Tile, out List<Space> TileToCheckList))
        {
            for (int i = 0; i < TileToCheckList.Count; i++)
            {
                Debug.Log(Tile.gameObject.name + " Element: " + (i + 1) + "/" + TileToCheckList.Count + ": " + TileToCheckList[i].gameObject.name);
            }
        }
        else
        {
            Debug.Log("SPACE OUT OF RANGE");
        }

        return TileToCheckList;
    }

    private List<Space> CheckNeighborsInrange(List<Space> CheckedSpaces, int NumberToCheck, Space SpaceToCheck)
    {
        if (NumberToCheck > 0)
        {
            for (int i = 0; i < SpaceToCheck.AdjacentTiles.Count; i++)
            {
                if (!CheckedSpaces.Contains(SpaceToCheck.AdjacentTiles[i].space))
                {
                    List<Space> TempChecked = new List<Space>(CheckedSpaces);

                    TempChecked.Add(SpaceToCheck.AdjacentTiles[i].space);

                    CheckNeighborsInrange(new List<Space>(TempChecked), NumberToCheck - 1, SpaceToCheck.AdjacentTiles[i].space);
                    
                    if(ListPairs.TryGetValue(SpaceToCheck.AdjacentTiles[i].space, out List<Space> NewPath))
                    {
                        if (NewPath.Count >= CheckedSpaces.Count)
                        {
                            ListPairs[SpaceToCheck.AdjacentTiles[i].space] = TempChecked;
                        }
                    }
                    else
                    {
                        ListPairs.Add(SpaceToCheck.AdjacentTiles[i].space, TempChecked);
                    }
                }
            }
        }

        return CheckedSpaces;
    }

    private IEnumerator MoveToSpace(List<Space> Path)
    {
        for (int i = 1; i < Path.Count; i++)
        {
            CurrentSpace = Path[i];
            CurrentSpace.ActivateSpace(this.Class);
            this.GetAvailableSpaces();
            yield return new WaitForSeconds(MoveSpeed);
        }

        yield return null;
    }
}
