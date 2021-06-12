using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    int currentLevel = 0;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

        //Cheat codes
        if(Input.GetKeyDown(KeyCode.R))
        {
            LoadLevel(currentLevel);
        }

     //Level Select
            for (int number = 0; number <= 9; number++)
            {
                if (Input.GetKeyDown(number.ToString()))
                    LoadLevel(number);
            }




    }


    //---Level Loading Functions----
    public void LoadLevel(int level)
    {
        if (level + 1 < SceneManager.sceneCountInBuildSettings)
        {
            currentLevel = level;
            SceneManager.LoadScene(currentLevel);
        }
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextLevel()
    {
        if (currentLevel + 1 < SceneManager.sceneCountInBuildSettings)
        {
            ++currentLevel;
            SceneManager.LoadScene(currentLevel);
        }
    }
}
