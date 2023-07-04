using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int value;

    public GameObject nextCube;
    public Rigidbody rb;
    GameObject pointmiddle;
    public int ID;
    GameManager gameManager;

    private void Awake()
    {
        ID = GetInstanceID();
        rb = gameObject.GetComponent<Rigidbody>();
        pointmiddle = GameObject.Find("PointMiddle");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GetComponent<ParticleSystemRenderer>().material = GetComponent<MeshRenderer>().material;

    }

    private void OnCollisionEnter(Collision collision)
    {
       

        if (collision.gameObject.CompareTag("Cube"))
        {
            if (collision.gameObject.TryGetComponent(out Cube cube))
            {
                if (cube.value == value)
                {
                    if (ID < cube.ID) return;
                    Destroy(cube.gameObject);
                    Destroy(this.gameObject);
                    if (nextCube)
                    {

                        GameObject temp = Instantiate(nextCube, transform.position, Quaternion.identity);
                        StartCoroutine(anitime());
                        int randomIndex = Random.Range(0, gameManager.cubes.Length);
                        Instantiate(gameManager.cubes[randomIndex], pointmiddle.transform.position + new Vector3(0 + Random.Range(-1.35f, 1.35f), 0-3, 0 + Random.Range(-3.41f, 2.1f)), Quaternion.identity);
                        gameManager.Score += Random.Range(3, 27);
                        gameManager.bubble.Play();
                        temp.GetComponent<ParticleSystem>().startSize = 1;
                    }
                }
            }
        }
    }
    IEnumerator anitime()
    {
        GetComponent<Animator>().SetBool("cubani", true);
        yield return new WaitForSeconds(0.155f);
        GetComponent<Animator>().SetBool("cubani", false);



    }
   
}
