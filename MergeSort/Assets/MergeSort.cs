using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSort : MonoBehaviour
{
    public GameObject cube;
    public int count;
    public float minSize;
    public float maxSize;
    GameObject[] cubes;
    Vector3[] posCube;
    
    float space = 0;
    GameObject newCube;
    void Start()
    {
        GameObject[] cubes = new GameObject[count];
        Vector3[] posCube = new Vector3[count];


        for (int i = 0; i <cubes.Length; i++)
        {
            newCube = Instantiate(cube);
            newCube.transform.localPosition = new Vector3(i+space, 1, 1); ;
            newCube.transform.localScale = new Vector3(1, Random.Range(minSize, maxSize), 1);
            cubes[i] = newCube;
            
            space += 0.5f;
        }
        _MergeSort(posCube);
        for(int i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.localPosition = posCube[i];
        }
    }
  
    public void _MergeSort(Vector3[] array)
    {
        if (array.Length < 2)
        {
            return;
        }
        int mid = array.Length / 2;
        Vector3[] leftArray = new Vector3[mid];
        Vector3[] rightArray = new Vector3[array.Length - mid];
        for(int i = 0; i <mid; i++)
        {
            leftArray[i] = array[i];
        }
        for(int i = mid; i < array.Length; i++)
        {
            rightArray[i-mid] = array[i];
        }
        _MergeSort(leftArray);
        _MergeSort(rightArray);
        Merge(array, leftArray, rightArray);

    }
    public void Merge(Vector3[] targetArray, Vector3[] array1, Vector3[] array2)
    {
        int minIndexArray1 = 0;
        int minIndexArray2 = 0;
        int minIndexTargetArray = 0;

        while(minIndexArray1<array1.Length && minIndexArray2 < array2.Length)
        {
            if(array1[minIndexArray1].y < array2[minIndexArray2].y) 
            {
                targetArray[minIndexTargetArray] = array1[minIndexArray1];
                minIndexArray1++;
                minIndexTargetArray++;
            }
            else 
            {
                targetArray[minIndexTargetArray] = array2[minIndexArray2];
                minIndexArray1++;
                minIndexTargetArray++;
            }
            
        }
        while(minIndexArray1 < array1.Length)
        {
            targetArray[minIndexTargetArray] = array1[minIndexArray1];
            minIndexArray1++;
            minIndexTargetArray++;
        }
        while (minIndexArray2 < array2.Length)
        {
            targetArray[minIndexTargetArray] = array2[minIndexArray2];
            minIndexArray2++;
            minIndexTargetArray++;
        }
    }
}
