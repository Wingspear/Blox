using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject userBlox;
    public Blox bloxCube;
    public GameObject spawnPointStart;
    public GameObject spawnPointFinish;
    public GameObject score;

    public static bool[,] bloxPattern;
    public int patternSize;
    public float lengthBlox;

    public static bool spawningOn;
    public float totalTimePassed;
    private float timeTracker1, timeTracker2;

    private float probConstant;
    private bool repositionUser;

    // Start is called before the first frame update
    void Start()
    {
        //initialize a 2x2 pattern
        patternSize = 1;
        lengthBlox = 0;
        spawningOn = false;
        totalTimePassed = 0;
        timeTracker1 = 0;
        timeTracker2 = 0;
        probConstant = 0.5f;
        repositionUser = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (spawningOn) {
            totalTimePassed += Time.deltaTime;
            score.GetComponent<Text>().text = ((int)totalTimePassed).ToString();

            timeTracker1 += Time.deltaTime;

            if (timeTracker1 >= 3f)
            {
                timeTracker2 += Time.deltaTime;

                if (repositionUser)
                {
                    repositionUser = false;
                    patternSize++;
                    lengthBlox = (spawnPointFinish.transform.position.x - spawnPointStart.transform.position.x) / patternSize;

                    if (patternSize == 2)
                    {
                        userBlox.SetActive(true);
                    }
                    userBlox.transform.localScale = new Vector3(lengthBlox, lengthBlox, transform.localScale.z);
                    userBlox.transform.position = new Vector3(spawnPointStart.transform.position.x + lengthBlox / 2, spawnPointStart.transform.position.y - lengthBlox / 2, userBlox.transform.position.z);

                    Camera.main.transform.position = userBlox.transform.position;
                    Camera.main.transform.SetParent(userBlox.transform);

                    bloxPattern = GeneratePattern(patternSize, 1f - (1f / patternSize) * (probConstant));
                    SpawnPattern(bloxPattern);
                }
            }
            else if (timeTracker1 < 3f)
            {
                timeTracker2 = 0;
            }
            
            if (timeTracker1 >= 60f)
            {
                timeTracker1 = 0;
                repositionUser = true;
            }
            else if (timeTracker2 >= 6f / (timeTracker1 / 8))
            {
                timeTracker2 = 0;
                bloxPattern = GeneratePattern(patternSize, 1f - (1f / patternSize) * (probConstant));
                SpawnPattern(bloxPattern);
            }
        }

    }

    public void StartSpawning()
    {
        spawningOn = true;
        patternSize = 1;
        timeTracker1 = 0;
        timeTracker2 = 0;
        repositionUser = true;
    }
    
    public void StopSpawning()
    {
        spawningOn = false;
        score.SetActive(false);
    }

    public void SpawnPattern(bool[,] pattern)
    {
        for (int r = 0; r < pattern.GetLength(0); r++)
        {
            for (int c = 0; c < pattern.GetLength(0); c++)
            {
                if (pattern[r, c])
                {
                    Blox blox = Instantiate(bloxCube);
                    blox.transform.localScale = new Vector3(lengthBlox * 0.95f, lengthBlox * 0.95f, blox.transform.localScale.z);
                    blox.transform.position = new Vector3(spawnPointStart.transform.position.x + lengthBlox / 2, spawnPointStart.transform.position.y - lengthBlox / 2, spawnPointStart.transform.position.z);
                    blox.transform.position += new Vector3(r * lengthBlox, -c * lengthBlox);
                    blox.GetComponent<Blox>().SetSpeed(5f * patternSize + timeTracker1);
                    
                }
            }
        }
    }

    //create a 2D array n x n pattern representation
    //(0, 1) probability of block appearing per individual block
    //copy pattern into the bloxPattern array
    //guarantee at least 1 empty space
    private bool[,] GeneratePattern(int n, float probability)
    {

        bool[,] pattern = new bool[n, n];
        bool fullBlock = true;

        do
        {
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (Random.Range(0, 1f) <= probability)
                    {
                        //has block
                        pattern[r, c] = true;
                    }
                    else
                    {
                        //empty space
                        pattern[r, c] = false;
                        fullBlock = false;
                    }
                }
            }

        }
        while (fullBlock);
        //guarantee there's at least one empty space

        return pattern;
    }
}
