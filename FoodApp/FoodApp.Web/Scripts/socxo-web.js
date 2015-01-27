// Hides the pageloader
$('#pageLoader').hide();

var menuLeft = document.getElementById('cbp-spmenu-s1'),
    menuTop = document.getElementById('cbp-spmenu-s3'),
    showTop = document.getElementById('showTop'),
    showLeftPush = document.getElementById('showLeftPush'),
    body = document.body;


// For all alert messages
function AlertMessage(message) {

    $('.ShowAlert').empty();
    $('.ShowAlert').html(message);
    $('.ShowAlert').show();
    setTimeout(function() {
        $('.ShowAlert').fadeOut();
    }, 5000);
}

//For all Success message
function SuccessMessage(message) {
    $('.ShowSuccessinfo').empty();
    $('.ShowSuccessinfo').html(message);
    $('.ShowSuccessinfo').show();
    setTimeout(function() {
        $('.ShowSuccessinfo').fadeOut();
    }, 5000);
}

// For all info messages
function InfoMessage(message) {
    $('.ShowInfo').empty();
    $('.ShowInfo').html(message);
    $('.ShowInfo').show();
    setTimeout(function() {
        $('.ShowInfo').fadeOut();
    }, 5000);
}

// Check if the form has errors
function IsValidForm(_formId) {
    var _isFormValid = true;
    $('#' + _formId).find('[data-val="true"]').each(function() {
        if (!$(this).valid()) {
            _isFormValid = false;
        }
    });
    $('.dynamic-div-validation-error').remove();
    $("textarea").each(function() {
        if ($(this).css('display') != 'none') {
            if ($(this).val().match(/<(\w+)((?:\s+\w+(?:\s*=\s*(?:(?:"[^"]*")|(?:'[^']*')|[^>\s]+))?)*)\s*(\/?)>/)) {
                $(this).parent().append("<div class='dynamic-div-validation-error'>Remove characters ('<' ,'>') </div>");
                _isFormValid = false;
            } else if ($(this).val().match(/[\<+]/g)) {
                $(this).parent().append("<div class='dynamic-div-validation-error'>Remove characters ('<' ,'>')</div>");
                _isFormValid = false;
            }
        }
    });

    $("input:text").each(function() {
        if ($(this).val().match(/<(\w+)((?:\s+\w+(?:\s*=\s*(?:(?:"[^"]*")|(?:'[^']*')|[^>\s]+))?)*)\s*(\/?)>/)) {
            $(this).parent().append("<div class='dynamic-div-validation-error'>Remove characters ('<' ,'>')</div>");
            _isFormValid = false;
        } else if ($(this).val().match(/[\<+]/g)) {
            $(this).parent().append("<div class='dynamic-div-validation-error'>Remove characters ('<' ,'>')</div>");
            _isFormValid = false;
        }
    });
    return _isFormValid;
}

function TrimText(text, len) {
    if (len == undefined || len == null) {
        len = 20;
    }
    var trimmedText = text;
    if (text.length > len) {
        trimmedText = text.substring(0, len - 3);
        trimmedText += "...";
    }
    return trimmedText;
}

var regxchars = {
    'special': /[\W]/g,
    'quotes': /['\''&'\"']/g,
    'notnumbers': /[^\d]/g,
    'numbers': /[\d+]/g,
    'alphanumeric': /[^a-zA-Z0-9- ]/g,
    'numbersAndDot': /[^'\d'&^'\.']/g,
    'htmlTags': /([\<])([^\>]{1,})*([\>])/g,
    'numbersAndSingleDot': /[\d+]/g,
    'tilda': /['~']/g
};

function specialCharCheck(o, w) {
    o.value = o.value.replace(regxchars[w], '');
}

function pageScrollTop() {
    $(document).scrollTop(0);
}