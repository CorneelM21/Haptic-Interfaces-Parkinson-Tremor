using UnityEngine;

public class GlasHaptiek : MonoBehaviour
{
    [Header("Vullen")]
    public Transform vloeistofObject;
    public Transform meetPunt;
    public float vulSnelheid = 0.005f;
    public float maxVloeistofHoogte = 0.8f;

    [Header("Geluid & Pitch")]
    public AudioSource schenkGeluid; // NIEUW: Hier koppelen we het geluid van de fles aan!
    public float startPitch = 0.8f;  // Het lage geluid (leeg glas)
    public float eindPitch = 1.6f;   // Het hoge geluid (vol glas)

    [Header("Haptische Instellingen")]
    [Range(0f, 1f)] public float trilKracht = 0.5f;
    [Range(0f, 1f)] public float trilSnelheid = 0.5f;

    public ScoreManager scoreBeheer;

    private OVRInput.Controller glasHand = OVRInput.Controller.None;
    private Vector3 origineleWaterSchaal;

    void Start()
    {
        if (vloeistofObject != null)
        {
            origineleWaterSchaal = vloeistofObject.localScale;
        }

        // Zet de pitch aan het begin voor de zekerheid netjes op de startwaarde
        if (schenkGeluid != null) schenkGeluid.pitch = startPitch;
    }

    void OnParticleCollision(GameObject other)
    {
        CheckEnTrilHand(OVRInput.Controller.RTouch);
        CheckEnTrilHand(OVRInput.Controller.LTouch);

        if (scoreBeheer != null) scoreBeheer.VoegPuntToeGlas();
        if (vloeistofObject != null && vloeistofObject.localScale.y < maxVloeistofHoogte)
        {
            Vector3 nieuweSchaal = vloeistofObject.localScale;
            nieuweSchaal.y += vulSnelheid;
            vloeistofObject.localScale = nieuweSchaal;

            // NIEUW: Roep de pitch-berekening aan elke keer als er een druppel in valt!
            UpdatePitch();
        }
    }

    void UpdatePitch()
    {
        if (schenkGeluid != null && vloeistofObject != null)
        {
            // 1. Bereken een percentage van 0.0 (leeg) tot 1.0 (vol)
            float vulPercentage = vloeistofObject.localScale.y / maxVloeistofHoogte;

            // 2. Laat Lerp de perfecte toonhoogte daartussenin berekenen!
            schenkGeluid.pitch = Mathf.Lerp(startPitch, eindPitch, vulPercentage);
        }
    }

    void CheckEnTrilHand(OVRInput.Controller controller)
    {
        bool houdtVast = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, controller);
        Vector3 lokalePos = OVRInput.GetLocalControllerPosition(controller);
        Vector3 echteWereldPos = Camera.main.transform.parent.TransformPoint(lokalePos);
        float afstand = Vector3.Distance(echteWereldPos, meetPunt.position);

        if (houdtVast && afstand < 0.2f)
        {
            glasHand = controller;
            OVRInput.SetControllerVibration(trilSnelheid, trilKracht, controller);
            CancelInvoke("StopTrillen");
            Invoke("StopTrillen", 0.1f);
        }
    }

    void StopTrillen()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }

    public void ResetWater()
    {
        if (vloeistofObject != null)
        {
            vloeistofObject.localScale = origineleWaterSchaal;
        }

        // NIEUW: Zet het geluid ook weer netjes terug naar de lage stand voor de volgende keer
        if (schenkGeluid != null)
        {
            schenkGeluid.pitch = startPitch;
        }
    }
}