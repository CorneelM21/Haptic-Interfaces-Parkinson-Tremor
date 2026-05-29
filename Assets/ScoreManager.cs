using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("Het Scherm")]
    public TextMeshProUGUI scoreTekst;

    private int waterInGlas = 0;
    private int waterGemorst = 0;

    void Start()
    {
        UpdateScherm();
    }

    public void VoegPuntToeGlas()
    {
        waterInGlas++;
        UpdateScherm();
    }

    public void VoegPuntToeTafel()
    {
        waterGemorst++;
        UpdateScherm();
    }

    public void ResetScore()
    {
        waterInGlas = 0;
        waterGemorst = 0;
        UpdateScherm();
    }

    void UpdateScherm()
    {
        if (scoreTekst != null)
        {
            int totaalWater = waterInGlas + waterGemorst;

            // KIJK HIER: We checken eerst of er überhaupt al water is gevallen
            if (totaalWater == 0)
            {
                // Scenario 1: De oefening is net gestart of gereset
                scoreTekst.text = $"Poured in glass: {waterInGlas}\n" +
                                  $"Spilled: {waterGemorst}\n" +
                                  $"Accuracy: --%"; // Je kunt hier ook "Start met schenken!" van maken
            }
            else
            {
                // Scenario 2: Er is water gevallen, dus we kunnen eerlijk rekenen
                float accuraatheid = ((float)waterInGlas / totaalWater) * 100f;

                scoreTekst.text = $"Poured in glass: {waterInGlas}\n" +
                                  $"Spilled: {waterGemorst}\n" +
                                  $"Accuracy: {Mathf.RoundToInt(accuraatheid)}%";
            }
        }
    }
}