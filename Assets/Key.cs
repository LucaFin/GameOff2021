using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    float livelloCompletato;
    [SerializeField]
    List<GameObject> spawner= new List<GameObject>();
    [SerializeField]
    GameObject Player;
    [SerializeField]
    Vector3 teleportPosition;
    [SerializeField]
    GameObject Camera;
    [SerializeField]
    GameObject cameraFollowPlayer;
    [SerializeField]
    Sprite spriteNextLevel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(TeleportPlayer());
            UnlockDoor();
        }
    }

    private void Start()
    {
        if (Player == null)
        {
            Player=GameObject.FindGameObjectWithTag("Player");
        }
    }

    IEnumerator TeleportPlayer()
    {
        Player.GetComponent<Collider2D>().isTrigger = true;
        Player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        while (Player.transform.position != teleportPosition)
        {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, teleportPosition,1f );
            yield return new WaitForSeconds(0.1f);
        }
        Player.GetComponent<Collider2D>().isTrigger = false;
        Player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
    
    }

    private void UnlockDoor()
    {

        PoolEnemy.poolEnemy.ClearPool();
        if (livelloCompletato == 1)
        {
            cameraFollowPlayer.SetActive(false);
            Camera.SetActive(true);
            Camera.GetComponent<Animator>().SetTrigger("level1-2");
            Player.GetComponent<PlayerMovement>().setSwitched(true);
            Player.GetComponent<SpriteRenderer>().sprite = spriteNextLevel;
            Player.transform.localScale = new Vector3(1, 1, 1);
            Player.GetComponent<PlayerMovement>().RefreshCollider();
        }
        if (livelloCompletato == 2)
        {
            Debug.Log("inserire animazione apertura porta");
        }
        if (livelloCompletato == 3)
        {
            Debug.Log("inserire animazione apertura porta");
        }
        foreach (GameObject spawn in spawner)
        {
            spawn.SetActive(true);
        }
    }
}
