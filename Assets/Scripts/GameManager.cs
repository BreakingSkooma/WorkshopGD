using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe qui permet le lien des diff�rents �l�ments du jeu et leur int�ractions
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private List<GameObject> entities;

    private Player playerSelected;

    [SerializeField]
    private List<Vector3Int> path;


    private void Awake()
    {
        instance = this;

        path = new List<Vector3Int>();
    }

    public void SelectPlayer(Player player)
    {
        playerSelected = player;
    }

    private void UnselectPlayer()
    {
        playerSelected = null;
        path.Clear();
    }

    public void Update()
    {
        Vector3Int gridPosition = MapManager.instance.GetGridPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetMouseButtonDown(0))
        {
            //Si un joueur est selectionner alors on regarder si on peut le d�placer
            if(playerSelected != null) { }
            {
                //V�rifie si il y a une autre instance sur la case
                foreach (GameObject entity in entities)
                {
                    //Si on selectionne une autre entit� alros le d�placement est annul�
                    if (MapManager.instance.GetGridPosition(entity.transform.position) == gridPosition)
                    {
                        return;
                    }
                }
                //V�rifie si il est possible de se d�placer sur la case, sinon annule de d�placement
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
            }
        }
    }
}