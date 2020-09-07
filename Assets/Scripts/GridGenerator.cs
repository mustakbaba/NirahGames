using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    public GameObject gridObject;
   public int side=5;

    private void Start()
    {
        for(int i=0;i<side;i++)
        {

            for (int j = 0; j < side; j++)
            {
                Instantiate(gridObject, new Vector3(i, -1, j), Quaternion.identity);

            }
           
        }
       


    }


}
