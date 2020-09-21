using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMaps : MonoBehaviour
{
    public Transform mParent;
    public GameObject ZeroObj, FirstObj, SecondObj, ThirdObj;
    public int[,] maps = new int[7, 46]{
        { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
    };
    private void Start()
    {
        for (int i = 0; i < maps.GetLength(0); i++)
        {
            for (int j = 0; j < maps.GetLength(1); j++)
            {
                Debug.Log("value" + maps[i, j]);
                var value = maps[i, j];
                GameObject preObj = null;
                switch (value)
                {
                    case 0:
                        preObj = ZeroObj;
                        break;
                    case 1:
                        preObj = FirstObj;
                        break;
                    case 2:
                        preObj = SecondObj;
                        break;
                    case 3:
                        preObj = ThirdObj;
                        break;
                }
                var obj = Instantiate(preObj);
                obj.transform.parent = mParent;
                obj.transform.localScale = preObj.transform.localScale;
                //obj.transform.localPosition = new Vector3(i * .7f, -j * .55f, 0);
                obj.transform.localPosition = new Vector3(j * 1.1f, -i * .6f, 0);
                if (value == 0) { obj.SetActive(false); }
            }
        }
    }
}
