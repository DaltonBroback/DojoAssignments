var days=1;
var maxdays;
var money=0.1;
var maxmoney;

function finalreward(maxdays){
  while(days<maxdays){
    money *= 2;
    days += 1
    }
  console.log(money+"dollars");
}

function finalgoal(maxmoney){
  while(money<maxmoney){
    money *= 2;
    days += 1
  }
  console.log(money+"dollars");
  console.log(days+"days");
}

function counting(maxdays){
  while(days<maxdays){
    money *= 2;
    console.log(money+"dollars");
    days += 1
    }
  console.log(money+"dollars");
}
