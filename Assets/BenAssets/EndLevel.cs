using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private string sceneBuildIndex;
    private Vector3 vector3;

    [SerializeField] GameObject Player1POS;
    [SerializeField] GameObject Player2POS;
    [SerializeField] string scenename;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float checkValue = Vector3.Distance(Player1POS.transform.position, Player2POS.transform.position);
        Debug.Log(checkValue + " is the checkvalue");

        //if over 5 then false
        if (checkValue <= 5.0f)
        {
            Debug.Log ("the check triggered");
            SceneManager.LoadScene(scenename);
        }
    }
}
