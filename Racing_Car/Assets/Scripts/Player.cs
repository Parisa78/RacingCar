using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0f, 1f)] public float moveAmount;
    public SpawnManager spawnManager;
    private bool canmoveleft;
    private bool canmoveright;
    private bool canmoveback;
    public GameObject Lights;
    void Start()
    {
        Lights.gameObject.SetActive(false);
        canmoveleft = true;
        canmoveright = true;
        canmoveback = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && canmoveright)
        {
            transform.position += new Vector3(moveAmount, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) && canmoveleft)
        {
            transform.position += new Vector3(-moveAmount, 0, 0);
        }

        if (Input.GetKey(KeyCode.W)) /// nayad bishtar aghab age safehe azbein raft
        {
            transform.position += new Vector3(0, 0, moveAmount);
        }

        if (Input.GetKey(KeyCode.S) && canmoveback)
        {
            transform.position += new Vector3(0, 0, -moveAmount);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag(TagNames.roadStart.ToString()))
        {
            Debug.Log("must canmoveback false");
            canmoveback = false;

        }
        if (other.gameObject.CompareTag(TagNames.entertunnel.ToString()))
        {
            Lights.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(TagNames.roadEnd.ToString()))
        {
            Debug.Log("new road");
            spawnManager.spawnTriggerEnter();

        }
        if (other.gameObject.CompareTag(TagNames.roadStart.ToString()))
        {
            canmoveback = true;
        }

        if (other.gameObject.CompareTag(TagNames.entertunnel.ToString()))
        {
            Lights.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagNames.leftCube.ToString()))
        {
            Debug.Log("left waalll");
            canmoveleft = false;

        }

        if (collision.gameObject.CompareTag(TagNames.rightCube.ToString()))
        {
            canmoveright = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagNames.leftCube.ToString()))
        {
            canmoveleft = true;
        }

        if (collision.gameObject.CompareTag(TagNames.rightCube.ToString()))
        {
            canmoveright = true;
        }
    }
}
