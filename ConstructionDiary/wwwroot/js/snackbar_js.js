$( document ).ready(function() {
myFunction();
});

var myFunction = function myFunction() {
 $.ajax({url: "/Home/CheckForPasswordReset", success: function(result){
        if(result)
            displaySnackBar();
    }});

    
}

var displaySnackBar = function(){
// Get the snackbar DIV
    var x = document.getElementById("snackbar")
    // Add the "show" class to DIV
    x.className = "show";
    // After 3 seconds, remove the show class from DIV
    setTimeout(function(){ x.className = x.className.replace("show", ""); }, 4000);
};