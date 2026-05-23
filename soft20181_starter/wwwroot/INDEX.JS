//function to toggle the responsive class for top nav
function myFunction() {
   // Get the HTML element with the ID "myTopnav" and assign it to the variable x
  var x = document.getElementById("myTopnav");
  
  // Check if the class name of the element is currently "topnav"
  if (x.className === "topnav") {
    // If it is, append the "responsive" class to the element's class list
    x.className += " responsive";
  } else {
     // If it's not, set the class name to "topnav"
    x.className = "topnav";
  }
}
// For font-size:
// I want to change h3 as well
// I want to change tag p
// I want to change tag h4
// I want to change tag h2 
// I want to change price h2 style for gallery box
// I want to change price div class shapes p 


document.addEventListener("DOMContentLoaded", function () {
  // Check if preferences are stored in Local Storage
  const storedFontSize = localStorage.getItem("fontSize") || "30px";
  const storedBgColor = localStorage.getItem("bgColor") || "#808080"; // Updated default body background color for dark mode
  const storedTextColor = localStorage.getItem("textColor") || "#ccc"; // Default text color for dark mode
  const storedNavColor = localStorage.getItem("navColor") || "rgb(217, 129, 15)"; // Updated default topnav background color for dark mode

  // Apply stored preferences or defaults
  document.body.style.backgroundColor = storedBgColor;
  document.body.style.color = storedTextColor;
  document.getElementById("myTopnav").style.backgroundColor = storedNavColor;

  // Set initial font size for header elements
  setFontSize(storedFontSize);

  // Handle user interaction to change preferences
 

  
   
  document.querySelector(".fa-moon").addEventListener("click", function () {
    // Switch to dark mode
    changeColor("#333", "#ccc", "rgb(217, 129, 15)"); // Update body background color, text color, and topnav background color
  });

  document.querySelector(".fa-sun").addEventListener("click", function () {
   // Switch to light mode
   changeColor("#808080", "333", "#808080"); // Update body background color and topnav text color
  });
  document.querySelector(".fa-plus").addEventListener("click", function () {
    // Increase font size
    changeFontSize(5);
  });

  document.querySelector(".fa-minus").addEventListener("click", function () {
    // Decrease font size
    changeFontSize(-2);
  });

  // Function to change font size
  function changeFontSize(change) {
    const currentSize = parseInt(getComputedStyle(document.body).fontSize);
    const newSize = currentSize + change;
    setFontSize(newSize + "px");
    // Save preference to Local Storage
    localStorage.setItem("fontSize", newSize + "px");
  }

  // Function to set font size for header elements
  function setFontSize(fontSize) {
    document.querySelectorAll("h1, h2, h3, h4, p").forEach((header) => {
      header.style.fontSize = fontSize;
    });
  }

  // Function to change background color and text color
  function changeColor(bgColor, textColor, navColor) {
    document.body.style.backgroundColor = bgColor;
    document.body.style.color = textColor;
    document.getElementById("myTopnav").style.backgroundColor = navColor;
    // Save preferences to Local Storage
    localStorage.setItem("bgColor", bgColor);
    localStorage.setItem("textColor", textColor);
    localStorage.setItem("navColor", navColor);
  }
}
);
