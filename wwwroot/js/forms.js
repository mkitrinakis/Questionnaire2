function hide(id) {
    document.getElementById(id).style.display = "none";
}
function show(id) {
    document.getElementById(id).style.display = "block";
}

function enable(name) {
    var els = document.getElementsByName(name);
    for (var i = 0; i < els.length; i++) {
        var el = els[i];
        el.style.pointerEvents = "auto";
        el.style.opacity = 1;
    }
}



function disable(name) {

    var els = document.getElementsByName(name);
    for (var i = 0; i < els.length; i++) {
        var el = els[i];
        el.style.pointerEvents = "none";
        el.style.opacity = 0.5;
        el.checked = false;
    }
}


function getOptionsValue(fieldName) {
    var radios = document.getElementsByName(fieldName);

    for (var i = 0, length = radios.length; i < length; i++) {
        if (radios[i].checked) {
            // do whatever you want with the checked radio
            console.log(fieldName + " returned: " + radios[i].value);
            return (radios[i].value);
        }
    }
    console.log(fieldName + " returned: <<blank>>");
    return "";
}

function validateHidesQA() {
    var q7 = getOptionsValue("Q7");
    if (q7 == "1") { enable("Q8"); } else { disable("Q8"); }

    var q8 = getOptionsValue("Q8");
    if (q8 == "5") { show("Q8OptionsOther"); } else { hide("Q8OptionsOther"); }

    var q9 = getOptionsValue("Q9");
    if (q9 == "5") { show("Q9OptionsOther"); } else { hide("Q9OptionsOther"); }
}



function validateHidesTableOther() {
    for (var i = 0; i <= 8 ; i++)
    {
        var name = "Q101.rows[" + i + "].val"; 
        var val = getOptionsValue(name); 
        if (val == "5") { show("Q101_rows_" + i + "__detail"); } else { hide("Q101_rows_" + i + "__detail"); }
    }
    for (var i = 0; i <= 3; i++) {
        var name = "Q102.rows[" + i + "].val";
        var val = getOptionsValue(name);
        if (val == "5") { show("Q102_rows_" + i + "__detail"); } else { hide("Q102_rows_" + i + "__detail"); }
    }
    for (var i = 0; i <= 5; i++) {
        var name = "Q103.rows[" + i + "].val";
        var val = getOptionsValue(name);
        if (val == "5") { show("Q103_rows_" + i + "__detail"); } else { hide("Q103_rows_" + i + "__detail"); }
    }
    for (var i = 0; i <= 7; i++) {
        var name = "Q104.rows[" + i + "].val";
        var val = getOptionsValue(name);
        if (val == "5") { show("Q104_rows_" + i + "__detail"); } else { hide("Q104_rows_" + i + "__detail"); }
    }
    for (var i = 0; i <= 5; i++) {
        var name = "Q105.rows[" + i + "].val";
        var val = getOptionsValue(name);
        if (val == "5") { show("Q105_rows_" + i + "__detail"); } else { hide("Q105_rows_" + i + "__detail"); }
    }
    for (var i = 0; i <= 6; i++) {
        var name = "Q106.rows[" + i + "].val";
        var val = getOptionsValue(name);
        if (val == "5") { show("Q106_rows_" + i + "__detail"); } else { hide("Q106_rows_" + i + "__detail"); }
    }
    for (var i = 0; i <= 4; i++) {
        var name = "Q107.rows[" + i + "].val";
        var val = getOptionsValue(name);
        if (val == "5") { show("Q107_rows_" + i + "__detail"); } else { hide("Q107_rows_" + i + "__detail"); }
    }
    for (var i = 0; i <= 7; i++) {
        var name = "Q108.rows[" + i + "].val";
        var val = getOptionsValue(name);
        if (val == "5") { show("Q108_rows_" + i + "__detail"); } else { hide("Q108_rows_" + i + "__detail"); }
    }
}


// read mode functions
function disableAllFields() {
    console.log('in disable'); 
    var x = document.getElementById("allFields");
    x.disabled = true; 
}

function hideAllButtons() {
    var buttons = document.getElementsByClassName("btn");
    for (var i = 0; i < buttons.length; i++) {
        var button = buttons[i];
        button.style.visibility = "hidden";
    }
}



// tab functions 
function goto1() {
 
    $('.nav-tabs a[href="#Section1"]').tab('show');
 
}
function goto2() {
 
    $('.nav-tabs a[href="#Section2"]').tab('show');
 
}
function goto3() {
 
    $('.nav-tabs a[href="#Section3"]').tab('show');
 
}

function goto4() {

    $('.nav-tabs a[href="#Section4"]').tab('show');

}

function goto5() {

    $('.nav-tabs a[href="#Section5"]').tab('show');

}

function goto6() {

    $('.nav-tabs a[href="#Section6"]').tab('show');

}