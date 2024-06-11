#include <Wire.h>
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27, 2, 1, 0, 4, 5, 6, 7, 3, POSITIVE);

const int TestLed = 8;
const int LedPin = 7;
const int ObstacleSensor = 4;  
int ledState = 0;
String receiveVal;
char d1;

void setup()  
{   
  pinMode(LedPin, OUTPUT);
  pinMode(TestLed, OUTPUT);
  pinMode(ObstacleSensor, INPUT);
  lcd.begin(16,2);
  lcd.noBacklight();
  Serial.begin(9600);    
}  
  
void loop()  
{        
  if(digitalRead(ObstacleSensor) == 0){
    digitalWrite(TestLed, HIGH);
    Serial.println("z");
  } else{
    digitalWrite(TestLed, LOW);
  }

  if(Serial.available() > 0)  
  {          
    receiveVal = Serial.readString();
    d1 = receiveVal.charAt(0);

    switch(d1){
      case 'A':
      lcd.clear();
      ledState = 1;
      lcd.backlight();
      lcd.setCursor(0, 0);     
      lcd.print("Not Armed");
      break;

      case 'a':
      ledState = 0;
      lcd.clear();
      lcd.noBacklight();
      break;

      case 'b':
      lcd.clear();
      ledState = 1;
      lcd.backlight();
      lcd.setCursor(0, 0);     
      lcd.print("Armed");
      lcd.setCursor(0, 1);
      lcd.print("Alt + F4");
      break;

      case 'c':
      lcd.clear();
      ledState = 1;
      lcd.backlight();
      lcd.setCursor(0, 0);     
      lcd.print("Armed");
      lcd.setCursor(0, 1);
      lcd.print("Alt + Tab");
      break;

      case 'd':
      lcd.clear();
      ledState = 1;
      lcd.backlight();
      lcd.setCursor(0, 0);     
      lcd.print("Armed");
      lcd.setCursor(0, 1);
      lcd.print("Desktop");
      break;

    }
  }     
      
  digitalWrite(LedPin, ledState);   

  delay(50);      
}