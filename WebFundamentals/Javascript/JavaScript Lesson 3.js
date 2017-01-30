var daysUntilMyBirthday = 60;
var x;
while (daysUntilMyBirthday > 0){
  if (daysUntilMyBirthday > 30){
    x = " days until my birthday. I hate waiting... =("
  }
  else if (daysUntilMyBirthday > 5){
    x = " days until my birthday! Almost there~"
  }
  else if(daysUntilMyBirthday > 1){
    x = " DAYS UNTIL MY BIRTHDAY! =)"
  }
  else {
    x =  " DAY UNTIL MY BIRTHDAY!!! =D"
  }
  console.log(daysUntilMyBirthday+x);
  daysUntilMyBirthday = daysUntilMyBirthday - 1
}
 console.log("IT'S PARTY TIME WOOHOOOOOOO!!!!!!!!!!!!!!!!");
