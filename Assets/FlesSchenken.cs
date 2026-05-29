using UnityEngine;

public class FlesSchenken : MonoBehaviour
{
    [Header("Instellingen")]
    public ParticleSystem waterStraal;
    public Transform meetPunt;
    public float schenkHoek = 90f;

    [Header("Geluid")]
    public AudioSource schenkGeluid; // NIEUW: Het vakje voor de luidspreker

    [Header("Haptische Feedback")]
    [Range(0f, 1f)] public float basisTrilSnelheid = 0.5f;

    private bool isAanHetSchenken = false;

    void Start()
    {
        if (waterStraal != null)
        {
            var emission = waterStraal.emission;
            emission.enabled = false;
        }
    }

    void Update()
    {
        float hoek = Vector3.Angle(Vector3.up, transform.up);

        if (hoek > schenkHoek && !isAanHetSchenken)
        {
            StartSchenken();
        }
        else if (hoek <= schenkHoek && isAanHetSchenken)
        {
            StopSchenken();
        }

        if (isAanHetSchenken)
        {
            float extraKanteling = hoek - schenkHoek;
            float dynamischeKracht = extraKanteling / (180f - schenkHoek);
            dynamischeKracht = Mathf.Clamp(dynamischeKracht + 0.1f, 0.1f, 1.0f);

            TrilActieveHand(OVRInput.Controller.RTouch, dynamischeKracht);
            TrilActieveHand(OVRInput.Controller.LTouch, dynamischeKracht);
        }
    }

    void TrilActieveHand(OVRInput.Controller controller, float kracht)
    {
        bool houdtVast = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, controller);

        // Vertaal ook hier de controller naar de Echte Wereld positie
        Vector3 lokalePos = OVRInput.GetLocalControllerPosition(controller);
        Vector3 echteWereldPos = Camera.main.transform.parent.TransformPoint(lokalePos);

        float afstand = Vector3.Distance(echteWereldPos, meetPunt.position);

        if (houdtVast && afstand < 0.2f)
        {
            OVRInput.SetControllerVibration(basisTrilSnelheid, kracht, controller);
        }
    }

    void StartSchenken()
    {
        isAanHetSchenken = true;
        if (waterStraal != null)
        {
            var emission = waterStraal.emission;
            emission.enabled = true;
        }

        // NIEUW: Zet het geluid aan!
        if (schenkGeluid != null)
        {
            schenkGeluid.Play();
        }
    }

    void StopSchenken()
    {
        isAanHetSchenken = false;
        if (waterStraal != null)
        {
            var emission = waterStraal.emission;
            emission.enabled = false;
        }

        // NIEUW: Zet het geluid uit!
        if (schenkGeluid != null)
        {
            schenkGeluid.Stop();
        }

        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }
}