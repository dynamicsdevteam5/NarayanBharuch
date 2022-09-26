$(document).ready(function () {
    var id = document.getElementsByClassName('CheckActive1');
    if (id != undefined && id.length > 0) {
        var newid = id;
        SetActiveMenu(newid[0].id);
    }

    $("#select-all").on("click", function () {
        var all = $(this);
        $('input:checkbox').each(function () {
            $(this).prop("checked", all.prop("checked"));
        });
    });

    $("#select-all-address").on("click", function () {
        var all = $(this);
        $('input:checkbox').each(function () {
            $(this).prop("checked", all.prop("checked"));
        });
    });

    // remover space
    $("input").on('blur', function () {
        $(this).val($(this).val().trim());
    });
    $("textarea").on('blur', function () {
        $(this).val($(this).val().trim());
    });

    //set default img if img not found
    $("img").error(function () {
        $(this).unbind("error").attr("src", "/Areas/Admin/Content/images/notavailable.png");
    });

    //add numeric class for number validation 
    $('.numeric').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });

    //Disable paste
    $(".numeric").bind("paste", function (e) {
        e.preventDefault();
    });

    //called when key is pressed in textbox
    $(".numeric").bind('keypress', function (e) {
        if ((this.value === "" || parseInt(this.value) === 0) && (e.which === 48 || e.which === 8)) {
            this.value = "";
            return false;
        }

        //if the letter is not digit then display error and don't type anything
        if (e.which !== 8 && e.which !== 0 && (e.which < 48 || e.which > 57)) {
            //display error message
            return false;
        }
        return true;
    });

    $(".numeric").bind('keyup', function (e) {
        if ((this.value === "" || parseInt(this.value) === 0) && (e.which === 48 || e.which === 8)) {
            this.value = "";
            return false;
        }
        return true;
    });

    // allow decimal input only
    $(".decimal").on("keypress keyup blur", function (event) {
        $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
        if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    });

    //add numeric class for number validation 
    $('.numericSpeed').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });

    //Disable paste
    $(".numericSpeed").bind("paste", function (e) {
        e.preventDefault();
    });

    //called when key is pressed in textbox
    $(".numericSpeed").bind('keypress', function (e) {
        if (e.which !== 8 && e.which !== 0 && (e.which < 47 || e.which > 57)) {
            return false;
        }
        return true;
    });

    //Disable paste
    $(".floats").bind("paste", function (e) {
        e.preventDefault();
    });

    $(".floats").bind('keyup', function (e) {
        if (this.value === "" && e.which === 46) {
            this.value = "";
            return false;
        }
        if (!CheckDecimal(this)) {
            this.value = "";
        }
        return true;
    });

});


// while partial view bind with ajax
$(document).ajaxStop(function () {
    // remover space
    $("input").on('blur', function () {
        $(this).val($(this).val().trim());
    });
    $("textarea").on('blur', function () {
        $(this).val($(this).val().trim());
    });

    //set default img if img not found
    $("img").error(function () {
        $(this).unbind("error").attr("src", "/Areas/Admin/Content/images/notavailable.png");
    });

    //add numeric class for number validation 
    $('.numeric').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });

    //Disable paste
    $(".numeric").bind("paste", function (e) {
        e.preventDefault();
    });

    $(".numeric").bind('keypress', function (e) {
        if (this.value === "" && (e.which === 48 || e.which === 8)) {
            this.value = "";
            return false;
        }

        //if the letter is not digit then display error and don't type anything
        if (e.which !== 8 && e.which !== 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
        return true;
    });

    $(".numeric").bind('keyup', function (e) {
        if ((this.value === "" || parseInt(this.value) === 0) && (e.which === 48 || e.which === 8)) {
            this.value = "";
            return false;
        }
        return true;
    });

    $('.numeric').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });

    // allow decimal input only
    $(".decimal").on("keypress keyup blur", function (event) {
        $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
        if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    });

    //Disable paste
    $(".floats").bind("paste", function (e) {
        e.preventDefault();
    });

    $(".floats").bind('keyup', function (e) {
        if (this.value === "" && e.which === 46) {
            this.value = "";
            return false;
        }

        if (!CheckDecimal(this)) {
            this.value = "";
        }
        return true;
    });

    //firstly unbind click
    $(".collapse-link").unbind("click");
    $('.collapse-link').on('click', function () {
        var ibox = $(this).closest('div.ibox');
        var button = $(this).find('i');
        var content = ibox.find('div.ibox-content');
        content.slideToggle(200);
        button.toggleClass('fa-chevron-up').toggleClass('fa-chevron-down');
        ibox.toggleClass('').toggleClass('border-bottom');
        setTimeout(function () {
            ibox.resize();
            ibox.find('[id^=map-]').resize();
        }, 50);
    });
});

function CheckDecimal(inputtxt) {
    var negativeNumber = /^[-0-9]\d*(\.\d+)?$/;

    if (inputtxt.value.length > 0) {
        if ($.isNumeric(inputtxt.value)) {
            return true;
        } else if (inputtxt.value.match(negativeNumber)) {
            return true;
        } else {
            return false;
        }
    } else { return true; }
}

function SetActiveMenu(id) {
    var lilist = document.getElementsByClassName('Lilist');
    var i;
    for (i = 0; i < lilist.length; i++) {
        $('#P_' + lilist[i].id).removeClass('active');
    }

    if (id.indexOf("+") > -1) {
        var sublist = document.getElementsByClassName('SubLiList');
        for (i = 0; i < sublist.length; i++) {
            $('#P_' + sublist[i].id).removeClass('active');
        }

        var parts = [];
        parts = id.split("+");
        for (i = 0; i < parts.length; i++) {
            if (document.getElementById('P_' + parts[i]) != null) {
                $('#P_' + parts[i]).removeClass('active');
                $('#P_' + parts[i]).addClass('active');
            }
        }

        //sublist1
        if (id.indexOf("/") > -1) {
            var sublist1 = document.getElementsByClassName('SubLilist1');
            for (i = 0; i < sublist1.length; i++) {
                $('#P_' + sublist1[i].id).removeClass('active');
            }
            parts = [];
            parts = id.split("+");
            for (i = 0; i < parts.length; i++) {
                if (document.getElementById('P_' + parts[i]) != null) {
                    $('#P_' + parts[i]).removeClass('active');
                    $('#P_' + parts[i]).addClass('active');
                }
            }
            var parts1 = [];
            parts1 = parts[1].split("/");
            for (i = 0; i < parts1.length; i++) {
                if (document.getElementById('P_' + parts1[i]) != null) {
                    $('#P_' + parts1[i]).removeClass('active');
                    $('#P_' + parts1[i]).addClass('active');
                }
            }
        }
    }
    else {
        $('#P_' + id).removeClass('active');
        $('#P_' + id).addClass('active');
    }
}

function Onsuccess() {
    var msg = document.getElementById('SuccessMessage').value;
    var errmsg = document.getElementById('ErrorMessage').value;
    if (msg !== "" && msg != null) {
        ShowSuccess(msg);
    }
    else if (errmsg !== "" && errmsg != null) {
        ShowError(errmsg);
    }
}

function fnReset() {

    $('select option[value=""]').attr("selected", true);

    var ele = document.getElementsByClassName('form-validate');
    $("input[type=hidden]").each(function () {
        $(this).val('');
    });

    $('input.form-control').val('');
    $('textarea.form-control').val('');

    var errorlab = document.getElementsByClassName('label1');
    var i;
    for (i = 0; i < errorlab.length; i++) {
        errorlab[i].textContent = "";
    }

    for (i = 0; i < ele.length; i++) {
        if (ele[i].tagName === 'INPUT') {
            ele[i].value = '';
            if (ele[i].type === 'file') {
                ele[i].defaultValue = '';
            }
            if (ele[i].type === 'checkbox') {
                ele[i].checked = false;
            }
        }
        else if (ele[i].tagName === 'TEXTAREA') {

            $(ele[i]).empty();
            $(ele[i]).val('');
            if (typeof window.CKEDITOR != "undefined") {
                for (window.instance in window.CKEDITOR.instances) {
                    if (window.CKEDITOR.instances.hasOwnProperty(window.instance)) {
                        // CKEDITOR.instances[instance].updateElement();
                        window.CKEDITOR.instances[window.instance].setData('');
                    }
                }
            }
        }
        else if (ele[i].tagName === 'LABEL') {
            $('#' + ele[i].id).empty();
            if (document.getElementById(ele[i].id)) {
                document.getElementById(ele[i].id).innerHTML = "";
            }
        }

        else if (ele[i].tagName === 'SELECT') {
            if (document.getElementById(ele[i].id)) {
                document.getElementById(ele[i].id).value = "";
            }
        }

        $('#myModal').modal('hide');
        $('#Modal').modal('hide');
        $("#images").empty();
        $("#DisplayImg").hide();
        $("#cnlImgIcon").hide();
        $("#DisplayImgicon").hide();
        $("#cnlImg").hide();
        $('input:checkbox').removeAttr('checked');

        if ($('#Image')) {
            $('#Image').attr('src', '/Areas/Admin/Content/images/notavailable.png');
            $("#userFile").val("");
            $('#divchange').css('display', 'none');
        }

        if ($('#my-origin-image')) {
            $('#my-origin-image').attr('src', '/Areas/Admin/Content/images/notavailable.png');
            $('#divOrgImage').css('display', 'none');
            $('#spnwidth').text('');
            $('#spnheight').text('');
        }
    }

    var elecheck = document.getElementsByClassName('chkactive');
    for (i = 0; i < elecheck.length; i++) {
        elecheck[i].checked = true;
    }

    var eleuncheck = document.getElementsByClassName('chkinactive');
    for (i = 0; i < eleuncheck.length; i++) {
        eleuncheck[i].checked = false;
    }
}

function scrolltop() {
    $('html, body').animate({ scrollTop: 0 }, 800);
}

function charCount(t) {
    var left = parseInt(document.getElementById(t.id).getAttribute("maxlength")) - (document.getElementById(t.id).value.length);
    if (left < 0) { left = 0; }
    document.getElementById(t.id).nextElementSibling.textContent = 'Characters left: ' + left;
}

function srNoKeyPress(t, e) {
    if (t.value === "0" && e.which === 48) {
        t.value = "1";
        return false;
    }

    //if the letter is not digit then display error and don't type anything
    if (e.which !== 8 && e.which !== 0 && (e.which < 48 || e.which > 57)) {
        return false;
    }
    return true;
}

function ShowError(message) {
    toastr.clear();
    toastr.options.progressBar = true;
    toastr.options.positionClass = 'toast-bottom-right';
    toastr.error(message);
}

function ShowSuccess(message) {
    toastr.clear();
    toastr.options.progressBar = true;
    toastr.options.positionClass = 'toast-bottom-right';
    toastr.success(message);
}

function ShowInfo(message) {
    toastr.clear();
    toastr.options.progressBar = true;
    toastr.options.positionClass = 'toast-bottom-right';
    toastr.info(message);
}

function ShowWarning(message) {
    toastr.clear();
    toastr.options.progressBar = true;
    toastr.options.positionClass = 'toast-bottom-right';
    toastr.warning(message);
}