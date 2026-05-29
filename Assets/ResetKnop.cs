using UnityEngine;

public class ResetKnop : MonoBehaviour
{
    [Header("Tafel & Score")]
    public TafelMorsen tafelScript;
    public ScoreManager scoreBeheer;

    [Header("De Fles")]
    public Transform fles;
    private Vector3 startPosFles;
    private Quaternion startRotFles;

    [Header("Lijst met Glazen (Zet hier al je glazen in)")]
    public GlasHaptiek[] alleGlasScripts; // Om al het water leeg te maken
    public Transform[] alleFysiekeGlazen; // Om alle glazen fysiek terug op tafel te zetten

    // Geheugen voor de posities van ALLE glazen
    private Vector3[] startPositiesGlazen;
    private Quaternion[] startRotatiesGlazen;

    void Start()
    {
        // 1. Sla de positie van de fles op
        if (fles != null)
        {
            startPosFles = fles.position;
            startRotFles = fles.rotation;
        }

        // 2. Maak ruimte in het geheugen voor al onze glazen
        startPositiesGlazen = new Vector3[alleFysiekeGlazen.Length];
        startRotatiesGlazen = new Quaternion[alleFysiekeGlazen.Length];

        // 3. Loop door de hele lijst en sla voor ELK glas zijn eigen startpositie op!
        for (int i = 0; i < alleFysiekeGlazen.Length; i++)
        {
            if (alleFysiekeGlazen[i] != null)
            {
                startPositiesGlazen[i] = alleFysiekeGlazen[i].position;
                startRotatiesGlazen[i] = alleFysiekeGlazen[i].rotation;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 1. Reset de plas, de score en de fles
        if (tafelScript != null) tafelScript.ResetPlas();
        if (scoreBeheer != null) scoreBeheer.ResetScore();
        ZetObjectTerug(fles, startPosFles, startRotFles);

        // 2. Maak het water in ELK glas leeg
        for (int i = 0; i < alleGlasScripts.Length; i++)
        {
            if (alleGlasScripts[i] != null) alleGlasScripts[i].ResetWater();
        }

        // 3. Zet ELK glas weer terug op zijn eigen plek
        for (int i = 0; i < alleFysiekeGlazen.Length; i++)
        {
            if (alleFysiekeGlazen[i] != null)
            {
                ZetObjectTerug(alleFysiekeGlazen[i], startPositiesGlazen[i], startRotatiesGlazen[i]);
            }
        }
    }

    // Ons vertrouwde "Teleporteer en Rem" systeempje
    void ZetObjectTerug(Transform fysiekObject, Vector3 doelPositie, Quaternion doelRotatie)
    {
        if (fysiekObject != null)
        {
            fysiekObject.position = doelPositie;
            fysiekObject.rotation = doelRotatie;

            Rigidbody rb = fysiekObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}