var start;
var end;
var skip;
var current;

function printRange(start,end,skip){
  current = start;
    if (end === undefined){
      end = start;
      current = 0;
    }
  while (current < end){
    if(skip === undefined){
      skip = 1;
    }
    console.log(current);
    current = current + skip;
  }
}
