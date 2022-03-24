let anchorGuest = document.getElementById('guest');
let anchorClient = document.getElementById('client');

let guestElements = document.getElementsByClassName('guest');
let loginElements = document.getElementsByClassName('login');

for (var i = 0; i < loginElements.length; i++) {
    loginElements[i].style['display'] = 'none';
}

anchorGuest.style['color'] = "rgb(232 232 232)";

anchorGuest.addEventListener('click',
    function (event) {
        event.preventDefault();
        anchorGuest.style['color'] = "rgb(232 232 232)";
        anchorClient.style['color'] = "rgb(3 102 214)";

        for (var i = 0; i < guestElements.length; i++) {
            guestElements[i].style['display'] = '';
        }

        for (var i = 0; i < loginElements.length; i++) {
            loginElements[i].style['display'] = 'none';
        }
    });

anchorClient.addEventListener('click',
    function (event) {
        event.preventDefault();
        anchorClient.style['color'] = "rgb(232 232 232)";
        anchorGuest.style['color'] = "rgb(3 102 214)";

        for (var i = 0; i < guestElements.length; i++) {
            guestElements[i].style['display'] = 'none';
        }

        for (var i = 0; i < loginElements.length; i++) {
            loginElements[i].style['display'] = '';
        }
    });
