#include <SoftwareSerial.h>// 시리얼 라이브러리 임포트

SoftwareSerial mySerial(3,2); //RX, TX 블루투스 모듈 핀 번호 설정

int analogInput[6] = {A0, A1, A2, A3, A4, A5};
int value[6] = {0, 0, 0, 0, 0, 0};  
int EMG ;

void setup()
{
  Serial.begin(9600);
  mySerial.begin(9600);
  for(int i=0;i<6;i++)
  pinMode(analogInput[i], INPUT);
}

void loop() 
{ 
  EMG = analogRead(analogInput[0]);
  // 데이터 받기(유니티 -> 아두이노 -> 시리얼 모니터)
  
  if (mySerial.available()) 
  { 
    Serial.write(mySerial.read()); //시리얼모니터에 데이터를 출력
  }
  
  int a = EMG - 250;
    if(a <= 0)
    {
      a = 0;
    }
    else
    {
      mySerial.println(a);
      mySerial.write(Serial.read());
    }
  
  // 데이터 보내기(시리얼 모니터 -> 아두이노 -> 유니티)
  // mySerial 블루투스 통신
  // Serial 시리얼 모니터 통신
}
