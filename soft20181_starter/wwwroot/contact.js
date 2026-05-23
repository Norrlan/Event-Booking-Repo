const form = document.querySelector("#contact-form");

const name_ = document.querySelector("#name");
const mail_ = document.querySelector("#mail");
const num_ = document.querySelector("#num");
const errorMessage = document.querySelector(".error-message");

$(document).ready(function () {


  $("#reload-btn").click(function () {
    $("#reload-btn").hide(5000, function () {
      alert("Button is now gone");
    });
  });
});

// Event handlers

//for form submission
form.addEventListener("submit", formSubmitted);

let contactsArray = [];

const xContacts = [
    { fname: "Ayo Kastro",mail: "ashjsbde", num: "34334" },
    {
      fname: "Tamino Hayate",
      mail: "taminohayate@ntu.ac.uk",
      num: "07402238403",
    },
    { fname: "", mail: "", num: "" },
    { fname: "         ", mail: "", num: "" },
    { fname: "1212121", mail: "", num: "" },
    { name: "......", studentId: "", mail: "", num: "" },
    {
      name: "Salisu Wada Yahaya",
      studentId: "wewewewe",
      mail: "wewewewe",
      num: "wewewewewewe",
    },
  ];

  
for(let i = 0; i < xContacts.length; i++) {
    let dataFromArray = xContacts[i];
    createDynamicContact(dataFromArray);
}


//  functions
function formSubmitted(event) {
  event.preventDefault();

  // check if the name is not empty
  if (name_.value.trim() === "") {
    name_.classList.add("invalid-input");
    errorMessage.textContent = "Please enter your full name";
    return;
  }

  // extract the data from the form
  const data = {
    name: name_.value,
    mail: mail_.value,
    num: num_.value,
  };

  // create the dynamic nodes using the data
  createDynamicContact(data);

  // append the current contact to the array of contacts
  contactsArray.push(data);

  // convert the array of contacts into a string
  let arrayString = JSON.stringify(contactsArray);

  // save the string to local storage
  localStorage.setItem("contact_app", arrayString);
}

function createDynamicContact(data) {
  const row = document.createElement("div");
  row.classList.add("row");

  const nameId = document.createElement("div");
  nameId.classList.add("name-id");

  const name = document.createElement("span");
  name.textContent = data.name;
  const id = document.createElement("span");
  id.textContent = data.studentId;

  nameId.appendChild(name);
  nameId.appendChild(id);

  const mail = document.createElement("div");
  mail.classList.add("mail");
  mail.textContent = data.mail;

  const num = document.createElement("div");
  num.classList.add("num");
  num.textContent = data.num;

  const trash = document.createElement("i");
  trash.classList.add("fa-solid", "fa-trash");

  row.appendChild(nameId);
  row.appendChild(mail);
  row.appendChild(num);
  row.appendChild(trash);

  contactArea.appendChild(row);
}

