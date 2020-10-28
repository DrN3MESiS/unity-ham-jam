using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvalBlock
{
    public void BlockGrade(Block block)
    {
        float grade = 0.0f;
        Debug.Log("------------------------");
        List<Mountain> Mountains = block.MountainEntities;
        float mountainsWithValleys = 0;
        float valleysWith3Trees = 0;
        float maximumDiff = 0;
        float initialHeight = 0, finalHeight = 0;

        for (int num = 0; num < Mountains.Count; num++)
        {
            if (num > 0)
            {
                // Checking the difference of height between actual mountain and previous
                float diff = Mathf.Abs(Mountains[num].Top.transform.position.y - Mountains[num - 1].Top.transform.position.y);

                if (diff > maximumDiff)
                {
                    maximumDiff = diff;
                }
            }

            // Checking if there's exist a valley, and then checking if their valley has tree

            if (Mountains[num].topIsValley)
            {
                mountainsWithValleys += 1.0f;
                if (Mountains[num].valley.Trees.Count >= 3)
                {
                    valleysWith3Trees += 1.0f;
                }
            }

            // saving the height for future calculation
            if (num == 0)
            {
                initialHeight = Mountains[num].Top.transform.position.y;
            }
            else if (num + 1 == Mountains.Count)
            {
                finalHeight = Mountains[num].Top.transform.position.y;
            }

        }

        // Checking the maximum difference in the mountains

        if (maximumDiff <= 2.0f)
        {
            grade += 1.0f;
            Debug.Log("Grade: " + grade + " | Reason: El cambio de alturas entre cada montaña es menor a 2" + " (+1)");
        }
        else if (maximumDiff <= 4)
        {
            grade += 0.5f;
            Debug.Log("Grade: " + grade + " | Reason: El cambio de alturas entre cada montaña es mayor a 2 y menor a 4" + " (+0.5)");
        }
        else
        {
            grade -= 1.0f;
            Debug.Log("Grade: " + grade + " | Reason: El cambio de alturas entre cada montaña es mayor a 4" + " (-1)");
        }


        int percentageOfValleys = (int)(mountainsWithValleys / (float)(Mountains.Count) * 100.0f);

        // Checking the amount of valleys appearing in the mountains

        if (percentageOfValleys >= 80)
        {
            grade += 1.0f;
            Debug.Log("Grade: " + grade + " | Reason: Por lo menos el 80% de las montañas tienen un valle" + " (+1)");
        }
        else if (percentageOfValleys >= 60)
        {
            grade += 0.5f;
            Debug.Log("Grade: " + grade + " | Reason: Por lo menos el 60% de las montañas tienen un valle" + " (+0.5)");
        }
        else
        {
            grade -= 1.0f;
            Debug.Log("Grade: " + grade + " | Reason: Por lo menos el 20% de las montañas tienen un valle" + " (-1)");
        }


        // Checking the amount of Trees on mountains

        int percentageOfTreesInValleys = (int)(valleysWith3Trees / mountainsWithValleys * 100.0f);

        if (percentageOfTreesInValleys >= 60)
        {
            grade += 1.0f;
            Debug.Log("Grade: " + grade + " | Reason: Por lo menos el 60% de los valles generados tienen por lo menos 3 arboles" + " (+1)");
        }
        else if (percentageOfTreesInValleys >= 40)
        {
            grade += 0.5f;
            Debug.Log("Grade: " + grade + " | Reason: Por lo menos el 40% de los valles generados tienen por lo menos 3 arboles" + " (+0.5)");
        }
        else
        {
            grade -= 1.0f;
            Debug.Log("Grade: " + grade + " | Reason: Por lo menos el 20% de los valles generados tienen por lo menos 3 arboles" + " (-1)");
        }

        // Checking if there are bridges

        if (block.QuantityOfBridges == 0)
        {
            grade += 1.0f;
            Debug.Log("Grade: " + grade + " | Reason: Hay 0 puentes" + " (+1)");
        }
        else if (block.QuantityOfBridges <= 2)
        {
            grade += 0.5f;
            Debug.Log("Grade: " + grade + " | Reason: Hay menos de 2 puentes" + " (+0.5)");
        }
        else
        {
            grade -= 1.0f;
            Debug.Log("Grade: " + grade + " | Reason: Hay mas de 3 puentes" + " (-1)");
        }



        float DiffStartEnd = Mathf.Abs(initialHeight - finalHeight);

        // Checking the difference of units between the first and last

        if (DiffStartEnd <= 5.0f)
        {
            grade += 1.0f;
            Debug.Log("Grade: " + grade + " | Reason: La diferencia de unidades entre montañas es menos de 5" + " (+1)");
        }
        else if (DiffStartEnd <= 10.0f)
        {
            grade += 0.5f;
            Debug.Log("Grade: " + grade + " | Reason: La diferencia de unidades entre montañas es menos de 10" + " (+0.5)");
        }
        else
        {
            grade -= 1.0f;
            Debug.Log("Grade: " + grade + " | Reason: La diferencia de unidades entre montañas es mayor a 10" + " (-1)");
        }

        if (grade >= 4.0f)
        {
            Debug.Log("The block is perfect");
        }
        else if (grade > 2.0f && grade < 4.0f)
        {
            Debug.Log("The block is regular");
        }
        else if (grade < 2.0f)
        {
            Debug.Log("The block is bad");
        }
    }
}
