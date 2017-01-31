var arr = ["James", "Jill", "Jane", "Jack"]
var reversed = false;
var i;
var pointer;

function logarray(arr,pointer,reversed){
  if (pointer === undefined){
    pointer = "->"
  }
  if (reversed === true){
    for(i = arr.length-1; i>-1; i--){
      console.log(i+" "+pointer+" "+arr[i])
    }
  }
  else{
    for(i = 0; i<arr.length; i++){
      console.log(i+" "+pointer+" "+arr[i])
    }
  }
}
