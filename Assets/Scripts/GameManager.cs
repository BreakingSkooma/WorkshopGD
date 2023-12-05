using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe qui permet le lien des différents éléments du jeu et leur intéractions
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject pathMarkerPrefab;

    [SerializeField]
    private List<GameObject> entities;

    private Player playerSelected;

    private List<Vector3Int> path;

    [SerializeField]
    private List<GameObject> pathMarkers;



    private void Awake()
    {
        instance = this;

        path = new List<Vector3Int>();
        pathMarkers = new List<GameObject>();
    }

    public void SelectPlayer(Player player)
    {
        playerSelected = player;
    }

    private void UnselectPlayer()
    {
        playerSelected.UnSelected();
        playerSelected = null;
        path.Clear();
    }

    public void Update()
    {
        Vector3Int gridPosition = MapManager.instance.GetGridPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetMouseButtonDown(0))
        {
            //Si un joueur est selectionner alors on regarder si on peut le déplacer
            if(playerSelected != null) { }
            {
                //Vérifie si il y a une autre instance sur la case
                foreach (GameObject entity in entities)
                {
                    //Si on selectionne une autre entité alros le déplacement est annulé
                    if (MapManager.instance.GetGridPosition(entity.transform.position) == gridPosition)
                    {
                        return;
                    }
                }
                //Vérifie si il est possible de se déplacer sur la case, sinon annule de déplacement
                if (!MapManager.instance.IsTileWalkable(gridPosition))
                {
                    return;
                }
                playerSelected.MoveTo(MapManager.instance.ConvertToWorldCoordsList(path));
                UnselectPlayer();
                //Deselectionne le joueur si on clique sur le joueur
                //Deplace le joueur sur la tuile puir le deselectionne
            }
        }

        if (playerSelected != null)
        {
;
            if (MapManager.instance.CheckTile(gridPosition) && !path.Contains(gridPosition))
            {
                path.Add(gridPosition);
                Vector3 point = MapManager.instance.GetWorldCords(gridPosition) + new Vector2(0.5f, 0.5f) ;
                GameObject newMarker = Instantiate(pathMarkerPrefab, point, Quaternion.identity);
                pathMarkers.Add(newMarker);
            }
        }
    }

    public void RemoveMarker(int index)
    {
        pathMarkers[index].SetActive(false);
    }

    public void ClearPathMakerList()
    {
        pathMarkers.Clear();
        GameObject[] allMark = GameObject.FindGameObjectsWithTag("Marker");
        foreach(GameObject mark in allMark)
        {
            Destroy(mark);
        }
    }
}