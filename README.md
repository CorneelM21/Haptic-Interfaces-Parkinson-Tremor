# Haptic-Interfaces-Parkinson-Tremor
Project for Haptic Interfaces Course


## 1. Introduction
*The medical context:* In current medical practice, Parkinson's disease-induced resting and action tremors present a significant challenge, severely impacting patients' quality of life and their ability to perform activities of daily living (ADLs) such as drinking or eating [1], [2]. It also has a large distressing impact on their social abilities and mental health, even in early-stage Parkinson's disease.

*The haptic advantage:* Haptic technology offers a multi-modal advantage by addressing both the physical and cognitive requirements of Parkinson's disease rehabilitation. Physically, active mechanical damping systems can dynamically counteract involuntary resting and action tremors in real-time, providing targeted resistance that dampens pathological oscillations without impeding a patient's voluntary motor intents [4]. Cognitively, haptic components can be simulated inside immersive virtual reality (VR) spaces to provide a safe, repeatable environment where patients practice essential activities of daily living (ADLs), such as pouring liquids, without the real-world frustration or mess of failure [6], [7].

By proposing a decoupled architecture where the physical exoskeleton (EduExo) and the virtual training software (Meta Quest 3 and Unity) operate entirely independently, this project actively fosters the key facilitators of assistive technology (AT) adoption [3]. This modularity lowers patient stress, minimizes hardware dependency, and aligns directly with individual user preferences and comfort, allowing the training system to serve as an accessible, non-stigmatizing assistive tool. This simple system also allows patients to exercise without the need for a doctor, which supports the reduction of clinical pressure [5].

*Existing solutions and gaps:* The WOTAS project already proved the possibility of suppressing tremors using a robotic exoskeleton [4]. It shows that applying internal forces, so-called haptic resistance, at the tremor frequency is a valid control strategy. However, comprehensive reviews of wearable tremor technologies highlight a persistent gap: these traditional rigid orthoses are frequently rejected by patients because their bulkiness, weight, and poor cosmetic appearance cause discomfort and social anxiety [9]. To address these limitations, the field is currently pivoting toward highly adaptive, intelligent control systems that better accommodate the user's natural motions [10]. This modern push for smart integration strongly supports our approach of using an EMG-driven control loop that targets unwanted tremors while seamlessly allowing voluntary movement.
Furthermore, there is a popular medication-based solution, namely Levodopa. While Levodopa remains the standard for managing Parkinson's disease, it comes with a severe long-term drawback known as Levodopa-Induced Dyskinesia (LID) [8]. This consists of severe, involuntary, and uncontrollable movements. This traps patients in a dilemma where lowering the medication dosage returns the tremors while raising it worsens the dyskinesia. This clinical trap strongly justifies the need for a physical, haptic exoskeleton to provide non-pharmacological tremor suppression.

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
2. **Virtual Training Environment:** We used the Meta Quest 3 and Unity to build a safe, gamified assessment scenario. This allows the patient to practice pouring water into various-sized glasses while receiving real-time visual feedback via a virtual scoreboard.

### 3.2 System Architecture

*(Electrical Schematic of the Haptic Interface)*
![System Wiring Diagram](WiringDiagram.jpg)

As shown in the schematic above, the systems are deliberately decoupled. The exoskeleton operates on a localized control loop via the Arduino microcontroller running the EMG classification code, while the VR simulation runs entirely on the Meta Quest 3 hardware. The motor controller regulates the haptic resistance based on the real-time EMG threshold data.

### 3.3 Construction & Programming

*(Fully Assembled EduExo Mounted on the User)*
![Assembled Exoskeleton Prototype](OverviewArm.jpg)

Building the prototype required several practical steps:
1. **Exoskeleton Integration:** We assembled the EduExo kit and mounted the EMG sensors on the user's arm, ensuring secure placement to capture clean myoelectric signals. 
2. **Control Logic:** The suppression algorithm was programmed to filter out tremor frequencies. When a deliberate movement is detected via the EMG, the motors allow the movement; when a tremor is detected, the motors actively resist it.
3. **VR Programming:** Using Unity, we programmed a liquid physics simulation and collision detection for the glasses. The scoring system calculates the ratio of correctly poured liquid versus spilled liquid to quantify the user's motor control.


### 3.4 Hardware Constraints & Troubleshooting
During iterative development and testing of the exoskeleton, several hardware constraints were identified. Resolving these required strict safety protocols, precise physical calibration, and software-level filtering to ensure a stable user experience.

**Electrical Safety & Short Circuits:** Wearable exoskeletons introduce significant risks if subjected to power surges or exposed wiring. To mitigate this, grid power was strictly prohibited during operation; the system was constrained entirely to a limited-current 9V battery. During the initial electronic assembly, short circuits were a primary concern. Our standard troubleshooting protocol involved verifying the power state via the onboard LEDs. If the LEDs failed to illuminate, or if components began to heat up, the system was immediately powered down. Diagnostics involved visually inspecting the Terminal Adapter, the AUX socket connections, and ensuring all exposed wire interfaces were fully isolated by the 4.8 mm heat-shrink tubing.

**Signal Noise and Sensor Placement:** Surface Electromyography (EMG) sensors are intrinsically susceptible to noise, crosstalk from surrounding muscles, and poor skin contact. Early testing revealed highly erratic, unpredictable motor behavior if the electrodes were placed improperly. This constraint was resolved by enforcing a strict sensor placement protocol: the two measuring electrodes were aligned directly over the part of the active muscle and under the arm strap, while the reference electrode was placed on an electrically neutral, bony area near the elbow. This ensured the reference node did not inadvertently record conflicting muscle activity, thereby cleaning the baseline signal.

**Baseline Jitter and Threshold Calibration:** Even with optimized electrode placement, resting human muscles continuously produce low-level electrical noise that can cause the servomotor to constantly twitch or behave in a jittery manner. To resolve this, we utilized the Arduino IDE's Serial Plotter to visually monitor the raw analog signal during both resting and flexing states. This data allowed us to accurately calibrate a hardcoded threshold variable within our control logic. The software was refined so that the servomotor actively disengages when the signal falls below this threshold, ensuring the motor remains entirely passive and stable until a deliberate, meaningful muscle contraction is executed by the user.

During iterative development of the Simulation software, several technical constraints were identified and resolved to ensure a stable user experience:

* **Tracking Origin Constraint:** Early testing revealed a calibration issue where the virtual table appeared to float at chest height because the headset tracking origin defaulted to *Eye Level*. This was resolved by forcing the OVR Manager to use *Floor Level* tracking.
* **Physics Ghosting:** The default grab mechanics caused held objects to become *Kinematic* (ignoring the physics engine). When holding the bottle and glass, they phased through one another. This was resolved by disabling `Kinematic While Selected` and utilizing *Velocity Tracking*, forcing objects to follow hands using physical forces rather than teleportation.
* **Momentum During Reset:** Resetting a falling object simply teleported it to the table, but it retained its downward momentum and instantly shot through the virtual wood. This was corrected by refining the reset function to explicitly access each object's `Rigidbody` and set both `velocity` and `angularVelocity` to `Vector3.zero` during teleportation.
* **Exhibition Casting Constraints:** For public demonstrations and clinical supervision, mirroring the headset view to an external monitor was required. To bypass the high latency of public Wi-Fi networks, a hardwired USB-C connection utilizing the **Meta Quest Developer Hub (MQDH)** was implemented, guaranteeing high-quality, zero-latency casting.

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

[9] J. S. Lora-Millan et al.,"A Review on Wearable Technologies for Tremor Suppression," Front. Neurol., vol. 12, p. 700600, Aug. 2021.

[10] T. Endrei et al., "Learning to suppress tremors: a deep reinforcement learning-enabled soft exoskeleton for Parkinson's patients," Front. Robot. AI, vol. 12, p. 1537470, May 2025.
