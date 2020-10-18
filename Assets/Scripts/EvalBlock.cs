using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvalBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlockGrade(Block block){
        float grade = 0.0f;
        Debug.Log("------------------------");
        List<Mountain> Mountains = block.MountainEntities;
        float mountainsWithValleys = 0;
        float valleysWith3Trees = 0;
        float maximumDiff = 0;
        float initialHeight = 0, finalHeight = 0;

        for (int num = 0; num < Mountains.Count; num++){
            if (num > 0){
                // Checking the difference of height between actual mountain and previous
                float diff = Mathf.Abs(Mountains[num].Top.transform.position.y - Mountains[num-1].Top.transform.position.y);
            
                if (diff > maximumDiff){
                    maximumDiff = diff;
                }
            }

            // Checking if there's exist a valley, and then checking if their valley has tree

            if (Mountains[num].topIsValley){
                mountainsWithValleys+=1.0f;
                if(Mountains[num].valley.Trees.Count >= 3){
                    valleysWith3Trees += 1.0f;
                }
            }

            // saving the height for future calculation
            if (num == 0){
                initialHeight = Mountains[num].Top.transform.position.y; 
            }
            else if (num + 1 == Mountains.Count){
                finalHeight = Mountains[num].Top.transform.position.y;
            }
            
        }

        // Checking the maximum difference in the mountains

        if (maximumDiff <= 2.0f){
            grade += 1.0f;
        }
        else if (maximumDiff <= 4){
            grade += 0.5f;
        }
        else{
            grade -= 1.0f;
        }

        Debug.Log("Grade: " + grade);

        int percentageOfValleys = (int)(mountainsWithValleys / (float)(Mountains.Count) * 100.0f);
        
        // Checking the amount of valleys appearing in the mountains

        if (percentageOfValleys >= 80){
            grade += 1.0f;
        }
        else if (percentageOfValleys >= 60){
            grade += 0.5f;
        }
        else{
            grade -= 1.0f;
        }

        Debug.Log("Grade: " + grade);

        // Checking the amount of Trees on mountains

        int percentageOfTreesInValleys = (int)(valleysWith3Trees / mountainsWithValleys * 100.0f);

        if (percentageOfTreesInValleys >= 60){
            grade += 1.0f;
        }
        else if (percentageOfTreesInValleys >= 40){
            grade += 0.5f;
        }
        else{
            grade -= 1.0f;
        }

        // Checking if there are bridges

        Debug.Log("Grade: " + grade);

        if (block.QuantityOfBridges == 0){
            grade += 1.0f;
        }
        else if (block.QuantityOfBridges <= 2){
            grade += 0.5f;
        }
        else{
            grade -= 1.0f;
        }

        Debug.Log("Grade: " + grade);

        float DiffStartEnd = Mathf.Abs(initialHeight - finalHeight);

        // Checking the difference of units between the first and last

        if (DiffStartEnd <= 5.0f){
            grade += 1.0f;
        }
        else if (DiffStartEnd <= 10.0f){
            grade += 0.5f;
        }
        else{
            grade -= 1.0f;
        }

        Debug.Log("Grade: " + grade);

        if (grade >= 3.0f){
            Debug.Log("Good block ");
        }
    }
}
