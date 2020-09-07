using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speedOfRotation;
    public Transform pivLeft, pivRight, pivForward, pivBack, center;
    bool isRotating = false;
    public GameObject mobileCanvas;
    private void Start()
    {
    }
    private void Update()
    {
#if UNITY_EDITOR
        if (!isRotating)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(Move("left"));

                isRotating = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(Move("right"));
                isRotating = true;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                StartCoroutine(Move("forward"));
                isRotating = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine(Move("back"));
                isRotating = true;
            }

        }




#elif UNITY_ANDROID
        mobileCanvas.SetActive(true);
#endif
    }
    public void ButtonLeft()
    {
        if (!isRotating)
            StartCoroutine(Move("left"));
        isRotating = true;
    } 
    public void ButtonRight()
    {
        if (!isRotating)
            StartCoroutine(Move("right"));
        isRotating = true;
    } 
    public void ButtonForward()
    {
        if (!isRotating)
            StartCoroutine(Move("forward"));
        isRotating = true;
    } 
    public void ButtonBack()
    {
        if (!isRotating)
            StartCoroutine(Move("back"));
        isRotating = true;
    }
    IEnumerator Move(string where)
    {
        for (int i = 0; i < 15; i++)
        {
            switch (where)
            {
                case "left":
                    gameObject.transform.RotateAround(pivLeft.transform.position, Vector3.forward, 6);
                    break;
                case "right":
                    gameObject.transform.RotateAround(pivRight.transform.position, Vector3.back, 6);
                    break;
                case "forward":
                    gameObject.transform.RotateAround(pivForward.transform.position, Vector3.right, 6);
                    break;
                case "back":
                    gameObject.transform.RotateAround(pivBack.transform.position, Vector3.left, 6);
                    break;


            }
            yield return new WaitForSeconds(speedOfRotation);
        }
        center.transform.position = gameObject.transform.position;
        isRotating = false;
    }

}
