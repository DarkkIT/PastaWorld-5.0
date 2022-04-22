// Payment form login/client info 
let anchorGuest = document.getElementById('guest');
let anchorClient = document.getElementById('client');

let guestElements = document.getElementsByClassName('guest');
let loginElements = document.getElementsByClassName('login');

let displayNone = 'none';
let displayAll = '';

anchorGuest.classList.add('clicked');
setDisplayProperty(loginElements, displayNone);

anchorGuest.addEventListener('click',
    function (event) {
        event.preventDefault();
        setElementsClass(anchorGuest, anchorClient);

        setDisplayProperty(guestElements, displayAll);
        setDisplayProperty(loginElements, displayNone);
    });

//anchorClient.addEventListener('click',
//    function (event) {
//        event.preventDefault();
//        setElementsClass(anchorClient, anchorGuest);

//        setDisplayProperty(loginElements, displayAll);
//        setDisplayProperty(guestElements, displayNone);
//    }
//);

function setElementsClass(firstElement, secondElement) {
    if (!firstElement.classList.contains('clicked')) {
        firstElement.classList.add('clicked');
        secondElement.classList.remove('clicked');
    } else {
        firstElement.classList.remove('clicked');
    }
}


function setDisplayProperty(elements, display) {
    for (var i = 0; i < elements.length; i++) {
        elements[i].style['display'] = display;
    }

    return elements;
}

// Payment form delivery fields
let toAddress = 'Доставка до адрес';
let toRestaurant = 'В наш ресторант';

let addressFields = document.getElementsByClassName('address-none');

let checkboxElements = document.getElementsByClassName('user-address');

for (let i = 0; i < checkboxElements.length; i++) {
    let element = checkboxElements[i];

    element.addEventListener('click',
        function (event) {
            for (var y = 0; y < addressFields.length; y++) {

                if (element.checked && element.value === toAddress) {
                    addressFields[y].style['display'] = '';
                } else if (element.checked && element.value === toRestaurant) {
                    addressFields[y].style['display'] = 'none';
                }
            }
        }
    );
}

//
let anchorToggle = document.getElementById('product-toggle');
let angleDown = document.createElement('i');
angleDown.className = 'fa-solid fa-angle-down';

let expandableElements = document.getElementById('expandable');
expandableElements.style['display'] = 'none';

anchorToggle.addEventListener('click',
    function (event) {
        let icon = anchorToggle.getElementsByTagName('i')[0];

        if (icon.style['display'] === 'none') {
            icon.style['display'] = '';
            angleDown.style['display'] = 'none';

            expandableElements.style['display'] = 'none';
        } else {
            anchorToggle.appendChild(angleDown);
            icon.style['display'] = 'none';
            angleDown.style['display'] = '';

            expandableElements.style['display'] = '';
        }
    }
);

//Errors
//let submitButton = document.getElementById('submit');


//submitButton.addEventListener('click',
//    function (event) {
//        event.preventDefault();
//        let form = document.getElementById('form');
//        let formData = new FormData(form);
//        let isAgreedField = formData.get('IsAgreedTermsAndConditions');

//        let hasError = false;

//        let isGuestClicked = anchorGuest.classList.contains('clicked');

//        if (isGuestClicked) {
//            let firstName = formData.get('FirstName');
//            let familyName = formData.get('FamilyName');
//            let phoneNumber = formData.get('PhoneNumber');
//            let email = formData.get('Email');

//            hasError = guestFieldsError(firstName, familyName, phoneNumber, email);
//        }

//        let isUserAddress = formData.get('UserOrOtherAddress');

//        if (isUserAddress) {
//            let address = formData.get('Address');
//            let addressDiv = document.getElementById('address');
//            errorMessage = 'Моля, попълнете адрес!';
//            hasError = errorProcessing(address, addressDiv, errorMessage);
//        }

//        hasError = termsAndConditionsError(isAgreedField);
//        debugger;
//        if (hasError) {
//            return;
//        }


//        var request;
//        if (window.XMLHttpRequest) {
//            //New browsers.
//            request = new XMLHttpRequest();
//        } else if(window.ActiveXObject) {
//            //Old IE Browsers.
//            request = new ActiveXObject("Microsoft.XMLHTTP");
//        }

//        //window.location.href = Url.Action("PostData", "Payment", "asd");

//        //if (request != null) {
//        //    var url = "/Payment/PostData";
//        //    request.open("POST", url, false);
//        //    request.setRequestHeader("Content-Type", "application/json");
//        //    request.onreadystatechange = function () {
//        //        if (request.readyState == 4 && request.status == 200) {
//        //            var response = JSON.parse(request.responseText);
//        //            alert("Hello: " + response.Name + ".\nCurrent Date and Time: " + response.DateTime);
//        //        }
//        //    };
//        //    request.send(JSON.stringify('EMo'));
//        //}




//        //var xhr = new XMLHttpRequest();
//        //xhr.open("POST", '/Payment/PostData', true);

//        //xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
//        //xhr.send(formData);

//        //xhr.onreadystatechange = function () { // Call a function when the state changes.
//        //    if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
//        //        // Request finished. Do processing here.
//        //    }
//        //}
//    });

//function guestFieldsError(firstName, familyName, phoneNumber, email) {
//    let errorMessage = '';
//    let nameDiv = document.getElementById('name');
//    let familyNameDiv = document.getElementById('lastName');
//    let phoneNumberDiv = document.getElementById('phone');
//    let emailDiv = document.getElementById('email');

//    let errorResult = false;

//    errorMessage = 'Моля, попълнете полето за собствено име!';
//    errorResult = errorProcessing(firstName, nameDiv, errorMessage);

//    errorMessage = 'Моля, попълнете полето за фамилно име!';
//    errorResult = errorProcessing(familyName, familyNameDiv, errorMessage);

//    errorMessage = 'Моля, попълнете полето за телефон за връзка!';
//    errorResult = errorProcessing(phoneNumber, phoneNumberDiv, errorMessage);

//    errorMessage = 'Моля, попълнете полето за email!';
//    errorResult = errorProcessing(email, emailDiv, errorMessage);

//    if (errorResult) {
//        return true;
//    }
//}

//function errorProcessing(fieldData, fieldDiv, errorMessage) {
//    if (!fieldData) {
//        fieldError(fieldDiv, errorMessage);
//        return true;
//    } else {
//        fieldError(fieldDiv, errorMessage, fieldData);
//    }
//}

//function fieldError(field, errorMessage, fieldData) {
//    let spanErrorElements = field.getElementsByClassName('error');
//    let firstErrorElement = spanErrorElements[0];

//    if (fieldData && firstErrorElement) {
//        firstErrorElement.remove();
//        return;
//    }

//    if (fieldData) {
//        return;
//    }

//    if (firstErrorElement) {
//        return;
//    }

//    var spanErr = document.createElement('p');
//    spanErr.innerText = errorMessage;
//    spanErr.style['color'] = 'red';
//    spanErr.className = 'error';
//    field.appendChild(spanErr);
//}

//var spanErr = document.createElement('p');

//function termsAndConditionsError(isAgreedField) {
//    let termsDiv = document.getElementById('terms-and-conditions');

//    if (isAgreedField === 'false') {
//        spanErr.innerText = 'Моля, съгласете се с Условията за ползване на сайта!';
//        spanErr.style['color'] = 'red';
//        spanErr.id = 'error';
//        termsDiv.appendChild(spanErr);
//        return true;
//    } else {
//        let error = document.getElementById('error');

//        if (error) {
//            error.innerText = '';
//        }
//    }
//}


