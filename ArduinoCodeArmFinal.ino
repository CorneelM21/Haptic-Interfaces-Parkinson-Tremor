#include <Servo.h>

Servo exoServo; 

// --- PINS ---
int servoAnalogInPin = A3; 
int emgAnalogInPin = A1;   
int servoControlPin = 3;   

int posIs;
int emgIs;
float posIsDeg;

// --- CALIBRATION VALUES ---
float rawAtZero = 187.0;   
float rawAtTarget = 370.0; 
float targetAngle = 90.0;  
float scaleFactor; 

// --- DYNAMIC EMG VARIABLES ---
int emgBaseline = 0;
int emgThreshold = 0;

// --- STATE MACHINE VARIABLES ---
float lockedPosDeg = 0.0;
bool isMoving = false; // Tracks whether the clutch is engaged

void setup() {
  Serial.begin(9600);
  
  scaleFactor = targetAngle / (rawAtTarget - rawAtZero);
  
  // Read initial position so we can lock it immediately on startup
  posIs = analogRead(servoAnalogInPin);
  lockedPosDeg = scaleFactor * (posIs - rawAtZero);
  
  // Constrain the startup angle to prevent violent snapping
  lockedPosDeg = constrain(lockedPosDeg, 0, 180);
  
  exoServo.attach(servoControlPin); 
  exoServo.write(lockedPosDeg);
  
  // --- EMG AUTO-CALIBRATION SEQUENCE ---
  Serial.println("Calibrating EMG... DO NOT MOVE OR FLEX!");
  long emgSum = 0;
  
  // Take 100 readings over 2 seconds to find the true resting baseline
  for(int i = 0; i < 100; i++) {
    emgSum += analogRead(emgAnalogInPin);
    delay(20); 
  }
  
  emgBaseline = emgSum / 100;
  
  // Set the threshold 85 points above the resting baseline
  emgThreshold = emgBaseline + 85; 
  
  Serial.print("Calibration Complete. Baseline: ");
  Serial.print(emgBaseline);
  Serial.print(" | Active Threshold: ");
  Serial.println(emgThreshold);
  
  delay(1000); // Brief pause so you can read the output
}

void loop() {
  // 1. READ SENSORS
  posIs = analogRead(servoAnalogInPin); 
  emgIs = analogRead(emgAnalogInPin); 
  posIsDeg = scaleFactor * (posIs - rawAtZero);
  
  // 2. STATE MACHINE LOGIC (Using dynamic threshold)
  if (emgIs > emgThreshold) {
      
      // --- STATE 1: INTENT TO MOVE ---
      if (!isMoving) {
        exoServo.detach(); // Press the clutch: cut power to the motor
        isMoving = true;
      }
      
      // Silently track the arm as the human moves it
      lockedPosDeg = posIsDeg;
      
  } else {
      
      // --- STATE 2: HOLD AGAINST TREMOR ---
      if (isMoving) {
        // Protect the servo from negative or out-of-bounds angles
        lockedPosDeg = constrain(lockedPosDeg, 0, 180);
        
        exoServo.attach(servoControlPin); // Release the clutch: turn motor back on
        exoServo.write(lockedPosDeg);     // Command it to hold the new spot
        isMoving = false;
      }
      
      // Notice there is no update to lockedPosDeg here. 
      // It stays frozen at the exact position you left it.
  }

  // --- DEBUGGING OUTPUT ---
  Serial.print("ActualAngle:");
  Serial.print(posIsDeg);
  Serial.print(", LockedTarget:");
  Serial.print(lockedPosDeg);
  Serial.print(", EMG:");
  Serial.print(emgIs);
  Serial.print(", Threshold:");
  Serial.println(emgThreshold);
  
  delay(20); 
}