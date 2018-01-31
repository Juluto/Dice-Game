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
    public Text TxtScore;
    public Text TxtLancer;
    // Déclaration du texte TxtTerminer
    public Text TxtTerminer;
    // Déclaration du GameObject addName
    public GameObject addName;
    // Déclaration du InputField IFNom
    public InputField IFNom;
    // Déclaration du script InsertScore
    InsertScore insertScore;
    bool playdice = false;
    bool party = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        party = true;
        // Initialisation des variables score et lance
        score = 0;
        lance = 0;
        // Masquer le GameObject addName
        addName.SetActive(false);
        // Initialisation du script InsertScore
        insertScore = GameObject.Find("InsertScore").GetComponent<InsertScore>();
    }

    // FixedUpdate est utilisé lorsqu'on veut ajouter une force à un objet
    void FixedUpdate()
    {
        diceVelocity = rb.velocity;
        // Vérifier que si on appuie sur la barre d'espace et si la partie est terminée,
        // la partie recommence
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
            ShowLancer();
            ShowScore();
            // Vérifier si la partie est terminée et mettre fin à la partie
            if (lance == nbLancerMax) {
                ShowPartieTermine();
                party = false;
                addName.SetActive(true);
            }
        }
    }

    // Afficher la face du dé
    IEnumerator ShowFace()
    {
        TxtDice.enabled = true;
        TxtDice.GetComponent<Text>().text = face.ToString();
        // Ajout du score et incrémentation du nombre de lancer
        score = score + face;
        lance++;
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
        TxtScore.GetComponent<Text>().text = "Score : " + score;
    }

    // Changer le texte du nombre de lancer dans l'interface
    void ShowLancer()
    {
        TxtLancer.GetComponent<Text>().text= "Nb Lancé : " + lance;
    }

    // Afficher que la partie est terminée
    void ShowPartieTermine()
    {
        TxtTerminer.enabled = true;
    }

    // Masquer que la partie est terminée
    void HidePartieTermine()
    {
        TxtTerminer.enabled = false;
    }

    // Remettre les compteurs à zéro et masquer que la partie est terminée
    void RestartGame()
    {
        score = 0;
        lance = 0;
        HidePartieTermine();
        ShowScore();
        ShowLancer();
        party = true;
    }

    // Ajouter le score dans la bdd
    public void AddScore()
    {
        insertScore.inputName = IFNom.text;
        insertScore.inputScore = score.ToString();
        insertScore.AddScore();
        addName.SetActive(false);

        party = true;
        RestartGame();
    }
}
