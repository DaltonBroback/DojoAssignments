var HOUR = 8;
var MINUTE = 50;
var PERIOD = "AM";
var DAYTIME;
var DESCRIPTOR;

function clock(HOUR, MINUTE, PERIOD){
if(PERIOD == "AM"){
  DAYTIME ='in the morning';
}
else{
  if(HOUR < 5){
    DAYTIME = "in the afternoon"
  }
  else if (HOUR > 7) {
    DAYTIME = "at night"
  }
  else{
    DAYTIME ='in the evening';
  }
}

if (HOUR == 12){
  DAYTIME = "";
  if (PERIOD == "AM"){
    HOUR = "Midnight"
  }
  else{
  HOUR = "noon";
  }
}
if(MINUTE === 0){
  DESCRIPTOR = "It's";
}
else if(MINUTE < 6){
  DESCRIPTOR = "It's five after";
}
else if (MINUTE < 15){
  DESCRIPTOR = "It's just after";
}
else if (MINUTE < 30){
  DESCRIPTOR = "It's a quarter after";
}
else if (MINUTE < 45){
  DESCRIPTOR = "It's half past";
}
else{
  HOUR = HOUR + 1;
  DESCRIPTOR = "It's almost";
}

console.log(DESCRIPTOR,HOUR,DAYTIME);
}
clock(12,0,"PM");
