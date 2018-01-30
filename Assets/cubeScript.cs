using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cubeScript : MonoBehaviour
{
    public int face;
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    public Text txt;
    bool playdice = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate est utilisé lorsqu'on veut ajouter une force à un objet
    void FixedUpdate()
    {
        diceVelocity = rb.velocity;
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.magnitude == 0)
        {
            LancerDe();
            playdice = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playdice && rb.velocity.magnitude == 0)
        {
            playdice = false;
            StartCoroutine(ShowFace());
        }
    }

    // Afficher la face du dé
    IEnumerator ShowFace()
    {
        txt.enabled = true;
        txt.GetComponent<Text>().text = face.ToString();
        yield return new WaitForSeconds(2f);
        txt.enabled = false;
    }

    // Lancer le dé
    void LancerDe()
    {
        float dirX = Random.Range(0, 1000);
        float dirY = Random.Range(0, 1000);
        float dirZ = Random.Range(0, 1000);
        transform.position = new Vector3(0, 3, 0);
        transform.rotation = Quaternion.identity;
        rb.AddForce(transform.up * 500);
        rb.AddTorque(dirX, dirY, dirZ);
    }
}
