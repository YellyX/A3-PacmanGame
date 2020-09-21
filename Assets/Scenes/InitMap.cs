using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InitMap : MonoBehaviour
{
    public GameObject[] gameobjs;
    private GameObject board;

    public int[,] mapList = new int[15, 14]
    {
        {1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7},
        {2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4},
        {2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 4},
        {2, 5, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4},
        {2, 5, 3, 4, 4, 3, 6, 3, 4, 4, 4, 3, 5, 3},
        {2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
        {2, 5, 3, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4},
        {2, 5, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3},
        {2, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4},
        {1, 2, 2, 2, 2, 1, 5, 4, 3, 4, 4, 3, 0, 4},
        {0, 0, 0, 0, 0, 2, 6, 4, 3, 4, 4, 3, 0, 3},
        {0, 0, 0, 0, 0, 2, 5, 4, 4, 5, 5, 5, 5, 5},
        {0, 0, 0, 0, 0, 2, 5, 4, 4, 5, 3, 4, 4, 0},
        {2, 2, 2, 2, 2, 1, 5, 3, 3, 5, 4, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 0, 0}
    };


    void Start()
    {
        CreateMap();
        var board2 = Instantiate(this.board, this.transform);
        board2.name = "board2";
        board2.transform.Rotate(180, 0, 180);
        var board3 = Instantiate(this.board, this.transform);
        board3.transform.Rotate(0, 0, 180);
        board3.name = "board3";
        board3.transform.position = new Vector3(0, -0.11f, 0);
        var board4 = Instantiate(this.board, this.transform);
        board4.name = "board4";
        board4.transform.Rotate(180, 0, 0);
        board4.transform.position = board3.transform.position;
    }

    void CreateMap()
    {
        board = new GameObject("board1");
        board.transform.parent = this.transform;
        for (var i = 0; i < mapList.GetLength(1); i++)
        {
            for (var j = 0; j < mapList.GetLength(0); j++)
            {
                var go = Instantiate(gameobjs[mapList[j, i]], board.transform);
                go.transform.position = new Vector3(-1.49f + 0.11f * i, 1.49f - 0.11f * j, -2);

                if (mapList[j, i]==1)
                {
                    if (IsContains(i - 1, j, 1, 2) && IsContains(i, j - 1, 1, 2))
                    {
                        go.transform.Rotate(0, 0, 180);
                        continue;
                    }

                    if (IsContains(i, j - 1, 2))
                    {
                        go.transform.Rotate(0, 0, 90);
                        continue;
                    }
                    if (IsContains(i - 1, j, 2))
                    {
                        go.transform.Rotate(0, 0, -90);
                        continue;
                    }
                }
                else if (mapList[j, i] == 2)
                {
                    if (IsContains(i - 1, j, 2, 1)|| IsContains(i + 1, j, 2, 1))
                    {
                        go.transform.Rotate(0, 0, 90);
                    }
                }
                else if (mapList[j, i] == 3)
                {
                    if (IsContains(i - 1, j, 4) && IsContains(i + 1, j, 4) && IsContains(i, j - 1, 3) && IsContains(i, j + 1, 4))
                    {
                        go.transform.Rotate(0, 0, 0);
                        continue;
                    }
                    if (IsContains(i - 1, j, 4) && IsContains(i, j + 1, 4))
                    {
                        go.transform.Rotate(0, 0, -90);
                        continue;
                    }
                    if (IsContains(i + 1, j, 3, 4) && IsContains(i, j - 1, 3, 4))
                    {
                        go.transform.Rotate(0, 0, 90);
                        continue;
                    }
                    if (IsContains(i - 1, j, 3, 4) && IsContains(i, j - 1, 3, 4))
                    {
                        go.transform.Rotate(0, 0, 180);
                        continue;
                    }
                    if (IsContains(i - 1, j, 4, 3))
                    {
                        go.transform.Rotate(0, 0, -90);
                        continue;
                    }

                    if (IsContains(i, j - 1, 3, 4))
                    {
                        go.transform.Rotate(0, 0, 90);
                        continue;
                    }
                }
                else if (mapList[j, i]==4)
                {
                    if (IsContains(i - 1, j, 4) && IsContains(i + 1, j, 3))
                    {
                        go.transform.Rotate(0, 0, 0);
                        continue;
                    }
                    if (IsContains(i, j - 1, 4) && IsContains(i + 1, j, 3))
                    {
                        go.transform.Rotate(0, 0, 90);
                        continue;
                    }
                    if (IsContains(i - 1, j, 4) && IsContains(i + 1, j, 3))
                    {
                        go.transform.Rotate(0, 0, 0);
                        continue;
                    }
                    if (IsContains(i - 1, j, 3) || IsContains(i + 1, j, 3))
                    {
                        go.transform.Rotate(0, 0, 0);
                        continue;
                    }

                    if (IsContains(i, j - 1, 3, 4, 7))
                    {
                        go.transform.Rotate(0, 0, 90);
                        continue;
                    }
                }
                else
                {
                    go.transform.Rotate(0, 0, 90);
                    go.transform.localScale = new Vector3(-1, 1, 1);
                }
            }
        }
    }
    
    public bool IsContains(int x, int y, params int[] value)
    {
        try
        {
            return value.Contains(mapList[y, x]);
        }
        catch (Exception)
        {
            return false;
        }
    }

}
