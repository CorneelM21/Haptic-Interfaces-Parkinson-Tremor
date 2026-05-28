# Haptic-Interfaces-Parkinson-Tremor
Project for Haptic Interfaces Course


## 1. Introduction
*The medical context:* In current medical practice, Parkinson's disease-induced resting and action tremors present a significant challenge, severely impacting patients' quality of life and their ability to perform activities of daily living (ADLs) such as drinking or eating [1], [2]. It also has a large distressing impact on their social abilities and mental health, even in early-stage PArkinson's disease.

*The haptic advantage:* Haptic technology offers a unique advantage here by providing active mechanical damping to physically counteract the tremors in real-time, while simultaneously offering a safe, simulated environment for motor-skill training.
*Existing solutions and gaps:* Existing solutions often rely heavily on pharmaceuticals, which can have severe side effects, or passive weighted wearables that cause muscle fatigue. This project aims to address these limitations by creating a dual-modality system: an active exoskeleton that differentiates between voluntary movement and involuntary tremors, paired with a completely decoupled Virtual Reality (VR) assessment environment. 

## 2. Supplies (Bill of Materials)
To ensure full reproducibility, below is the comprehensive list of components required to build this prototype:

| Component | Part Number / Type | Quantity | Estimated Cost | Vendor / Link |
| :--- | :--- | :--- | :--- | :--- |
| EduExo kit | N/A | 1 | [Cost] | [Link] |
| Meta Quest 3 Head-Mounted Display | N/A | 1 | [Cost] | [Link] |
| Unity (software) | Version [X.X] | 1 | Free | [Link] |
| EMG Sensor | [Part Number] | [Quantity] | [Cost] | [Link] |
| [Any specific microcontrollers?] | [Part Number] | [Quantity] | [Cost] | [Link] |

## 3. Methods
### 3.1 Conceptual Framework & Component Selection
The conceptual framework for our design relies on a modular, two-part system that can operate entirely independently:
1. **Physical Haptic Interface:** We utilized the EduExo kit paired with an external EMG sensor to create an active tremor-suppression wearable. The EMG sensor was chosen to detect the user's muscle signals, allowing the system's control logic to differentiate between high-frequency unwanted tremors and lower-frequency intended movements. 
2. **Virtual Training Environment:** We used the Meta Quest 3 and Unity to build a safe, gamified assessment scenario. This allows the patient to practice pouring water into various-sized glasses while receiving real-time visual feedback via a virtual scoreboard.

### 3.2 System Architecture
*(Upload an image of your system architecture showing both the Exo and the VR setup, then link it here)*
![System Architecture Diagram](link_to_your_uploaded_image.png)

As shown in the diagram above, the systems are deliberately decoupled. The exoskeleton operates on a localized control loop via [mention the microcontroller/PC running the EMG code], while the VR simulation runs entirely on the Meta Quest 3 hardware. 

### 3.3 Construction & Programming
Building the prototype required several practical steps:
1. **Exoskeleton Integration:** We assembled the EduExo kit and mounted the EMG sensors on the user's [specify the muscle group, e.g., forearm/biceps]. 
2. **Control Logic:** The suppression algorithm was programmed to filter out tremor frequencies. When a deliberate movement is detected via the EMG, the motors allow the movement; when a tremor is detected, the motors actively resist it.
3. **VR Programming:** Using Unity, we programmed a liquid physics simulation and collision detection for the glasses. The scoring system calculates the ratio of correctly poured liquid versus spilled liquid to quantify the user's motor control.

### 3.4 Hardware Constraints & Troubleshooting
During development, we managed several constraints:
* **Signal Noise:** EMG sensors are highly susceptible to noise. We addressed this by [explain how you filtered the data or improved sensor placement].
* **Actuator Control:** Tuning the PID controller of the EduExo to feel supportive rather than restrictive required iterative testing to find the right balance.
* **Decoupling:** Ensuring the user could wear the Quest 3 comfortably while the exoskeleton was active required careful cable management and physical workspace setup.

## 4. Discussion
Upon testing the prototype, the dual-system approach proved [describe performance—was it effective?]. The EduExo successfully provided resistance to simulated tremors, while the VR environment accurately tracked the pouring task. 

However, we noted the following unexpected constraints:
* **Limitation 1:** [e.g., Latency in the EMG signal processing?]
* **Limitation 2:** [e.g., Weight of the exoskeleton during prolonged use?]

*User Feedback:* Qualitative feedback indicated that having a separated VR environment was less stressful for users, as a physical water-pouring failure did not result in an actual mess.

## 5. Conclusion and Future Work
In summary, the most significant aspect of this prototype is its modularity: providing physical assistance and virtual assessment as standalone or complementary tools. 

For future development, we suggest:
* Integrating Bluetooth communication so the VR simulation can record the real-time force data generated by the exoskeleton.
* Refining the EMG machine-learning model to better adapt to patient-specific tremor profiles.

## 6. References
[1] L. E. Heusinkveld et al., "Impact of Tremor on Patients With Early Stage Parkinson's Disease," Front. Neurol., vol. 9, p. 628, Aug. 2018.
[2] R. A. Hauser et al., "Burden of tremor in Parkinson's disease: A survey study," J. Parkinsons Dis., vol. 15, no. 3, pp. 541-551, Mar. 2025.
