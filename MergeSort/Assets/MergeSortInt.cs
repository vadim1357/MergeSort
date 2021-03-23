using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSortInt : MonoBehaviour
{
    public MeshRenderer cube; // префаб обьекта (куба)
    public int count; // количество кубов
    public float minSize; // минимальное значение размера по оси Y
    public float maxSize; // максимальное значение размера по оси Y
    float[] sizeY;// массив значений размеров обьектов по оси Y
    MeshRenderer[] cubes; // массив для обьектов
    float space = 0; // расстояние от одного обьекта до другого
    void Start()
    {
        sizeY = new float[count];
        cubes = new MeshRenderer[count];
       
        for(int i = 0; i < cubes.Length; i++)
        {
            float size = Random.Range(minSize, maxSize);// значение размера по оси Y
            MeshRenderer newCube = Instantiate(cube);// создание обьекта
            newCube.transform.localPosition = new Vector3(i + space, 1, 1);// устанавливаем локальную позицию обьекта (newCube)
            newCube.transform.localScale = new Vector3(1, size, 1); // устанавливаем локальный размер обьекта (newCube)

            sizeY[i] = size;
            cubes[i] = newCube;
            space++;
            
        }
        MergeSort(sizeY);// отсортировать обьекты по размеру
        
        Invoke("_Merge",3);// запусть сортировку через 3 секунды после старта
        
        
    }
    public void _Merge()// метод изменения размера
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.localScale = new Vector3(1, sizeY[i], 1);
            
        }
        
    }

    private void MergeSort(float[] array)// метод сортировки массива слиянием (массив который нужно отсортеровать)
    {
        if(array.Length< 2)
        {
            return;
        }
        int mid = array.Length / 2; // середина основоного (array) массива
        float[] left = new float[mid];// левая чсть основного массива
        float[] right = new float[array.Length - mid];// правая часть основного массива
        for(int i = 0; i < mid; i++)
        {
            left[i] = array[i];
        }
        for(int i = mid; i < array.Length; i++)
        {
            right[i - mid] = array[i];
        }
        MergeSort(left);
        MergeSort(right);
        Merge(array, left, right);
    }
    private void Merge(float[] targetArray, float[] array1, float[] array2)// сравнение элементов массива (основной массив, левая его часть, правая его часть)
    {
        int minIndex1 = 0;// индекс первого не проверенного элемента левого (array1)  массива
        int minIndex2 = 0;// индекс первого не проверенного элемента правого (array2) массива
        int minIndexTarget = 0; // индекс первого элемента основного (targetArray) массива
        while(minIndex1<array1.Length && minIndex2< array2.Length)
        {
            if (array1[minIndex1] < array2[minIndex2])
            {
                targetArray[minIndexTarget] = array1[minIndex1];
                minIndex1++;
            }
            else
            {
                targetArray[minIndexTarget] = array2[minIndex2];
                minIndex2++;
            }
            minIndexTarget++;
        }
        while (minIndex1 < array1.Length)
        {
            targetArray[minIndexTarget] = array1[minIndex1];
            minIndex1++;
            minIndexTarget++;
        }
        while (minIndex2 < array2.Length)
        {
            targetArray[minIndexTarget] = array2[minIndex2];
            minIndex2++;
            minIndexTarget++;
        }
    }
}
