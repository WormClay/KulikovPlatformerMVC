using UnityEngine;
using UnityEngine.Tilemaps;
namespace PlatformerMVC
{
    public sealed class GeneratorController
    {
        private Tilemap _tilemap;
        private Tile _tile;
        private int _mapHeight;
        private int _mapWidth;

        private int _fillPercent;
        private int _smoothPercent;

        private bool _borders;
        private int[,] _map;

        public GeneratorController(GeneratorLevelView view)
        {
            _tilemap = view._tilemap;
            _tile = view._tile;
            _mapHeight = view._mapHeight;
            _mapWidth = view._mapWidth;

            _fillPercent = view._fillPercent;
            _smoothPercent = view._smoothPercent;

            _borders = view._borders;
            _map = new int[_mapWidth, _mapHeight];
        }

        public void Start()
        {
            FillMap();
            for (int i = 0; i < _smoothPercent; i++)
            {
                SmothMap();
            }

            DrawTiles();
        }


        public void FillMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    if (x == 0 || x == _mapWidth - 1 || y == 0 || y == _mapHeight - 1)
                    {
                        if (_borders)
                        {
                            _map[x, y] = 1;
                        }
                    }
                    else
                    {
                        _map[x, y] = Random.Range(0, 100) < _fillPercent ? 1 : 0;
                    }
                }
            }
            //Debug.Log(_map.Length);
        }

        private void SmothMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    int neighbour = GetNeigbour(x,y);
                    if (neighbour > 4) 
                    {
                        _map[x, y] = 1;
                    } else if (neighbour < 4) 
                    {
                        _map[x, y] = 0;
                    }
                }
            }
        }

        private int GetNeigbour(int x, int y) 
        {
            int neigbour = 0;

            for (int gridX = x-1; gridX <= x+1; gridX++)
            {
                for (int gridY = y-1; gridY <= y+1; gridY++)
                {
                    if (gridX>=0&& gridX<_mapWidth&& gridY>=0&& gridY < _mapHeight) 
                    {
                        if (gridX != x || gridY != y) 
                        {
                            neigbour += _map[gridX, gridY]; 
                        }

                    } else 
                    {
                        neigbour++;
                    }
                }
            }
            return neigbour;
        }

        private void DrawTiles() 
        {
            if (_map == null) return;
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    if (_map[x,y]==1)
                    {
                        Vector3Int tilePosition = new Vector3Int(-_mapWidth/2+x,_mapHeight/2+y,0);
                        _tilemap.SetTile(tilePosition, _tile);
                    }
                }
            }
        }
    }
}
