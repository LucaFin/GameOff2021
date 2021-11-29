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
            //Player.transform.position = Vector3.MoveTowards(Player.transform.position, teleportPosition,1f );
            yield return new WaitForSeconds(0.1f);
            Player.transform.position = teleportPosition;
        }
        Player.GetComponent<Collider2D>().isTrigger = false;
        Player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
    
    }

    private void UnlockDoor()
    {
        if (livelloCompletato == 1)
        {
            StartCoroutine(TeleportPlayer());
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
            Camera.GetComponent<Animator>().SetTrigger("level2-3");
            Player.GetComponent<PlayerMovement>().setSwitched(false);
            Player.transform.localScale = new Vector3(1, 1, 1);
            Player.GetComponent<LevelUp>().evolve(teleportPosition);
        }
        if (livelloCompletato == 3)
        {
        }
        PoolEnemy.poolEnemy.ClearPool();
        foreach (GameObject spawn in spawner)
        {
            spawn.SetActive(true);
        }
    }
}
