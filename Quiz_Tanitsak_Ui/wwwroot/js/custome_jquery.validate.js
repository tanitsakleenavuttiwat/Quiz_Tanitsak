$.extend($.validator.messages, {
    required: "กรุณาระบุข้อมูล",
    remote: "กรุณาแก้ไขข้อมูลนี้",
    email: "กรุณากรอกอีเมลให้ถูกต้อง",
    url: "กรุณาใส่ URL ที่ให้ถูกต้อง",
    date: "กรุณาใส่ค่าวันที่ให้ถูกต้อง",
    dateISO: "กรุณาใส่ค่าวันที่ให้ถูกต้อง (ISO).",
    number: "กรุณาใส่ค่าเป็นตัวเลขให้ถูกต้อง",
    digits: "กรุณาใส่แค่้ค่าที่เป็นตัวเลข",
    creditcard: "กรุณาใส่เลขบัตรเดรดิตให้ถูกต้อง",
    equalTo: "กรุณาใส่ค่าที่เท่ากันอีกครั้งหนึ่ง",
    accept: "กรุณาใส่ข้อมูลที่มีนามสกุลไฟล์ที่ถูกต้อง",
    maxlength: jQuery.validator.format("กรุณาระบุข้อมูลบมากที่สุด {0} ตัวอักษร"),
    minlength: jQuery.validator.format("กรุณาระบุข้อมูลอย่างต่ำ {0} ตัวอักษร"),
    max: jQuery.validator.format("กรุณาใส่ค่าน้อยกว่าหรือเท่ากับ {0}"),
    min: jQuery.validator.format("กรุณาใส่ค่ามากกว่าหรือเท่ากับ {0}"),
    step: $.validator.format("กรุณาใส่ค่าหลังจุดทศนิยมห้ามมากกว่า {0}"),
	nowhitespace:"กรุณาอย่าใส่ค่าว่าง"
});


$.validator.setDefaults({
    ignore: [],
    focusCleanup: true,
    errorElement: "span",
    errorPlacement: function (error, element) {
        var elem = $(element);
        if (elem.parent().hasClass("icheck-primary") || elem.parent().hasClass("icheck")) {
            error.insertAfter($(elem).next("label"));
            error.addClass('iCheckValidate');
        }
        else {
            error.insertAfter(element);
        }
    }
});
/*
default_setting
    required: "This field is required.",
    remote: "Please fix this field.",
    email: "Please enter a valid email address.",
    url: "Please enter a valid URL.",
    date: "Please enter a valid date.",
    dateISO: "Please enter a valid date (ISO).",
    number: "Please enter a valid number.",
    digits: "Please enter only digits.",
    creditcard: "Please enter a valid credit card number.",
    equalTo: "Please enter the same value again.",
    accept: "Please enter a value with a valid extension.",
    maxlength: jQuery.validator.format("Please enter no more than {0} characters."),
    minlength: jQuery.validator.format("Please enter at least {0} characters."),
    rangelength: jQuery.validator.format("Please enter a value between {0} and {1} characters long."),
    range: jQuery.validator.format("Please enter a value between {0} and {1}."),
    max: jQuery.validator.format("Please enter a value less than or equal to {0}."),
    min: jQuery.validator.format("Please enter a value greater than or equal to {0}.")
*/