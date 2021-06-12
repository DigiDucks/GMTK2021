using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    PlayerMovement[] playerPos;

    [SerializeField]
    bool next_level = false;

    private void Start()
    {
        playerPos = FindObjectsOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            float checkValue = 0;
            if(playerPos.Length >= 2)
            {
                checkValue = Vector3.Distance(playerPos[0].transform.position, playerPos[1].transform.position);
                Debug.Log(checkValue + " is the checkvalue");
            }

            //if over 5 then false
            if (checkValue <= 5.0f)
            {
                next_level = true;
                Debug.Log ("the check triggered");
                GameManager.instance.LoadNextLevel();
            }
        }


    }
}
