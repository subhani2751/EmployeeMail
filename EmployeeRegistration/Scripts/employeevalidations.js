
var obj = null;
function validations() {
    debugger;
    var Rvalue = true
    var name = document.getElementById("sName").value;
    var Phone = document.getElementById("iPhone").value;
    var dateofbirth = document.getElementById("sdateofbirth").value;
    var State = document.getElementById("sState").value;
    var City = document.getElementById("sCity").value;
    var Email = document.getElementById("sEmail").value;
    var Qualification = document.querySelector('input[name="sQualification"]:checked');
    var sHobbies = $('#sHobbies').val();

    if (name == null || name == "" || name == undefined || name == '') {
        Rvalue = false
        document.getElementById("Nameval").innerText = "Please Enter Name";
    } else {
        document.getElementById("Nameval").innerText = "";
    }
    if (Phone == null || Phone == "" || Phone == undefined || Phone == '') {
        Rvalue = false
        document.getElementById("Phoneval").innerText = "Please Phone Number";
    }
    else {
        var mobileexpresssion = /^[0-9]{10}$/;
        var stratcheck = /^[6-9]\d*$/;
        if (!mobileexpresssion.test(Number(Phone))) {
            document.getElementById("Phoneval").innerText = "please Enter valid moblie Number"
            Rvalue = false
        } else if (!mobileexpresssion.test(Number(Phone)) || !stratcheck.test(Number(Phone))) {
            document.getElementById("Phoneval").innerText = "moblie Number should be start with 7 or 8 or 9"
            Rvalue = false
        }
        else {
            document.getElementById("Phoneval").innerText = "";
        }
    }
    if (dateofbirth == null || dateofbirth == "" || dateofbirth == undefined || dateofbirth == '') {
        document.getElementById("dateofbirthval").innerText = "Date of Birth should not be Empty"
        Rvalue = false;
    }
    else {
        document.getElementById("dateofbirthval").innerText = "";
    }
    if (State == null || State == "" || State == undefined || State == '') {
        Rvalue = false
        document.getElementById("Stateval").innerText = "State should not be Empty";
    } else {
        document.getElementById("Stateval").innerText = "";
        if (City == null || City == "" || City == undefined || City == '' || City == '0') {
            Rvalue = false
            document.getElementById("Cityval").innerText = "City should not be Empty";
        } else {
            document.getElementById("Cityval").innerText = "";
        }
    }
    //if (City == null || City == "" || City == undefined || City == '' || City=='0') {
    //    Rvalue = false
    //    document.getElementById("Stateval").innerText = "State should not be Empty";
    //} else {
    //    document.getElementById("Stateval").innerText = "";
    //}
    if (Email == null || Email == "" || Email == undefined || Email == '') {
        Rvalue = false
        document.getElementById("Emailval").innerText = "Email should not be Empty";
    }
    else {
        var mobileexpresssion = /^[a-zA-Z0-9._%+-@]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        if (!mobileexpresssion.test(Email)) {
            document.getElementById("Emailval").innerText = "please Enter valid  Email"
            Rvalue = false
        }
        else {
            document.getElementById("Emailval").innerText = "";
        }
    }
    if (Qualification == null || Qualification == "" || Qualification == undefined || Qualification == '') {
        document.getElementById("Qualificationval").innerText = "Please Select Qualification"
        Rvalue = false;
    }
    else {
        document.getElementById("Qualificationval").innerText = "";
    }
    if (sHobbies.length == 0 ) {
        Rvalue = false
        document.getElementById("Hobbiesval").innerText = "Hobbies should not be Empty";
    } else {
        document.getElementById("Hobbiesval").innerText = "";
    }
    if (Rvalue) {
        obj = null;
        let Qualification_val = Qualification.value;
        let sHobbiesval = "";
        if (sHobbies.length > 0) {
            sHobbies.forEach(element =>
                sHobbiesval = sHobbiesval + element + ',')
        }
        sHobbiesval=sHobbiesval.slice(0, sHobbiesval.length - 1)
        obj = {
            sName: name,
            iPhone: Phone,
            sEmail: Email,
            sdateofbirth: dateofbirth,
            sCity: City,
            sState: State,
            sHobbies: sHobbiesval,
            sQualification: Qualification_val,
        };
        return Rvalue;
    } else { return false; }
    
}


$(document).ready(function () {
    $('.datepicker').datepicker({
        dateFormat: 'dd-mm-yy', // Set your desired date format 'yy-mm-dd'
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        yearRange: "-100:+0" // Set the range of selectable years
    });

    $('#calendarIcon').click(function () {
        $('.datepicker').datepicker('show');
    });
    $('#sHobbies').SumoSelect({
        placeholder: 'This is a placeholder',
        selectAll: true,
        csvDispCount: 10,
        search: true,
    });
    $('#EMPgrid').dataTable({
        paginate: true,
        scrollY: 300
});
    //$('#sHobbies').select2({
    //    //placeholder: '--Select any State--',
    //    multiple: true,
    //    width: 'resolve',
    //});
    //$('.multiselect').multiselect({
    //    includeSelectAllOption: true
    //});
});

$('#sState').change(function () {
    debugger;
    var stateid = $(this).val();
    $.ajax({
        url: 'EMP/GetCities',  //'@Url.Action("GetCities", "EMP")'
        type: 'Post',
        // datatype:"json",
        data: { stateid: stateid },// "stateid=" + stateid,//JSON.stringify({ stateid: stateid }),
        success: function (cities) {
            var sCitydropdown = $('#sCity');
            sCitydropdown.empty();
            sCitydropdown.append("<option value='0'>--Select any City--</option>");
            $.each(cities, function (index, city) {
                debugger;
                sCitydropdown.append("<option value='" + city.Value + "'>" + city.Text + "</option>");
                //sCitydropdown.append($('<option>', { value: city.value, Text: city.Text }));
            });
        },
        error: function (error) {
            console.error('Error fetching cities:', error);
        }
    });
});

function SaveEmp() {
    if (validations()) {
        debugger;
        if (obj != null) {
            $.ajax({
                url: 'EMP/EmpSave',  //'@Url.Action("GetCities", "EMP")'
                type: 'Post',
                // datatype:"json",
                data: obj,// "stateid=" + stateid,//JSON.stringify({ stateid: stateid }),
                success: function (data) {
                    var EMPgrid = $('#EMPgrid');
                    $.each(data, function (index, record) {
                        var options = { year: 'numeric', month: '2-digit', day: '2-digit' };
                        record.sdateofbirth=new Date(parseInt(record.sdateofbirth.match(/\d+/)[0])).toLocaleDateString(undefined, options).replace(/\//g, '-');
                        var emplty = '<tr id="EMPgridtr"> <td id="EMPgridtd">' + record.sName + '</td><td id="EMPgridtd">' + record.iPhone + '</td>';
                        emplty += '<td id="EMPgridtd" >' + record.sdateofbirth + '</td><td id="EMPgridtd">' + record.sState + '</td>';
                        emplty += '<td id="EMPgridtd" >' + record.sCity + '</td><td id="EMPgridtd">' + record.sEmail + '</td>';
                        emplty += '<td id="EMPgridtd" >' + record.sHobbies + '</td><td id="EMPgridtd" > ' + record.sQualification + '</td >';
                        emplty += '<td id="EMPgridtd"><a href = "/Emp/Delete/' + record.iMasteriD + '" > Delete</a> | <a href = "/Emp/Edit/' + record.iMasteriD + '" > Edit</a></td></tr>';
                        EMPgrid.append(emplty);
                    });
                    $('#sName').val('');
                    $('#iPhone').val('');
                    $('#sdateofbirth').val('');
                    $('#sState').val('');
                    $('#sCity').val('');
                    $('#sEmail').val('');
                    // Clear ListBox selection, if needed
                    //$('#sHobbies').SumoSelect();
                    $('#sHobbies')[0].sumo.unSelectAll();
                    // Assuming sHobbies is the ID of the ListBox
                    // Clear radio button selection, if needed
                    $('input[name="sQualification"]').prop('checked', false);
                },
                error: function (error) {
                    console.error('Error fetching cities:', error);
                }
            });
        }
    }
}