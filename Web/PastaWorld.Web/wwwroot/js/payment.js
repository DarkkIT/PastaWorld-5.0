// Payment form login/client info 
let anchorGuest = document.getElementById('guest');
let anchorClient = document.getElementById('client');

let guestElements = document.getElementsByClassName('guest');
let loginElements = document.getElementsByClassName('login');

let displayNone = 'none';
let displayAll = '';

setDisplayProperty(loginElements, displayNone);
let blackColor = "rgb(25 25 25)";
let blueColor = "rgb(3 102 214)";
let bold = 'bold';
let normal = 'normal';

anchorGuest.style['color'] = blackColor;
anchorGuest.style['fontWeight'] = bold;

anchorGuest.addEventListener('click',
    function (event) {
        event.preventDefault();
        anchorGuest.style['color'] = blackColor;
        anchorClient.style['color'] = blueColor;

        anchorGuest.style['fontWeight'] = bold;
        anchorClient.style['fontWeight'] = normal;

        setDisplayProperty(guestElements, displayAll);
        setDisplayProperty(loginElements, displayNone);
    });

anchorClient.addEventListener('click',
    function (event) {
        event.preventDefault();
        anchorClient.style['color'] = blackColor;
        anchorGuest.style['color'] = blueColor;

        anchorClient.style['fontWeight'] = bold;
        anchorGuest.style['fontWeight'] = normal;

        setDisplayProperty(guestElements, displayNone);
        setDisplayProperty(loginElements, displayAll);
    }
);

function setDisplayProperty(elements, display) {
    for (var i = 0; i < elements.length; i++) {
        elements[i].style['display'] = display;
    }

    return elements;
}

// Payment form delievery fields
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
