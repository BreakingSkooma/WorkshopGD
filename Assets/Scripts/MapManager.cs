using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//Classe qui fait le lien entre la TileMap et les datas des tiles
public class MapManager : MonoBehaviour
{
    //Singleton
    public static MapManager instance;



    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake()
    {
        instance = this;

        dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach(var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }


    //Method who convert a world position to a grid position
    public Vector3Int GetGridPosition(Vector2 position)
    {
        return map.WorldToCell(position);
    }

    // Method who return the TileBase Object at one position
    public TileBase GetTile(Vector2 position)
    {
        Vector3Int gridPos = GetGridPosition(position);
        return map.GetTile(gridPos);
    }

    public TileBase GetTile(Vector3Int gridPosition)
    {
        return map.GetTile(gridPosition);
    }

    //Method who return if a Tile is walkable or not
    public bool IsTileWalkable(Vector2 position)
    {
        TileBase tile = GetTile(position);
        return dataFromTiles[tile].walkable;
    }

    public bool IsTileWalkable(Vector3Int position)
    {
        TileBase tile = GetTile(position);
        return dataFromTiles[tile].walkable;
    }

    public bool IsTileWalkable(TileBase tile)
    {
        return dataFromTiles[tile].walkable;
    }

    //Method who return tile world coords

    public Vector2 GetWorldCords(Vector3Int gridPosition)
    {
        return map.CellToWorld(gridPosition);
    }

    public bool CheckTile(Vector3Int gridPosition)
    {
        return map.HasTile(gridPosition);
    }

    public List<Vector2> ConvertToWorldCoordsList(List<Vector3Int> gridCoordsList)
    { 
        List<Vector2> result = new List<Vector2>();
        foreach (Vector3Int coord in gridCoordsList)
        {
            Vector2 newCoords = GetWorldCords(coord);
            newCoords += new Vector2(0.5f, 0.5f);
            result.Add(newCoords);
        }
        return result;
    }


}
