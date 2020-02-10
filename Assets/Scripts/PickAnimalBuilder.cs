using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAnimalBuilder : MonoBehaviour
{
    //Need the animals and one of them is randomly chosen and the player needs to pick the correct one from two rows of animals, 5 in each row. 
    //Using GameObjects because I can make prefabs of them.
    public GameObject[] animals;

    //The animal the player needs to pick out
    [SerializeField]
    private int chosenAnimalIndex;
    private GameObject chosenAnimal;

    //Another reference for the chosen one so I can check if the player clicks on the wrong one (The one that shows which one to find instead of the one "hidden" with other animals
    //Probably a better way to do this but let's go with it for now (Maybe I can just disable the collision box2D from it?)
    private GameObject chosenIcon;

    //Make a list to hold the random animals + the chosen one so we can spawn them later. Also so we can check the list if it already has an animal so we won't have duplicates.
    [SerializeField]
    private List<GameObject> randomAnimals;


    // Start is called before the first frame update
    void Start()
    {
        SetUpGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetListDebug();
            
        }
    }

    //Function to do all the other functions
    //Maybe making more functions will help with debugging, going to try that
    void SetUpGame()
    {
        PickRandomAnimal();
        SpawnChosenAnimal();
        ListRandomAnimals();
        //DebugList();
    }

    //Pick a random animal from the animals array. (Maybe I could use local variables and out the animal but going to use a variable just in case.
    void PickRandomAnimal()
    {
        //chosenAnimal = animals[Random.Range(0, (animals.Length - 1))];
        chosenAnimalIndex = Random.Range(0, animals.Length - 1);
        Debug.Log(chosenAnimal);
    }

    //Spawn the randomed animal and disable its collider so it can't be clicked
    void SpawnChosenAnimal()
    {
        //chosenIcon = Instantiate(chosenAnimal, new Vector3(0, 8, 0), Quaternion.identity);
        chosenIcon = Instantiate(animals[chosenAnimalIndex], new Vector3(0, 8, 0), Quaternion.identity);
        chosenIcon.GetComponent<BoxCollider2D>().enabled = false;
    }

    void ListRandomAnimals()
    {
        //Add the chosen animal to the list
        //randomAnimals.Add(chosenAnimal);

        for(int i = 0; i < 9; i++)
        {
            int randomIndex = Random.Range(0, animals.Length);

            if (randomAnimals.Contains(animals[randomIndex]))
            {
                i--;
                
            }
            else
            {
                randomAnimals.Add(animals[randomIndex]);
            }

            //Debug.Log(i);

              
        }

        randomAnimals.Insert((Random.Range(0, randomAnimals.Count - 1)), chosenAnimal);
        


    }

    void DebugList()
    {
        foreach (GameObject gameObject in randomAnimals)
        {
            Debug.Log(gameObject);
        }
    }

    void ResetListDebug()
    {
        randomAnimals.Clear();
        ListRandomAnimals();
    }


}
