// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#CreateCustomer').on('click',

    (event) => {
        let FirstName = $('#FirstName').val();
        let LastName = $('#LastName').val();
        let Address = $('#Address').val();
        let Email = $('#Email').val();
        let Username = $('#Username').val();
        let Password = $('#Password').val();
        let RegistrationDate = $('#RegistrationDate').val();
         
        let data = JSON.stringify({
            FirstName: FirstName,
            LastName: LastName,
            Address: Address,
            Email: Email,
            Username: Username,
            Password: Password,
            RegistrationDate: RegistrationDate 
        });

        console.log(data)

        $.ajax({
            url: `/api/Customers1`,
            method: 'POST',
            contentType: 'application/json',
            data: data
        }).done(response => {

            console.log(response);

            console.log('The registration was  successful');
            $('#responseDiv').html('The registration was  successful');
            alert('The registration was  successful')
            window.open('/customers/index', '_self');

        }).fail(failure => {

            $('#responseDiv').html('Error in the communication')
        }).always(response => {
            console.log(response);
        });




    }
);



function loadCustomers() {

    $.ajax({
        url: `/api/Customers1/optionCustomer`,
        method: 'GET',
        contentType: 'application/json'
    }).done(response => {

        let divText= "<ul>"
        response.forEach(function (item) {
             divText = divText + "<li>" + item.firstName + "</li>"
        } )
        divText = divText + "</ul>"
      
        $('#CustomersContent').html(divText)
    }).fail(failure => {

        $('#CustomersContent').html('Error in the communication')
    }).always(response => {
        console.log(response);
    });
}


