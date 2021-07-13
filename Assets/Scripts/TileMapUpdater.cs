using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class TileMapUpdater : MonoBehaviour
{
    [SerializeField] public Tile comparedTile;
    [SerializeField] public GameObject torchTile;
    private Vector2 tileOffset = new Vector2(0.5f,0.5f);
    Tilemap tilemap;
    TilemapRenderer tilemapRenderer;


    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        tilemapRenderer = GetComponent<TilemapRenderer>();
        Vector3Int cellPosition = tilemap.WorldToCell(transform.Find("Tilemap World Position").position);



        transform.Find("Tilemap World Position").transform.position = tilemap.GetCellCenterWorld(cellPosition);

        for (int i = tilemap.cellBounds.yMin; i < tilemap.size.y; i++)
        {
            for (int k = tilemap.cellBounds.xMin; k < tilemap.size.x; k++)
            {
                if (tilemap.GetTile(new Vector3Int(k,i,0)) == comparedTile)
                {
                    Instantiate(torchTile,new Vector3(k+GetComponentInParent<Transform>().position.x+tileOffset.x, i+GetComponentInParent<Transform>().position.y+tileOffset.y, -1),Quaternion.identity);
                }
            }
        }
    }
}