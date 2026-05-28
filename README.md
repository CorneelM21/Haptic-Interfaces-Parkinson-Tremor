# Haptic-Interfaces-Parkinson-Tremor
Project for Haptic Interfaces Course


## 1. Introduction
*The medical context:* In current medical practice, Parkinson's disease-induced resting and action tremors present a significant challenge, severely impacting patients' quality of life and their ability to perform activities of daily living (ADLs) such as drinking or eating [1], [2]. It also has a large distressing impact on their social abilities and mental health, even in early-stage PArkinson's disease.

*The haptic advantage:* Haptic technology offers a multi-modal advantage by addressing both the physical and cognitive requirements of Parkinson's disease rehabilitation. Physically, active mechanical damping systems can dynamically counteract involuntary resting and action tremors in real-time, providing targeted resistance that dampens pathological oscillations without impeding a patient's voluntary motor intents [4]. Cognitively, haptic components can be simulated inside immersive virtual reality (VR) spaces to provide a safe, repeatable environment where patients practice essential activities of daily living (ADLs)—such as pouring liquids—without the real-world frustration or mess of failure [6], [7].

By proposing a decoupled architecture where the physical exoskeleton (EduExo) and the virtual training software (Meta Quest 3 and Unity) operate entirely independently, this project actively fosters the key facilitators of AT adoption [3]. This modularity lowers patient stress, minimizes hardware dependency, and aligns directly with individual user preferences and comfort, allowing the training system to serve as an accessible, non-stigmatizing assistive tool. 

This simple system also allows patients to exercise without the need of a doctor, which supports the reduction of clinical pressure [5].

*Existing solutions and gaps:* The WOTAS project already proved the possibility to suppress tremors using a robotic exoskeleton [4]. It shows that applying internal forces, so called haptic resistance, at the tremor frequency is a valid control strategy. Although it worked, the fact that this solution is too bulky, heavy and expensive were constantly returning points is users feedback. There is also a popular medication based solution, namely Levodopa. While Levodopa remains the "gold standard" for managing Parkinson's disease, it comes with a severe long-term drawback known as Levodopa-Induced Dyskinesia (LID) [8]. This consists of severe, involuntary, and uncontrollable movements. This traps patients in a dilemma where lowering the medication dosage returns the tremors while raising it worsens the dyskinesia. This clinical trap strongly justifies the need for a physical, haptic exoskeleton to provide tremor suppression.

## 2. Supplies (Bill of Materials)
To ensure full reproducibility, below is the comprehensive list of components required to build this prototype:

All estimated costs are provided in Euros (€).

### 1. Exoskeleton Core Kit

The physical exoskeleton, including all structural components, motors, and sensors, is sourced as a complete kit.

| Component | Description | Estimated Cost | Sourcing Link |
| :--- | :--- | :--- | :--- |
| **EduExo 2.0 (Lite Kit)** | Complete kit containing 3D-printed parts, cuffs, Arduino Nano, EMG sensor, motor, and cables. | ~€350.00 | [Auxivo Store](https://www.auxivo.com/product-page/eduexo-2-0) |

### 2. VR & Software Requirements

These components are required to run and develop the virtual reality simulation.

| Component | Description | Estimated Cost | Sourcing Link |
| :--- | :--- | :--- | :--- |
| **Meta Quest 3S (128GB)** | Standalone VR Headset for running the simulation. | €329.99 | [Amazon](https://www.amazon.de/s?k=meta+quest+3s) |
| **Unity Software** | Game engine used for VR development (Personal Edition). | €0.00 | [Unity Download](https://unity.com/download) |

### 3. Required Tools & Equipment

To fully assemble the EduExo 2.0 prototype, you will need the following workspace tools and equipment. These can be sourced from standard hardware stores or Amazon.

| Component | Estimated Cost | Amazon Sourcing Link |
| :--- | :--- | :--- |
| **Soldering iron & solder kit** | €15.00 | [Search on Amazon](https://www.amazon.de/s?k=soldering+iron+kit+with+solder) |
| **Helping hand tool** | €12.00 | [Search on Amazon](https://www.amazon.de/s?k=helping+hands+soldering) |
| **2 mm hex key (Allen wrench)** | €4.00 | [Search on Amazon](https://www.amazon.de/s?k=2mm+hex+key) |
| **Precision screwdriver set** | €10.00 | [Search on Amazon](https://www.amazon.de/s?k=precision+screwdriver+set+flat+cross) |
| **Wire stripping tool / side cutter**| €10.00 | [Search on Amazon](https://www.amazon.de/s?k=wire+stripping+tool+side+cutter) |
| **Crimp pliers / flat pliers** | €15.00 | [Search on Amazon](https://www.amazon.de/s?k=crimp+pliers+flat) |
| **Insulation tape** | €4.00 | [Search on Amazon](https://www.amazon.de/s?k=electrical+insulation+tape) |
| **9V Rechargeable batteries + charger**| €18.00 | [Search on Amazon](https://www.amazon.de/s?k=9v+rechargeable+battery+with+charger) |

---
*Note: Prices are estimates and may vary based on region, availability, and taxes (VAT).*

## 3. Methods
### 3.1 Conceptual Framework & Component Selection
The conceptual framework for our design relies on a modular, two-part system that can operate entirely independently:

1. **Physical Haptic Interface:** We utilized the EduExo kit paired with an external EMG sensor to create an active tremor-suppression wearable. The EMG sensor was chosen to detect the user's muscle signals, allowing the system's control logic to differentiate between high-frequency unwanted tremors and lower-frequency intended movements.

2. **Virtual Training Environment:** The primary objective of this part of the project was to develop a realistic, accessible, and standalone Virtual Reality (VR) pouring simulation for patient rehabilitation and training. To achieve this, the Unity 3D Engine was used as the foundational software environment. Unity provides a robust, built-in physics engine and modular C# scripting, which are essential for simulating realistic fluid dynamics, tracking particles, and managing object collisions in real-time.
For the VR integration, the Meta Quest SDK was utilized. This SDK provides highly optimized, pre-configured interaction logic, such as hand-tracking and grab mechanics, which drastically accelerated and facilitated the prototyping phase. In order to use this SDK, a standalone Meta Quest headset was selected. This also has major advantages over a standard PC headset, as operating the application natively on the headset removes the constraint of physical cables, thereby maximizing accessibility, safety, and freedom of movement for patients during their rehabilitation exercises.

### 3.2 System Architecture
*(Upload an image of your system architecture showing both the Exo and the VR setup, then link it here)*
![System Architecture Diagram](link_to_your_uploaded_image.png)

As shown in the diagram above, the systems are deliberately decoupled. The exoskeleton operates on a localized control loop via [mention the microcontroller/PC running the EMG code], while the VR simulation runs entirely on the Meta Quest 3 hardware. 

The system architecture was designed around a three-tier logic flow: Input, Logic, and Output. 

* **Input Layer:** User interactions and spatial positioning are captured by the OVR Camera Rig, translating real-world hand and head movements into the virtual space.
* **Logic Layer:** The core rules of the simulation are governed by Unity’s physics engine working in tandem with custom C# scripts. The `GlasHaptiek` script detects individual fluid particles as they enter predefined collision zones. This data is passed to a centralized `ScoreManager` script, which calculates the user's pouring accuracy. Additionally, a `ResetKnop` script acts as the master state controller, managing the spatial data of all interactive elements.
* **Output Layer:** The system provides multimodal feedback. This includes the visual rendering of the fluid, real-time UI text updates on a physical in-game scoreboard, and audio/haptic feedback triggered upon object collisions.

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

[3] S. Malden et al., "Patient and Carer-Related Facilitators and Barriers to the Adoption of Assistive Technologies for the Care of Older Adults: Systematic Review," JMIR Aging, vol. 8, p. e73917, Nov. 2025.

[4] E. Rocon et al., "Design and Validation of a Rehabilitation Robotic Exoskeleton for Tremor Assessment and Suppression," IEEE Trans. Neural Syst. Rehabil. Eng., vol. 15, no. 3, pp. 367-378, Sep. 2007.

[5] D. I. Feldman et al., "A Nationwide Telehealth Heart Failure Program: Can Remote Patient Monitoring and Guideline Directed Treatment Protocols Help Bridge the Gaps in Heart Failure Management?," Journal of Cardiac Failure, vol. 29, no. 3, Mar. 2023.

[6] C. G. Canning et al., "Virtual reality in research and rehabilitation of gait and balance in Parkinson disease," Nature Reviews Neurology, vol. 16, no. 8, pp. 409-425, Aug. 2020.

[7] Q. Wu, M. Qiu, X. Liu, W. A. He, T. Yang, and C. Jia, "The Role of Virtual Reality on Parkinson's Disease Management: A Bibliometric and Content Analysis," Sensors, vol. 25, no. 5, art. no. 1432, Feb. 2025.

[8] L. di Biase et al., "Levodopa-Induced Dyskinesias in Parkinson's Disease: An Overview on Pathophysiology, Clinical Manifestations, Therapy Management Strategies and Future Directions," J. Clin. Med., vol. 12, no. 13, p. 4427, Jul. 2023.
