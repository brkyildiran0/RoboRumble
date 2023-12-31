using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TilePanelUI : MonoBehaviour
{
    public Transform TileManagerTransformHierarchy;
    [SerializeField] private Sprite tileSprite;

    private RectTransform rectTransform;
    private float rectWidth, rectHeight;
    private float rowTileDimension, columnTileDimension;

    public static TilePanelUI Instance;
    
    public List<Vector2> coloredTiles;

    public Color softRed; 
    private void Awake()
    {
        Instance = this;
        rectTransform = GetComponent<RectTransform>();

        rectWidth = rectTransform.rect.width;
        rectHeight = rectTransform.rect.height;
    }

    private void OnEnable()
    {
        EventManager.OnTilesCreated += CalculateTileAmounts;
        EventManager.OnTilesCreated += DrawUITiles;
    }
    private void OnDisable()
    {
        EventManager.OnTilesCreated -= CalculateTileAmounts;
        EventManager.OnTilesCreated -= DrawUITiles;
    }

    public void CalculateTileAmounts()
    {
        rowTileDimension = rectWidth / TileController.Instance.rowCount;
        columnTileDimension = rectHeight / TileController.Instance.columnCount;
    }

    public void DrawUITiles()
    {
        var TileManagerObject = FindObjectOfType<TileController>();

        for (int i = 0; i < TileController.Instance.rowCount; i++)
        {
            for (int j = 0; j < TileController.Instance.columnCount; j++)
            {
                var tile = TileManagerTransformHierarchy.GetChild(i * TileController.Instance.columnCount + j);
                var tileRectTransform = tile.AddComponent<RectTransform>();

                float posX = (rowTileDimension * j) - (rectWidth / 2) + (rowTileDimension / 2);
                float posY = (columnTileDimension * i) - (rectHeight / 2) + (columnTileDimension / 2);
                tileRectTransform.anchoredPosition = new Vector2(posX, posY);
                tileRectTransform.sizeDelta = new Vector2(rowTileDimension, columnTileDimension);

                var tileImage = tileRectTransform.AddComponent<Image>();

                Vector2 currentTile = new Vector2(i, j);
                if (coloredTiles.Contains(currentTile))
                {
                    if (coloredTiles[coloredTiles.Count - 1] == currentTile)
                    {
                        tileImage.color = new Color(0, 120, 0);
                    }
                    else
                    {
                        tileImage.color = Color.white;
                    }
                }
                else
                {
                    tileImage.color = new Color(softRed.r, softRed.g, softRed.b, softRed.a);
                }
                tileImage.sprite = tileSprite;
            }
        }
    }

    public int PathContains(Tile tile)
    {
        Vector2 tilePos = new Vector2(tile.row, tile.col);
        if (coloredTiles.Contains(tilePos))
        {
            if (coloredTiles[coloredTiles.Count - 1] == tilePos)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        return -1;
    }

}
