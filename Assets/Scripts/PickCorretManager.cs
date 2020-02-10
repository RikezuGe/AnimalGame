using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCorretManager : MonoBehaviour
{

    public GameObject[] animals;

    public Transform rowStartPos;
    public Transform toFindPosition;

    private int randomAnimal;
    private int animalsInList;

    private GameObject animalToFind;
    private string animalName;
    private List<GameObject> animalsToRow;

    // Start is called before the first frame update
    void Start()
    {
        //animalsInList = 0;
        PickAnimal();
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.transform.name == animalName)
            {
                Debug.Log("correct!");
            }
            else
            {
                Debug.Log("wrong! " + animalName);
            }
        }

        if(Input.GetKeyUp(KeyCode.R))
        {
            foreach (GameObject gameObject in animalsToRow)
            {
                Debug.Log(gameObject + "hdhdhdh");
                PickAnimal();
            }
        }
    }

    void PickAnimal()
    {
        animalsInList = 0;
        int listRandom = 0;

        randomAnimal = Random.Range(0, (animals.Length-1));
        animalToFind = animals[randomAnimal];
        animalName = animalToFind.name;
        Debug.Log(animalToFind);
        Instantiate(animalToFind, toFindPosition.position, Quaternion.identity);

        animalsToRow = new List<GameObject>();
        animalsToRow.Add(animals[randomAnimal]);

        //for (int i = 0; i < 10; i++)
        //{
        //    Debug.Log(i);

        //}

        while (animalsInList < 8)
        {
            listRandom = Random.Range(0, (animals.Length-1));

            if(listRandom == randomAnimal || animalsToRow.Contains(animals[listRandom]))
            {
                return;
            }
            else
            {
                animalsToRow.Add(animals[listRandom]);
                animalsInList++;
            }
        }

        int columns = 5;
        int rows = 2;
        int randomListAnimal = 0;
        int spawnXoffset = 0;
        int spawnYoffset = 0;

        for(int x = 0; x < rows; x++)
        {
            for(int y = 0; y < columns; y++)
            {
                Instantiate(animalsToRow[randomListAnimal], rowStartPos.position + new Vector3 (spawnXoffset, spawnYoffset), Quaternion.identity);
                spawnXoffset += 3;
                randomListAnimal++;
            }
            spawnYoffset -= 4;
            spawnXoffset = 0;
        }

        //foreach (GameObject gameObject in animalsToRow)
        //{


        //}
        Debug.Log("hehehe");
    }


}
