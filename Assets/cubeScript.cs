using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cubeScript : MonoBehaviour
{
    public int score;
    public int lance;
    public int nbLancerMax;
    public int face;
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    public Text TxtDice;
    // Déclaration des textes TxtScore, TxtLancer
    // ...
    // Déclaration du texte TxtTerminer
    // ...
    // Déclaration du GameObject addName
    // ...
    // Déclaration du InputField IFNom
    // ...
    // Déclaration du script InsertScore
    // ...
    bool playdice = false;
    bool party = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        party = true;
        // Initialisation des variables score et lance
        // ...
        // Masquer le GameObject addName
        // ...
        // Initialisation du script InsertScore
        // ...
    }

    // FixedUpdate est utilisé lorsqu'on veut ajouter une force à un objet
    void FixedUpdate()
    {
        diceVelocity = rb.velocity;
        // Vérifier que si on appuie sur la barre d'espace et si la partie est terminée,
        // la partie recommence
        // ...
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.magnitude == 0 && party)
        {
            LancerDe();
            playdice = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playdice && rb.velocity.magnitude == 0 && party)
        {
            playdice = false;
            StartCoroutine(ShowFace());
            // Mettre à jour le score et le nombre de lancer dans l'interface
            // ...
            // Vérifier si la partie est terminée et mettre fin à la partie
            // ...
        }
    }

    // Afficher la face du dé
    IEnumerator ShowFace()
    {
        TxtDice.enabled = true;
        TxtDice.GetComponent<Text>().text = face.ToString();
        // Ajout du score et incrémentation du nombre de lancer
        // ...
        yield return new WaitForSeconds(2f);
        TxtDice.enabled = false;
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

    // Changer le texte du score dans l'interface
    void ShowScore()
    {
        // ...
    }

    // Changer le texte du nombre de lancer dans l'interface
    void ShowLancer()
    {
        // ...
    }

    // Afficher que la partie est terminée
    void ShowPartieTermine()
    {
        // ...
    }

    // Masquer que la partie est terminée
    void HidePartieTermine()
    {
        // ...
    }

    // Remettre les compteurs à zéro et masquer que la partie est terminée
    void RestartGame()
    {
        // ...
    }

    // Ajouter le score dans la bdd
    public void AddScore()
    {
        // ...
    }
}
