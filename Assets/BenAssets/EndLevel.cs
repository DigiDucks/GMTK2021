using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    PlayerMovement[] playerPos;

    private void Start()
    {
        playerPos = FindObjectsOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float checkValue = Vector3.Distance(playerPos[0].transform.position, playerPos[1].transform.position);
        Debug.Log(checkValue + " is the checkvalue");

        //if over 5 then false
        if (checkValue <= 5.0f)
        {
            Debug.Log ("the check triggered");
            GameManager.instance.LoadNextLevel();
        }
    }
}
