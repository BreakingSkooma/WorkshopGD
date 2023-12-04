using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridposition = map.WorldToCell(mouseposition);

            TileBase clickedTile = map.GetTile(gridposition);
            bool walkable = dataFromTiles[clickedTile].walkable;

            print("At position " + gridposition + " there is a " + clickedTile+ " and the walkable is "+walkable);
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


}
