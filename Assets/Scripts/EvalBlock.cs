using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvalBlock: MonoBehaviour
{
    public float grade = 0.0f;
    public float mountainDiff = 0.0f;
    public float valleyPercentage = 0.0f;
    public float treesPercentage = 0.0f;
    public float bridgesQuantity = 0.0f;
    public float blockDiff = 0.0f;
    
    public void BlockGrade(Block block){
        Debug.Log("------------------------");
        List<Mountain> Mountains = block.MountainEntities;
        float mountainsWithValleys = 0;
        float valleysWith3Trees = 0;
        // float maximumDiff = 0;
        float initialHeight = 0, finalHeight = 0;

        for (int num = 0; num < Mountains.Count; num++){            
            if (num > 0){
                // Checking the difference of height between actual mountain and previous                
                float currHeight = Mountains[num].entryHeight;
                float prevHeight = currHeight - Mountains[num].exitHeight + Mountains[num-1].entryHeight;
                float diff = Mathf.Abs(currHeight - prevHeight);            
               
                // Checking the maximum difference in the mountains
                if (diff <= 1.5f){
                    mountainDiff += 1.0f / Mountains.Count;
                }
                else if (diff <= 3.0f){
                    mountainDiff += 0.5f / Mountains.Count;
                }
                else{
                    mountainDiff -= 1.0f / Mountains.Count;
                }
            }

            // Checking if there's exist a valley, and then checking if their valley has tree

            if (Mountains[num].topIsValley)
            {
                mountainsWithValleys += 1.0f;
                if (Mountains[num].valley.noTrees >= 3)
                {
                    valleysWith3Trees += 1.0f;
                }
            }

            // saving the height for future calculation
            finalHeight += Mountains[num].entryHeight - Mountains[num].exitHeight;            
        }

        int percentageOfValleys = (int)(mountainsWithValleys / (float)(Mountains.Count) * 100.0f);

        // Checking the amount of valleys appearing in the mountains

        if (percentageOfValleys >= 80){
            valleyPercentage += 1.0f;
        }
        else if (percentageOfValleys >= 60){
            valleyPercentage += 0.5f;
        }
        else{
            valleyPercentage -= 1.0f;
        }

        // Checking the amount of Trees on mountains

        int percentageOfTreesInValleys = (int)(valleysWith3Trees / mountainsWithValleys * 100.0f);

        if (percentageOfTreesInValleys >= 60){
            treesPercentage += 1.0f;
        }
        else if (percentageOfTreesInValleys >= 40){
            treesPercentage += 0.5f;
        }
        else{
            treesPercentage -= 1.0f;
        }

        // Checking if there are bridges

        if (block.QuantityOfBridges == 0){
            bridgesQuantity += 1.0f;
        }
        else if (block.QuantityOfBridges <= 2){
            bridgesQuantity += 0.5f;
        }
        else{
            bridgesQuantity -= 1.0f;
        }

        float DiffStartEnd = Mathf.Abs(initialHeight - finalHeight);

        // Checking the difference of units between the first and last

        if (DiffStartEnd <= 3.0f){
            blockDiff += 1.0f;
        }
        else if (DiffStartEnd <= 7.0f){
            blockDiff += 0.5f;
        }
        else{
            blockDiff -= 1.0f;
        }

        grade = mountainDiff + valleyPercentage + treesPercentage + bridgesQuantity + blockDiff;            
        if (grade >= 3.0f){
            Debug.Log("Good block ");
        }

        block.grade = grade;
    }
}
