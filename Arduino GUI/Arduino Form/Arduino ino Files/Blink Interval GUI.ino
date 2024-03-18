#define led_pin 8
int delayTimeInSeconds = 1; // Default delay of 1 second

void setup() {
  pinMode(led_pin, OUTPUT);
  Serial.begin(9600); // Start serial communication at 9600 baud rate
}

void loop() {
  if (Serial.available() > 0) {
    // Read the incoming value as the delay in seconds.
    delayTimeInSeconds = Serial.parseInt();
    if (delayTimeInSeconds < 1) delayTimeInSeconds = 1; // Prevents delay from being less than 1 second
    // Clear the serial buffer to ensure fresh start for the next read
    while (Serial.available() > 0) Serial.read();
  }

  // Turn the LED on, then off, and wait for the specified delay.
  digitalWrite(led_pin, HIGH); // Turn the LED on
  delay(1000); // Keep it on for 1 second
  digitalWrite(led_pin, LOW); // Turn the LED off

  // Convert seconds to milliseconds for delay.
  delay(delayTimeInSeconds * 1000);
}
