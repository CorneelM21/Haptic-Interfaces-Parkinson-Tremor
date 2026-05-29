using UnityEngine;

public class TafelMorsen : MonoBehaviour
{
    [Header("Mors Instellingen")]
    public Transform tafelPlas;
    public float groeiSnelheid = 0.01f;
    public float maxPlasGrootte = 1.0f;

    public ScoreManager scoreBeheer;

    private Vector3 originelePlasSchaal; // NIEUW: Geheugen voor de plas

    void Start()
    {
        // NIEUW: Onthoud de kleine start-plas
        if (tafelPlas != null)
        {
            originelePlasSchaal = tafelPlas.localScale;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (scoreBeheer != null) scoreBeheer.VoegPuntToeTafel();
        if (tafelPlas != null && tafelPlas.localScale.x < maxPlasGrootte)
        {
            Vector3 nieuweSchaal = tafelPlas.localScale;
            nieuweSchaal.x += groeiSnelheid;
            nieuweSchaal.z += groeiSnelheid;
            tafelPlas.localScale = nieuweSchaal;
        }
    }

    // NIEUW: Een reset-functie speciaal voor de tafel
    public void ResetPlas()
    {
        if (tafelPlas != null)
        {
            tafelPlas.localScale = originelePlasSchaal;
        }
    }
}